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
			bullet.AddForce(new Vector2((Ufo.transform.position.x - Gun.transform.position.x) * speed , (Ufo.transform.position.y - Gun.transform.position.y) * speed));
		}

		SequenceProccess ();
	}

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
}
