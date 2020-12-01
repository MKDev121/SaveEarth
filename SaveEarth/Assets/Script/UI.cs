using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public AudioSource audiosource;
    public AudioClip[] audioclip;
    public int scenenumber;
    public GameObject TutorialOpenObj;
    // Start is called before the first frame update
    void Start()
    {
        Cursor. visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartScene()
    {
        Invoke("loadscene",.2f);
        audiosource.clip=audioclip[0];
        audiosource.Play();
         SceneManager.LoadScene(scenenumber);
    }
    void loadscene()
    {
        SceneManager.LoadScene(scenenumber);
    }
    public void TutorialOpen()
    {
        TutorialOpenObj.SetActive(true);
        audiosource.clip=audioclip[0];
        audiosource.Play();
    }
    public void TutorialClose()
    {
        TutorialOpenObj.SetActive(false);
        audiosource.clip=audioclip[0];
        audiosource.Play();
    }
    public void Quitgame()
    {
        Application.Quit();
        audiosource.clip=audioclip[0];
        audiosource.Play();
    }
    public void resume()
    {
        Time.timeScale=1f;
        audiosource.clip=audioclip[0];
        audiosource.Play();
        GameObject.Find("Earth").GetComponent<Earth>().timestoped=false;
        GameObject.Find("ResumePanel").SetActive(false);
    }
    
     public  void OnPointerEnter(PointerEventData data)
    {
        Debug.Log("OnPointerExit called.");
        gameObject.GetComponent<RectTransform>().localScale=new Vector3(1.3f,1.3f,1.3f);
        audiosource.clip=audioclip[1];
        audiosource.Play();
    }
     public  void OnPointerExit(PointerEventData data)
    {
        Debug.Log("OnPointerExit called.");
        gameObject.GetComponent<RectTransform>().localScale=new Vector3(1f,1f,1f);
    }
}
