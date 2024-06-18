using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ObjectPool objPool;
    
    private float nextSpawnPosition = 10f;
    public float MapLength = 26f;

    public Queue<GameObject> activeMaps = new Queue<GameObject>();

    public int score;
    private float time;

    [SerializeField] private GameObject endPansel;
    [SerializeField] private GameObject goTextUI;
    private bool goTxtUIOneFalse = true;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;

    [SerializeField] private Text endScoreText;
    [SerializeField] private Text endBestScoreText;

    private void Awake()
    {
        Instance = this;
        objPool = GetComponent<ObjectPool>();
    }

    private void Update()
    {
        TimeUpdate();
    }

    public void SpawnMap()
    {
        if (goTxtUIOneFalse)
        {
            goTextUI.SetActive(false);
            goTxtUIOneFalse = false;
        }

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

    private void TimeUpdate()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("F1");        
    }

    public void ScoreUpdate()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        endScoreText.text = score.ToString();

        endPansel.SetActive(true);
    }

    public void ReStartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}