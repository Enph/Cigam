using UnityEngine;
using System.Collections;

public class BattleCardSpawnScript : MonoBehaviour {

	public int teamId;
	public bool spawnInUse;
	public Vector3 myCoordinates;
	public Quaternion myRotations;
	
	// Use this for initialization
	void Start () {
		this.spawnInUse = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		myCoordinates = transform.position;
		myRotations = transform.rotation;
	}
}
