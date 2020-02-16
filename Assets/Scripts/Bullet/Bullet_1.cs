using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_1 : MonoBehaviour {
	public float Damage = 1; //当前子弹的伤害
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.Lives <= 0 || Player.State == 0) return ;
		mMove ();
	}
	void mMove() {
		transform.Translate (Vector3.up * 10 * Time.deltaTime);
		if (transform.position.y > 6.7f)
			Destroy (gameObject);
	}
}
