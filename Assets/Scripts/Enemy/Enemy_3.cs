using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敌人
public class Enemy_3: MonoBehaviour {
	public GameObject BulletExp; //子弹爆炸粒子特效
	public GameObject PlayerExp; //玩家爆炸粒子特效
	public GameObject EnemyExp;  //敌人爆炸粒子特效
	public GameObject SpecialItem;
	public float HP;             //当前敌人血量
	private const float ShotScore = 30;   //击中当前怪物得分
	private const float DeathScore = 500; //击败当前怪物得分
	public static  float DownSpeed = 1;   //下降速度
	public static  float RotateSpeed = 0;//旋转速度

	private float x;
	private float direction = 1;

	// Use this for initialization
	void Start () {
		gameObject.transform.localEulerAngles = new Vector3(90, -180, 0);
		x = gameObject.transform.position.x;

	}
	
	// Update is called once per frame
	void Update () {
		if(Player.Lives <= 0 || Player.State==0) return ;
		mMove();
	}

	//移动
	void mMove() {
		if(direction==1) {
			transform.Translate(Vector3.right * DownSpeed /2 * Time.deltaTime,Space.World);
			if(transform.position.x-x>1f) direction = -1;
		}
		else {
			transform.Translate(Vector3.left * DownSpeed /2 * Time.deltaTime, Space.World);
			if(transform.position.x-x<-1f) direction = 1;
		}
		transform.Translate (Vector3.down * DownSpeed * Time.deltaTime * ((Player.Score)/100000+1), Space.World);
		transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
		if (transform.position.y < -4.7f)
			Destroy (gameObject);
	}

	//触发器
	void OnTriggerEnter(Collider col) {
		Debug.Log (col.gameObject.name);
		//敌人与子弹碰撞
		if (col.tag == "Bullet") {
			Instantiate (BulletExp, col.gameObject.transform.position, Quaternion.identity);
			HP -= 1;
			Player.Score += ShotScore;
			Destroy (col.gameObject);
		} 
		//敌人与玩家碰撞
		else if (col.tag == "Player") {
			Instantiate (PlayerExp, col.gameObject.transform.position, Quaternion.identity);
			//Destroy (col.gameObject);
			col.gameObject.GetComponent<Player>().mBeHurt();
		}
		//与道具特殊物品碰撞（获得）
		else if (col.tag == "SpecialItems") {

		}
		if (HP <= 0) {
			if(Random.Range (0, 5)>=5-1) {
            	Instantiate (SpecialItem, transform.position, Quaternion.identity);
       		}
			Instantiate (EnemyExp, gameObject.transform.position, Quaternion.identity);
			Player.Score += DeathScore;
			Destroy (gameObject);
		}
	}
}
