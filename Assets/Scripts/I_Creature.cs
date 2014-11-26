using UnityEngine;
using System.Collections;

public interface I_Creature{

	string getName();
	int getPower();
	int getToughness();
	int getCMC();
	int getNoColorMana();
	int getRedMana();
	int getGreenMana();
	int getBlueMana();
	int getBlackMana();
	int getWhiteMana();
	bool isSummoningSickness();
	bool isFlying();
	bool isIntimidate();
	bool isHaste();
	bool isLifelink();
	bool isVigilance();
	void Die();
	
}
