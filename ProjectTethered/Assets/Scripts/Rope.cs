using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			GameObject.Find("PlayerArrow").GetComponent<PlayerArrowsMovement>().IncreaseStringLength(1);
			GameObject.Find("PlayerController").GetComponent<PlayerController>().ChangeRopeMeterSizes();
			Destroy(gameObject); 
		}
	}
}
