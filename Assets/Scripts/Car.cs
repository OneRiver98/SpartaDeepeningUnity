using UnityEngine;

public class Car : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            transform.parent.gameObject.SetActive(false);
        }

        else if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}