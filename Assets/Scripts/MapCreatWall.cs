using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreatWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SpawnMap("Map");
        }
    }
}
