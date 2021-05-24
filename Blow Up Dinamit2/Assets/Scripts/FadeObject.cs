using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour {
	public Rigidbody2D rig;
	private SpriteRenderer sp;
	private Color startColor;
	private Color endColor;
	private float t = 0.0f;
	bool jump = true;
	float waveSize = 0.1f;
	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D> ();
		sp = GetComponent<SpriteRenderer> ();
		startColor = sp.color;
		endColor = new Color (startColor.r , startColor.b , startColor.g , 0.0f);

	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;

		sp.material.color = Color.Lerp (startColor , endColor , t/2);

		if (gameObject.tag == "Smoke") {
			rig.AddForce (new Vector2(0 , 0.0005f) );
		}
			
		if (sp.material.color.a <= 0.0f) {
			Destroy (gameObject);
		}
	}
}
