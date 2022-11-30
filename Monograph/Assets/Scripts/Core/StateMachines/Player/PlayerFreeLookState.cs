using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
    private const float AnimatorDampTime = 0.1f;
    private bool play;
    private float speed = 0.5f;

    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.FreeLookMovementSpeed = 3;
        stateMachine.InputReader.RunEvent += OnRun;
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        Move(movement * stateMachine.FreeLookMovementSpeed, deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            if (play)
            {
                play = false;
                stateMachine.WalkOnGrassAudio.Stop();
            }
            return;
        }

        if (!play || !stateMachine.WalkOnGrassAudio.isPlaying)
        {
            play = true;
            stateMachine.WalkOnGrassAudio.PlayDelayed(.5f);
        }
        
        stateMachine.Animator.SetFloat(FreeLookSpeedHash, speed, AnimatorDampTime, deltaTime);
        Debug.Log("Play");

        FaceMovementDirection(movement, deltaTime);
    }

    public override void Exit()
    {
        stateMachine.InputReader.RunEvent -= OnRun;
    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.InputReader.MovementValue.y +
        right * stateMachine.InputReader.MovementValue.x;
    }

    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movement),
            deltaTime * stateMachine.RotationDamping
            );
    }

    private void OnRun()
    {
        stateMachine.SwitchState(new PlayerRunningState(stateMachine));
    }
}
