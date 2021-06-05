using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFalow : MonoBehaviour {

	public GameObject player;
	Vector3 vec = new Vector3(0, 0, 0);
	// Update is called once per frame
	void Update () {
		try {
			transform.position = player.transform.position;
			vec = player.transform.position;
		} catch (System.Exception ex) {
			transform.position = vec;
		}


	}
}
