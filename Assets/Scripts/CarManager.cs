using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject car;
    private Transform InsPosition;

    private void Awake()
    {
        InsPosition = GetComponent<Transform>();
    }

    private void Start()
    {
        Instantiate(car, InsPosition);
    }
}
