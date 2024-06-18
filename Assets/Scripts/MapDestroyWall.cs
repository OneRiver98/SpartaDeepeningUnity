using UnityEngine;

public class MapDestroyWall : MonoBehaviour
{
    [SerializeField] private MapCreatWall creatWall; 
    [SerializeField] private GameObject backWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ʈ���ŷ� �ʻ��� ����. 
        {
            GameManager.Instance.DeactivateOldMap();
            if(creatWall) creatWall.enabled = true;
            backWall.SetActive(true);

            this.enabled = false;
        }
    }
}
