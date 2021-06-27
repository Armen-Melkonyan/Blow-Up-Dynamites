using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour {
	public GameObject UFO;
	public GameObject dynamite;
	public GameObject UFOFalow;
	public GameObject dynamiteFalow;

	public bool cameraOnUfo =true;

	Vector3 vec = new Vector3(0, 0, 0);
	// Update is called once per frame
	void Update () {
		try {
			if(cameraOnUfo){
				transform.position = UFOFalow.transform.position;
				vec = UFOFalow.transform.position;
			}
			else{
				transform.position = dynamiteFalow.transform.position;
				Invoke("RechangeCamerasPos", 2);
			}

		} catch (System.Exception ex) {
			transform.position = vec;
		}
	}

	void RechangeCamerasPos(){
		cameraOnUfo = true;
	}

	public void ChangeCamerasPos(){
		cameraOnUfo = false;
	}


}
