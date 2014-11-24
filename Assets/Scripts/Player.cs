using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour
{
	public GameManager[] gameManager;


	string playerName;
	public int playerHealth;
	int opponentsHealth;
	public int teamId;
	public int deckSize;
	public bool showPlayersHandCard;
	public string lastTooltip = " ";
	public Texture[] islandZoom;
	public Texture[] handZoom;
	public Land_Island[] myIsland;
	public BattleCardSpawnScript[] BattleSpawn;
	public LandSpawnCoordScript[] LandSpawn;

	public string[] playerDeck;
	public string[] playerCardHand;
	public Texture[] MyHandOfCardsTextures;
	public Texture[] currentZoom;
	public bool myTurn;

	public string[] phaseNames;
	public bool showInitialGamephase;
	public string gamePhase ;
	
	void start()
	{
		BattleSpawn = GameObject.FindObjectsOfType<BattleCardSpawnScript>();
		LandSpawn = GameObject.FindObjectsOfType<LandSpawnCoordScript>();
		gameManager = GameObject.FindObjectsOfType<GameManager>();


	}

	void Awake()
	{
		Debug.Log("PlayerScript Start");
		this.playerName = "Default_Player# "+Random.Range(0,10);
		this.playerHealth = 20;
		this.opponentsHealth = 20;
		this.showInitialGamephase = true;
		this.deckSize = playerDeck.Length;
		//this.showPlayersHandCard = false;
		this.playerDeck = new string[60];
		this.playerCardHand = new string[7];
		this.MyHandOfCardsTextures = new Texture[60];
		this.teamId = PhotonNetwork.player.ID;
		this.handZoom = new Texture[7];
		this.phaseNames = new string[7]{"Untap","UpKeep","Draw","Main1","Battle","Main2","End"};

		gameManager = GameObject.FindObjectsOfType<GameManager>();
		PhotonNetwork.sendRate = 20; //send rate: 20 times per second 
		PhotonNetwork.sendRateOnSerialize = 10; //10 time per second
		DealInitialCardsInHand();
		showPlayersHandCard = true;
	}

	void Update()
	{
		int currentPos = 0; //position of the currentZoom array
		myIsland = GameObject.FindObjectsOfType<Land_Island>(); //get all the islands
		currentZoom = new Texture[myIsland.Length + MyHandOfCardsTextures.Length]; //reinitalize the array of current Textures (This can be kept, but size will increase by every type of card)
		// cycle through the islands, will have to do for every type of card

		for(int i = 0; i < myIsland.Length; i++){
			currentZoom[currentPos] = myIsland[i].currentText; // insert into current texures
			currentPos++;
		}
		for(int j = 0; j < handZoom.Length; j++){
			currentZoom[currentPos] = handZoom[j];
			currentPos++; 
		}



	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
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
			ChoosePhases();
		}

		GUIStyle style = new GUIStyle ();
		style.richText = true;
		style.fontSize = 30;
		GUI.Label(new Rect(Screen.width * 0.65f,Screen.height * 0.02f,200,100),"<color=white>"+gamePhase.ToString()+"</color>",style);


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
					Debug.Log ("Card In Hand Clicked");
					Debug.Log (teamId);
				
					LandSpawnCoordScript myLandCards;
					BattleCardSpawnScript myBattleCards;
					

					if(this.teamId == 0)
					{
						if(playerCardHand[i].Substring(0,4)=="Land"){
							for(int j=0;j<LandSpawn.Length;j++)
							{
								if(LandSpawn[j].spawnInUse == false && LandSpawn[j].teamId == this.teamId)
								{
									LandSpawn[j].spawnInUse = true;
									LandSpawn[j].card_name = playerCardHand[i];
									myLandCards = LandSpawn[j];
									
									PhotonNetwork.Instantiate(LandSpawn[j].card_name, myLandCards.transform.position, myLandCards.transform.rotation, 0); 
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
									break;
								}
								else
								{
									Debug.Log("All Land card spots in use");
								}
							}
						}
					}
					else if(this.teamId == 1)
					{
						if(playerCardHand[i].Substring(0,4)=="Land"){
							for(int j=0;j<LandSpawn.Length;j++)
							{
								if(LandSpawn[j].spawnInUse == false && LandSpawn[j].teamId == this.teamId)
								{
									LandSpawn[j].spawnInUse = true;
									LandSpawn[j].card_name = playerCardHand[i];
									myLandCards = LandSpawn[j];
									
									PhotonNetwork.Instantiate(LandSpawn[j].card_name, myLandCards.transform.position, myLandCards.transform.rotation, 0); 
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
									break;
								}
								else
								{
									Debug.Log("All Land card spots in use");
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
<<<<<<< Updated upstream
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
=======
	}
>>>>>>> Stashed changes


	[RPC]
	public void ChoosePhases()
	{
		for(int i = 0; i<this.phaseNames.Length; i++)
		{
			if(GUI.Button(new Rect(Screen.width * 0.80f,Screen.height * 0.10f+(i*50),100,50),phaseNames[i]))
			{
				gamePhase = "Player: "+PhotonNetwork.player.ID+" Phase: "+phaseNames[i];
				Debug.Log(gamePhase);

			}
		}
<<<<<<< Updated upstream
=======
	}

	public void setPhaseMessage(string phaseName)
	{
		this.gamePhase = phaseName;
>>>>>>> Stashed changes
	}
}