using UnityEngine;

public class MapCreatWall : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private MapDestroyWall destroyWall;

    private void Awake()
    {
        if(wall) wall.SetActive(false); // 게임 플레이중에 뒤로 못 가게 막는 벽.
    }

    private void OnTriggerEnter(Collider other) // 트리거로 맵생성 구현.
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SpawnMap();
            if(wall) wall.SetActive(true);
            if(destroyWall)destroyWall.enabled = true;

            this.enabled = false;
        }
    }
}
