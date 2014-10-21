using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public string currentMenu;
	private Options options;
	private MainMenu mainMenu;

	// Use this for initialization
	void Start () {
	
		this.currentMenu = "MainMenuGUI";
		this.options = new Options();
		this.mainMenu = new MainMenu();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI()
	{
		if(this.currentMenu == "MainMenuGUI")
		{
			mainMenu.MainMenuGUI();
		}
		else if(this.currentMenu == "OptionsGUI")
		{
			options.OptionsGUI();
		}


	}
	public string getCurrentMenu()
	{
		return currentMenu;
	}

}
