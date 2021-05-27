using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagment : MonoBehaviour {

	public Image[] star1Image;
	public Image[] star2Image;
	public Image[] star3Image;

	public Button[] buttonImage;

	public int[] levelLock;

	private Source source;

	public Sprite StarOn , StarOfft , ButtonOpen , ButtonClose;

	int level;

	void Avake(){
		source = GetComponent<Source> ();

		int l = source.levelCount;
		Debug.Log ("level: " + l);
		star1Image = new Image[l];
		star2Image = new Image[l];
		star3Image = new Image[l];

		buttonImage = new Button[source.levelCount];



	}

	void Start(){
		levelLock = new int[4];

		for (int i = 1; i < levelLock.Length; i++) {
			levelLock[i]=PlayerPrefs.GetInt ("Lock" + (i + 1));

			if (levelLock[i] == 1) {
				buttonImage [i].image.overrideSprite = ButtonOpen;
			} else if(levelLock[i] == 0){
				buttonImage [i].image.overrideSprite = ButtonClose;
			}
		}
	



		print (levelLock[1]);

		Level ();
	}

	public void Leve1Btn() {

		Application.LoadLevel("Level01");
		PlayerPrefs.SetInt ("Level" , 1);

	}

	public void Leve2Btn() {
		if (levelLock[1] == 1) {//if level lock is open
			Application.LoadLevel("Level02");
			PlayerPrefs.SetInt ("Level" , 2);
		}

	}


	public void Leve3Btn() {
		if (levelLock[2] == 1) {//if level lock is open
			Application.LoadLevel("Level03");
			PlayerPrefs.SetInt ("Level" , 3);
		}

	}

	public void Leve4Btn() {
		if (levelLock[3] == 1) {
			Application.LoadLevel("Level04");
			PlayerPrefs.SetInt ("Level" , 4);
		}

	}


	void Level(){
		int[] star = new int[4];

		//int l = PlayerPrefs.GetInt ("Level");

		for (int i = 0; i < 4; i++) {

			star[i] = PlayerPrefs.GetInt ("Stars" +( i + 1)); //star{1, 2, 3, 4} each star is between 1 to 3
			//Debug.Log("Stars" + i + 1);

		}


		for (int i = 0; i < 4; i++) {

			switch (star[i]) {
			case 1:
				star1Image[i].GetComponent<Image> ().sprite = StarOn;

				break;
			case 2:
				star1Image[i].GetComponent<Image> ().sprite = StarOn;
				star2Image[i].GetComponent<Image> ().sprite = StarOn;
				break;
			case 3:
				star1Image[i].GetComponent<Image> ().sprite = StarOn;
				star2Image[i].GetComponent<Image> ().sprite = StarOn;
				star3Image[i].GetComponent<Image> ().sprite = StarOn;
				break;
			default:
				break;
			}
		}

	}
}
