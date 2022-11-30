using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue", order = 0)]
public class Dialogue : ScriptableObject
{
    public string npcName;
    public string[] dialogueText;
}
