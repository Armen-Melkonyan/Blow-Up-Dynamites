using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour {
	public GameObject UFO;
	public GameObject dynamite;
	public GameObject UFOFalow;
	public GameObject dynamiteFalow;
	Vector3 vec = new Vector3(0, 0, 0);
	// Update is called once per frame
	void Update () {
		try {
			if(UFO.activeSelf){
				transform.position = UFOFalow.transform.position;
				vec = UFOFalow.transform.position;
				Debug.Log("Camera on ufo");
			}
			else{
				transform.position = dynamiteFalow.transform.position;
				Debug.Log("Camera on dynamite");
			}

		} catch (System.Exception ex) {
			transform.position = vec;
		}


	}
}
