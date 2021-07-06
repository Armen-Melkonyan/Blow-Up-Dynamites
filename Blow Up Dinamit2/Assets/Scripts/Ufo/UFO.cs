using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFO : MonoBehaviour {
	//Classes
	public FadeObject fadeObject;
	public HealthBar healthBar;
	public GameStatus gameStatus;
	public Cabin cabin;

	public int totalParts = 8;//to make 8 bodyPart

	public Rigidbody2D rig;            // Rigidbody of ufo
	public Rigidbody2D prifabSmok;     //To make smoke
	public Rigidbody2D prifabBodyPart; //Make body parts when ufo explod 
	public Rigidbody2D prifabExplosion;//For make an explosion


	public Animator anim;

	public GameObject rocketL, rocketR, rocketUp, rocketDown; 
	public GameObject wave;
	public GameObject ExpKey , Dinamite;
	public GameObject ufoUnderAttack;

	public Image StarImg1, StarImg2, StarImg3 , GameMessagesImg;
	//public Button GameUiBtn;
	public Sprite StarOn , StarOff  , WinSprite , GoverSprite , NextBtn , EmptySp;

	public Image storImage;
	public Sprite imageDefault;

	Source sourse;

	public int life;
	public int star;
	public int speed;
	public int rocetForse;
	public bool buttonUp = false;//To move ufo up
	public bool buttonDown = false;//To move ufo down
	public bool buttonRight = false;//to move ufo right
	public bool buttonLeft = false;//to move ufo left
	public bool buttonWave = false;//To active or deactiv wave

	bool selectButtonOnKeyBoard = true;//To change game control on key board or tach screem

	string[] levelLock;
	int level = 1;



	bool veryBadSmoke = false;
	bool ufoDestroyed = false;
	bool isStore = false;
	float timeCounter = 0;
	string storedObjectName;

	void Avake(){
		sourse = GetComponent<Source> ();
		life = sourse.life;
		star = sourse.star;
		speed = sourse.speed;
		rocetForse = sourse.rocetForse;
		levelLock = new string[sourse.levelCount];
	}
	// Use this for initialization
	void Start () {
		//Initialize helthBar
		healthBar.setMaxHealth(300);

		rig = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		var moveHorizontal = Input.GetAxis ("Horizontal");
		var moveVertical = Input.GetAxis ("Vertical");

		Vector2 moveing = new Vector2 (moveHorizontal *speed , moveVertical * rocetForse);

		if (!ufoDestroyed) {
			if (selectButtonOnKeyBoard && selectButtonOnKeyBoard) {
				rig.AddForce (moveing);//to move and fly ufo
			}


			//turn on UFO wave system
			if (selectButtonOnKeyBoard && (Input.GetKeyDown (KeyCode.Space)) && !isStore) {
				wave.SetActive (true);
			} 
			//Don't turn on UFO wave
			else if (selectButtonOnKeyBoard && (Input.GetKeyDown (KeyCode.Space)) && isStore) {
				Restor ();//Give back the object
			} 
			//Turn off UFO Wave
			else if (selectButtonOnKeyBoard && (Input.GetKeyUp (KeyCode.Space))) {
				wave.SetActive (false);
			}

			//To add force to the UFO by buttons on the screen phone
			//Move UFO to the up
			else if (!selectButtonOnKeyBoard && buttonUp) {
				rig.AddForce (new Vector2(0, rocetForse));
			} 
			//Move UFO to the down
			else if (!selectButtonOnKeyBoard && buttonDown) {
				rig.AddForce (new Vector2(0, -rocetForse));
			}
			//Move UFO to the right
			else if (!selectButtonOnKeyBoard && buttonRight) {
				rig.AddForce (new Vector2(speed, 0));
			}
			//Move UFO to the left
			else if (!selectButtonOnKeyBoard && buttonLeft) {
				rig.AddForce (new Vector2(-speed, 0));
			}
		
			if (!selectButtonOnKeyBoard && buttonWave && !isStore/*&& !isStore*/) {
				wave.SetActive (true);
			}
			else if(!selectButtonOnKeyBoard && buttonWave && isStore/*&& isStore*/){
				Restor ();
			}
			else if (!selectButtonOnKeyBoard && !buttonWave) {
				wave.SetActive (false);
			}

			//Changing game control between keyboard and screen sensor 
			//S: sellect screen 
			//K: select keyboard 
			if (Input.GetKey (KeyCode.S)) {
				selectButtonOnKeyBoard = false;
			} else if (Input.GetKey (KeyCode.K)) {
				selectButtonOnKeyBoard = true;
			}
	
			Rocket ();//
		}


		//else if (!buttonWave) {
			//wave.SetActive (false);
		//}
			
		if (veryBadSmoke) {
			SmocProccess ();
		}
	}

	//To make ufo static when dynamite has explode
	public void UfoStatic(){
		rig.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
	}
	//To make ufo dinamic when 2 second after explosion
	public void UfoDinamic(){
		rig.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
	}

	//When ufo wave capture an object
	public void IsStore(){
		isStore = true;
	}

	//Whene ufo capture the obgect
	public void Store(string s){
		storedObjectName = s;
	}

	//Return the object back
	void Restor(){
		switch (storedObjectName) {
		case "ExpKey":
			ExpKey.SetActive (true);
			ExpKey.transform.position = wave.transform.position;
			break;
		case "Dinamit":
			Dinamite.SetActive (true);
			Dinamite.transform.position = wave.transform.position;
			break;
		default:
			break;
		}
		isStore = false;
		storImage.GetComponent<Image> ().sprite = imageDefault;
	}

	//UI buttons for moving ufo 
	//UI button move up
	public void UpButtonDown(){
		buttonUp = !buttonUp;
	}
	public void UpButtonUP(){
		buttonUp = !buttonUp;
	}

	//UI button move down
	public void DownButtonDown(){
		buttonDown = !buttonDown;
	}
	public void DownButtonUp(){
		buttonDown = !buttonDown;
	}

	//UI button moveright
	public void RightButtonDown(){
		buttonRight = !buttonRight;
	}
	public void RightButtonUp(){
		buttonRight = !buttonRight;
	}

	//UI button move left
	public void LeftButtonDown(){
		buttonLeft = !buttonLeft;
	}
	public void LeftButtonUp(){
		buttonLeft = !buttonLeft;
	}


	//UI button wave
	public void WaveButtonDown(){
		buttonWave = true;
	}
	public void WaveButtonUp(){
		buttonWave = false;
	}

	//turn on roket's motor
	private void Rocket(){
		if (Input.GetKeyDown ("right") || (!selectButtonOnKeyBoard && buttonRight)) {
			rocketR.SetActive (true);
		}
		else if (Input.GetKeyUp ("right") || (!selectButtonOnKeyBoard && !buttonRight)) {
			rocketR.SetActive (false);
		}

		if (Input.GetKeyDown ("left") || (!selectButtonOnKeyBoard && buttonLeft)) {	
			rocketL.SetActive (true);
		}
		else if (Input.GetKeyUp ("left") || (!selectButtonOnKeyBoard && !buttonLeft)) {
			rocketL.SetActive (false);
		}			

		if (Input.GetKeyDown ("up") || (!selectButtonOnKeyBoard && buttonUp)) {
			rocketUp.SetActive (true);
		}
		else if (Input.GetKeyUp ("up") || (!selectButtonOnKeyBoard && !buttonUp)) {
			rocketUp.SetActive (false);
		}

		if (Input.GetKeyDown ("down") || (!selectButtonOnKeyBoard && buttonDown)) {
			rocketDown.SetActive (true);
		}
		else if (Input.GetKeyUp ("down") || (!selectButtonOnKeyBoard && !buttonDown)) {
			rocketDown.SetActive (false);
		}
	}

	//Calculate the amount of damage
	void DamageProccess(){
		healthBar.SetHealth (life);
		if (life <= 50) {
			//make animation for ufo
			anim.SetInteger ("damage", 1);
			//Make animation for cabin
			cabin.DamageCabin1 ();
		} 
		if (life  <= 30) {
			//Make animation for ufo
			anim.SetInteger ("damage", 2);
			//Make animation for cabin
			cabin.DamageCabin2 ();
			//Make smoke for ufo
			veryBadSmoke = true;
		} 
		if (life <= 5) {
			ufoDestroyed = true;//To immobilize ufo
			star = 0;
			PlayerPrefs.SetInt ("Stars1", star);
			Invoke ("UfoExplode" , 2);
		}
	}

	//Make a smoke 
	void SmocProccess(){
		var ufoPos = transform;

		Rigidbody2D makeSmok;
		timeCounter += Time.deltaTime; 

		//making smoke in etch 0.2 seconds
		if (timeCounter > .2) {
			makeSmok = Instantiate (prifabSmok, ufoPos.position, Quaternion.identity) as Rigidbody2D;
			timeCounter = 0;
		}
	}

	//When the ufo exploded
	void UfoExplode(){
		gameStatus.GameOver ();

		var t = transform;	//to get ufo position	
		Rigidbody2D makeBodyPart;

		for (int i = 0; i < totalParts; i++) {
			t.TransformPoint (0 ,-100 , 0);
			FadeObject clone = Instantiate (fadeObject, t.position, Quaternion.identity) as FadeObject;
			clone.GetComponent<Rigidbody2D> ().AddForce (new Vector3(0 , 20,0) * Random.Range(-60, 60));
			clone.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * Random.Range(50,400));
		}

		Rigidbody2D _makeExplosion;
		_makeExplosion = Instantiate (prifabExplosion, t.position, Quaternion.identity) as Rigidbody2D;

		Destroy (gameObject);
	}
		
	void OnTriggerEnter2D(Collider2D coll){
		switch (coll.gameObject.tag) {
		case "Ground":
			anim.SetInteger ("ufo" , 0);
			break;
		case "Star":
			star++;
			Debug.Log ("Star " + star  );
			switch (star) {
			case 1:
				StarImg1.GetComponent<Image>().sprite = StarOn;
				break;
			case 2:
				StarImg2.GetComponent<Image>().sprite = StarOn;
				break;
			case 3:
				StarImg3.GetComponent<Image>().sprite = StarOn;
				break;
			default:
				StarImg1.GetComponent<Image>().sprite = StarOff;
				break;
			}
			Destroy (coll.gameObject);
			break;
		case "ExitAndWin":
			level = PlayerPrefs.GetInt ("Level");
			Debug.Log ("Level: " + level);

			PlayerPrefs.SetInt ("Stars" + level, star);//make stars[n]
			PlayerPrefs.SetInt ("Score", life);

			PlayerPrefs.SetInt (("Lock" + (level + 1)) , 1);//lock3 = 1 next level lock opened
			Debug.Log(PlayerPrefs.GetInt("Lock" + (level + 1)));

			//Active UI buttons game control (next, exit, restart)
			gameStatus.Win();

			Destroy (gameObject , 0.5f);
			break;
		case "Boarder":
			star = 0;
			life = 0;
			PlayerPrefs.SetInt ("Stars1", star);
			gameStatus.GameOver ();
			Destroy (gameObject , 1f);
			break;
		case "Bullet":
			//Make a flash when hit by the bullet
			ufoUnderAttack.SetActive (true);

			//Make a smoke on the ufo
			var ufoPos = transform;
			Rigidbody2D makeSmok;
			makeSmok = Instantiate (prifabSmok, ufoPos.position, Quaternion.identity) as Rigidbody2D;

			//Decreased life
			life -= 2;
			DamageProccess ();
			break;
		default:
			break;
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		switch (coll.gameObject.tag) {
		case "Ground":
			anim.SetInteger ("ufo" , 1);
			break;
		case "Bullet":
			ufoUnderAttack.SetActive (false);
			break;
		default:
			break;
		}
	}

	public void OnCollisionEnter2D(Collision2D coll){
		switch (coll.gameObject.tag) {
		case "Spike":
			life -= 2;
			var cabin = GameObject.FindGameObjectWithTag ("Cabin"); 
			DamageProccess ();
			break;
		case "Explosion":
			life = 0;
			DamageProccess ();
			// AudioSource.PlayClipAtPoint(BombSound, transform.position, 1f);
			//GameOver();
			break;
		}
	}
}
