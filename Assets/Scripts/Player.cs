using UnityEngine;
using System.Collections;


public class Player : Photon.MonoBehaviour
{
	public GameManager[] gameManager;
	public Player[] player;

	public int playerHealth;
	public int opponentsHealth;
	public string playerName;
	public int teamId;
	public int deckSize;
	public bool showPlayersHandCard;

	public Texture[] islandZoom;
	public Texture[] handZoom;
	public Land_Island[] myIsland;
	public Land_Forest[] myForest;
	public Land_Mountain[] myMount;
	public Land_Plains[] myPlains;
	public Land_Swamp[] mySwamp;
	
	public Creature_Geistofthemoors[] myGeist;
	public Creature_Krenkosenforcer[] myKrenk;
	public Creature_Monasteryswiftspear[] myMonastery;
	public Creature_Oreskosswiftclaw[] myOreskos;
	public Creature_Serraangel[] mySerra;
	public Creature_Soulmender[] mySoulmender;
	public Creature_Sungracepegasus[] mySungrace;
	public Creature_Thunderinggiant[] myThundering;
	
	public Instant_Divineverdict[] myDivine;
	public Instant_Inspiredcharge[] myInspired;
	public Instant_Lightningstrike[] myLightning;
	public Instant_Raisethealarm[] myRaise;

	public Sorcery_Lavaaxe[] myLava;

	public BattleCardSpawnScript[] BattleSpawn;
	public LandSpawnCoordScript[] LandSpawn;

	public string[] playerDeck;
	public string[] playerCardHand;
	public Texture[] MyHandOfCardsTextures;
	public Texture[] currentZoom;
	public string[] phaseNames;
	public bool showInitialGamephase;
	public string gamePhase;
	public bool showPlayerTurnMenu;
	public bool showPlayersHealth;


	//Turns
	public bool myTurn;
	public bool opponentsTurn;


	//GUI styles
	GUIStyle style;
	GUIStyle healthStyle;


	void start()
	{
		//BattleSpawn = GameObject.FindObjectsOfType<BattleCardSpawnScript>();
		//LandSpawn = GameObject.FindObjectsOfType<LandSpawnCoordScript>();
		//gameManager = GameObject.FindObjectsOfType<GameManager>();

	}

	void Awake()
	{
		Debug.Log("PlayerScript Start");
		this.playerName = "n:"+PhotonNetwork.player.ID;
		this.deckSize = playerDeck.Length;
		this.playerDeck = new string[60];
		this.playerCardHand = new string[7];
		this.MyHandOfCardsTextures = new Texture[60];
		this.teamId = PhotonNetwork.player.ID;
		
		Debug.Log("Awake Team id = "+this.teamId);
		
		style = new GUIStyle ();
		healthStyle = new GUIStyle ();
		style.richText = true;
		style.fontSize = 25;
		healthStyle.richText = true;
		healthStyle.fontSize = 20;
		
		this.phaseNames = new string[7]{"Untap","UpKeep","Draw","Main1","Battle","Main2","End"};
		this.handZoom = new Texture[7];
		
		gameManager = GameObject.FindObjectsOfType<GameManager>();
		BattleSpawn = GameObject.FindObjectsOfType<BattleCardSpawnScript>();
		LandSpawn = GameObject.FindObjectsOfType<LandSpawnCoordScript>();
		player = GameObject.FindObjectsOfType<Player>();
		
		//showPlayersHealth = true;
		
		
		if(teamId == 1) // make player 1 start first
		{
			Debug.Log("Showing player1 Menu");
			//this.showPlayerTurnMenu = true;
			this.myTurn = true;
		}
		
		DealInitialCardsInHand();
		showPlayersHandCard = true;
		
		
		PhotonNetwork.sendRate = 20; //send rate: 20 times per second 
		PhotonNetwork.sendRateOnSerialize = 10; //10 time per second
	}

