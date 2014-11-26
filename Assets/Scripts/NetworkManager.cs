using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	//GET OTHER SCRIPTS
	public GameManager[] gameManager;
	public VectorManager[] vectorManager;
	public DebugDev[] debugDev;


	public string roomName;
	public bool NetworkMenu;
	public Player[] player;
		
	public static int playerWhoIsIt;
	public GameObject players;
	public GameObject player1;
	public GameObject player2;


	// Use this for initialization
	void Start () {
		//PhotonNetwork.logLevel = PhotonLogLevel.Full;
		this.roomName = "random";
		PhotonNetwork.ConnectUsingSettings("0.1");
		player = GameObject.FindObjectsOfType<Player>();
		gameManager = GameObject.FindObjectsOfType<GameManager>();
		vectorManager = GameObject.FindObjectsOfType<VectorManager>();
		debugDev = GameObject.FindObjectsOfType<DebugDev>();

		this.NetworkMenu = true;
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindObjectsOfType<Player>();

	}



	void OnGUI()
	{
		if(NetworkMenu == true)
		{
			GUI.Box (new Rect (0, 0,Screen.width,Screen.height), "Lobby"); //a box to hold all the buttons	
			GUI.Box (new Rect (Screen.width /3 , Screen.height /8 , Screen.width * 0.65f , Screen.height /2),PhotonNetwork.connectionStateDetailed.ToString()); // Server list Window

			GUILayout.BeginArea (new Rect (Screen.width /3 , Screen.height /8 , Screen.width * 0.65f , Screen.height /2));

			if(PhotonNetwork.GetRoomList().Length != 0)
			{
				int index = 1;
				foreach (RoomInfo game in PhotonNetwork.GetRoomList())
				{
					if(GUI.Button(new Rect(10,10+(index *50), Screen.width*0.65f , 50),game.name + " \t\tPlayers:" + game.playerCount + "/" + game.maxPlayers + "\t\t Ping: "+PhotonNetwork.GetPing()))
					{
						this.NetworkMenu = false; // Turn off Network GUI
						PhotonNetwork.JoinRoom(game.name);
					}
					index ++;
				}
			}
			else
			{
				GUI.Label(new Rect(0, 0, 250, 100), "No Games Found");
			}
			GUILayout.EndArea();
			
			if (GUI.Button (new Rect (10,10,200,50), "Host Game"))
			{
				//Launch Server and then refresh the room list
				this.NetworkMenu = false; // Turn off Network GUI
				PhotonNetwork.CreateRoom(roomName + System.Guid.NewGuid().ToString("N"),true,true,2);
				OnReceivedRoomListUpdate();
			}
			//REFRESH SERVER LIST
			else if (GUI.Button (new Rect (10,110,200,50), "Refresh List"))
			{
				//Refresh the room list
				OnReceivedRoomListUpdate();				
			}
			
			else if (GUI.Button (new Rect (10,160,200,50), "Deck Builder")) 
			{
				//Deck Builder page
				this.NetworkMenu = false;
				Debug.Log ("Loading Deck Builder scene...");
				SwitchLevel("DeckBuilder");
			}
			
			else if (GUI.Button (new Rect (10,210,200,50), "Back")) 
			{
				//back to main menu
				this.NetworkMenu = false;
				SwitchLevel("MainMenu");
			}
			else
			{
				//Debug.Log ("GameLobbyGUI did not load anything");
			}
		} //END NETWORK MENU
		else
		{
			//do not display
			gameManager[0].showConnectionState = true;
		}
	}
	
	public RoomInfo[] OnReceivedRoomListUpdate()
	{
		return PhotonNetwork.GetRoomList();
	}

	void OnJoinedRoom()
	{
		this.NetworkMenu = false;
		gameManager[0].showEnterPlayerName = true;
		debugDev[0].showDebugMenu = true;
		playerWhoIsIt = PhotonNetwork.player.ID;


		SpawnMyPlayer();

	}


	void SpawnMyPlayer()
	{
		if(player == null)
		{
			Debug.Log("Spawning Error");
			return;
		}

		//Player myPlayer;
		//myPlayer.setPlayerName = PhotonNetwork.player.ID;
		Vector3 spawnPosition = vectorManager[0].player1Spawn;
		Quaternion spawnRotation = vectorManager[0].player1Rotation;

		if(PhotonNetwork.player.ID == 1)
		{
			spawnPosition = vectorManager[0].player2Spawn;
			spawnRotation = vectorManager[0].player2Rotation;
		}

		//myPlayer = PhotonNetwork.Instantiate("PlayerController", spawnPosition, spawnRotation, 0);
		GameObject go = PhotonNetwork.Instantiate("PlayerController", spawnPosition, spawnRotation, 0);
		//go.GetComponent<Player>().enabled = true;

		Debug.Log("Player 1 Room Entered");
		if(PhotonNetwork.player.ID == 1)
		{
			player[0].teamId = 1;
			player[0].DealInitialCardsInHand();
			player[0].showPlayersHandCard = true;
		}
		else
		{
			player[1].teamId = 2;
			player[1].DealInitialCardsInHand();
			player[1].showPlayersHandCard = true;
		}


	}

	
	public void SwitchLevel (string level)
	{
		StartCoroutine (DoSwitchLevel(level));
	}
	
	IEnumerator DoSwitchLevel (string level)
	{
		PhotonNetwork.Disconnect();
		while (PhotonNetwork.connected)
			yield return null;
		Application.LoadLevel(level);
	}

}

