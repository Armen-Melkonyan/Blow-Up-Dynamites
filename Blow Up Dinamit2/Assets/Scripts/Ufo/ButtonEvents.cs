using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour {

	public void Next (){
		Application.LoadLevel ("Levels");
	}

	public void LevelPage (){
		Application.LoadLevel ("Levels");
	}

	public void UI_Page (){
		Application.LoadLevel ("GameUI");
	}
		
	public void Exit (){
		Debug.Log ("Exit");
	}
}
