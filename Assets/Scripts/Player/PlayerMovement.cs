using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 100f;
    [SerializeField] private float[] bounds = { 4f, -4f }; //0:upper 1:lower  play area bounds

    private float currentMoveDirection = 0f;
    float newY;

    void Update()
    {
        currentMoveDirection = Input.GetAxisRaw("Vertical");

        //calculate the new Y value and ensure that it is clamped to be within the play area bounds
        newY = Mathf.Clamp(transform.position.y + (currentMoveDirection * movementSpeed * Time.deltaTime), bounds[1], bounds[0]);

        //move in the player in their disired direction
        if (currentMoveDirection > 0f)
        {
            gameObject.transform.position = new Vector3 (transform.position.x, newY, transform.position.z);
        }
        else if (currentMoveDirection < 0f) 
        {
            gameObject.transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
