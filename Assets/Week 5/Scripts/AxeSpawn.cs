using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpawn : MonoBehaviour
{
    public GameObject axe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnAxe()
    {
        Instantiate(axe, transform.position, transform.rotation);
    }
}
