using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{

    public Slider healthBar;

    //health bar goes down if player is injured
    void isInjured(float damage)
    {
        healthBar.value -= damage;
    }

}
