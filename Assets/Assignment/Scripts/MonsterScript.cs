using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    //player game object
    public GameObject player;

    //monster direction vector
    Vector2 upwards;

    //monster rigidbody
    Rigidbody2D rigidbody;

    //maximum height and timer floats
    public float maxHeight;
    float timer = 0;

    //monster sprite renderer
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        upwards = rigidbody.position + Vector2.up;
        maxHeight = rigidbody.position.y + 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 9)
        {
            //monster's face turns red before it damages player
            spriteRenderer.color = Color.red;
            if (timer > 10)
            {
                //damage player after 10 secs and destroy monster
                player.SendMessage("isInjured", 1);
                Destroy(gameObject);
            }
        }
    }
    private void FixedUpdate()
    {
        //increment rigidbody upwards when spawned, stops at maxheight
        if (upwards.y < maxHeight)
        {
            rigidbody.MovePosition(upwards);
            upwards.y += 0.01f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            //destroy monster if player collides with it
            Destroy(gameObject);
        }
    }
}
