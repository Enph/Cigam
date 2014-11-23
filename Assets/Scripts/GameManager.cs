using UnityEngine;
using System.Collections;


/*This class will take care of all the game logic as well as the board game logic
 * 
 * 
 * 
 * 
 */

public class GameManager : Photon.MonoBehaviour {

	//Class objects
	public NetworkManager[] networkManager;
	public Player[] player;
	public LandSpawnCoordScript[] LandSpawn;
	public BattleCardSpawnScript[] BattleSpawn;

	//If statements when to display menus
	public bool showConnectionState = false;
	public bool showEnterPlayerName = false;
	public string enterPlayerName;
	
	// Use this for initialization
	void Start () {
		this.networkManager = GameObject.FindObjectsOfType<NetworkManager>();
		this.player = GameObject.FindObjectsOfType<Player>();
		LandSpawn = GameObject.FindObjectsOfType<LandSpawnCoordScript>();
		BattleSpawn = GameObject.FindObjectsOfType<BattleCardSpawnScript>();

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
			//GUILayout.Label ("Player Name:" + player[0].getPlayerName());
			GUILayout.Label ("Player Name:" + PhotonNetwork.player.ID);

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

	public void SpawnCardsOnLandArea()
	{
		Debug.Log ("Spawning Land Card");
		for(int i=0;i<LandSpawn.Length;i++)
		{
			if(LandSpawn[i].spawnInUse == false)
			{
				LandSpawn[i].spawnInUse = true;
				LandSpawnCoordScript myCards = LandSpawn[i];
				Debug.Log ("x: "+myCards.transform.position.x + " y "+myCards.transform.position.y + " z "+myCards.transform.position.z);
				PhotonNetwork.Instantiate("Card", myCards.transform.position, myCards.transform.rotation, 0); 
				break;
			}
			else
			{
				Debug.Log("All card spots in use");
			}
		}
	}

	public void SpawnCardsOnAttackField()
	{
		Debug.Log ("Spawning Creature Card");
	//	((MonoBehaviour)myPlayerGO.GetComponent("Oreskos_Swiftclaw")).enabled = true;

		for(int i=0;i<LandSpawn.Length;i++)
		{
			if(BattleSpawn[i].spawnInUse == false)
			{

				BattleSpawn[i].spawnInUse = true;
				BattleCardSpawnScript myCards = BattleSpawn[i];
				Debug.Log ("x: "+myCards.transform.position.x + " y "+myCards.transform.position.y + " z "+myCards.transform.position.z);
				PhotonNetwork.Instantiate("Card", myCards.transform.position, myCards.transform.rotation, 0); 
				break;
			}
			else
			{
				Debug.Log("All card spots in use");
			}
		}
	}

	public void SpawnLandIsland()
	{
		Debug.Log ("Spawning Island Card");


		for(int i=0;i<LandSpawn.Length;i++)
		{
			if(LandSpawn[i].spawnInUse == false)
			{
				LandSpawn[i].spawnInUse = true;
				LandSpawnCoordScript myCards = LandSpawn[i];
				Debug.Log ("x: "+myCards.transform.position.x + " y "+myCards.transform.position.y + " z "+myCards.transform.position.z);

				GameObject Land_Island = PhotonNetwork.Instantiate("Land_Island", myCards.transform.position, myCards.transform.rotation, 0); 
				break;
			}
			else
			{
				Debug.Log("All Land card spots in use");
			}
		}

	}




	public void SpawnMyDeck()
	{

	}
}
