using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject deadPrefab;
    private Animator animator;
    private CharacterController controller;
    private InputReader input;
    private ForceReceiver forceReceiver;
    private PlayerStateMachine stateMachine;

    private void Start() {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        input = GetComponent<InputReader>();
        forceReceiver = GetComponent<ForceReceiver>();
        stateMachine = GetComponent<PlayerStateMachine>();
    }

    public void Dead()
    {
        Debug.Log("Player Dead");
        animator.SetBool("Dead", true);

        controller.enabled = false;
        input.enabled = false;
        forceReceiver.enabled = false;
        stateMachine.enabled = false;

        Instantiate(deadPrefab);
    }
}
