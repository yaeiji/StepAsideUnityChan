using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	private GameObject mainCamObj;

	// Use this for initialization
	void Start () {
		
		mainCamObj = Camera.main.gameObject;
		//回転する角度を設定
		this.transform.Rotate(0,Random.Range(0,360),0);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0, 3, 0);

		if (mainCamObj.transform.position.z > this.transform.position.z) {
			Destroy (this.gameObject);
		}
		
	}
}
