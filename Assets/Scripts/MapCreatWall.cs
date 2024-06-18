using UnityEngine;

public class MapCreatWall : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private MapDestroyWall destroyWall;

    private void Awake()
    {
        if(wall) wall.SetActive(false); // ���� �÷����߿� �ڷ� �� ���� ���� ��.
    }

    private void OnTriggerEnter(Collider other) // Ʈ���ŷ� �ʻ��� ����.
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
