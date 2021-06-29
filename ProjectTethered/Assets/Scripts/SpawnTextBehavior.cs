using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTextBehavior : MonoBehaviour
{
	float speed = 1; 

    void Start()
    {
		Destroy(gameObject, 0.5f); 
    }

    void Update()
    {
		transform.Translate(transform.up * Time.deltaTime * speed);
	}
}
