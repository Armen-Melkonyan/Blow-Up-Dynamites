using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour {
	
	public Rigidbody2D rig;
	public int force = 100;
	public UFO ufo;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnTriggerEnter2D(Collider2D coll){
		
		if (coll.gameObject.tag == "Wave") {
			rig.AddForce (new Vector2 (0, force));
		} 

		if (coll.gameObject.tag == "WaveGenerator") {
			gameObject.SetActive (false);
			ufo.IsStore ();
		}
	}
}
