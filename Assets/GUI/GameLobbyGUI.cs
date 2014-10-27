using UnityEngine;
using System.Collections;

public class GameLobbyGUI : MonoBehaviour {

	private const string roomName = "RoomName";
	private RoomInfo[] roomsList;
	
	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
		PhotonNetwork.autoJoinLobby = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Box (new Rect (0, 0,Screen.width,Screen.height), "Lobby"); //a box to hold all the buttons

		GUI.Box (new Rect (Screen.width /3 , Screen.height /8 , Screen.width * 0.65f , Screen.height /2),PhotonNetwork.connectionStateDetailed.ToString()); // Server list Window
		GUILayout.BeginArea (new Rect (Screen.width /3 , Screen.height /8 , Screen.width * 0.65f , Screen.height /2));

		if(PhotonNetwork.GetRoomList().Length != 0)
		{
			for (int i = 0; i < roomsList.Length; i++)
			{
				if (GUI.Button(new Rect(10, 10 + (10 * i), 100, 50), "Join " + roomsList[i].name))
				{
					GUI.Label (new Rect(0,0,100,100),roomsList[i].name);
					GUI.Label( new Rect(10, 10, 100, 100) ,"Stat A");//Label Current players in the room networkManager.roomsList[i].playerCount.ToString()
					GUI.Label( new Rect(40, 10, 100, 100) ,"Stat B"); //Label Max players per room networkManager.roomsList[i].maxPlayers.ToString
					GUI.Label( new Rect(70, 10, 100, 100) ,"Stat C"); //Label If game can be joined networkManager.roomsList[i].open.ToString
				}
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
			PhotonNetwork.CreateRoom(roomName + System.Guid.NewGuid().ToString("N"),true,true,2);
			OnReceivedRoomListUpdate();
		}

		//JOIN A SELECTED GAME
		else if (GUI.Button (new Rect (10,60,200,50), "Join Game")) 
		{
			//Network.Connect(NetworkManager.hostData[networkManager.getHostData()]);
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

	void OnReceivedRoomListUpdate()
	{
		roomsList = PhotonNetwork.GetRoomList();
	}
	

	void OnJoinedRoom()
	{
		Debug.Log("Connected to Room: ");
		Debug.Log ("Loading GamePhase Scene");
		PhotonNetwork.LoadLevel("GamePhase");

	}
}
