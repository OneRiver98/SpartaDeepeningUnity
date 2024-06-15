using UnityEngine;

public class Car : MonoBehaviour
{
    private float direction;

    private Vector3 startPosition = Vector3.zero;
    private Vector3 MoveDirection;

    private Rigidbody rigidBody;
    private Transform transForm;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        transForm = GetComponent<Transform>();
    }

    private void Start()
    {
        if (transForm.position.x < 0)
        {
            startPosition = Vector3.right;
            direction = 90f;
        }
        else 
        {
            startPosition = Vector3.left;
            direction = -90f;
        }

        transForm.rotation = Quaternion.Euler(0f, direction, 0f);
    }

    private void FixedUpdate()
    {        
        rigidBody.velocity = startPosition * 10;
    }
}
