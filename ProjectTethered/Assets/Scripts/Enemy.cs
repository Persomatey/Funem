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

	public LayerMask toIgnore;

	private GameObject playerWasd;
	private GameObject playerArro; 

	public int awarenessRadius = 5; 

	void Start()
    {
		healthBarCont = transform.GetChild(0); 
		health = maxHealth;
		speed = 3;
		hit = false;
		source = GetComponent<AudioSource>();
		coStarted = false;

		playerWasd = GameObject.Find("PlayerWASD");
		playerArro = GameObject.Find("PlayerArrow"); 
	}

    void FixedUpdate()
    {
		CheckHealth();
		UpdateHealthBar(); 
		Behavior();
		SpriteFlipper();
	}

	private void Update()
	{
		CheckForPlayer(); 
	}

	void CheckForPlayer()
	{
		Vector2 directionArro = playerArro.transform.position - transform.position;
		Vector2 directionWasd = playerWasd.transform.position - transform.position;

		RaycastHit2D hitArro = Physics2D.Raycast(transform.position, directionArro, awarenessRadius, ~toIgnore);
		RaycastHit2D hitWasd = Physics2D.Raycast(transform.position, directionWasd, awarenessRadius, ~toIgnore);

		if (hitArro.collider && hitArro.collider.tag != "Wall")
		{
			isAware = true;

			if (playerObj)
			{
				playerObjOther = playerObj;
			}

			playerObj = hitArro.collider.gameObject;

			Debug.DrawRay(transform.position, directionArro * 0.25f, Color.red);
		}
		else
		{
			Debug.DrawRay(transform.position, directionArro * 0.25f, Color.white);
		}

		if (hitWasd.collider && hitWasd.collider.tag != "Wall")
		{
			isAware = true;

			if (playerObj)
			{
				playerObjOther = playerObj;
			}

			playerObj = hitWasd.collider.gameObject;

			Debug.DrawRay(transform.position, directionWasd * 0.25f, Color.red);
		}
		else 
		{
			Debug.DrawRay(transform.position, directionWasd * 0.25f, Color.white);
		}
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

		if (col.gameObject.tag == "Enemy")
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
