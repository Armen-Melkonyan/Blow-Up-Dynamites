using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveGenerator : MonoBehaviour {

	public Image storImage;
	public Sprite expKey , dinamite;
	public UFO ufo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "ExpKey") {
			storImage.GetComponent<Image> ().sprite = expKey;
		}
		if (coll.gameObject.tag == "Dinamit") {
			storImage.GetComponent<Image> ().sprite = dinamite;
		}

		ufo.Store (coll.gameObject.tag);
	}
}



