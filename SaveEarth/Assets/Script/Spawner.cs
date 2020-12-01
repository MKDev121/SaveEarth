using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timebtw;
    float timer;
    public GameObject Aesteriod; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>=Time.deltaTime)
        {
            timer-=Time.deltaTime;
        }else{
            timer=Time.deltaTime+timebtw;
            Instantiate(Aesteriod,transform.position,transform.rotation);
        }
    }
}
