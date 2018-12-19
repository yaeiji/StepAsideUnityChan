using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeController : MonoBehaviour {

	GameObject mainCamObj;

	// Use this for initialization
	void Start () {
		mainCamObj = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (mainCamObj.transform.position.z > this.transform.position.z) {
			Destroy (this.gameObject);
		}
	}
}
