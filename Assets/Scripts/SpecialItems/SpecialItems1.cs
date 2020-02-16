using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItems1 : MonoBehaviour
{
    public static  float DownSpeed = 2;   //下降速度
	public static  float RotateSpeed = 0;//旋转速度

	private float x;
	private float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        x = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        mMove();
    }
    void mMove() {
		if(direction==1) {
			transform.Translate(Vector3.right * DownSpeed /2 * Time.deltaTime,Space.World);
			if(transform.position.x-x>1f) direction = -1;
		}
		else {
			transform.Translate(Vector3.left * DownSpeed /2 * Time.deltaTime, Space.World);
			if(transform.position.x-x<-1f) direction = 1;
		}
		transform.Translate (Vector3.down * DownSpeed * Time.deltaTime, Space.World);
		transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
		if (transform.position.y < -4.7f)
			Destroy (gameObject);
	}
    void OnTriggerEnter(Collider col) {
		Debug.Log (col.gameObject.name);
        Debug.Log(gameObject.name);

		//道具与玩家碰撞
		if (col.tag == "Player") {
			//Instantiate (PlayerExp, col.gameObject.transform.position, Quaternion.identity);
			col.gameObject.GetComponent<Player>().mGetSpecialItem();
            
            Destroy(gameObject);
		}

	}
}
