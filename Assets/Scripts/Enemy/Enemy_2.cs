using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敌人
public class Enemy_2: MonoBehaviour {
	public GameObject BulletExp; //子弹爆炸粒子特效
	public GameObject PlayerExp; //玩家爆炸粒子特效
	public GameObject EnemyExp;  //敌人爆炸粒子特效
	public GameObject SpecialItem;
	public float HP;             //当前敌人血量
	private const float ShotScore = 20;   //击中当前怪物得分
	private const float DeathScore = 300; //击败当前怪物得分
	public static  float DownSpeed = 2;   //下降速度
	public static  float RotateSpeed = 90;//旋转速度

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Player.Lives <= 0 || Player.State==0) return ;
		mMove();
	}

	//移动
	void mMove() {
		transform.Translate (Vector3.down * DownSpeed * Time.deltaTime *  ((Player.Score)/30000+1));
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
			if(Random.Range (0, 10)>=10-1) {
            	Instantiate (SpecialItem, transform.position, Quaternion.identity);
       		}
			Instantiate (EnemyExp, gameObject.transform.position, Quaternion.identity);
			Player.Score += DeathScore;
			Destroy (gameObject);
		}
	}
}
