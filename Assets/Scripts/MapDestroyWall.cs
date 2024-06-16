using UnityEngine;

public class MapDestroyWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.DeactivateOldMap();
        }
    }
}
