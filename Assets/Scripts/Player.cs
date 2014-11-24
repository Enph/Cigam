using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour
{
	public GameManager[] gameManager;


	string playerName;
	public int playerHealth;
	int opponentsHealth;
	int teamId;
	int deckSize;
	public bool showPlayersHandCard;
	public string lastTooltip = " ";
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
	public bool myTurn;

	public string[] phaseNames;
	public string gameState;
	public bool showInitialGamephase;
	
	void start()
	{
		
	}

	void Awake()
	{
		Debug.Log("PlayerScript Start");
		this.playerName = "Default_Player# "+Random.Range(0,10);
		this.playerHealth = 20;
		this.opponentsHealth = 20;
		this.showInitialGamephase = true;
		this.deckSize = playerDeck.Length;
		this.showPlayersHandCard = false;
		this.playerDeck = new string[60];
		this.playerCardHand = new string[7];
		this.MyHandOfCardsTextures = new Texture[60];

		this.teamId = PhotonNetwork.player.ID;
		Debug.Log("Awake Team id = "+this.teamId);
		
		this.handZoom = new Texture[7];

		this.phaseNames = new string[7]{"Untap","UpKeep","Draw","Main1","Battle","Main2","End"};


		if(PhotonNetwork.player.ID == 1)
			this.myTurn = true;
		else
			this.myTurn = false;

		gameManager = GameObject.FindObjectsOfType<GameManager>();
		BattleSpawn = GameObject.FindObjectsOfType<BattleCardSpawnScript>();
		LandSpawn = GameObject.FindObjectsOfType<LandSpawnCoordScript>();
	}

	void Update()
	{	
		Debug.Log("Update Team id = "+this.teamId);
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

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if(stream.isWriting)
		{
			//This is our player stuff
			stream.SendNext (this.gameState);
		}
		else
		{
			//this is player 2 stuff
			this.gameState = (string) stream.ReceiveNext();
		}
	}


	public string getPlayerName()
	{
		return this.playerName;
	}

	public void setPlayerName(string name)
	{
		this.playerName = name;
	}

	void OnGUI(){

		DisplayZoomCard();
		displayCardsInHand ();
		if(showPlayersHandCard == true)
		{
			displayCardsInHand();
			displayPhases();
		}

		GUIStyle style = new GUIStyle ();
		style.richText = true;
		style.fontSize = 30;
		GUI.Label(new Rect(Screen.width * 0.65f,Screen.height * 0.02f,200,100),"<color=white>"+gameState.ToString()+"</color>",style);


	}
	


void DisplayZoomCard(){

		for(int i = 0; i < currentZoom.Length; i++){
			if(currentZoom[i] != null){ //if the current texture is not null, display on screen. the only not null texture will be the one hovered over.
				GUI.Box (new Rect(Screen.width * 0.74f, Screen.height * 0.6f, Screen.width / 4f, Screen.height / 3f), currentZoom[i]);
			}
		}

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
	
	
	
	

	
	public void displayPhases()
	{
		/*
		if(showInitialGamephase) //this only needs to be called once to show the game state when the game first gets initalized
		{
			this.gameState ="Player: "+PhotonNetwork.player.ID+" Phase: "+phaseNames[0].ToString();
			showInitialGamephase = false;
		}
*/

		for(int i = 0; i<this.phaseNames.Length; i++)
		{
			if(GUI.Button(new Rect(Screen.width * 0.80f,Screen.height * 0.10f+(i*50),100,50),phaseNames[i]))
			{
				this.gameState = "Player: "+PhotonNetwork.player.ID+" Phase: "+phaseNames[i].ToString(); //Tell the game state
			}
		}
	}
}
