using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        Destroy(this);
        SceneManager.LoadScene(0);
    }
}
