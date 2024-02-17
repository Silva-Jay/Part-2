using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public GameObject player;
    Vector2 upwards;
    Rigidbody2D rigidbody;
    public float maxHeight;
    float timer = 0;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        upwards = rigidbody.position + Vector2.up;
        maxHeight = rigidbody.position.y + 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 14)
        {
            spriteRenderer.color = Color.red;
            if (timer > 15)
            {
                player.SendMessage("isInjured", 1);
                Destroy(gameObject);
            }
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
