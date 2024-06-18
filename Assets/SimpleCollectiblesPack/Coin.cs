using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour 
{
	public bool rotate; 

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;

	private int point = 100;

    private void OnEnable() // 코인 실행 되면 랜덤확률로 꺼버리게 해서 랜덤 생성 구현함.
    {
		int i = Random.Range(0, 10);

		if(i > 4)
		{
			gameObject.SetActive(false);
		}
    }

    void Update () 
	{
		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Collect ();
		}
	}

	public void Collect()
	{
		if(collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		GameManager.Instance.score += point;
		GameManager.Instance.ScoreUpdate();

        gameObject.SetActive(false);
	}
}
