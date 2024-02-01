using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawnScript : MonoBehaviour
{
    public GameObject plane;
    //current timer value
    float timer;
    float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //increment timer by time.deltatime
        timer += Time.deltaTime;

        if(timer >= spawnRate){
            Instantiate(plane, transform);
            timer = 0;
            spawnRate = Random.Range(1, 5);
        }
    }
}
