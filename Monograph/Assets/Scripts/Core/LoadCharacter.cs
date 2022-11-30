using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public enum PlayerGender { FEMALE, MALE }
    private PlayerGender playerGender;
    private string PrefabChoice => playerGender == PlayerGender.FEMALE ? "FemaleCharacter" : "MaleCharacter";

    private void Awake()
    {
        playerGender = (PlayerGender)PlayerPrefs.GetInt("gender");
        Load();
    }

    private void Load()
    {
        GameObject instance = Instantiate(
            Resources.Load(PrefabChoice, typeof(GameObject)),
            transform.position,
            Quaternion.identity) as GameObject;
    }
}
