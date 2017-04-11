using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Snowball : MonoBehaviour
{
	private float _x;
	private GameObject _obsGen;
	public float speed;

	void Start()
	{
		_obsGen = GameObject.Find ("SnowGenerator");
		//transform.position = _obsGen.transform.position;
	}
	void Update()
	{
		//transform = _obsGen.Get;
		//transform.position = ;


		transform.position = new Vector3 (_x, transform.position.y, transform.position.z);
		_x -= speed;

	}
}


