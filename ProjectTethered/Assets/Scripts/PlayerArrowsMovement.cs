using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowsMovement : MonoBehaviour
{
	float speed = 5;
	public bool northRes;
	public bool southRes;
	public bool westRes;
	public bool eastRes;
	private GameObject wasd;
	private SpringJoint2D joint;
	private LineRenderer line;

	public Material matA;
	public Material matB;

	private AudioSource source;
	public AudioClip ropeStretchSFX;
	private bool sfxPlaying; 

	void Start()
	{
		wasd = GameObject.Find("PlayerWASD");
		line = GetComponent<LineRenderer>();
		joint = GetComponent<SpringJoint2D>();
		source = GetComponent<AudioSource>(); 
		line = GetComponent<LineRenderer>();
		//line.material = new Material(Shader.Find("Sprites/Default"));
		line.widthMultiplier = 0.2f;
		float alpha = 1.0f;
		sfxPlaying = false; 
	}

	void Update()
	{
		Movement();

		line = GetComponent<LineRenderer>();

		line.SetPosition(0, new Vector3(wasd.transform.position.x, wasd.transform.position.y, -4.0f));
		line.SetPosition(1, new Vector3(transform.position.x, transform.position.y, -4.0f));

		if (Vector3.Distance(transform.position, wasd.transform.position) >= joint.distance)
		{
			joint.enabled = true;
			line.material = matB;
		}
		else if (Vector3.Distance(transform.position, wasd.transform.position) <= joint.distance)
		{
			joint.enabled = false;
			line.material = matA;
		}

		if (Vector3.Distance(transform.position, wasd.transform.position) > joint.distance)
		{
			if (!sfxPlaying)
			{
				sfxPlaying = true; 
				StartCoroutine(PlaySFX());
			}
		}
	}

	void Movement()
	{
		#region Movement 
		if (!northRes && Input.GetKey("up")) 
		{
			transform.Translate(transform.up * Time.deltaTime * speed);
		}
		if (!westRes && Input.GetKey("left")) 
		{
			transform.Translate(-transform.right * Time.deltaTime * speed);
		}
		if (!southRes && Input.GetKey("down")) 
		{
			transform.Translate(-transform.up * Time.deltaTime * speed);
		}
		if (!eastRes && Input.GetKey("right")) 
		{
			transform.Translate(transform.right * Time.deltaTime * speed);
		}
		#endregion Movement

		#region Restraints
		RaycastHit northHit;
		Vector3 north = transform.TransformDirection(Vector3.up);
		if (Physics.Raycast(transform.position, north, out northHit, 0.5f) && northHit.collider.gameObject.tag == "Wall")
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 0.5f, Color.red);
			northRes = true;
		}
		else
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 0.5f, Color.white);
			northRes = false;
		}

		RaycastHit southHit;
		Vector3 south = transform.TransformDirection(Vector3.down);
		if (Physics.Raycast(transform.position, south, out southHit, 0.5f) && southHit.collider.gameObject.tag == "Wall")
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 0.5f, Color.red);
			southRes = true;
		}
		else
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 0.5f, Color.white);
			southRes = false;
		}

		RaycastHit westHit;
		Vector3 west = transform.TransformDirection(Vector3.left);
		if (Physics.Raycast(transform.position, west, out westHit, 0.5f) &&westHit.collider.gameObject.tag == "Wall")
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 0.5f, Color.red);
			westRes = true;
		}
		else
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 0.5f, Color.white);
			westRes = false;
		}

		RaycastHit eastHit;
		Vector3 east = transform.TransformDirection(-Vector3.left);
		if (Physics.Raycast(transform.position, east, out eastHit, 0.5f) && eastHit.collider.gameObject.tag == "Wall")
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.left) * 0.5f, Color.red);
			eastRes = true;
		}
		else
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.left) * 0.5f, Color.white);
			eastRes = false;
		}
		#endregion Restraints
	}

	public void IncreaseStringLength(int amount)
	{
		joint.distance += amount; 
	}

	IEnumerator PlaySFX()
	{
		source.PlayOneShot(ropeStretchSFX);
		yield return new WaitForSeconds(ropeStretchSFX.length); 
		sfxPlaying = false; 
	}
}
