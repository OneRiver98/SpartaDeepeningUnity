using UnityEngine;

public class TrueCar : MonoBehaviour
{
    private float speed;
    private float size;
    private float direction;

    private int randomNum;

    private Vector3 startDirection = Vector3.zero;
    private Vector3 startPosition = Vector3.zero;

    [SerializeField] private GameObject[] car;
    private GameObject curCar;

    private Transform transForm;
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        transForm = GetComponent<Transform>();
    }

    private void Start()
    {
        randomNum = Random.Range(0, car.Length);
        Instantiate(car[randomNum],transForm);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = startDirection * speed;
    }

    private void OnEnable()
    {
        StartCar();
    }

    private void StartCar()
    {
        startPosition = transForm.position;

        speed = Random.Range(8f, 15f);
        size = Random.Range(0.8f, 1.3f);

        if (startPosition.x < 0)
        {
            startDirection = Vector3.right;
            direction = 90f;
        }
        else
        {
            startDirection = Vector3.left;
            direction = -90f;
        }

        transForm.rotation = Quaternion.Euler(0f, direction, 0f);
        transForm.localScale = new Vector3(size, size, size);
    }
}
