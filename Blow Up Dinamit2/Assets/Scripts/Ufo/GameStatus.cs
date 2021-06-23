using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

	public GameObject ufo, dynamite;
	public Image GameMessagesImg;
	public Button exitBtn , nextBtn;
	public Sprite winSprite , gameOverSprite , nextButton , exitButton;

	//To change Cameras position on dynamite
	//public void CameraOnBomb(){
		//ufo.SetActive (false);
		//dynamite.SetActive (true);
		//Debug.Log ("Camera on bomb! ");
	//}

	// Use this for initialization
	public void Win(){
		GameMessagesImg.enabled = true;
		GameMessagesImg.GetComponent<Image> ().sprite = winSprite;
	
		nextBtn.gameObject.SetActive(true);
		exitBtn.gameObject.SetActive (true);
	}

	public void GameOver(){
		GameMessagesImg.enabled = true;
		GameMessagesImg.GetComponent<Image> ().sprite = gameOverSprite;

		exitBtn.gameObject.SetActive (true);
	}
}
