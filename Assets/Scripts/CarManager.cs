using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    private float waitTime;

    private Transform spawnPositionsParent;
    private List<Vector3> spawnPositions = new List<Vector3>();

    private Coroutine carSpawnCorou;

    private void Awake()
    {        
        spawnPositionsParent = GetComponent<Transform>();
    }

    public void Initialize() //                                                                 Awake에 있던 코드와  스타트에 있는 코루틴과 합쳤다. 이걸 이해하면 좋을듯 // 다시 수정함
    {
        if (spawnPositions != null) spawnPositions.Clear(); // 저장 돼있는 스폰위치 리셋

        for (int i = 0; i < spawnPositionsParent.childCount; i++) //스폰위치 새로 잡아주는 거
        {
            spawnPositions.Add(spawnPositionsParent.GetChild(i).transform.position);
        }

        if (carSpawnCorou != null) // 실행중인 코루틴 중지
        {
            StopCoroutine(carSpawnCorou);
            carSpawnCorou = null;
        }

        carSpawnCorou = StartCoroutine(SpawnCar()); // 코루틴 시작
    }

    private IEnumerator SpawnCar()
    {
        while (true)
        {
            if (spawnPositions == null || spawnPositions.Count == 0) yield break; // 오류방지

            waitTime = Random.Range(1f, 3f);

            for (int i = 0; i < 5; i++)
            {
                int spawnPoint = Random.Range(0, spawnPositions.Count);

                GameObject car = GameManager.Instance.SpawnObjPool("Car");
                car.SetActive(false); // 이 CarManager는 비활성화를 못 해줘서 Enable을 사용하지 못 했다.
                car.transform.position = spawnPositions[spawnPoint];
                car.SetActive(true);
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
}
