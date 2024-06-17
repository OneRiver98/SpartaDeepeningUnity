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

    public void Initialize() //                                                                 Awake�� �ִ� �ڵ��  ��ŸƮ�� �ִ� �ڷ�ƾ�� ���ƴ�. �̰� �����ϸ� ������ // �ٽ� ������
    {
        if (spawnPositions != null) spawnPositions.Clear(); // ���� ���ִ� ������ġ ����

        for (int i = 0; i < spawnPositionsParent.childCount; i++) //������ġ ���� ����ִ� ��
        {
            spawnPositions.Add(spawnPositionsParent.GetChild(i).transform.position);
        }

        if (carSpawnCorou != null) // �������� �ڷ�ƾ ����
        {
            StopCoroutine(carSpawnCorou);
            carSpawnCorou = null;
        }

        carSpawnCorou = StartCoroutine(SpawnCar()); // �ڷ�ƾ ����
    }

    private IEnumerator SpawnCar()
    {
        while (true)
        {
            if (spawnPositions == null || spawnPositions.Count == 0) yield break; // ��������

            waitTime = Random.Range(1f, 3f);

            for (int i = 0; i < 5; i++)
            {
                int spawnPoint = Random.Range(0, spawnPositions.Count);

                GameObject car = GameManager.Instance.SpawnObjPool("Car");
                car.SetActive(false); // �� CarManager�� ��Ȱ��ȭ�� �� ���༭ Enable�� ������� �� �ߴ�.
                car.transform.position = spawnPositions[spawnPoint];
                car.SetActive(true);
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
}
