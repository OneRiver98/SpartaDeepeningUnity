using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    private static readonly int isMove = Animator.StringToHash("Move");
    private float magnituteThreshold = 0.5f;

    private void Start()
    {
        topDownController.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isMove, vector.magnitude > magnituteThreshold);
    }
}