using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
	private float speed;
	private AudioSource source;
	public AudioClip swordSwingSFX;
	private bool owningChar; // false = Wasd , true = Arro 
	private bool swordDir; // false = counter clockwise , true = clockwise 
	int count = 0; 

	void Start()
	{
		speed = 1500f;
		source = GetComponent<AudioSource>();
		source.PlayOneShot(swordSwingSFX); 

		if(transform.parent.transform.parent.GetComponent<PlayerArrowsMovement>())
		{
			owningChar = true; 
			swordDir = transform.parent.transform.parent.GetComponent<PlayerArrowsMovement>().lastDir; 
		}
		else if (transform.parent.transform.parent.GetComponent<PlayerWASDMovement>())
		{
			owningChar = false; 
			swordDir = transform.parent.transform.parent.GetComponent<PlayerWASDMovement>().lastDir;
		}
	}

	void FixedUpdate()
	{
		if (swordDir)
		{
			transform.parent.gameObject.transform.Rotate(0, 0, -speed * Time.deltaTime);

			if (transform.parent.gameObject.transform.rotation.z > 0.0f)
			{
				if(!owningChar)
				{
					GameObject.Find("PlayerController").GetComponent<PlayerController>().swordSwingingWasd = false;
				}
				else
				{
					GameObject.Find("PlayerController").GetComponent<PlayerController>().swordSwingingArro = false;
				}

				Debug.Log("<color=yellow>How many times hit: </color>" + count); 
				Destroy(gameObject);
			}
		}
		else
		{
			transform.parent.gameObject.transform.Rotate(0, 0, speed * Time.deltaTime);

			if (transform.parent.gameObject.transform.rotation.z < 0.0f)
			{

				if (!owningChar)
				{
					GameObject.Find("PlayerController").GetComponent<PlayerController>().swordSwingingWasd = false;
				}
				else
				{
					GameObject.Find("PlayerController").GetComponent<PlayerController>().swordSwingingArro = false;
				}

				Debug.Log("<color=yellow>How many times hit: </color>" + count);
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Enemy" && !col.isTrigger)
		{
			count++;
			Vector2 direction = (col.transform.position - transform.position).normalized;
			if (!col.GetComponent<Enemy>().hit)
			{
				Debug.Log("<color=lightyellow>Making enemy go fly</color>");
				col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				col.GetComponent<Rigidbody2D>().AddForce(direction * 1000);
				col.GetComponent<Enemy>().CallingEnemyForceStopper(); 
			}
			col.gameObject.GetComponent<Enemy>().TakeDamage(1);
		}
	}

	IEnumerator EnemyForceStopper(Rigidbody2D enemyRb)
	{
		yield return new WaitForSeconds(0.1f);
		Debug.Log("<color=red>Stopping Velocity</color>"); 
		enemyRb.GetComponent<Enemy>().hit = false;
		enemyRb.velocity = Vector2.zero;
	}
}
