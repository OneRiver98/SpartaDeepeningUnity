using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ObjectPool objPool;
    
    private float nextSpawnPosition = 10f;
    public float MapLength = 26f;

    public Queue<GameObject> activeMaps = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
        objPool = GetComponent<ObjectPool>();
    }

    public void SpawnMap()
    {
        GameObject map = SpawnObjPool("Map");
        map.transform.position = new Vector3(1.35f, -0.56f, nextSpawnPosition);

        map.GetComponentInChildren<CarManager>().Initialize(); // 이렇게도 코드 작성 가능.
        //map.GetComponentInChildren<CoinSpawnManager>().Initialize();

        map.SetActive(true);
        activeMaps.Enqueue(map);

        nextSpawnPosition += MapLength;
    }

    public void DeactivateOldMap()
    {
        if (activeMaps.Count > 0)
        {
            GameObject oldMap = activeMaps.Dequeue();
            oldMap.SetActive(false);
        }
    }

    public GameObject SpawnObjPool(string tag)
    {
        GameObject obj = objPool.SpawnFromPool(tag);
        return obj;
    }
}
