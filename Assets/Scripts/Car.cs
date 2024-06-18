using UnityEngine;

public class Car : MonoBehaviour // �ö��̴��� �ٸ��� ���� �ؾ� �ؼ� �ڵ��� �������� �ö��̴�������
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