using UnityEngine;
using System.Collections;


/*This class will take care of all the game logic as well as the board game logic
 * spawn land is land?
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

	//If statements when to display GUImenus
	public bool showConnectionState = false;
	public bool showEnterPlayerName = false;
	public bool showPlayerTurnMenu = false;
	public string enterPlayerName;

	//Players Pre-Defined Decks
	public string[] deck_Red_White = new string[60];
	public string[] deck_Red = new string[60];

	//Whose Turn is it to play
	public bool player1Turn;
	public bool player2Turn; //this is first set in the network manager spawnMyPlayer function
	public string playersNameTurn;


	// Use this for initialization
	void Start () {
		this.networkManager = GameObject.FindObjectsOfType<NetworkManager>();
		LandSpawn = GameObject.FindObjectsOfType<LandSpawnCoordScript>();
		BattleSpawn = GameObject.FindObjectsOfType<BattleCardSpawnScript>();
		deck_Red_White = new string[60];
		deck_Red = new string[60];



		Generate_Red_WhiteDeck();
		GenerateRedDeck();
		Shuffle();
		Shuffle();

	}
	
	// Update is called once per frame
	void Update () 
	{
		this.player = GameObject.FindObjectsOfType<Player>();

	}
	
	void OnGUI()
	{
		if(showConnectionState == true)
		{
			GUILayout.Label("Connection State: "+PhotonNetwork.connectionStateDetailed.ToString());
			GUILayout.Label("Ping: " + PhotonNetwork.GetPing());
			GUILayout.Label("Count of players: " + PhotonNetwork.countOfPlayersInRooms.ToString());
			GUILayout.Label ("Player Name:" + player[0].getPlayerName());
			GUILayout.Label ("Player ID:" + PhotonNetwork.player.ID);
			GUILayout.Label ("Players Turn:" +this.playersNameTurn);

		}
		if(showEnterPlayerName == true)
		{
			GUILayout.BeginArea (new Rect (Screen.width /3 , Screen.height /8 , Screen.width * 0.65f , Screen.height /2));
			GUILayout.Label("Enter Player Name:");
			//enterPlayerName = GUI.TextField(new Rect(10, 20, 200, 20), enterPlayerName, 25);
			enterPlayerName = "player1";
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



	public void Generate_Red_WhiteDeck()
	{
		Debug.Log ("Generate Red White Decks");
		//Insert 24 lands
			deck_Red_White[0] = "Land_Plains";
			deck_Red_White[1] = "Land_Mountain";
			deck_Red_White[2] = "Land_Plains";
			deck_Red_White[3] = "Land_Mountain";
			deck_Red_White[4] = "Land_Plains";
			deck_Red_White[5] = "Land_Mountain";
			deck_Red_White[6] = "Land_Plains";
			deck_Red_White[7] = "Land_Mountain";
			deck_Red_White[8] = "Land_Plains";
			deck_Red_White[9] = "Land_Mountain";
			deck_Red_White[10] = "Land_Plains";
			deck_Red_White[11] = "Land_Mountain";
			deck_Red_White[12] = "Land_Plains";
			deck_Red_White[13] = "Land_Mountain";
			deck_Red_White[14] = "Land_Plains";
			deck_Red_White[15] = "Land_Mountain";
			deck_Red_White[16] = "Land_Plains";
			deck_Red_White[17] = "Land_Mountain";
			deck_Red_White[18] = "Land_Plains";
			deck_Red_White[19] = "Land_Mountain";
			deck_Red_White[20] = "Land_Plains";
			deck_Red_White[21] = "Land_Plains";
			deck_Red_White[22] = "Land_Plains";
			deck_Red_White[23] = "Land_Plains";

		//insert randomly other nonland cards	
			deck_Red_White[24] = "Creature_Geistofthemoors";
			deck_Red_White[25] = "Creature_Geistofthemoors";
			deck_Red_White[26] = "Creature_Krenkosenforcer";
			deck_Red_White[27] = "Creature_Krenkosenforcer";
			deck_Red_White[28] = "Creature_Monasteryswiftspear";
			deck_Red_White[29] = "Creature_Monasteryswiftspear";
			deck_Red_White[30] = "Creature_Monasteryswiftspear";
			deck_Red_White[31] = "Creature_Monasteryswiftspear";
			deck_Red_White[32] = "Creature_Oreskosswiftclaw";
			deck_Red_White[33] = "Creature_Oreskosswiftclaw";
			deck_Red_White[34] = "Creature_Oreskosswiftclaw";
			deck_Red_White[35] = "Creature_Oreskosswiftclaw";
			deck_Red_White[36] = "Creature_Serraangel";
			deck_Red_White[37] = "Creature_Soulmender";
			deck_Red_White[38] = "Creature_Serraangel";
			deck_Red_White[39] = "Creature_Soulmender";
			deck_Red_White[40] = "Creature_Sungracepegasus";
			deck_Red_White[41] = "Creature_Sungracepegasus";
			deck_Red_White[42] = "Creature_Sungracepegasus";
			deck_Red_White[43] = "Creature_Sungracepegasus";
			deck_Red_White[44] = "Creature_Thunderinggiant";
			deck_Red_White[45] = "Creature_Thunderinggiant";
			deck_Red_White[46] = "Instant_Divineverdict";
			deck_Red_White[47] = "Instant_Inspiredcharge";
			deck_Red_White[48] = "Instant_Divineverdict";
			deck_Red_White[49] = "Instant_Inspiredcharge";
			deck_Red_White[50] = "Instant_Lightningstrike";
			deck_Red_White[51] = "Instant_Raisethealarm";
			deck_Red_White[52] = "Instant_Lightningstrike";
			deck_Red_White[53] = "Instant_Raisethealarm";
			deck_Red_White[54] = "Instant_Lightningstrike";
			deck_Red_White[55] = "Instant_Raisethealarm";
			deck_Red_White[56] = "Instant_Lightningstrike";
			deck_Red_White[57] = "Instant_Raisethealarm";
			deck_Red_White[58] = "Sorcery_Lavaaxe";
			deck_Red_White[59] = "Sorcery_Lavaaxe";
		Debug.Log("Deck Size: "+deck_Red_White.Length);

	}

	public void GenerateRedDeck()
	{
		//Insert 24 lands
		for(int i=0;i<24;i++)
		{
			deck_Red[i] = "Land_Mountain";
		}
	}
	
	public void Shuffle()
	{
		System.Random random = new System.Random();
		for(int i = 59;i>-1;i--){
			int j = random.Next(0,59);
			string temp = deck_Red_White[j];
			deck_Red_White[j] = deck_Red_White[i];
			deck_Red_White[i] = temp;
		}
	}	




}
