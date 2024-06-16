using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    private float waitTime;

    private Transform spawnPositionsParent;
    private List<Vector3> spawnPositions = new List<Vector3>();

    private void Awake()
    {
        spawnPositionsParent = GetComponent<Transform>();

        for (int i = 0; i < spawnPositionsParent.childCount; i++)
        {
            spawnPositions.Add(spawnPositionsParent.GetChild(i).transform.position);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnCar());
    }

    private IEnumerator SpawnCar()
    {
        while (true)
        {
            waitTime = Random.Range(1f, 3f);

            for (int i = 0; i < 5; i++)
            {
                int spawnPoint = Random.Range(0, spawnPositions.Count);

                GameObject car = GameManager.Instance.SpawnObjPool("Car");
                car.SetActive(false);
                car.transform.position = spawnPositions[spawnPoint];
                car.SetActive(true);
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
}
