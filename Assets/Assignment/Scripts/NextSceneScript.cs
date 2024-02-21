using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneScript : MonoBehaviour
{
    //load next scene if portal is collided with
    private void OnTriggerEnter2D(Collider2D collision)
    {
        loadScene(1);
    }

    //load scene function
    public void loadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
