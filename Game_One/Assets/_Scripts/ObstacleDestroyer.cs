using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObstacleDestroyer : MonoBehaviour {

    private GameObject _destroyerPoint;

    // Use this for initialization
    void Start ()
	{
		_destroyerPoint = GameObject.Find ("Destroyer Point");
	}

	void Update()
	{
		if (this.transform.position.x < _destroyerPoint.transform.position.x) 
		{
			Destroy (this.gameObject);
		}
	}

}
