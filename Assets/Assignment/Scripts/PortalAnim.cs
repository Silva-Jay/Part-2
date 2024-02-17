using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnim : MonoBehaviour
{
    public AnimationCurve ac;
    Vector3 startPos;
    Vector3 endPos;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = transform.position;
        endPos.y = startPos.y + 1;
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = ac.Evaluate(timer);
        transform.position = Vector3.Lerp(startPos, endPos, interpolation);
        timer += Time.deltaTime;
    }
}
