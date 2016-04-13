using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class ScreenVideo : MonoBehaviour {

    public static ScreenVideo _instance;
    
    int width,height;
    Texture2D cutImage;
    Rect rect;
    public List<Texture2D> list1 = new List<Texture2D>();
    string name;

  //  float time = 0.3f;
    int n=0;


    void Awake()
    {
        _instance = this;
    }
    
    void Start () {
        width = Screen.width;
        height = Screen.height;
        ////加载图片
       // GetPic();
	}


    
    //加载图片方法
    void GetPic()
    {
        for (int i = 0; i < 1267; i++)
        {
            if (i < 10)
                name = "000" + i;
            else if (i >= 10 && i < 100)
                name = "00" + i;
            else if (i >= 100 && i < 1000)
                name = "0" + i;
            else if (i >= 1000 && i < 1267)
                name = i+"";


            Texture2D texture = (Texture2D)Resources.Load("VideoPics/zdy2min" + name);
            list1.Add(texture);
        }
    }
}
