using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFO : MonoBehaviour {
	//Classes
	public FadeObject fadeObject;
	public HealthBar healthBar;
	public GameStatus gameStatus;

	public int totalParts = 8;//to make 8 bodyPart

	public Rigidbody2D rig;
	public Rigidbody2D prifabSmok;
	public Rigidbody2D prifabBodyPart;
	public Rigidbody2D prifabExplosion;

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
			rig.AddForce (moveing);//to move and fly ufo
			Rocket ();//
		}

		//turn on UFO wave system
		if (Input.GetKeyDown(KeyCode.Space) && !isStore) {
			wave.SetActive (true);
		}else if (Input.GetKeyDown(KeyCode.Space) && isStore) {
			Restor ();
		}
		else if (Input.GetKeyUp(KeyCode.Space)) {
			wave.SetActive (false);
		}
			
		if (veryBadSmoke) {
			SmocProccess ();
		}
	}

	//When ufo wave capture an object
	public void IsStore(){
		isStore = true;
	}

	public void Store(string s){
		storedObjectName = s;
	}

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

	private void Rocket(){
		
		if (Input.GetKeyDown ("right")) {
			rocketR.SetActive (true);
		}
		else if (Input.GetKeyUp ("right")) {
			rocketR.SetActive (false);
		}

		if (Input.GetKeyDown ("left")) {	
			rocketL.SetActive (true);
		}
		else if (Input.GetKeyUp ("left")) {
			rocketL.SetActive (false);
		}			

		if (Input.GetKeyDown ("up")) {
			rocketUp.SetActive (true);
		}
		else if (Input.GetKeyUp ("up")) {
			rocketUp.SetActive (false);
		}

		if (Input.GetKeyDown ("down")) {
			rocketDown.SetActive (true);
		}
		else if (Input.GetKeyUp ("down")) {
			rocketDown.SetActive (false);
		}
	}

	void DamageProccess(){
		healthBar.SetHealth (life);
		if (life <= 50) {
			anim.SetInteger ("damage", 1);
		} 
		if (life  <= 30) {
			anim.SetInteger ("damage", 2);
			veryBadSmoke = true;
		} 
		if (life <= 5) {
			ufoDestroyed = true;//To immobilize ufo
			star = 0;
			PlayerPrefs.SetInt ("Stars1", star);
			Invoke ("UfoExplode" , 2);
		}
	}

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

	void UfoExplode(){
		gameStatus.GameOver ();

		var t = transform;		
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

			PlayerPrefs.SetInt ("Stars" + level, star);//make stars'n'
			PlayerPrefs.SetInt ("Score", life);

			PlayerPrefs.SetInt (("Lock" + (level + 1)) , 1);//lock3 = 1 next lock opened
			Debug.Log(PlayerPrefs.GetInt("Lock" + (level + 1)));

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
		case "Tank":
			//GameOver();
			break;
		}
	}
}
