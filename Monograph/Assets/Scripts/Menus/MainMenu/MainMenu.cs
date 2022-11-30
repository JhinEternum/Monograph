using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Menus.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menu1;
        [SerializeField] private GameObject menu2;
        [SerializeField] private AudioSource ost;
        [SerializeField] private AudioSource windOst;
        [SerializeField] private GameObject female;
        [SerializeField] private GameObject male;

        private void Start()
        {
            ost.loop = true;
            windOst.loop = true;
        }

        public void PlayButton()
        {
            if (!PlayerPrefs.HasKey("gender"))
            {
                menu1.SetActive(false);
                menu2.SetActive(true);
                female.SetActive(true);
                male.SetActive(true);
                return;
            }
            SceneManager.LoadScene(1);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        public void FemaleButton()
        {
            PlayerPrefs.SetInt("gender", 0);
            SceneManager.LoadScene(1);
        }

        public void MaleButton()
        {
            PlayerPrefs.SetInt("gender", 1);
            SceneManager.LoadScene(1);
        }
    }

}
