using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyEffect : MonoBehaviour {

    public bool playFlash = false;
    float time = 0;
  //  public Texture2D[] efxPics;
    int n = 0;
    List<Texture2D> effects = new List<Texture2D>();
    public NewInterface newInterface;
    UITexture tex;
    Animator animator;

    void Awake()
    {
        GetPic();
        //newInterface = transform.parent.Find("NewInterface").GetComponent<NewInterface>();
        tex=GetComponent<UITexture>();
        animator=GetComponent<Animator>();
    }
    
    void Start () {
       
	
	}


    void FixedUpdate()
    {
       // renderer.material.mainTexture = effects[n];
        tex.mainTexture = effects[n];

        if (playFlash)
        {
           // animator.SetTrigger("Show");
           // gameObject.SetActive(true);
            time += Time.deltaTime;
            if (time >= 0.02f)
            {
                n++;
                time = 0;
            }
            if (n > 119)
            {
                //  newInterface.Hide();
                playFlash = false;
                n = 0;
                gameObject.SetActive(false);
            }
        }
      
	
	}
    //加载图片方法
    void GetPic()
    {
        for (int i = 1; i < 121; i++)
        {
            if (i < 10)
                name = "000" + i;
            else if (i >= 10 && i < 100)
                name = "00" + i;
            else if (i >= 100)
                name = "0" + i;



            Texture2D texture = (Texture2D)Resources.Load("calA/cal" + name);
            effects.Add(texture);
        }
    }
}
