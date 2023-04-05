using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMoves : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float speed = 10.0f;
    private ManageQuestions manageQuestions;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        manageQuestions = GameObject.FindObjectOfType<ManageQuestions>();

    }

    void Update()
    {
        //Input.GetKeyDown(KeyCode.Mouse0)
        //Debug.Log("Correct car drives returns: " + ManageQuestions.correct);
        if (ManageQuestions.correct && Input.GetKeyDown(KeyCode.Mouse0))
        {
    
            // Calculate the forward direction of the car in 2D
            Vector2 forwardDirection = new Vector2(transform.right.x, transform.right.y);

            // Move the car 1 cm forward in the forward direction
            myRigidbody.MovePosition(myRigidbody.position + forwardDirection * speed);
        }
    }
}

