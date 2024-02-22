using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static float score {  get; private set; }
    Vector3 startPos;
    Rigidbody2D ball;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        ball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            score += 1;
            transform.position = startPos;
            ball.velocity = Vector2.zero;
        }
    }
}
