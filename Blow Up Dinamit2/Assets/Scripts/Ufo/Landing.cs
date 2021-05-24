using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour {

	public GameObject ground;
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Ground") {
			anim.SetInteger ("pin" , 1);
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag == "Ground") {
			anim.SetInteger ("pin" , 2);
			Invoke ("ReturnToIdle" , 1f);
		}
	}

	void ReturnToIdle(){
		anim.SetInteger ("pin" , 3);
	}


}
