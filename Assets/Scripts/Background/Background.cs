using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 5, Space.World);
        if(transform.position.y < -6f) {
            transform.position = new Vector3(0,7.81f,2f);
        }
    }
}
