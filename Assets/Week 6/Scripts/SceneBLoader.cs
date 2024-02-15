using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBLoader : MonoBehaviour
{
    
    int currentSceneIndex;
    int nextSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
