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

	// Use this for initialization
	void Start () {
		this.player1Spawn = new Vector3(10.0f,45.0f,-5.0f);
		this.player2Spawn = new Vector3(-10.0f,45.0f,5.0f);
		this.player1Rotation.eulerAngles = new Vector3(90,0,0); //rotate 90 degrees on x-axis
		this.player2Rotation.eulerAngles = new Vector3(90,180,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
