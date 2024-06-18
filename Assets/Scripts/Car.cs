using UnityEngine;

public class Car : MonoBehaviour // 컬라이더를 다르게 적용 해야 해서 자동차 렌더러에 컬라이더적용함
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