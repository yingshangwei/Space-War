using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class help : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnGUI() {
        GUI.Label(new Rect(Screen.width/2-30,50,60,30), "操作说明");
        GUI.Label(new Rect(Screen.width/2-50,80,120,30), "上下左右:控制方向");
        GUI.Label(new Rect(Screen.width/2-50,110,120,30), "空格       :发射子弹");
        GUI.Label(new Rect(Screen.width/2-50,140,120,30), "P           :暂停游戏");
        GUI.Label(new Rect(Screen.width/2-50,170,120,30), "ESC      :返回主菜单");
        if(GUI.Button(new Rect(Screen.width/2-30,280,50,30), "Back")) {
            SceneManager.LoadScene("begin");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
