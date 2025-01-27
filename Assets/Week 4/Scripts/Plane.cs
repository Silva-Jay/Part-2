using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody;
    Vector2 currentPosition;
    public float speed = 1;
    public AnimationCurve landing;
    float timerValue;
    SpriteRenderer spriteRenderer;

    //spawn position of plane
    Vector3 spawnPos;

    //array of sprites
    public Sprite[] planes = new Sprite[4];
    int planeSprites;

    //float for plane distruction proximity
    float tooClose = 0.2f;

    //landing boolean
    public bool isLanding = false;

    //runway boolean
    public bool isRunway;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        //initiate spawnPos vector2
        spawnPos.x = Random.Range(-5, 5);
        spawnPos.y = Random.Range(-5, 5);
        spawnPos.z = 0;

        //position code
        transform.position = spawnPos;

        //randomize rotation
        transform.Rotate(0, 0, Random.Range(-10, 10));
        //randomize speed
        speed = Random.Range(1, 3);
        //randomize sprite

        planeSprites = Random.Range(0, 4);
        spriteRenderer.sprite = planes[planeSprites];

    }

    void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }

        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    void Update()
    {
        //landing
        if (isLanding == true)
        {
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);
            
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
                GameObject.Find("Runway").GetComponent<Runway>().playerScore += 1;
                isLanding = false;
            }

            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);

        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i<lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }

        //danger zone in On Trigger 2D

        
    }

    void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Vector2.Distance(lastPosition, newPosition)> newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRunway == false)
        {
            spriteRenderer.color = Color.red;
        }
        else if (isRunway == true)
        {
            spriteRenderer.color = Color.white;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Vector3.Distance(transform.position, collision.transform.position) < tooClose && isRunway == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D()
    {
        spriteRenderer.color = Color.white;
        isRunway = false;
    }

    //destroy planes when no longer visible on camera or editor
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
