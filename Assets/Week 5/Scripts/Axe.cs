using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 movement;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector3(1, 0, 0);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position - movement * 5 * Time.deltaTime);
        transform.Rotate(0, 0, 5);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.SendMessage("TakeDamage", 2);
            Destroy(gameObject);
        }
    }
}
