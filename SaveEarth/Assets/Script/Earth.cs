using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth : MonoBehaviour
{
    public Camera Cam;
    Rigidbody2D rb;
    public float speed;
   public GameObject missile;
   public Transform[] Launcherpos;
   AudioSource audiosource;
   public GameObject missilelaunch;
   public GameObject GameOver;
   public RectTransform Cursorpos;
   public int time;
   public float timebtw;
   float timer;
   public Text TimeText;
   public Spawner[] spawnercs;
   public Transform SpawnManager;
   public GameObject[] MisslieStats;
   int missilecount;
   public float timebtwshoot;
   float shoottimer;
   public GameObject resumepanel;
   public bool timestoped=false;
    // Start is called before the first frame update
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody2D>();
        audiosource=gameObject.GetComponent<AudioSource>();
        timer=timebtw;
        missilecount=4;
        shoottimer=timebtwshoot;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        updation();
        SpawnManager.Rotate(0f,0f,2f);
       if(timer>=Time.deltaTime)
       {
           timer-=Time.deltaTime;
       }else{
           timer=Time.deltaTime+timebtw;
            time+=1;
           
       }
        TimeText.text=time.ToString();
        if(shoottimer>=Time.deltaTime)
        {
            shoottimer-=Time.deltaTime;
        }else{
            shoottimer=timebtwshoot+Time.deltaTime;
            if(missilecount<4)
            missilecount+=1;
        }
        
        if(Input.GetKeyDown("escape"))
        {
            timestoped=true;
            resumepanel.SetActive(true);
        }if(timestoped==true)
        {
            Time.timeScale=0f;
        }else{
            Time.timeScale=1f;
        }
        Cursorpos.position=Input.mousePosition;
        Cursor. visible = false;
        Vector2 mousepos=Cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir=new Vector2(transform.position.x,transform.position.y)-mousepos;
        float angle=Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0f,0f,angle+90f);
        if(Input.GetMouseButtonDown(0)&&missilecount!=0)
        {
            if(missilecount>0)
            {
            missilecount-=1;
            }
             missilelaunch.SetActive(true);
             for(int i=0;i<=3;i++)
             {
                 if(Launcherpos[i].gameObject.activeSelf==true)
                 {
                Instantiate(missile,Launcherpos[i].position,Launcherpos[i].rotation);
                 }
             }
            audiosource.Play();
           
            
        }else if(Input.GetMouseButtonUp(0))
        {
              missilelaunch.SetActive(false);
        }
       
    }
    void updation()
    {
        if(time>=50&&time<100)
        {
            
            for(int i=0;i<=3;i++)
            {
            spawnercs[i].timebtw=4;
           
            }
            Launcherpos[1].gameObject.SetActive(true);
            MisslieStats[1].gameObject.SetActive(true);
        }else if(time>=100&&time<150)
        {
            
            
            
            for(int i=0;i<=3;i++)
            {
            spawnercs[i].timebtw=3;
           
            }
            MisslieStats[2].gameObject.SetActive(true);
            Launcherpos[2].gameObject.SetActive(true);
        }else if(time>=150)
        {
            
            for(int i=0;i<=3;i++)
            {
            spawnercs[i].timebtw=2;
           
            }
            MisslieStats[2].gameObject.SetActive(true);
            Launcherpos[3].gameObject.SetActive(true);
        }
    }
}
