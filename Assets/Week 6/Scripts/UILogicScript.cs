using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILogicScript : MonoBehaviour
{
    public void nextScene()
    {
        SceneManager.LoadScene(3);
    }

    public void resolution169()
    {
        Screen.SetResolution(1360, 768, false);
    }

    public void resolutionHD()
    {
        Screen.SetResolution(1920, 1080, false);
    }
}
