using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health;
	private const int maxHealth = 2;
	public bool isAware;
	public GameObject playerObj;
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

    void Update()
    {
		CheckHealth();
		UpdateHealthBar(); 
		Behavior(); 
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
		if (!hit)
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
			GameObject.Find("PlayerController").GetComponent<PlayerController>().TakeDamage(1);
			Vector2 direction = (col.transform.position - transform.position).normalized;
			playerObj.GetComponent<Rigidbody2D>().AddForce(direction * 1000);
			StartCoroutine(ForceStopper());
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
			playerObj = col.gameObject; 
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			isAware = false;
			playerObj = null; 
		}
	}

	IEnumerator ForceStopper()
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