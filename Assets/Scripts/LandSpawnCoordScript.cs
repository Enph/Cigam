using UnityEngine;
using System.Collections;

public class LandSpawnCoordScript : MonoBehaviour {

	public int teamId; //Will be used to distinguise which side of the board the land will spawn on
	public bool spawnInUse; //flag to tell the system if the gameobject has a card already spawned on it
	public Vector3 myCoordinates;
	public Quaternion myRotations;

	// Use this for initialization
	void Start () {
		myCoordinates.y = 1;
	}
	
	// Update is called once per frame
	void Update () {
		myCoordinates = transform.position;
		myRotations = transform.rotation;
	}
}
