using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public string roomName = "RoomName";
	private RoomInfo[] roomsList;
	public GameObject PlayerPrefab;
	public Player player;
	public bool NetworkMenu;


	// Use this for initialization
	void Start () {
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
		PhotonNetwork.ConnectUsingSettings("0.1");
		this.player = new Player();
		this.NetworkMenu = true;
	}

	void Awake()
	{
		//NetworkManager networkManager = new NetworkManager();
		NetworkManager.DontDestroyOnLoad(this);
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
			
			GUILayout.BeginArea (new Rect (Screen.width /3 , Screen.height /8 , Screen.width * 0.65f , Screen.height /2));
			
			if(PhotonNetwork.GetRoomList().Length != 0)
			{
				int index = 0;
				foreach (RoomInfo game in PhotonNetwork.GetRoomList())
				{
					//GUI.Label(new Rect(10, 10 + (10 * i), 100, 50), "Join " + roomsList[i].name);	
					//GUILayout.Label(game.name + " " + game.playerCount + "/" + game.maxPlayers);
					if(GUI.Button(new Rect(10, 10 + (10 * index), Screen.width/3 - 10, 50),this.roomName + " \t\tPlayers:" + game.playerCount + "/" + game.maxPlayers + "\t\t Ping: "+PhotonNetwork.GetPing()))
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
				PhotonNetwork.CreateRoom(roomName + System.Guid.NewGuid().ToString("N"),true,true,3);
				OnReceivedRoomListUpdate();
			}
			
			//JOIN A SELECTED GAME
			else if (GUI.Button (new Rect (10,60,200,50), "Join Game")) 
			{
				Debug.Log("Joining game...");
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
				Debug.Log ("Loading Deck Builder scene...");
				Application.LoadLevel("DeckBuilder");
			}
			
			else if (GUI.Button (new Rect (10,210,200,50), "Back")) 
			{
				//back to main menu
				Application.LoadLevel("MainMenu");
			}
			else
			{
				//Debug.Log ("GameLobbyGUI did not load anything");
			}
		}
		else
		{
			//do not display
		}
	}
	
	void OnReceivedRoomListUpdate()
	{
		roomsList = PhotonNetwork.GetRoomList();
	}

	void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate(PlayerPrefab.name, Vector3.up * 5, Quaternion.identity, 0);
		PhotonNetwork.LoadLevel("GamePhase");
	}
}

