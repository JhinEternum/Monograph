using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMenu : MonoBehaviour
{
    private InputReader inputReader;
    [SerializeField] private GameObject PauseMenuPrefab;

    private void Awake() {
        inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        inputReader.PauseEvent += OnPauseMenu;
    }

    private void OnDisable()
    {
        inputReader.PauseEvent -= OnPauseMenu;
    }

    private void OnPauseMenu()
    {
        Instantiate(PauseMenuPrefab);
    }
}
