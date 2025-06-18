using System;
using System.Collections;
using UnityEngine;

public class ThrowCake : MonoBehaviour
{
    public bool isAiming;
    private LineRenderer _lineRenderer;
    [SerializeField] private Material lineMaterial;
    
    private enum ThrowState
    {
        Default,
        Aiming,
        Throwing,
    }
    private ThrowState _currentState;
    private ThrowState[] _states;
    [SerializeField]private float arcHeight = 4f;
    [SerializeField]private float aimSpeedMult = 10f;
    [SerializeField]private float maxAimDistance = 15f;
    private bool _isMovingRight;
    private Vector3 _startLocation;
    private Vector3 _endLocation;
    
    private GameObject _cakePrefab;
    private CakeData _currentCake;
    private GameStateManager _gameStateManager;
    
    [SerializeField] private Animator animator;


    private void Start()
    {
        _states = (ThrowState[])Enum.GetValues(typeof(ThrowState));
        _endLocation = transform.position;
        isAiming = false;
        _isMovingRight = true;
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;   
    }

    //Bind the Event
    public void OnEnable() { EventManager.OnUpdateCake += UpdateCurrentCakeData; }
    public void OnDisable() { EventManager.OnUpdateCake -= UpdateCurrentCakeData; }

    //Logic triggered on event call
    void UpdateCurrentCakeData(CakeData newCake)
    {
        _currentCake = newCake;
    }


    private void Update()
    {
        
        //Changes Enum state on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentState == ThrowState.Default) //makes sure you have enough batter for the cake
            {
                if (_gameStateManager.CheckBatter())
                {
                    _gameStateManager.UpdateBatter(-_currentCake.cost);
                    IncrementState();
                }
            }
            else
            {
                IncrementState();
            }
        }
        //Switches based on enum state
        switch (_currentState)
        {
            case ThrowState.Default:
                break;
            case ThrowState.Aiming:
                SetThrowPositions();
                SetLineColour();
                DrawCakeTrajectory(_startLocation,CalculateThrowVelocity());
                break;
            case ThrowState.Throwing:
                Throw(_cakePrefab);
                break;
                
        }
    }

   //Gets distance that end point of aim has moved
    private float GetAimDistance()
    {
        return _endLocation.x - _startLocation.x;
    }

   //Changes to next enum state when called
    private void IncrementState()
    {
        int currentIndex = Array.IndexOf(_states, _currentState);
        int nextIndex = (currentIndex + 1) % _states.Length;
        _currentState = _states[nextIndex];
    }

    //Sets the start and end location of the throw
      //Bounces back and forth, changes direction when it reaches set distance or when it returns to player
      //Distance can be changed by changing maxAimDistance
      //Speed of aim moving can be changed with aimSpeedMult
    
    private void SetThrowPositions()
    {
        _startLocation = transform.position;
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, _startLocation);
        if (_isMovingRight)
        {
            _endLocation.x += Time.deltaTime * aimSpeedMult;
            if (GetAimDistance() > maxAimDistance)
            {
                _isMovingRight = !_isMovingRight;
            }
        }
        else if (!_isMovingRight)
        {
            _endLocation.x -= Time.deltaTime * aimSpeedMult;
            if (GetAimDistance() < 0f)
            {
                _isMovingRight = !_isMovingRight;
            }
        }
    }

    //Throws cake
      //Creates cake prefab from input into function
      //Calculates and sets velocity to throw cake
      //Resets some variables for next throw
      //Changes back to default state
    private void Throw(GameObject cakePrefab)
    {
        StartCoroutine(playerThrowAnimation());

        GameObject cakeObject = Instantiate(cakePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = cakeObject.GetComponent<Rigidbody2D>();
        rb.velocity = CalculateThrowVelocity();
        _endLocation.x = _startLocation.x;
        
        //makes sure the new cake projectile knows where it's landing
        CakeProjectile cakeProjectile = cakeObject.GetComponent<CakeProjectile>();
        cakeProjectile.Initialize(new Vector2(GetAimDistance(), _startLocation.y), _currentCake);

        
        _lineRenderer.enabled = false;
        _isMovingRight = true;
        IncrementState();
    }

    private IEnumerator playerThrowAnimation()
    {
        animator.SetInteger("playerState", 2); //sets the player state to throwing so the animation can play
        yield return new WaitForSeconds(0.27f);
        animator.SetInteger("playerState", 0); //sets the player state to idle
    }

    //Calculates velocity to throw cake at to land on target
    Vector3 CalculateThrowVelocity()
    {
        float displacementY = _endLocation.y - _startLocation.y;
        
        Vector3 displacementXZ = new Vector3(_endLocation.x - _startLocation.x, 0, _endLocation.z - _startLocation.z);
        float time = Mathf.Sqrt(-2*arcHeight/Physics2D.gravity.y) + Mathf.Sqrt(2*(displacementY-arcHeight)/Physics2D.gravity.y);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics2D.gravity.y * arcHeight);
        Vector3 velocityXZ = displacementXZ / time;
        
        Vector3 velocityXYZ =  velocityXZ + velocityY * -Mathf.Sign(Physics2D.gravity.y);
        return velocityXYZ;
    }

   //Calculates air time of cake, used to correctly draw the arc
    float CalculateTravelTime()
    {
        float displacementY = _endLocation.y - _startLocation.y;
        float time = Mathf.Sqrt(-2*arcHeight/Physics2D.gravity.y) + Mathf.Sqrt(2*(displacementY-arcHeight)/Physics2D.gravity.y);
        return time;
    }
    
    //Draws arc to visualise trajectory
    //change position count to increase/decrease precision of line
    void DrawCakeTrajectory(Vector3 startPosition, Vector3 initialVelocity)
    {
        _lineRenderer.positionCount = 200;
        float travelTime = CalculateTravelTime();
        Vector3 currentPosition = startPosition;
        Vector3 currentVelocity = initialVelocity;
        float timeStep = travelTime/_lineRenderer.positionCount;

        for (int i = 0; i < _lineRenderer.positionCount; i++)
        {
            _lineRenderer.SetPosition(i, currentPosition);
            currentVelocity += new Vector3(0, Physics.gravity.y * timeStep, 0);
            currentPosition += currentVelocity * timeStep;
        }
    }

    void SetLineColour()
    {
        float interpValue = (Vector3.Distance(_startLocation,_endLocation)/(maxAimDistance));
        lineMaterial.SetFloat("_InterpValue",interpValue);
    }
}
