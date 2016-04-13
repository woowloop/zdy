using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class HistoryPicture : MonoBehaviour
{
    public static HistoryPicture _instance;
    List<string> lsPicDirPath = new List<string>();
    string path;
    int userPicNum = 0, moviePicNumZ = 0;
    List<Texture2D>[] lsHisPicArr = new List<Texture2D>[2];
    void Awake()
    {
        _instance = this;

    }
    void Start()
    {
        //TestMobileTexture._instance.OnMoviePlayFinsh += StartLoadHisPic;
        lsHisPicArr[(int)_EPISORT.USER] = new List<Texture2D>();
        lsHisPicArr[(int)_EPISORT.MOVIE] = new List<Texture2D>();
        //StartLoadHisPic();
        Debug.Log("StartLoadHisPic");

    }
    //获取健身记录地址 29fe17471ff14e38bf80c967ba379eb1
    //视频结束后调用
    IEnumerator LoadHisPic()
    {
        while (true)
        {
            //break;
            if (Scoring_Tony1.isCompleteCreatePic)
            {
                Scoring_Tony1.isCompleteCreatePic = false;
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
        path = Application.persistentDataPath + "/" + QRlogin._instance.user.id + "/";
       // path = Application.persistentDataPath + "/" + "29fe17471ff14e38bf80c967ba379eb1" + "/";
        DirectoryInfo info = new DirectoryInfo(path);
        DirectoryInfo[] dirList = info.GetDirectories();
        for (int i = 0; i < dirList.Length; i++)
        {
            string name = dirList[i].Name;
            lsPicDirPath.Add(name);
            Debug.Log(name);
        }
        yield return new WaitForSeconds(0.1f);
        Debug.Log("dir count:"+lsPicDirPath.Count);
        for (int i = 0; i < lsPicDirPath.Count; i++)
        {
            GetPicID(i);
            GetPicZID(i);
        }
    }
    public void StartLoadHisPic()
    {
        userPicNum = 0;
        moviePicNumZ = 0;
        lsPicDirPath.Clear();
        foreach (var item in lsHisPicArr)
        {
            item.Clear();
        }
        Debug.Log("StartLoadHisPic2");
        StartCoroutine(LoadHisPic());

    }
    //获取某一次的健身照片dateID是历史的第几次锻炼ID
    //选择观看历史数据照片时调用
    public void GetPicID(int dateID)
    {
        for (int i = 0; lsPicDirPath.Count > 0; i++)
        {
            string pathnew = path + lsPicDirPath[dateID].ToString() + "/" + i.ToString() + ".jpg";
            Debug .Log ("+++::"+pathnew);
            if (System.IO.File.Exists(pathnew))
            {
                StartCoroutine(LoadPic(i, dateID));
                userPicNum++;
            }
            else
            {
                Debug.Log("error:" + dateID + "::" + pathnew);
                break;
            }

        }


    }
    public void GetPicZID(int dateID)
    {
        for (int i = 0; lsPicDirPath.Count > 0; i++)
        {
            string pathnew = path + lsPicDirPath[dateID].ToString() + "/" + i.ToString()+"_T" + ".jpg";
            //Debug.Log(pathnew);
            if (System.IO.File.Exists(pathnew))
            {
                StartCoroutine(LoadPicZ(i, dateID));
                moviePicNumZ++;
            }
            else
            {
                Debug.Log("error:" + dateID + "::" + pathnew);
                break;
            }

        }


    }
    IEnumerator LoadPic(int shownum, int dateID)
    {

        //label .text = "file://" + path + hispath [num] + "/test.jpg";
        //		WWW www = new WWW ("file:///c:/test.png");
        WWW www = new WWW("file:///" + path + lsPicDirPath[dateID] + "/" + shownum.ToString() + ".jpg");
        //Debug.Log("{}]]]]  " + path);
        yield return www;
        if (www.error == null)
        {
            Texture2D tex2 = (Texture2D)www.texture;
            //tex2.Compress(false);
            lsHisPicArr[(int)_EPISORT.USER].Add(tex2);
            //ui.mainTexture = (Texture2D)www.texture;
        }
        else
        {
            Debug.Log(www.error);
        }

    }
    IEnumerator LoadPicZ(int shownum, int dateID)
    {
        //Debug.Log("file://" + path + hispath[dateID] + "/" + "z" + shownum.ToString() + ".png");
        //label .text = "file://" + path + hispath [num] + "/test.jpg";
        //		WWW www = new WWW ("file:///c:/test.png");
        WWW www = new WWW("file:///" + path + lsPicDirPath[dateID] + "/"  + shownum.ToString()+"_T" + ".jpg");
        yield return www;
        if (www.error == null)
        {
            Texture2D tex2 = (Texture2D)www.texture;
            //tex2.Compress(false);
            lsHisPicArr[(int)_EPISORT.MOVIE].Add(tex2);
        }
        else
        {
            Debug.Log(www.error);
        }

    }
}
