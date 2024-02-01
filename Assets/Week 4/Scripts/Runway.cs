using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public float playerScore = 0;
    Rigidbody2D runway;
    // Start is called before the first frame update
    void Start()
    {
        runway = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        other.gameObject.GetComponent<Plane>().isRunway = true;

        if (runway.OverlapPoint(new Vector2(other.transform.position.x, other.transform.position.y)))
        {

            if (Vector3.Distance(transform.position, other.transform.position) < 3)
            {
                other.gameObject.GetComponent<Plane>().isLanding = true;
            }
        }
    }

}
