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
	public Texture[] currentZoom;
	public Land_Island[] myIsland;
	public BattleCardSpawnScript[] BattleSpawn;
	public LandSpawnCoordScript[] LandSpawn;
	public string[] playerDeck;
	public string[] playerCardHand;
	public Texture[] MyHandOfCardsTextures;

	
	void start()
	{
		BattleSpawn = GameObject.FindObjectsOfType<BattleCardSpawnScript>();
		LandSpawn = GameObject.FindObjectsOfType<LandSpawnCoordScript>();
	}

	void Awake()
	{
		Debug.Log("PlayerScript Start");
		this.playerName = "Default_Player# "+Random.Range(0,10);
		this.playerHealth = 20;
		this.opponentsHealth = 20;
		this.deckSize = playerDeck.Length;
		this.showPlayersHandCard = false;
		this.playerDeck = new string[60];
		this.playerCardHand = new string[7];
		this.MyHandOfCardsTextures = new Texture[60];
		this.teamId = PhotonNetwork.player.ID;
		
		
		gameManager = GameObject.FindObjectsOfType<GameManager>();
	}

	void Update()
	{
		myIsland = GameObject.FindObjectsOfType<Land_Island>(); //get all the islands
		currentZoom = new Texture[myIsland.Length]; //reinitalize the array of current Textures (This can be kept, but size will increase by every type of card)
		for(int i = 0; i < myIsland.Length; i++){ // cycle through the islands, will have to do for every type of card
			currentZoom[i] = myIsland[i].currentText; // insert into current texures
		}
	}

	void OnPhotonSerialView(PhotonStream stream , PhotonMessageInfo info)
	{
		if(stream.isWriting)
		{
			//This is our player stuff
			stream.SendNext(playerHealth);
		}
		else
		{
			//this is player 2 stuff
			this.opponentsHealth = (int) stream.ReceiveNext();
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
		if(showPlayersHandCard == true)
			displayCardsInHand();
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
		for(int i = 0; i < playerCardHand.Length; i++){
			if(playerCardHand[i] != null){
				if(GUI.Button(new Rect(Screen.width * 0.02f+(i*100),Screen.height * 0.75f,100,120),MyHandOfCardsTextures[i])){
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
			}
			else
			{
				Debug.Log("playerCardHand is null");
			}
		}
	}
	
}
