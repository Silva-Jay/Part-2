using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{

    public Slider healthBar;
    // Start is called before the first frame update
    void isInjured(float damage)
    {
        healthBar.value -= damage;
    }

}
