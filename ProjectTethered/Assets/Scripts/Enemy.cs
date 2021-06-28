using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health;
	private const int maxHealth = 2;
	public bool isAware;
	public GameObject playerObj;
	public GameObject playerObjOther; 
	private float speed; 
	private Transform healthBarCont;
	public bool hit;

	private AudioSource source;
	public AudioClip hitSFX;
	public AudioClip deathSFX;

	private bool coStarted; 

	void Start()
    {
		healthBarCont = transform.GetChild(0); 
		health = maxHealth;
		speed = 3;
		hit = false;
		source = GetComponent<AudioSource>();
		coStarted = false; 
	}

    void FixedUpdate()
    {
		CheckHealth();
		UpdateHealthBar(); 
		Behavior();
		SpriteFlipper(); 
	}

	void SpriteFlipper()
	{
		if(playerObj)
		{
			if(playerObj.transform.position.x > transform.position.x)
			{
				GetComponent<SpriteRenderer>().flipX = true; 
			}
			else
			{
				GetComponent<SpriteRenderer>().flipX = false;
			}
		}
	}

	void Behavior()
	{
		if (health > 0)
		{
			if (isAware)
			{
				Attack();
			}
			else
			{
				Idle();
			}
		}
	}

	void Attack()
	{
		if (!hit || !coStarted)
		{
			transform.position = Vector3.MoveTowards(transform.position, playerObj.transform.position, speed * Time.deltaTime);
		}
	}

	void Idle()
	{

	}

	void UpdateHealthBar()
	{
		healthBarCont.localScale = new Vector3( (float)health / (float)maxHealth , healthBarCont.localScale.y, healthBarCont.localScale.z); 
	}

	void CheckHealth()
	{
		if (health > maxHealth)
		{
			health = maxHealth; 
		}

		if (health <= 0)
		{
			health = 0;
			if (!coStarted)
			{
				//GetComponent<BoxCollider2D>().enabled = false; 
				coStarted = true;
				source.PlayOneShot(deathSFX); 
				StartCoroutine(WaitToDie());
			}
		}
	}

	public void TakeDamage(int dam)
	{
		if (!hit)
		{
			health -= dam;
			if(health > 0)
			{
				source.PlayOneShot(hitSFX);
			}
			hit = true; 
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (!coStarted)
			{
				GameObject.Find("PlayerController").GetComponent<PlayerController>().TakeDamage(1);
				Vector2 direction = (col.transform.position - transform.position).normalized;
				playerObj.GetComponent<Rigidbody2D>().AddForce(direction * 1000);
				StartCoroutine(PlayerForceStopper());
			}
		}
		if (col.gameObject.tag == "Wall")
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			hit = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			isAware = true;
			if (playerObj)
			{
				playerObjOther = playerObj;
			}
			playerObj = col.gameObject; 
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (col.gameObject == playerObjOther)
			{
				playerObjOther = null;
			}
			else
			{
				if(playerObjOther)
				{
					playerObj = playerObjOther;
					playerObjOther = null; 
				}
				else
				{
					isAware = false;
					playerObj = null;
				}
			}
		}
	}

	public void CallingEnemyForceStopper()
	{
		StartCoroutine(EnemyForceStopper()); 
	}

	IEnumerator EnemyForceStopper()
	{
		yield return new WaitForSeconds(0.1f);
		Debug.Log("<color=red>Stopping Velocity</color>");
		GetComponent<Enemy>().hit = false;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	IEnumerator PlayerForceStopper()
	{
		yield return new WaitForSeconds(0.1f);
		GameObject.Find("PlayerController").GetComponent<PlayerController>().wasd.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GameObject.Find("PlayerController").GetComponent<PlayerController>().arrow.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	IEnumerator WaitToDie()
	{
		yield return new WaitForSeconds(deathSFX.length);
		Destroy(gameObject); 
	}
}
