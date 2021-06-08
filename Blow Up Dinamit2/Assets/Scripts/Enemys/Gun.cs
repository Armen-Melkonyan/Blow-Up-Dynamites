using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public Transform Ufo;
	private Rigidbody2D rig;
	public Rigidbody2D prifabBullet;
	public bool fire = false;
	float fireTime = 0;
	//public GameObject Bullet;
	float r = 0; //Tank Distance

	// Use this for initialization
	void Start () {
		rig = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		try {
			Vector3 direction = Ufo.position - transform.position;
			float angle = Mathf.Atan2 (direction.y , direction.x) * Mathf.Rad2Deg;
			rig.rotation = angle;
		} catch (System.Exception ex) {
			Debug.Log ("UFO destroyed");
		}

		//A bullet is fired whenever the ufo is approached
		DistanceProssecc ();

		if (r <= 15) {
			var ufoPos = transform;
			Rigidbody2D fire;

			fireTime += Time.deltaTime;

			if (fireTime > 10) {
				fire = Instantiate (prifabBullet, ufoPos.position, Quaternion.identity) as Rigidbody2D;
				fireTime = 0;
			}
		}
	}

	void DistanceProssecc (){
		try {
			var x = Ufo.transform.position.x - transform.position.x;
			var y = Ufo.transform.position.y - transform.position.y;
			x = Mathf.Pow (x, 2);
			y = Mathf.Pow (y, 2);

			r = Mathf.Sqrt (x + y);
		} catch (System.Exception ex) {
			Debug.Log ("UFO destroyed");
		}



	}
}
