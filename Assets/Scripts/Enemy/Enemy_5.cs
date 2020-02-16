using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敌人
public class Enemy_5: MonoBehaviour {
	public GameObject BulletExp; //子弹爆炸粒子特效
	public GameObject PlayerExp; //玩家爆炸粒子特效
	public float HP;             //当前敌人血量

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		mMove();
	}

	//移动
	void mMove() {
		transform.Translate (Vector3.down * 10 * Time.deltaTime);
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
			Destroy (col.gameObject);
		} 
		//敌人与玩家碰撞
		else if (col.tag == "Player") {
			Instantiate (PlayerExp, col.gameObject.transform.position, Quaternion.identity);
			Destroy (col.gameObject);
		}
		//与道具特殊物品碰撞（获得）
		else if (col.tag == "SpecialItems") {

		}
		if (HP <= 0)
			Destroy (gameObject);
	}
}
