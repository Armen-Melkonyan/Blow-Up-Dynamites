using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabin : MonoBehaviour {

	public Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	public void DamageCabin1(){
		anim.SetInteger ("cabin", 1);
	}

	public void DamageCabin2(){
		anim.SetInteger ("cabin", 1);
	}



}
