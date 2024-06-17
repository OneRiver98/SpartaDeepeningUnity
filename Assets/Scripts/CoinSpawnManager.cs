//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CoinSpawnManager : MonoBehaviour
//{
//    private int randomNum;

//    private Transform coinSpawnPositionsParent;
//    private List<Transform> coinSpawnPositions = new List<Transform>();
//    private List<GameObject> curCoin = new List<GameObject>();

//    private void Awake()
//    {
//        coinSpawnPositionsParent = GetComponent<Transform>();
//    }

//    public void Initialize()
//    {
//        for (int i = 0; i < coinSpawnPositionsParent.childCount; i++)
//        {
//            coinSpawnPositions.Add(coinSpawnPositionsParent.GetChild(i).transform);
//        }
//    }

//    private void OnEnable()
//    {
//        if (curCoin != null || curCoin.Count == 0)
//        {
//           for (int i = 0; i < curCoin.Count; i++)
//            {
//                curCoin[i].SetActive(false);
//            }
//        }

//        if (coinSpawnPositions != null)
//        {
//            for (int i = 0; i < 5; i++)
//            {
//                randomNum = Random.Range(0, coinSpawnPositions.Count);

//                GameObject coin = GameManager.Instance.SpawnObjPool("Coin");
//                coin.transform.position = coinSpawnPositions[randomNum].position;

//                curCoin.Add(coin);
//            }
//        }
//    }
//}
