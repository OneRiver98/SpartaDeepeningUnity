using UnityEngine;

public class Car : MonoBehaviour
{
    private float speed;
    private float size;
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

    private void FixedUpdate()
    {        
        rigidBody.velocity = startPosition * speed;
    }

    private void OnEnable()
    {
        speed = Random.Range(8f, 15f);
        size = Random.Range(0.8f, 1.3f);

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
        transForm.localScale = new Vector3(size, size, size);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
