using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    //private Transform transform;
    private float moveX = -1;
    private float moveY = 0.00f;
    private Camera camera;
    private float LEFT_BOUNDX = -2.7f;
    private float RIGHT_BOUNDX = 2.7f;

    // Use this for initialization
    void Start () {

        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        //transform = GetComponent<Transform>();

        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {

        speed = 3;

        //if touch left side of the screen moveX * -1
        /*
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            if (touchDeltaPosition.x < 0)
            {
                moveX = moveX * -1;
            } else
            {
                speed = 8;
            }
        }
        */
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 currentMouseClickWorldSpace = camera.ScreenToWorldPoint(Input.mousePosition);
            if (currentMouseClickWorldSpace.x < 0)
            {
                moveX = moveX * -1;
            }
        }

        //Is holding the button?
        if (Input.GetMouseButton(0))
        {
            Vector3 currentMouseClickWorldSpace = camera.ScreenToWorldPoint(Input.mousePosition);
            if (currentMouseClickWorldSpace.x > 0)
            {
                speed = 8;
                transform.Rotate(new Vector3(0f, 0f, 10f*moveX*-1));
            }
        }

        // Out of bounds check
        if (transform.position.x > RIGHT_BOUNDX)
        {
            moveX = Math.Abs(moveX) * -1;
        }
        if (transform.position.x < LEFT_BOUNDX)
        {
            moveX = Math.Abs(moveX);
        }

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveX, moveY);

        transform.Rotate(new Vector3(0f, 0f, 5f*moveX*-1));

        // No momentum
        Move(moveX, moveY, movement);

        Debug.Log(GetComponent<Transform>().position.y);

        }

    void Move(float h, float v, Vector2 movement)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;
        // Move the player to its current position plus the movement.
        Vector2 newPosition = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
        rb2d.MovePosition(newPosition);
    }
}
