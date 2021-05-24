using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionKey : MonoBehaviour {

	public Animator anim;
	public Bomb bomb;
	Rigidbody2D rig;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void  OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "UFO") {
			anim.SetBool ("expKey" , true);

			bomb.MakeExplosion ();
		}

		
	}
}
