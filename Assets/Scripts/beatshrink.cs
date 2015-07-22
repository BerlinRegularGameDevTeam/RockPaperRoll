using UnityEngine;
using System.Collections;

public class beatshrink : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.localScale -= new Vector3(0.005F,0.005F,0.005F);

		if(transform.localScale.x<0){Destroy(gameObject);}

	}
}
