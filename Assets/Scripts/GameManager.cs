using UnityEngine;
using System.Collections;


/*This class will take care of all the game logic as well as the board game logic
 * 
 * 
 * 
 * 
 */

public class GameManager : MonoBehaviour {

	Player player;

	// Use this for initialization
	void Start () {

		if(PhotonNetwork.countOfPlayersInRooms > 0)
		{
		//this.player.playerName = "Player1";
		//this.player.SetPosition(0.0f,4.0f,-8.0f); //player2 spawn point
		//this.player.SetCameraPosition(0.0f,0.0f,0.0f);
		//this.player.SetCameraPosition();
			player.name = "Player1";
		
		}
		else
		{
			//this.playerPrefab = GameObject.FindWithTag("playerPrefab");
			//this.player.playerName = "Player2";
			//this.player.SetPosition(0.0f,4.0f,7.0f); //player1 spawn point
			player.name = "Player2";

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUILayout.Label("Connection State: "+PhotonNetwork.connectionStateDetailed.ToString());
		GUILayout.Label("Ping: " + PhotonNetwork.GetPing());
		GUILayout.Label("Count of players: " + PhotonNetwork.countOfPlayersInRooms.ToString());
		GUILayout.Label ("Player Name:" + PhotonNetwork.playerName);
		//GUILayout.Label("Player Coord:" + "[" + player.SpawnPosition.x.ToString() + "," +player.SpawnPosition.y.ToString() + "," + player.SpawnPosition.z.ToString() + "]");

		//BACK TO MAIN MENU
		if(Input.GetKey(KeyCode.Escape))
		{
			PhotonNetwork.Disconnect();
			Application.LoadLevel("MainMenu");
		}

	}

}
