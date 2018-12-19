using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {

	//アニメーションするためのコンポーネントを入れる
	private Animator myAnimator;
	//Unityちゃんを移動させるコンポーネントを入れる(追加)
	private Rigidbody myRigidbody;
	//全身するための力
	private float forwardForce =800.0f;
	//左右に移動するための力
	private float turnForce=500.0f;
	//左右に移動できる範囲
	private float movableRange=3.4f;
	//ジャンプするための力
	private float upForce=500.0f;

	//動きを原則させる係数
	private float coefficient=0.95f;

	//geam終了の判定
	private bool isEnd=false;

	//ゲーム終了時に表示するテキスト
	private GameObject stateText;

	//スコアを表示させるテキスト
	private GameObject scoreText;

	private int score;

	//左ボタン押の判定
	private bool isLButtonDown=false;
	//右ボタン押の判定
	private bool isRButtonDown=false;

	// Use this for initialization
	void Start () {

		//Animatorコンポーネントを取得
		this.myAnimator=GetComponent<Animator>();

		//走るアニメーションの追加
		this.myAnimator.SetFloat("Speed",1);

		//Rigidbodyコンポーネントを取得
		this.myRigidbody = GetComponent<Rigidbody>();

		//シーン中のstateTerxオブを取得
		this.stateText=GameObject.Find("GameResultText");

		//シーン中のscoreTextオブを取得	
		this.scoreText=GameObject.Find("ScoreText");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (this.isEnd) {
			this.forwardForce *= this.coefficient;
			this.turnForce *= this.coefficient;
			this.upForce *= this.coefficient;
			this.myAnimator.speed *= this.coefficient;
		}
		//Unityちゃんに前方向の力を加える
		this.myRigidbody.AddForce(this.transform.forward*this.forwardForce);

		//Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる
		if((Input.GetKey ( KeyCode.LeftArrow )||this.isLButtonDown)&& -this.movableRange<this.transform.position.x){
			//左に移動
			this.myRigidbody.AddForce(-this.turnForce,0,0);
		}else if((Input.GetKey(KeyCode.RightArrow)||this.isRButtonDown)&&this.movableRange>this.transform.position.x){
			//右に移動
			this.myRigidbody.AddForce(turnForce,0,0);
		}

		//ジャンプしていないときにスペースが押された時にジャンプする
		if(Input.GetKeyDown(KeyCode.Space)&&this.transform.position.y<0.5f){
			//ジャンプアニメーションを再生
			this.myAnimator.SetBool("Jump",true);
			//Unityちゃんに上方向の力を加える
			this.myRigidbody.AddForce(this.transform.up*this.upForce);
		}

		//ジャンプステートの場合はjumpにfalseをセットする
		if(this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump")){
			this.myAnimator.SetBool ("Jump", false);
		}
	}

	//鳥がーモードで他のオブジェクトと接触した場合処理
	void OnTriggerEnter(Collider other ){

		//障害物に衝突した場合
		if(other.gameObject.tag=="CarTag"|| other.gameObject.tag=="TrafficConeTag"){
			this.isEnd = true;
			//stateTextにGAMEOverを表示
			this.stateText.GetComponent<Text>().text="GAMEOVER";
		}

		//ゴール地点に到達した場合
		if(other.gameObject.tag=="GoalTag"){
			this.isEnd = true;
			this.stateText.GetComponent<Text>().text="CLRAR!!";
		}

		//コインに衝突した場合
		if(other.gameObject.tag=="CoinTag"){

			//スコア加算
			this.score+=10;

			this.scoreText.GetComponent<Text>().text="Score"+this.score+"pt";

			//パーティクルを再生
			GetComponent<ParticleSystem>().Play();

			//接触したコインのオブを吐き
			Destroy(other.gameObject);
		}
	}

	//ジャンプボタンを押した梅の処理
	public void GetMyJumpButtonDown(){
		if (this.transform.position.y < 0.5f) {
			this.myAnimator.SetBool ("Jump", true);
			this.myRigidbody.AddForce (this.transform.up * this.upForce);
		}
	}
	//左ボタンを押し続けた場合の処理
	public void GetMyLeftButtonDown(){
		this.isLButtonDown = true;
	}
	//左ボタンを離した場合の処理
	public void GetMyLeftButtonUp(){
		this.isLButtonDown = false;
	}

	//右ボタンを押し続けた場合の処理
	public void GetMyRightButtonDown(){
		this.isRButtonDown = true;
	}
	//右ボタンを離した時の処理
	public void GetMyRigthButtonUp(){
		this.isRButtonDown = false;
	}
}
