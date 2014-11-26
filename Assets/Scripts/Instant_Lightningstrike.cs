using UnityEngine;
using System.Collections;

public class Instant_Lightningstrike : Photon.MonoBehaviour {

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		int targets = 1;
		//Gets all the creature cards on the board
		int thisCardPosition = 0;
		if(show_options==true){
			for(int i = 0;i<gameManager[0].BattleSpawn.Length;i++){
				Debug.Log(gameManager[0].BattleSpawn.Length);
				//check that the spot on the board is in use and its only a creature
				if(gameManager[0].BattleSpawn[i].spawnInUse == true && gameManager[0].BattleSpawn[i].card_name == "Instant_Lightningstrike"){
					thisCardPosition = i;
				}
				if(gameManager[0].BattleSpawn[i].spawnInUse == true && gameManager[0].BattleSpawn[i].card_name.Substring(0,7) != "Instant" && gameManager[0].BattleSpawn[i].card_name.Substring(0,7) != "Sorcery"){
					//Make the button for each legal card target
					if(GUI.Button(new Rect(Screen.width * 0.60f,Screen.height * 0.10f+(targets*50),100,50), gameManager[0].BattleSpawn[i].card_name))
					{
						Debug.Log("Target "+gameManager[0].BattleSpawn[i].card_name);
						//Gets all the creature cards on the board
						//GameObject[] target = GameObject.FindGameObjectsWithTag("Creature");
						for(int j = 0;j<target.Length;j++){
							//Cast the all as type I_creature so we can access its variables
							I_Creature temp = target[j].GetComponent(typeof(I_Creature)) as I_Creature;
							//Make sure its the name of the creature you clicked on
							if(temp.getName() == gameManager[0].BattleSpawn[i].card_name){
								//Does it die or Naw
								if(temp.getToughness() <= 3){
									//remove target and alightning strike from board
									Debug.Log("Kills "+gameManager[0].BattleSpawn[i].card_name);
									Debug.Log(gameManager[0].BattleSpawn[i].card_name + " Toughtness = " + temp.getToughness());
									gameManager[0].BattleSpawn[i].spawnInUse = false;
									gameManager[0].BattleSpawn[i].card_name = "";
									gameManager[0].BattleSpawn[thisCardPosition].spawnInUse = false;
									gameManager[0].BattleSpawn[thisCardPosition].card_name = "";
									PhotonView pv = target[j].GetComponent<PhotonView>();
									if(pv==null){
										Debug.Log("Problem its empty");
									}
									else{
										target[j].GetComponent<PhotonView>().RPC("Die",PhotonTargets.All,null);
										this.GetComponent<PhotonView>().RPC("Die",PhotonTargets.All,null);
									}
									//temp.Die();
									//this.Die();
								}
								else{
									//remove lightning strike
									Debug.Log("Survives "+gameManager[0].BattleSpawn[i].card_name);
									gameManager[0].BattleSpawn[thisCardPosition].spawnInUse = false;
									gameManager[0].BattleSpawn[thisCardPosition].card_name = "";
									this.Die();
								}
							}
						}
					}
					targets++;
				}
			}
			if(GUI.Button(new Rect(Screen.width * 0.60f,Screen.height * 0.10f,100,50), "Opponent"))
			{
				Debug.Log("Target Player");
				//damage player
				gameManager[0].BattleSpawn[thisCardPosition].spawnInUse = false;
				gameManager[0].BattleSpawn[thisCardPosition].card_name = "";
				this.Die();
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
	[RPC]
	public void Die(){
		Destroy(gameObject);
	}
}
