using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public Rigidbody2D prifabBombExp;
	public GameObject dinamite;
	public GameObject mine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void KeyPressed(){
		try {
			if (dinamite.activeSelf) {
				MakeExplosion();
			} 
		} catch (System.Exception ex) {
				
		}
	}


	void MakeExplosion(){
		var t = transform;
		Rigidbody2D makeExplosion = Instantiate (prifabBombExp, t.position, Quaternion.identity) as Rigidbody2D;
		gameObject.SetActive (false);
		Destroy (gameObject , 2f);
	}

	public void OnCollisionEnter2D(Collision2D coll){
		if ((coll.gameObject.tag == "UFO" || coll.gameObject.tag == "Landing") && gameObject.tag == "Bomb") {
			MakeExplosion ();
		}

	}

		
}
