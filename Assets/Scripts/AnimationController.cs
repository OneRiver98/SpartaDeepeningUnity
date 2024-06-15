using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected TopDownController topDownController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        topDownController = GetComponent<TopDownController>();
    }
}
