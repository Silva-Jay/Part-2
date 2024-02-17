using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    Vector2 upwards;
    Rigidbody2D rigidbody;
    public float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        upwards = rigidbody.position + Vector2.up;
        maxHeight = rigidbody.position.y + 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //increment rigidbody upwards
        if (upwards.y < maxHeight)
        {
            rigidbody.MovePosition(upwards);
            upwards.y += 0.01f;
        }
    }
}
