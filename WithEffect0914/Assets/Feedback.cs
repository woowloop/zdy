using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Feedback : MonoBehaviour {
    public static Feedback _instance;

    GameObject player, video, videoTex, playerTex;
    public bool start = false;
    float time, showTime, reaminTime;
    int id;
    UIGrid grid;
    public GameObject smallMissPic;
    int endId;
    int idInStartTime = 0;
    public List<GameObject> missPics = new List<GameObject>();
    int idInMissPics, playId;
    UILabel playerTime, videoTime;
    string minuteTex, secondTex;
    string path1, path2, path, picName;
    Texture t;


    void Awake()
    {
        _instance = this;
        player = transform.Find("Player").gameObject;
        video = transform.Find("Video").gameObject;
        videoTex = transform.Find("VideoTex").gameObject;
        playerTex = transform.Find("PlayerTex").gameObject;
        grid = transform.Find("Scroll View/Grid").GetComponent<UIGrid>();
        videoTime = transform.Find("Video/VideoTime").GetComponent<UILabel>();
        playerTime = transform.Find("Player/PlayerTime").GetComponent<UILabel>();

        //自身隐藏
        this.gameObject.SetActive(false);
    }

    void Start()
    {

    }


    void FixedUpdate()
    {
        //print("picName" + picName);
        //按下方向左键，返回，按下方向右键，进入回放界面
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //NewCourseEnd._instance.Return();
        }
     
        /*if (start)
        {

            showTime += Time.deltaTime;
            if (showTime >= 1)
            {
                reaminTime++;
                showTime = 0;
            }
            //分钟数
            int minute = (int)(reaminTime / 60);
            //秒数
            int second = (int)reaminTime % 60;

            if (minute <= 9)
                minuteTex = "0" + minute;
            if (second <= 9)
                secondTex = "0" + second;
            else
                secondTex = second + "";

            videoTime.text = minuteTex + ":" + secondTex;
            playerTime.text = minuteTex + ":" + secondTex;

            //videoTime.text = reaminTime + "";
            //playerTime.text = reaminTime + "";

            //隐藏两张图片
            videoTex.SetActive(false);
            playerTex.SetActive(false);
            time += 1;
            if (time == 4)
            {
               // video.renderer.material.mainTexture = ScreenVideo._instance.list1[id];
                StartCoroutine(GetVideoPic(id));
				StartCoroutine(GetMissPic(id));
                //player.renderer.material.mainTexture = ScreenRgb._instance.list2[id];
                id++;
                time = 0;
                endId = (int)Math.Floor(1267 / 127 * (Scoring_Tony1.missStartTimeList[idInStartTime] + 6));
                if (id > endId)
                {
                    start = false;
                    time = 0;
                    id = 0;
                    //调用小图片颜色恢复方法
                    missPics[playId].GetComponent<SmallMissPic>().ColorRecover();
                    showTime = 0;
                }
            }*/
        //}
       


    }
    //显示方法
    public void ShowPlayer()
    {
        //显示
        gameObject.SetActive(true);
        // camera.SetActive(true);
        //显示错误图片列表
        ShowMissList();
        // print("显示出来"); 
    }

    //显示错误图片列表方法
    void ShowMissList()
    {
       /* foreach (int id in Scoring_Tony1.missPicsList)
        {
            GameObject smallPic = NGUITools.AddChild(grid.gameObject, smallMissPic);
            grid.AddChild(smallPic.transform);
            //把每个图片都加入错误图片集合
            missPics.Add(smallPic);
            idInMissPics = missPics.IndexOf(smallPic);
            smallPic.GetComponent<SmallMissPic>().ShowSmallPic(id, idInMissPics);
        }*/
    }
    //播放视频截图方法
    public void PlayBackPng(int id, int playId)
    {/*
        this.id = id;
        this.playId = playId;
        start = true;
        idInStartTime = Scoring_Tony1.missPicsList.IndexOf(id);
        reaminTime = Scoring_Tony1.missStartTimeList[idInStartTime];*/
    }
    //清空小图片列表方法
    public void ClearSmallPic()
    {
        foreach (Transform t in grid.transform)
        {
            Destroy(t.gameObject);
        }
        start = false;
        time = 0;
        showTime = 0;
        gameObject.SetActive(false);
    }

    IEnumerator GetVideoPic(int id)
    {
            if (id < 10)
                picName = "01000" + id;
            else if (id >= 10 && id < 100)
                picName = "0100" + id;
            else if (id >= 100 && id < 1000)
                picName = "010" + id;
            else if (id >= 1000 && id < 1266)
                picName = "01" + id;
      
        path1 ="file:///" + Application.streamingAssetsPath + "/VideoPics/" + picName + ".png";
        WWW wwww1 = new WWW(path1);
        yield return wwww1;
       // t = (Texture)wwww.texture;
        video.renderer.material.mainTexture = wwww1.texture;
    }

	IEnumerator GetMissPic(int id)
	{
		path2 ="file:///" + Application.dataPath + "/shexiang/" + id + ".png";
		WWW wwww2 = new WWW(path2);
		yield return wwww2;
		// t = (Texture)wwww.texture;
		player.renderer.material.mainTexture = wwww2.texture;
	}
}
