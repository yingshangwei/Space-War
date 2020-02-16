using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	private float h; //左右移动的量
	private float v; //上下移动的量
	private float NormalV = -0.4f; //玩家正常飞行速度系数
	private float preTime = 0; //记录上一颗子弹发射的时间
	private float BulletInterval = 0.1f; //控制子弹发射的间隔
	public bool IsWing = false; //机翼是否可用
	private GameObject FirePoint, FirePointLeft, FirePointRight; //开火点
	public GameObject Bullet; //子弹预制体
	public static float Lives = 3; //玩家血量
	public static float Score = 0; //玩家分数

	public static int State = 1; //玩家状态 0为暂停 1为正常游戏

	/*玩家可以到达的地图边界*/
	public float PlayerToMapTop = 5.45f;
	public float PlayerToMapBotton = -3.45f;
	public float PlayerToMapLeft = -6.1f;
	public float PlayerToMapRight = 6.1f;

	public float HighScore;

	
	void OnGUI() {
		GUI.Label(new Rect(Screen.width/2-155,Screen.height/2-295, 100, 20), "Lives="+Lives);
		GUI.Label(new Rect(Screen.width/2-155,Screen.height/2-275, 100, 20),"Score="+(int)Score);
		if(Lives<=0) {
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-50,100,100), "Play Again")) {
				Lives = 3;
				Score = 0;
				SceneManager.LoadScene("play");
			}
		}
	}


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene("begin");
		}
		if(Input.GetKeyDown("p") && Lives > 0) State ^= 1;
		if(Lives<=0 || State == 0) return ;
		mMove ();
		mFire ();
		Score += Time.deltaTime*5; //生存得分
	}
	void InitPlayer() {
		Lives = 3;
		Score = 0;
	}
	void mMove() {
		h = Input.GetAxis ("Horizontal");
		h = h != 0 ? (h < 0 ? -1 : 1) : 0;
		transform.Translate (Vector3.right * Time.deltaTime * 5 * h);
		transform.localEulerAngles = new Vector3(0, -30*h, 0);
		if (transform.position.x > PlayerToMapRight)
			transform.position = new Vector3 (PlayerToMapRight, transform.position.y, 0);
		else if (transform.position.x < PlayerToMapLeft)
			transform.position = new Vector3 (PlayerToMapLeft, transform.position.y, 0);

		v = Input.GetAxis ("Vertical");
		v = v != 0 ? (v < 0 ? -1 : 1) : NormalV;
		transform.Translate (Vector3.up * Time.deltaTime * 5 * v);
		if (transform.position.y > PlayerToMapTop)
			transform.position = new Vector3 (transform.position.x, PlayerToMapTop, 0);
		else if (transform.position.y < PlayerToMapBotton)
			transform.position = new Vector3 (transform.position.x, PlayerToMapBotton, 0);
	}

	//射击
	void mFire() {
		if (Input.GetKey (KeyCode.Space) && Time.time-preTime>BulletInterval) {
			preTime = Time.time;
			FirePoint = GameObject.Find ("FirePoint");
			Instantiate (Bullet, FirePoint.transform.position, Quaternion.identity);
			if (IsWing) {
				FirePointLeft = GameObject.Find ("FirePointLeft");
				FirePointRight = GameObject.Find ("FirePointRight");
				Instantiate (Bullet, FirePointLeft.transform.position, Quaternion.identity);
				Instantiate (Bullet, FirePointRight.transform.position, Quaternion.identity);
			}
			//Debug.Log (Time.time);
		}
	}

	//受到伤害
	public void mBeHurt() {
		StartCoroutine (FlashInPlace ());
		if (IsWing) {
			IsWing = false;
		} 
		else {
			gameObject.transform.position = new Vector3 (0, PlayerToMapBotton, 0);
			Lives -= 1;
			if (Lives <= 0) {
				//TODO:GameOver
				if(PlayerPrefs.HasKey("HighScore")) {
					HighScore = max(Score,PlayerPrefs.GetFloat("HighScore"));
				}
				else HighScore = Score;
				PlayerPrefs.SetFloat("HighScore", HighScore);
			} 

		}
		StartCoroutine (FlashInPlace ());

	}
	float max(float a, float b) {
		if(a>b) return a;
		else return b;
	}
	public void mGetSpecialItem() {
		IsWing = true;
	}

	//闪烁 无敌态3s
	IEnumerator FlashInPlace() {
		gameObject.GetComponent<Collider> ().enabled = false;
		for (int i = 1; i <= 10; i++) {
			gameObject.GetComponent<Renderer> ().enabled = false;
			yield return new WaitForSeconds (0.15f);
			gameObject.GetComponent<Renderer> ().enabled = true;
			yield return new WaitForSeconds (0.15f);
		}
		gameObject.GetComponent<Collider> ().enabled = true;
	}
}
