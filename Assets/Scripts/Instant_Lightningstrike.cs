using UnityEngine;
using System.Collections;

public class Instant_Lightningstrike : Photon.MonoBehaviour,I_Instant {

	public GameManager[] gameManager;
	public Player[] player;
	public GameObject[] target;

	public int cardNum;
	public string cardName;	
	public Texture front;
	public Texture background;
	public Texture tapped;
	public Texture currentText;
	public int no_color_mana = 1;
	public int white_mana = 0;
	public int red_mana = 1;
	public int black_mana = 0;
	public int blue_mana = 0;
	public int green_mana = 0;

	public int caster;

	public bool show_options = true;
	
	public int state = 0;
	string tag;
	
	
	Vector3 axis = new Vector3(0f,1f,0f);
	
	
	
	// Use this for initialization
	void Start () {
		tag = "untap";
		this.gameManager = GameObject.FindObjectsOfType<GameManager>();
		this.player = Player.FindObjectsOfType<Player>();
		this.cardName = "Instant_Lightningstrike";
		this.target = GameObject.FindGameObjectsWithTag("Creature");
		//this.caster = -1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		//used to print the postion of the buttons
		int targets = 1;
		//used to find the postion of this card on board, the for loop finds the postion
		int thisCardPosition = 0;
		for(int i = 0;i<gameManager[0].BattleSpawn.Length;i++){
			if(gameManager[0].BattleSpawn[i].spawnInUse == true && gameManager[0].BattleSpawn[i].card_name == "Instant_Lightningstrike"){
				thisCardPosition = i;
			}
		}
		//if youa re the one that cast the card display buttons with options
		if(show_options==true && caster==player[0].teamId){
			//for every spot in battle spawn
			for(int i = 0;i<gameManager[0].BattleSpawn.Length;i++){
				//check that the spot on the board is in use and its only a creature
				if(gameManager[0].BattleSpawn[i].spawnInUse == true && gameManager[0].BattleSpawn[i].card_name.Substring(0,7) != "Instant" && gameManager[0].BattleSpawn[i].card_name.Substring(0,7) != "Sorcery"){
					//Make the button for each legal card target
					if(GUI.Button(new Rect(Screen.width * 0.60f,Screen.height * 0.10f+(targets*50),100,50), gameManager[0].BattleSpawn[i].card_name))
					{
						//for every object that has a tag creature
						for(int j = 0;j<target.Length;j++){
							//Cast all the target objects as type I_creature so we can access its variables
							I_Creature temp = target[j].GetComponent(typeof(I_Creature)) as I_Creature;
							//Make sure its the name of the creature you want to kill
							if(temp.getName() == gameManager[0].BattleSpawn[i].card_name){
								//Does it die or Naw
								if(temp.getToughness() <= 3){
									//Set the battlespawn positions to not in use and name to blank so a new card can be placed
									gameManager[0].BattleSpawn[i].spawnInUse = false;
									gameManager[0].BattleSpawn[i].card_name = "";
									gameManager[0].BattleSpawn[thisCardPosition].spawnInUse = false;
									gameManager[0].BattleSpawn[thisCardPosition].card_name = "";
									//remove target and lightning strike from board from both players screens
									PhotonView pv = target[j].GetComponent<PhotonView>();
									if(pv==null){
										Debug.Log("Problem its empty");
									}
									else{
										target[j].GetComponent<PhotonView>().RPC("Die",PhotonTargets.All,null);
										this.GetComponent<PhotonView>().RPC("Die",PhotonTargets.All,null);
									}
								}
								else{
									//remove only lightning strike since creature survived
									gameManager[0].BattleSpawn[thisCardPosition].spawnInUse = false;
									gameManager[0].BattleSpawn[thisCardPosition].card_name = "";
									this.GetComponent<PhotonView>().RPC("Die",PhotonTargets.All,null);
								}
							}
						}
					}
					//increment target after creating a button for a legal target
					targets++;
				}
			}
			//Create a button to damage the opponent instead of a creature
			if(GUI.Button(new Rect(Screen.width * 0.60f,Screen.height * 0.10f,100,50), "Opponent"))
			{
				//remove lightning strike from the board
				gameManager[0].BattleSpawn[thisCardPosition].spawnInUse = false;
				gameManager[0].BattleSpawn[thisCardPosition].card_name = "";
				this.GetComponent<PhotonView>().RPC("Die",PhotonTargets.All,null);
				//damage opponent
				//player[0].TakeDamage(3);
				PhotonView pv = player[0].GetComponent<PhotonView>();
				if(pv == null)
					Debug.Log("Take Damage pv error");
				else
				{
					//Both functions below must be called to deal damage to an opponent
					player[0].GetComponent<PhotonView>().RPC("TakeDamage",PhotonTargets.Others,3 );
					player[0].TakeOpponentsDamageLocal(3);
				}
			}
		}
	}
		
	public void showBack(){
		renderer.enabled = true;
		renderer.material.mainTexture = background;
	}
	
	public void showFront(){
		renderer.enabled = true;
		renderer.material.mainTexture = front;
	}
	
	public void hideCard(){
		renderer.enabled = false;
	}
	
	public void tapCard(){
		renderer.enabled = true;
		this.transform.RotateAround(transform.position,axis, 90);
	}
	
	public void untapCard(){
		renderer.enabled = true;
		this.transform.RotateAround(transform.position,axis, -90);
		
	}
	
	public void setCardName(string name){
		this.cardName=name;
	}
	
	void OnMouseUp(){
		
		switch(state){
		case 0:
			tapCard ();
			state = 1;
			break;
		case 1:	
			untapCard ();
			state = 0;
			break;
		}
		
	}
	
	void OnMouseOver(){
		currentText = renderer.material.mainTexture;
		Debug.Log ("I am selected");
	}
	
	void OnMouseExit(){
		currentText = null;
	}
	
	public int getPlayer(){
		return caster;
	}
	public void setPlayer(int whocast){
		this.caster = whocast;
	}
	
	[RPC]
	public void Die(){
		Destroy(gameObject);
	}
}
