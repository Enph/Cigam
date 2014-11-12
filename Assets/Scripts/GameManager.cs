using UnityEngine;
using System.Collections;


/*This class will take care of all the game logic as well as the board game logic
 * 
 * 
 * 
 * 
 */

public class GameManager : Photon.MonoBehaviour {

	public NetworkManager[] networkManager;
	public Player[] player;


	//If statements when to display menus
	public bool showConnectionState = false;
	public bool showEnterPlayerName = false;



	public string enterPlayerName;
	
	// Use this for initialization
	void Start () {
		this.networkManager = GameObject.FindObjectsOfType<NetworkManager>();
		this.player = GameObject.FindObjectsOfType<Player>();
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
			GUILayout.Label ("Player Name:" + player[0].getPlayerName());
			GUILayout.Label("Player Coord:" + "[" + player[0].player_Xcoord + "," +player[0].player_Ycoord.ToString() + "," + player[0].player_Zcoord.ToString() + "]");


		}
		if(showEnterPlayerName == true)
		{
			GUILayout.BeginArea (new Rect (Screen.width /3 , Screen.height /8 , Screen.width * 0.65f , Screen.height /2));
			GUILayout.Label("Enter Player Name:");
			enterPlayerName = GUI.TextField(new Rect(10, 20, 200, 20), enterPlayerName, 25);
			if (GUI.Button (new Rect (10,50,200,50), "OK"))
			{
				player[0].setPlayerName(enterPlayerName);
				this.showEnterPlayerName = false; //turn off enter player name GUI
				this.showConnectionState = true; //turn on Main game UI
			}
			GUILayout.EndArea();
		}


		//BACK TO MAIN MENU
		if(Input.GetKey(KeyCode.Escape))
		{
			PhotonNetwork.Disconnect();
			Application.LoadLevel("MainMenu");
		}
		
	}
}
