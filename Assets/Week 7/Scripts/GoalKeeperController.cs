using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class GoalKeeperController : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    float distance;
    Vector2 playerDirection;

    // Update is called once per frame
    void Update()
    {
        if (Controller.SelectedPlayer == null) return;
        playerDirection = (Vector2)transform.position - (Vector2)Controller.SelectedPlayer.transform.position;
        distance = playerDirection.magnitude;
        playerDirection.Normalize();
    }

    private void FixedUpdate()
    {
        if (Controller.SelectedPlayer == null) return;
            
        rigidbody.position = (Vector2)transform.position - playerDirection * distance / 2;
        
    }
}
