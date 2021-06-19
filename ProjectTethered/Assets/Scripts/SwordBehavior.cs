using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
	float speed;
	private AudioSource source;
	public AudioClip swordSwingSFX;

	void Start()
	{
		speed = 1000f;
		source = GetComponent<AudioSource>();
		source.PlayOneShot(swordSwingSFX); 
	}

	void FixedUpdate()
	{
		transform.parent.gameObject.transform.Rotate(0, 0, -speed * Time.deltaTime);

		if (transform.parent.gameObject.transform.rotation.z > 0.0f)
		{
			GameObject.Find("PlayerController").GetComponent<PlayerController>().swordSwinging = false; 
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Enemy" && !col.isTrigger)
		{
			col.gameObject.GetComponent<Enemy>().TakeDamage(1);
			Vector2 direction = (col.transform.position - transform.position).normalized;
			StartCoroutine(ForceStopper(col.GetComponent<Rigidbody2D>()));
			col.GetComponent<Rigidbody2D>().AddForce(direction * 1000);
		}
	}

	IEnumerator ForceStopper(Rigidbody2D enemyRb)
	{
		yield return new WaitForSeconds(0.1f);
		enemyRb.velocity = Vector2.zero;
		enemyRb.GetComponent<Enemy>().hit = false;
	}
}
