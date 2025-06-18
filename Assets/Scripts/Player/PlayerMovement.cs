using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 100f;
    [SerializeField] private float[] bounds = { 4f, -4f }; //0:upper 1:lower  play area bounds
    [SerializeField] private Animator animator;

    private bool _canMove;

    private float currentMoveDirection = 0f;
    float newY;

    void OnEnable()
    {
        EventManager.OnSetMovementState += SetMovementState;
    }

    void OnDisable()
    {
        EventManager.OnSetMovementState -= SetMovementState;
    }
    
    void Update()
    {
        if (_canMove)
        {
            currentMoveDirection = Input.GetAxisRaw("Vertical");
        }
        else
        {
            currentMoveDirection = 0f;
        }
        
        //calculate the new Y value and ensure that it is clamped to be within the play area bounds
        newY = Mathf.Clamp(transform.position.y + (currentMoveDirection * movementSpeed * Time.deltaTime), bounds[1], bounds[0]);

        //move in the player in their disired direction
        if (currentMoveDirection > 0f)
        {
            animator.SetInteger("playerState", 1); //sets the player state to walking so the animation can play
            gameObject.transform.position = new Vector3 (transform.position.x, newY, transform.position.z);
        }
        else if (currentMoveDirection < 0f) 
        {
            animator.SetInteger("playerState", 1);
            gameObject.transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
        else
        {
            if (animator.GetInteger("playerState") == 1) //sets the player state to idle if it's walking, to not clash with the throwing anim
            {
                animator.SetInteger("playerState", 0);
            }
        }
    }

    void SetMovementState(bool newState)
    {
        _canMove = newState;
    }
}
