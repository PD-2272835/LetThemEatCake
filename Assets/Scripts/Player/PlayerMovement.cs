using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float movementSpeed = 10f;
    Vector2 currentMoveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ProcessInput()
    {
        Input.GetAxis("vertical");
        

    }

    void BoundsCheck()
    {

    }
}
