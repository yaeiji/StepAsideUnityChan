using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {


	//carPrefabを入れる
	public GameObject CarPrefab;
	//coinPrefabを入れる
	public GameObject CoinPrefab;
	//cornPrefabを入れる
	public GameObject ConePrefab;

	private GameObject unitychan;

    GameObject car;
    GameObject coin;
    GameObject cone;

	//スタート地点
	private int startPos=-160;
	//ゴール地点
	private int goalPos=120;
	//アイテムをだす
	private float posRange=3.4f;

	private int i;

	// Use this for initialization
	void Start () {

		unitychan = GameObject.Find ("unitychan");

	    i = startPos;

		//Debug.Log (unitychan.transform.position.z);
	/*
		//一定の距離ごとにアイテムを生成
		for(int i=startPos;i<goalPos; i+=15){
			//どのアイテムをだすのかランダムに設定
			int num =Random.Range(1,11);
			if (num <= 2) {
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
				    cone = Instantiate (ConePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
				}
			} else {
			//アイテムの種類を決める
				for(int j=-1;j<=1;j++){
					//アイテムの種類を決める
					int item =Random.Range(1,11);

					//アイテムを奥z座標のオフセットをランダムにせってい
					int offsetZ=Random.Range(-5,6);

					//60%コイン配置：３０％車はいち：１０％何もなし
					if (1 <= item && item <= 6) {
						//コイン生成
					    coin = Instantiate (CoinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);

					} else if (7 <= item && item <= 9) {
					//車を作成
						car =Instantiate(CarPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y , i + offsetZ);
					}
				}
			}
		}
			


	for (int i = startPos; i <= unitychan.transform.position.z+40 ; i =+15) {
			int num = Random.Range (1, 11);
			Debug.Log (num);
			if (num <= 2) {
				for (float j = 0; j < 1; j += 0.4f) {
					cone = Instantiate (ConePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
				}
			} else {
				for (int j = -1; j < 1; j++) {
					int item = Random.Range (1, 11);
					int offsetZ=Random.Range(-5,6);

					//60%コイン配置：３０％車はいち：１０％何もなし
					if (1 <= item && item <= 6) {
						//コイン生成
						coin = Instantiate (CoinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);

					} else if (7 <= item && item <= 9) {
						//車を作成
						car =Instantiate(CarPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y , i + offsetZ);
					}
				}
			}
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {


		//Debug.Log ((int)unitychan.transform.position.z+50);
		//Debug.Log (i);
		//Debug.Log (goalPos);

		if(  ((unitychan.transform.position.z+50) <= goalPos) && (((int)unitychan.transform.position.z+50) == i) ){
			
			int num =Random.Range(1,11);
			if (num <= 2) {
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					cone = Instantiate (ConePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
				}
			} else {
				//アイテムの種類を決める
				for(int j=-1;j<=1;j++){
					//アイテムの種類を決める
					int item =Random.Range(1,11);

					//アイテムを奥z座標のオフセットをランダムにせってい
					int offsetZ=Random.Range(-5,6);

					//60%コイン配置：３０％車はいち：１０％何もなし
					if (1 <= item && item <= 6) {
						//コイン生成
						coin = Instantiate (CoinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);

					} else if (7 <= item && item <= 9) {
						//車を作成
						car =Instantiate(CarPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y , i + offsetZ);
					}
				}
			}
			i += 15;
		}

	}
		


}
