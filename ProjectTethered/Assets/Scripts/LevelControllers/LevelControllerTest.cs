using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerTest : MonoBehaviour
{
	public GameObject plateA;
	public GameObject plateB;

	public GameObject doorA;
	public GameObject doorB; 

	void Update()
	{
		if(plateA.GetComponent<Plate>().pressed)
		{
			Destroy(doorA); 
		}

		if (plateB.GetComponent<Plate>().pressed)
		{
			doorB.GetComponent<SpriteRenderer>().enabled = false;
			doorB.GetComponent<BoxCollider2D>().enabled = false; 
		}
		else
		{
			doorB.GetComponent<SpriteRenderer>().enabled = true;
			doorB.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
}
