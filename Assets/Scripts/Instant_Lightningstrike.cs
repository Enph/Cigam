using UnityEngine;
using System.Collections;

public class Instant_Lightningstrike : MonoBehaviour {

	public GameManager[] gameManager;
	public Player[] player;

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		float position = 0;
		int targets = 1;
		if(show_options==true){
			if(GUI.Button(new Rect(Screen.width * 0.60f,Screen.height * 0.10f,100,50), "Opponent"))
			{
				Debug.Log("Target Player");
			}
			for(int i = 0;i<gameManager[0].BattleSpawn.Length;i++){
				if(gameManager[0].BattleSpawn[i].spawnInUse == true && gameManager[0].BattleSpawn[i].card_name.Substring(0,7) != "Instant" && gameManager[0].BattleSpawn[i].card_name.Substring(0,7) != "Sorcery"){
					if(GUI.Button(new Rect(Screen.width * 0.60f,Screen.height * 0.10f+(targets*50),100,50), gameManager[0].BattleSpawn[i].card_name))
					{
						Debug.Log("Target "+gameManager[0].BattleSpawn[i].card_name);	
					}
					targets++;
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
}
