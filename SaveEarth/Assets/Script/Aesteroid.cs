using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aesteroid : MonoBehaviour
{
    public Transform Target;
    public float speed; 
    public GameObject Explode;
    public GameObject EarthExplode;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,Target.position,speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //missile triggerd
        if(other.tag=="Missile")
        {
            Instantiate(Explode,transform.position,transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }else if(other.name=="Earth")
        {
             Instantiate(EarthExplode,other.GetComponent<Transform>().position,transform.rotation);
              other.GetComponent<Earth>().GameOver.SetActive(true);
            Destroy(other.gameObject);
            Destroy(gameObject);
           
        }
    }
}
