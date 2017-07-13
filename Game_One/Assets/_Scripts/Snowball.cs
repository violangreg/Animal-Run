using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Snowball : MonoBehaviour
{
	public float speed = 0.0f;
	void Start()
	{
		//_obsGen = GameObject.Find ("SnowGenerator");
		//transform.position = _obsGen.transform.position;
	}
	void Update()
	{
		//transform = _obsGen.Get;
		//transform.position = ;

		transform.Translate (new Vector3 (-1, 0, 0) * speed * Time.deltaTime);
	}
}