	void Update()
	{	
		//Debug.Log("Update Team id = "+this.teamId);
		int currentPos = 0; //position of the currentZoom array
		myIsland = GameObject.FindObjectsOfType<Land_Island>(); //get all the islands
		myDivine = GameObject.FindObjectsOfType<Instant_Divineverdict>();
		myForest = GameObject.FindObjectsOfType<Land_Forest>();
		myGeist = GameObject.FindObjectsOfType<Creature_Geistofthemoors>();
		myInspired = GameObject.FindObjectsOfType<Instant_Inspiredcharge>();
		myKrenk = GameObject.FindObjectsOfType<Creature_Krenkosenforcer>();
		myLava = GameObject.FindObjectsOfType<Sorcery_Lavaaxe>();
		myLightning = GameObject.FindObjectsOfType<Instant_Lightningstrike>();
		myMonastery = GameObject.FindObjectsOfType<Creature_Monasteryswiftspear>();
		myMount = GameObject.FindObjectsOfType<Land_Mountain>();
		myOreskos = GameObject.FindObjectsOfType<Creature_Oreskosswiftclaw>();
		myPlains = GameObject.FindObjectsOfType<Land_Plains>();
		myRaise = GameObject.FindObjectsOfType<Instant_Raisethealarm>();
		mySerra = GameObject.FindObjectsOfType<Creature_Serraangel>();
		mySoulmender = GameObject.FindObjectsOfType<Creature_Soulmender>();
		mySungrace = GameObject.FindObjectsOfType<Creature_Sungracepegasus>();
		mySwamp = GameObject.FindObjectsOfType<Land_Swamp>();
		myThundering = GameObject.FindObjectsOfType<Creature_Thunderinggiant>();
		
		
		currentZoom = new Texture[myIsland.Length + MyHandOfCardsTextures.Length + myThundering.Length + mySwamp.Length + mySungrace.Length + mySoulmender.Length + mySerra.Length + myRaise.Length + myPlains.Length + myOreskos.Length + myMount.Length + myMonastery.Length + myLightning.Length + myLava.Length + myKrenk.Length + myInspired.Length + myGeist.Length + myForest.Length + myDivine.Length]; //reinitalize the array of current Textures (This can be kept, but size will increase by every type of card)
		// cycle through the islands, will have to do for every type of card
		for(int i = 0; i < myDivine.Length; i++){
			currentZoom[currentPos] = myDivine[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myForest.Length; i++){
			currentZoom[currentPos] = myForest[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myGeist.Length; i++){
			currentZoom[currentPos] = myGeist[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myInspired.Length; i++){
			currentZoom[currentPos] = myInspired[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myKrenk.Length; i++){
			currentZoom[currentPos] = myKrenk[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myLava.Length; i++){
			currentZoom[currentPos] = myLava[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myMonastery.Length; i++){
			currentZoom[currentPos] = myMonastery[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myMount.Length; i++){
			currentZoom[currentPos] = myMount[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myOreskos.Length; i++){
			currentZoom[currentPos] = myOreskos[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myPlains.Length; i++){
			currentZoom[currentPos] = myPlains[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myIsland.Length; i++){
			currentZoom[currentPos] = myIsland[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myThundering.Length; i++){
			currentZoom[currentPos] = myThundering[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < myRaise.Length; i++){
			currentZoom[currentPos] = myRaise[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < mySwamp.Length; i++){
			currentZoom[currentPos] = mySwamp[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < mySoulmender.Length; i++){
			currentZoom[currentPos] = mySoulmender[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < mySerra.Length; i++){
			currentZoom[currentPos] = mySerra[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int i = 0; i < handZoom.Length; i++){
			currentZoom[currentPos] = handZoom[i];
			currentPos++; 
		}
	}

	//Syncs Variables across the network
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if(stream.isWriting == true)
		{
			stream.SendNext(gamePhase);
		}
		else
		{
			gamePhase = (string)stream.ReceiveNext();
		}
	}

	public string getPlayerName()
	{
		return playerName;
	}

	public void setPlayerName(string name)
	{
		this.playerName = name;
	}

	void OnGUI(){

		DisplayZoomCard();
		//displayCardsInHand ();

		if(showPlayersHandCard == true)
		{
			displayCardsInHand();
		}
		if(showPlayerTurnMenu == true && this.myTurn == true)
		{
			ShowPlayersTurnMenu();
		}

		if(gamePhase != null)
		{
			GUI.Label(new Rect(Screen.width * 0.65f,Screen.height * 0.02f,200,100),"<color=white>"+gamePhase.ToString()+"</color>",style);
		}


			DisplayPlayer1Health();
			DisplayPlayer2Health();

	}

	public void DisplayZoomCard(){

		for(int i = 0; i < currentZoom.Length; i++){
			if(currentZoom[i] != null){ //if the current texture is not null, display on screen. the only not null texture will be the one hovered over.
				GUI.Box (new Rect(Screen.width * 0.74f, Screen.height * 0.6f, Screen.width / 4f, Screen.height / 3f), currentZoom[i]);
			}
		}

	}


	[RPC]
	public void TakeDamage(int damageAmount)
	{
		if(playerHealth == null || opponentsHealth == null) // set to 20 
		{
			playerHealth = 20;
			opponentsHealth = 20;

		}
		playerHealth = playerHealth - damageAmount;
	}

	public void TakeOpponentsDamageLocal(int damageAmount)
	{
		if(playerHealth == null) // set to 20 
		{
			this.opponentsHealth = 20;
		}
		opponentsHealth = opponentsHealth - damageAmount;
	}


	public void DealInitialCardsInHand()
	{

		for(int i=0;i<gameManager[0].deck_Red_White.Length;i++)
		{
			playerDeck[i] = gameManager[0].deck_Red_White[i];
		}


		int j=0;
		for(int i=playerDeck.Length-1;i>=playerDeck.Length-7;i--)
		{
			string textureToLoad = "CardPictures/"+playerDeck[i].ToString();
			//Debug.Log("FileName: "+textureToLoad);

			Texture tex = Resources.Load(textureToLoad) as Texture ;
			Debug.Log (tex);

			MyHandOfCardsTextures[j] = tex; //Give the texturename of the card taken out of the deck
			playerCardHand[j] = playerDeck[i]; // give the name of the card taken from the deck
			j++;
			this.deckSize--;
		}
	}

	public void displayCardsInHand()
	{
		//Debug.Log("CardsInHand");
		this.teamId = PhotonNetwork.player.ID;
		for(int i = 0; i < playerCardHand.Length; i++){
			if(playerCardHand[i] != null){
				Rect myRect = new Rect(Screen.width * 0.025f+(i*100),Screen.height * 0.75f,100,120);
				//GUILayout.BeginArea(new Rect(Screen.width * 0.025f+(i*100),Screen.height * 0.75f,100,120));
				if(GUI.Button(myRect, MyHandOfCardsTextures[i])){	
				
					LandSpawnCoordScript myLandCards;
					BattleCardSpawnScript myBattleCards;
					
					Debug.Log("Card Pressed");
					Debug.Log("Team id = "+this.teamId);
					
					if(this.teamId == 1)
					{
						Debug.Log("Team id = "+this.teamId);
						if(playerCardHand[i].Substring(0,4)=="Land"){
							for(int j=0;j<LandSpawn.Length;j++)
							{
								if(LandSpawn[j].spawnInUse == false && LandSpawn[j].teamId == this.teamId)
								{
									LandSpawn[j].spawnInUse = true;
									LandSpawn[j].card_name = playerCardHand[i];
									myLandCards = LandSpawn[j];
									
									PhotonNetwork.Instantiate(LandSpawn[j].card_name, myLandCards.transform.position, myLandCards.transform.rotation, 0); 
									Debug.Log("Play a "+LandSpawn[j].card_name);
									break;
								}
								else
								{
									Debug.Log("All Land card spots in use");
								}
							}
						}
						else{
							for(int j=0;j<BattleSpawn.Length;j++)
							{
								if(BattleSpawn[j].spawnInUse == false && BattleSpawn[j].teamId == this.teamId)
								{
									BattleSpawn[j].spawnInUse = true;
									BattleSpawn[j].card_name = playerCardHand[i];
									myBattleCards = BattleSpawn[j];
									
									PhotonNetwork.Instantiate(BattleSpawn[j].card_name, myBattleCards.transform.position, myBattleCards.transform.rotation, 0); 
									
									GameObject[] target;
									target = GameObject.FindGameObjectsWithTag("Instant");
									I_Instant temp = target[0].GetComponent(typeof(I_Instant)) as I_Instant;
									temp.setPlayer(1);
									
									Debug.Log("Play a "+BattleSpawn[j].card_name);
									break;
								}
								else
								{
									Debug.Log("All Creature card spots in use");
								}
							}
						}
					}
					else if(this.teamId == 2)
					{
						Debug.Log("Team id = "+this.teamId);
						if(playerCardHand[i].Substring(0,4)=="Land"){
							for(int j=0;j<LandSpawn.Length;j++)
							{
								if(LandSpawn[j].spawnInUse == false && LandSpawn[j].teamId == this.teamId)
								{
									LandSpawn[j].spawnInUse = true;
									LandSpawn[j].card_name = playerCardHand[i];
									myLandCards = LandSpawn[j];
									
									PhotonNetwork.Instantiate(LandSpawn[j].card_name, myLandCards.transform.position, myLandCards.transform.rotation, 0); 
									Debug.Log("Play a "+LandSpawn[j].card_name);
									break;
								}
								else
								{
									Debug.Log("All Land card spots in use");
								}
							}
						}
						else{
							for(int j=0;j<BattleSpawn.Length;j++)
							{
								if(BattleSpawn[j].spawnInUse == false && BattleSpawn[j].teamId == this.teamId)
								{
									BattleSpawn[j].spawnInUse = true;
									BattleSpawn[j].card_name = playerCardHand[i];
									myBattleCards = BattleSpawn[j];
									
									PhotonNetwork.Instantiate(BattleSpawn[j].card_name, myBattleCards.transform.position, myBattleCards.transform.rotation, 0); 
									
									GameObject[] target;
									target = GameObject.FindGameObjectsWithTag("Instant");
									I_Instant temp = target[0].GetComponent(typeof(I_Instant)) as I_Instant;
									temp.setPlayer(2);
									
									Debug.Log("Play a "+BattleSpawn[j].card_name);
									break;
								}
								else
								{
									Debug.Log("All Creature card spots in use");
								}
							}
						}
					}
				}
				if(myRect.Contains(Event.current.mousePosition)){
					handZoom[i] = MyHandOfCardsTextures[i];
				}
				else handZoom[i] = null;
			}
		}
	}	

	public void ShowPlayersTurnMenu()
	{
		if(GUI.Button(new Rect(Screen.width * 0.85f,Screen.height * 0.10f,100,50),phaseNames[0]))//Untap button
		{
			gamePhase = "Player: "+this.playerName+" Phase: "+phaseNames[0];
			Debug.Log(gamePhase);
		}
		if(GUI.Button(new Rect(Screen.width * 0.85f,Screen.height * 0.10f+(1*50),100,50),phaseNames[1]))//upKeep button
		{
			gamePhase = "Player: "+this.playerName+" Phase: "+phaseNames[1];
			Debug.Log(gamePhase);
		}
		if(GUI.Button(new Rect(Screen.width * 0.85f,Screen.height * 0.10f+(2*50),100,50),phaseNames[2]))//Draw button
		{
			gamePhase = "Player: "+this.playerName+" Phase: "+phaseNames[2];
			Debug.Log(gamePhase);
		}
		if(GUI.Button(new Rect(Screen.width * 0.85f,Screen.height * 0.10f+(3*50),100,50),phaseNames[3]))// Main phase 1 phase
		{
			gamePhase = "Player: "+this.playerName+" Phase: "+phaseNames[3];
			Debug.Log(gamePhase);
		}
		if(GUI.Button(new Rect(Screen.width * 0.85f,Screen.height * 0.10f+(4*50),100,50),phaseNames[4]))// Battle Button
		{
			gamePhase = "Player: "+this.playerName+" Phase: "+phaseNames[4];
			Debug.Log(gamePhase);
		}
		if(GUI.Button(new Rect(Screen.width * 0.85f,Screen.height * 0.10f+(5*50),100,50),phaseNames[5]))//Main Phase 2 button
		{
			gamePhase = "Player: "+this.playerName+" Phase: "+phaseNames[5];
			Debug.Log(gamePhase);
		}
		if(GUI.Button(new Rect(Screen.width * 0.85f,Screen.height * 0.10f+(6*50),100,50),phaseNames[6])) // End Button
		{
			gamePhase = "Player: "+this.playerName+" Phase: "+phaseNames[6];

			PhotonView pv = player[0].GetComponent<PhotonView>();
			if(pv == null)
				Debug.Log("Take Damage pv error");
			else{
				this.myTurn = false;
				player[0].GetComponent<PhotonView>().RPC("ToggleOpponentsTurn",PhotonTargets.Others,null );
			}

			Debug.Log(gamePhase);
		}
	}

	//my turn
	public void ToggleMyTurn()
	{
		if(this.myTurn == true)
			this.myTurn = false;
		else
			this.myTurn = true;
	}

	[RPC]
	public void ToggleOpponentsTurn()
	{
		if(this.myTurn == true)
			this.myTurn = false;
		else
			this.myTurn = true;	}

	public void setPlayersHealth(int hp)
	{
		this.playerHealth = hp;
		this.opponentsHealth = hp;
	}

	[RPC]
	public void DisplayPlayer1Health()
	{
		if(PhotonNetwork.playerList.Length > 1)
				GUI.Label(new Rect(Screen.width * 0.25f,Screen.height * 0.01f,200,100),"<color=white>"+"Life:"+playerHealth.ToString()+"</color>",healthStyle);
	}

	[RPC]
	public void DisplayPlayer2Health()
	{
		if(PhotonNetwork.playerList.Length > 1)
			GUI.Label(new Rect(Screen.width * 0.45f,Screen.height * 0.01f,200,100),"<color=white>"+"Opponents:"+opponentsHealth.ToString()+"</color>",healthStyle);
	}
}
