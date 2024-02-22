using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogicScript : MonoBehaviour
{
    SpriteRenderer playerBase;
    Color baseColor;
    // Start is called before the first frame update
    void Start()
    {
        playerBase = GetComponent<SpriteRenderer>();
        baseColor = playerBase.color;
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
        Selected(true);
    }


}
