using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnScript : MonoBehaviour
{

    public GameObject monster;
    float timer;
    Vector3 spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5) 
        {
            timer = 0;
            Instantiate(monster, transform);

            spawn.x = Random.Range(-1, 20);
            transform.position.Set(spawn.x, spawn.y, spawn.z);
        }
    }
}
