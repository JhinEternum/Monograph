using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{

    private void Start() {
        GameObject ostGameObject = GameObject.FindGameObjectWithTag("OST");
        ostGameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
