using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class MonsterSpawnScript : MonoBehaviour
{

    public GameObject monster;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 5)
        {
            timer += Time.deltaTime;
        }
        else if (timer > 5) 
        {
            timer = 0;
            Instantiate(monster, new Vector3(Random.Range(-1, 18), transform.position.y, 0), transform.rotation);
        }
    }
}
