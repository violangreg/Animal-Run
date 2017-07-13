using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObstacleDeactivator : MonoBehaviour {

	private GameObject _deactivatorPoint;

	// Use this for initialization
	void Start ()
	{
		_deactivatorPoint = GameObject.Find ("Deactivator Point");
	}

	void Update()
	{
		if (transform.position.x < _deactivatorPoint.transform.position.x) 
		{
			gameObject.SetActive (false);
		}
	}

}
