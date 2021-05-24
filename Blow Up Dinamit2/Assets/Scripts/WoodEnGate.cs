using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodEnGate : MonoBehaviour {

	public Rigidbody2D prifabGateExplode;
	public Rigidbody2D prifabWoodenPart;
	int totalParts = 6;
	public FadeObject fadeObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Explosion") {
			var t = transform;
			Rigidbody2D makeGateExplod = Instantiate (prifabGateExplode, t.position, Quaternion.identity) as Rigidbody2D;
			Destroy (gameObject);

			//Rigidbody2D makeWoodenPart = Instantiate (prifabWoodenPart, t.position, Quaternion.identity) as Rigidbody2D;

			for (int i = 0; i < totalParts; i++) {
				t.TransformPoint (0 ,-100 , 0);
				FadeObject clone = Instantiate (fadeObject, t.position, Quaternion.identity) as FadeObject;
				clone.GetComponent<Rigidbody2D> ().AddForce (new Vector3(0 , 20,0) * Random.Range(-60, 60));
				clone.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * Random.Range(50,400));
			}

		}
	}
}
