using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPage : MonoBehaviour {

	public void Play(){
		Application.LoadLevel ("Levels");
	}

	public void ResetGame (){
		for (int i = 1; i < 4; i++) {
			PlayerPrefs.SetInt ("Lock" + i , 0 );
		}

		for (int i = 0; i < 4; i++) {
			PlayerPrefs.SetInt ("Stars" + i , 0 );
		}

		for (int i = 1; i < 4; i++) {
			Debug.Log (PlayerPrefs.GetInt("Lock") + "\t" + PlayerPrefs.GetInt("Stars") );
			Debug.Log ("GAME RESTARTED ");
		}
	}

	public void Help(){
	}

	public void Exit(){
		Application.Quit();
	}
}
