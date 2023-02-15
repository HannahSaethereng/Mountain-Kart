using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoves : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float speed = 10.0f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Calculate the forward direction of the car in 2D
            Vector2 forwardDirection = new Vector2(transform.right.x, transform.right.y);

            // Move the car 1 cm forward in the forward direction
            myRigidbody.MovePosition(myRigidbody.position + forwardDirection * speed);
        }
    }
}