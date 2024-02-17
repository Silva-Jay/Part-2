using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //movement vectors
    Vector2 direction;
    Vector2 destination;

    //rigidbody component
    Rigidbody2D rigidbody;

    //movement speed
    public float speed = 7f;

    //animator component
    Animator silva;

    //health float
    public float health = 10;
    public float maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        silva = GetComponent<Animator>();
    }
    public void isInjured(float damage)
    {
        health -= damage;
    }

    private void FixedUpdate()
    {
        //direction vector is set to the direction where the mouse was clicked
        direction = destination - (Vector2)transform.position;

        //stop player movement when it hits the destination
        if (direction.magnitude < 0.1)
        {
                direction = Vector2.zero;
        }

        //increment player
        rigidbody.MovePosition(rigidbody.position + direction.normalized * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        //if mouse is pressed, set destination vector to where it was pressed on the screen
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //if player moves, set floats in animation controller to the proper direction and speed
        if (direction.x != 0 || direction.y != 0)
        {
            silva.SetFloat("Horizontal", direction.x);
            silva.SetFloat("Vertical", direction.y);
        }

        silva.SetFloat("Speed", direction.sqrMagnitude);

    }
}
