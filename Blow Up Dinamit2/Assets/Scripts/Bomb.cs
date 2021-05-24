using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public Rigidbody2D prifabBombExp;
	public GameObject Dinamite;
	public GameObject Mine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void MakeExplosion(){
		if (Dinamite.activeSelf) {
			var t = transform;
			Rigidbody2D makeExplosion = Instantiate (prifabBombExp, t.position, Quaternion.identity) as Rigidbody2D;
			gameObject.SetActive (false);
			Destroy (gameObject , 2f);
		} 

	}

	public void OnCollisionEnter2D(Collision2D coll){
		if ((coll.gameObject.tag == "UFO" || coll.gameObject.tag == "Landing") && gameObject.tag == "Bomb") {
			MakeExplosion ();
		}

	}

		
}
