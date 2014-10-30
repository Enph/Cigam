using UnityEngine;
using System.Collections;


/*This class will take care of all the game logic as well as the board game logic
 * 
 * 
 * 
 * 
 */

public class GameManager : MonoBehaviour {

	Player player1;
	Player player2;

	public GameObject playerPrefab;
	public GameObject playerPrefab1;

	// Use this for initialization
	void Start () {
		PhotonNetwork.Instantiate(playerPrefab.name, Vector3.up * 5, Quaternion.identity, 0);
		this.player1 = new Player();
		this.player2 = new Player();
		player1.spawnPlayer("Player1_Camera");
		player2.spawnPlayer("Player2_Camera");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}


	void OnJoinedRoom()
	{


	}
}
