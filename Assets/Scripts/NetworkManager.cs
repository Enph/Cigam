using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	//GET OTHER SCRIPTS
	public GameManager[] gameManager;


	public string roomName = "Eric's Testing #";
	public bool NetworkMenu;
	public Camera standbyCamera;
	public Player[] player;
	public Vector3 oneCard;
	public Vector3 twoCard;
	public Quaternion rotTwo;
	// Use this for initialization
	void Start () {
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
		PhotonNetwork.ConnectUsingSettings("0.1");
		player = GameObject.FindObjectsOfType<Player>();
		gameManager = GameObject.FindObjectsOfType<GameManager>();
		this.NetworkMenu = true;
		oneCard = new Vector3(0.0f, 1.0f, 2.0f);
		twoCard = new Vector3(0.0f, 1.0f, -2.0f);
		rotTwo = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{
		if(NetworkMenu == true)
		{
			GUI.Box (new Rect (0, 0,Screen.width,Screen.height), "Lobby"); //a box to hold all the buttons	
			GUI.Box (new Rect (Screen.width /3 , Screen.height /8 , Screen.width * 0.65f , Screen.height /2),PhotonNetwork.connectionStateDetailed.ToString()); // Server list Window
			
			GUILayout.BeginArea (new Rect (Screen.width * 0.10f , Screen.height /8 , Screen.width * 0.65f , Screen.height /2));

			if(PhotonNetwork.GetRoomList().Length != 0)
			{
				int index = 1;
				foreach (RoomInfo game in PhotonNetwork.GetRoomList())
				{

					if(GUI.Button(new Rect(10,10+(index *50), Screen.width/3 - 10, 50),this.roomName + " \t\tPlayers:" + game.playerCount + "/" + game.maxPlayers + "\t\t Ping: "+PhotonNetwork.GetPing()))
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
		SpawnMyPlayer();
	}


	void SpawnMyPlayer()
	{

		if(player == null)
		{
			Debug.Log("Spawning Error");
			return;
		}

		Player myPlayer;

		if(PhotonNetwork.countOfPlayersInRooms <1)
		{
			myPlayer = player[0]; //player1 spawn
			PhotonNetwork.Instantiate("Card", oneCard, Quaternion.identity, 0);
			
		}
		else{
			myPlayer = player[1]; //player2 spawn
			PhotonNetwork.Instantiate("Card", twoCard, rotTwo, 0); 
		}
		PhotonNetwork.Instantiate("PlayerController", myPlayer.transform.position, myPlayer.transform.rotation, 0);

		GameObject myPlayerGO = (GameObject)PhotonNetwork.Instantiate("PlayerController", myPlayer.transform.position, myPlayer.transform.rotation, 0);
		((MonoBehaviour)myPlayerGO.GetComponent("Player")).enabled = true;
		//standbyCamera.enabled = false;
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

