using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour {

	public GameObject snowball;
	public float maxPos;
	public float delayTimer;
	float timer;
	public PlayerManager player;

	// Use this for initialization
	void Start () 
	{
		timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!player.isDead())
		{
			timer -= Time.deltaTime;

			if (timer <= 0) {
				// Position the object at random y pos
				Vector3 objectPos = new Vector3 (transform.position.x, Random.Range (-maxPos, maxPos), transform.position.z);
				Instantiate (snowball, objectPos, transform.rotation);

				// Reset timer
				timer = delayTimer;
			}
		}
	}
}
