using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public Transform startPosition;
    public Transform endPosition;
    public float lerpTimer;
    SpriteRenderer sr;
    public Color startcol;
    public Color endcol;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = animationCurve.Evaluate(lerpTimer);
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, interpolation);
        lerpTimer += Time.deltaTime;

        sr.color = Color.Lerp(startcol, endcol, interpolation);
    }
}
