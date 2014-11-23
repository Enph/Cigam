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
	

	public string[] playerDeck;
	public string[] playerCardHand;
	public Texture[] MyHandOfCardsTextures;
	public Texture[] currentZoom;

	
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
		this.playerCardHand = new string[7];
		this.MyHandOfCardsTextures = new Texture[60];
		this.handZoom = new Texture[7];
		
		gameManager = GameObject.FindObjectsOfType<GameManager>();
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
		displayCardsInHand ();

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
				GUILayout.BeginArea(new Rect(Screen.width * 0.025f+(i*100),Screen.height * 0.75f,100,120));
				GUILayout.Button(new GUIContent(MyHandOfCardsTextures[i], "MouseOverHand"));
				if (Event.current.type == EventType.Repaint && GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition)) {
					handZoom[i] = MyHandOfCardsTextures[i];
					//lastTooltip = GUI.tooltip;
				}
				else handZoom[i] = null;
				GUILayout.EndArea();
			}
		}
		
		
		
	}

}
