using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour 
{

    private float _distanceBetweenX, _distanceBetweenY;

    public GameObject obstacle;
	public Transform generationPoint;
    public ObjectPooler objectPool;
    public float distanceBetweenMinX, distanceBetweenMaxX, distanceBetweenMinY, distanceBetweenMaxY, originalY;
	public Vector3 newObsPos;

	public Snowball snow;

	// Use this for initialization
	void Start () 
	{
		originalY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < generationPoint.position.x) 
		{
			_distanceBetweenX = Random.Range (distanceBetweenMinX, distanceBetweenMaxX);
			_distanceBetweenY = Random.Range (distanceBetweenMinY, distanceBetweenMaxY);

			transform.position = new Vector3 (transform.position.x, originalY, transform.position.z);
			transform.position = new Vector3 (transform.position.x + _distanceBetweenX, transform.position.y + _distanceBetweenY, transform.position.z);


			//Instantiate (obstacle, transform.position, transform.rotation);
			GameObject newObstacle = objectPool.GetPooledObject ();
			Debug.Log (newObstacle.name);

			//snow.transform.position.x = transform.position.x;

			newObsPos = newObstacle.transform.position = transform.position;

			Debug.Log (newObstacle.transform.position);

			newObstacle.transform.rotation = transform.rotation;
			newObstacle.SetActive (true);
		}
	}

	Vector3 GetNewObsPos()
	{
		return newObsPos;
	}

}
