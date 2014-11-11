using UnityEngine;
using System.Collections;


/*This class will take care of all the game logic as well as the board game logic
 * 
 * 
 * 
 * 
 */

public class GameManager : Photon.MonoBehaviour {

	bool showConnectionState = false;

	
	private static GameManager instance = null;

	public static GameManager SharedInstance {
		get {
			if (instance == null) {
				instance = new GameManager();
			}
			return instance;
		}
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI()
	{

		if(showConnectionState == true)
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
		else
		{

		}
		
	}
}
