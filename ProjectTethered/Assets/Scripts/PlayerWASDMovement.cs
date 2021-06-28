using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWASDMovement : MonoBehaviour
{
	float speed = 5;
	public bool northRes;
	public bool southRes;
	public bool westRes;
	public bool eastRes;

	public bool lastDir; 

	void Update()
	{
		Movement(); 
	}

	void Movement()
	{
		#region Movement 
		if (!northRes && Input.GetKey("w"))
		{
			transform.Translate(transform.up * Time.deltaTime * speed);
		}
		if (!westRes && Input.GetKey("a"))
		{
			transform.Translate(-transform.right * Time.deltaTime * speed);
		}
		if (!southRes && Input.GetKey("s"))
		{
			transform.Translate(-transform.up * Time.deltaTime * speed);
		}
		if (!eastRes && Input.GetKey("d"))
		{
			transform.Translate(transform.right * Time.deltaTime * speed);
		}
		#endregion Movement

		#region Last Direction 
		if (Input.GetKey("a") && !Input.GetKey("d"))
		{
			lastDir = false;
		}
		else if (Input.GetKey("d") && !Input.GetKey("a"))
		{
			lastDir = true;
		}
		#endregion Last Direction

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
		if (Physics.Raycast(transform.position, west, out westHit, 0.5f) && westHit.collider.gameObject.tag == "Wall")
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
}
