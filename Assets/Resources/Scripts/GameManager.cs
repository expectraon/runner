using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsPause { get; set; }

    // Update is called once per frame
    void Update()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        if (IsPause)
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
        }
        else
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1f;
            }
        }
    }

    private void SceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        IsPause = false;
    }

}
