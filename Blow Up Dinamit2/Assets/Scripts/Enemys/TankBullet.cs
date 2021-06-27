using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour {

	public Source source;
	public GameObject Ufo , Gun;

	public Rigidbody2D bullet;

	public Rigidbody2D prifabSequence;

	public bool fire = false;
	float timeCounter = 0;

	public Vector2 maxVelocity = new Vector2(0.5f , 0.5f);
	float speed;

	Vector3 offSet;

	// Use this for initialization
	void Start () {
		bullet = GetComponent<Rigidbody2D> ();
		speed = source.bulletSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		var absVelX = Mathf.Abs (bullet.velocity.x);
		var absVelY = Mathf.Abs (bullet.velocity.y);

		if (absVelX < maxVelocity.x || absVelX < maxVelocity.y)
		{
			//FireSound.Play();
			try {
				bullet.AddForce(new Vector2((Ufo.transform.position.x - Gun.transform.position.x) * speed , (Ufo.transform.position.y - Gun.transform.position.y) * speed));
			} catch (System.Exception ex) {
				Debug.Log ("UFO destroyed");
			}

		}
		//Make a trail of fire for bullets
		SequenceProccess ();
	}

	//void OnTriggerEnter2D(Collider2D coll){
	//	if (coll.gameObject.tag == "UFO") {
	//		Destroy (gameObject);
	//	}
	//}

	void SequenceProccess(){
		var ufoPos = transform;

		Rigidbody2D sequence;
		timeCounter += Time.deltaTime; 

		//making smoke in etch 0.2 seconds
		if (timeCounter > .01) {
			sequence = Instantiate (prifabSequence, ufoPos.position, Quaternion.identity) as Rigidbody2D;
			timeCounter = 0;
		}
	}

	//void OnTriggerExit2D(Collider2D coll){
	//	if (coll.gameObject.tag == "BackGround") {

	//		var gunPos = transform;
	//		//Vector3 gunPos = Gun.transform.position;

	//		Rigidbody2D bull;
	//		//	makeSmok = Instantiate (prifabSmok, ufoPos.position, Quaternion.identity) as Rigidbody2D;
	//		Destroy (gameObject);
	//		bull = Instantiate (bullet, gunPos.position, Quaternion.identity) as Rigidbody2D;


	//	}
	//}
}
