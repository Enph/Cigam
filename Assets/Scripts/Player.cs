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

	public string[] playerDeck;
	public string[] playerCardHand;
	public Texture[] MyHandOfCardsTextures;

	
	void start()
	{

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
		this.playerCardHand = new string[6];
		
		
		gameManager = GameObject.FindObjectsOfType<GameManager>();
	}

	void Update()
	{
		myIsland = GameObject.FindObjectsOfType<Land_Island>();
		currentZoom = new Texture[myIsland.Length];
		for(int i = 0; i < myIsland.Length; i++){
			currentZoom[i] = myIsland[i].currentText;
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
			if(currentZoom[i] != null){
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
		Debug.Log("got here"+playerDeck.Length);
		for(int i=playerDeck.Length-1;i>=playerDeck.Length-8;i--)
		{
			string textureToLoad = "Textures/"+playerDeck[i];
			Debug.Log("FileName: "+textureToLoad);

			MyHandOfCardsTextures[j] = Resources.Load("Textures/" + textureToLoad.ToString()) as Texture; //Give the texturename of the card taken out of the deck
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
				GUI.Box (new Rect(Screen.width * 0.74f, Screen.height * 0.2f + (i+50), Screen.width / 4.0f, Screen.height / 3.0f), MyHandOfCardsTextures[i]);
			}
			else
			{
				Debug.Log("playerCardHand is null");
			}
		}
	}
	
}
