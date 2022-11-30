using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private TMP_Text dialogueText;
    private TMP_Text npcName;

    private void Start()
    {
        npcName.text = dialogue.npcName;
    }
}
