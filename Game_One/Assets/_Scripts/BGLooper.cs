using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public GameObject looperPoint;
    public LayerMask layer;
    public int numPanels;

	void Start ()
	{
		looperPoint = GameObject.Find ("BGLooper");
	}

	void Update()
	{
		if (transform.position.x < looperPoint.transform.position.x) 
		{
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		//Debug.Log ("Triggered: " + collider.name);

        if (collider.IsTouchingLayers(layer))
        {
            float widthOfBGObject = collider.bounds.size.x;
            Vector3 position = collider.transform.position;

            position.x += widthOfBGObject * numPanels;

            collider.transform.position = position;
        }
	}
}
