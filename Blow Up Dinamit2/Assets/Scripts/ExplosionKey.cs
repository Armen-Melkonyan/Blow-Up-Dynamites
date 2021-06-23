using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionKey : MonoBehaviour {

	public Animator anim;
	public Bomb bomb;
	public GameStatus gameStatus;
	public GameObject ufo;
	public bool testIfItHide = true;
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
			anim.SetBool ("expKey" , true);//Move down handel of explosion key
		
			if(testIfItHide){
				ufo.SetActive(false);
			    StartCoroutine (ReturnUfo(2));//make 2 seconds delay to return ufo
			}

			bomb.KeyPressed ();

		}
	}

	IEnumerator ReturnUfo(float t){
		yield return new WaitForSeconds (t);
		testIfItHide = false;
		ufo.SetActive (true);
	}
		
}
