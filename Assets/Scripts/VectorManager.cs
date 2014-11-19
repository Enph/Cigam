using UnityEngine;
using System.Collections;

public class VectorManager : MonoBehaviour {


	public Vector3 player1Spawn;
	public Vector3 player2Spawn;

	public Quaternion player1Rotation;
	public Quaternion player2Rotation;


	//ALL 8 CARDS FROM LEFT TO RIGHT WHERE LAND WILL BE PLAYED
	public Vector3 LandCoord1, LandCoord2, LandCoord3, LandCoord4,LandCoord5,LandCoord6,LandCoord7,LandCoord8;
	public Vector3 BattlePlaneCoord1, BattleCoord2,BattleCoord3,BattleCoord4,BattleCoord5,BattleCoord6,BattleCoord7,BattleCoord8;
	//public Vector3[] Lands;
	//public Vector3[] NonLandPermanent;


	



	// Use this for initialization
	void Start () {
		this.player1Spawn = new Vector3(0.0f,12.0f,24.0f);
		this.player2Spawn = new Vector3(0.0f,12.0f,-24.0f);

		this.player1Rotation = new Quaternion(-4.216698E-08f,0.9659258f,-0.2588191f,-1.573693E-07f); //rotate 35 degrees on x-axis
		this.player2Rotation = new Quaternion(0.35f,0.0f,0.0f,1.0f);

		//Lands = GameObject.FindGameObjectsWithTag("LandSpawnCoord");
		//NonLandPermanent = GameObject.FindGameObjectsWithTag("BattleCardSpawn");


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
