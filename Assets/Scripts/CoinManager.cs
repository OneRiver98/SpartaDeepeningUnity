using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private Transform coinSpawnPositionsParent;
    private List<Transform> coins = new List<Transform>();

    private void Awake()
    {
        coinSpawnPositionsParent = GetComponent<Transform>();
    
        for (int i = 0; i < coinSpawnPositionsParent.childCount; i++)
        {
            coins.Add(coinSpawnPositionsParent.GetChild(i).transform);
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < coins.Count; i++)
        {
            coins[i].gameObject.SetActive(true);
        }
    }
}
