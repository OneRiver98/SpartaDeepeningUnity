using UnityEngine;

public class MapDestroyWall : MonoBehaviour
{
    [SerializeField] private MapCreatWall creatWall; 
    [SerializeField] private GameObject backWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 트리거로 맵생성 구현. 
        {
            GameManager.Instance.DeactivateOldMap();
            if(creatWall) creatWall.enabled = true;
            backWall.SetActive(true);

            this.enabled = false;
        }
    }
}
