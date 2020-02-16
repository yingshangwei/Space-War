using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatEnemy1 : MonoBehaviour {
	public GameObject Enemy; //怪物预制体
	private float preTime = 0; //上一个怪物生成的时间
	private float CreatEnemyInterval = 1f; //怪物生成的时间间隔
	private Vector3 EnemyPosition = new Vector3(0,6.6f,0); //怪物生成位置 随机
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.Lives <= 0 || Player.State == 0) return ;
		//Debug.Log ("CreatEnemyRun!");
		if(Player.Score > 3000) mCreatEnemy();
	}
	void mCreatEnemy() {
		if (Time.time - preTime > CreatEnemyInterval) {
			preTime = Time.time;
			EnemyPosition.x = Random.Range (-2.5f, 2.5f);
			Instantiate (Enemy, EnemyPosition, Quaternion.identity);
		}
	}
}
