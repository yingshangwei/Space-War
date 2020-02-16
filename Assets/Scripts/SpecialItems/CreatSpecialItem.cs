using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatSpecialItem : MonoBehaviour
{
    public GameObject SpecialItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Creat(float len, Vector3 pos) {
        if(Random.Range (0, len)>len-1) {
            Instantiate (SpecialItem, pos, Quaternion.identity);
        }
    }
}
