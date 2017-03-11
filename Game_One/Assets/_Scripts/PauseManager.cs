using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
	private bool _tog;
	GameObject paused, unPause;

	// Use this for initialization
	void Start () 
	{
		paused = GameObject.Find ("Paused");
		unPause = GameObject.Find ("UnPause");
		paused.SetActive (false);
		_tog = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void Toggle()
	{
		if (_tog) {
			paused.SetActive (true);
			unPause.SetActive (false);
			_tog = false;
		} else {
			_tog = true;
		}
	}
}
