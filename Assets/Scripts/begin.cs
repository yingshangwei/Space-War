using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class begin : MonoBehaviour
{
    // Start is called before the first frame update
    public float HighScore;
    void Start()
    {
        Player.Lives = 3;
        Player.Score = 0;
        Player.State = 0;
    }
    
    void OnGUI() {
        
        GUI.Label(new Rect(Screen.width/2-30,50,60,30), "太空战争");
        if(PlayerPrefs.HasKey("HighScore")) {
            HighScore = PlayerPrefs.GetFloat("HighScore");
            GUI.Label(new Rect(Screen.width/2-30,100,150,30), "最高得分:"+  (int)HighScore);
        }
        else GUI.Label(new Rect(Screen.width/2-30,100,150,30), "最高得分:无");
        if(GUI.Button(new Rect(Screen.width/2-25,Screen.height/2-15,50,20), "Play")) {
            Player.Lives = 3;
            Player.Score = 0;
            Player.State = 1;
			SceneManager.LoadScene("play");
		}
        if(GUI.Button(new Rect(Screen.width/2-25,Screen.height/2+15,50,20), "Help")) {
            SceneManager.LoadScene("help");
        }
        if(GUI.Button(new Rect(Screen.width/2-25,Screen.height/2+45,50,20), "Quit")) {
            Application.Quit();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
