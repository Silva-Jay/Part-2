using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogicScript : MonoBehaviour
{
    SpriteRenderer playerBase;
    Color baseColor;
    Rigidbody2D rb;
    public float speed = 500;
    // Start is called before the first frame update
    void Start()
    {
        playerBase = GetComponent<SpriteRenderer>();
        baseColor = playerBase.color;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Selected(bool isClicked)
    {
        if (isClicked == true) 
        {
            playerBase.color = Color.yellow;
        }
        else
        {
            playerBase.color = baseColor;
        }
    }
    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }
}
