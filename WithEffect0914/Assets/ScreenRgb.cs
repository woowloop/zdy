using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class ScreenRgb : MonoBehaviour
{

    public static ScreenRgb _instance;

    WebCamTexture cameraTexture;
    string cameraName = "";
   // bool isPlay = false;
    // bool isPlay=true;
    //public string prjpath;
    //public string downpath;
    //public bool Onpath=false ;
    public List<Texture2D> list2 = new List<Texture2D>();
    float time = 0;
    public bool canCreate = false;
    public GameObject RgbPannel;
    public int num = 0;
    private Scoring_Tony1 st1;

    //public Texture2D texture;

    void Awake()
    {
        //StartShowCam();
        _instance = this;
    }

    void Start()
    {
        //StartShowCam("");
        st1 = GameObject.Find("Cube1").GetComponent<Scoring_Tony1>();
        TestMobileTexture._instance.OnMoviePlayStart += StartShowCam;

        //SelectCoursePannel._instance.OnEnterGamePlay += StartShowCam;

        TestMobileTexture._instance.OnMoviePlayFinsh += StopCam;

        //CurveScore._instance.OnRestartGame += StartShowCam;
        
    }

    /*void FixedUpdate () {

       // print("list2.Count" + list2.Count);

        / *if (canCreate)
        {
            //开始计时
            time += 1;
            //时间到时
            if (time > 4)
            {
                StartCoroutine(getTexture2d());
                time = 0f;
            }
        }* /
        //else
        //    time = 0;
          
       

    }*/
    public void StopCam()
    {
        if (cameraTexture)
        {
            cameraTexture.Stop();
        }
    }
    public void StartShowCam()
    {
        StartCoroutine(OpenCam()); 
    }
    IEnumerator OpenCam()
    {
        Debug.Log("openCam");
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {

            WebCamDevice[] devices = WebCamTexture.devices;

            cameraName = devices[0].name;

            cameraTexture = new WebCamTexture(cameraName, 400, 300, 12);
            //GetComponent<UITexture>().mainTexture = cameraTexture;
            RgbPannel.renderer.material.mainTexture = cameraTexture;
            cameraTexture.Play();
            //texture = new Texture2D(cameraTexture.width, cameraTexture.height);
            //isPlay = true;

        }

    }
    //    IEnumerator getTexture2d()
    //    {
    //
    //        yield return new WaitForFixedUpdate();
    //
    //
    //        int y = 0;
    //
    //        while (y < texture.height)
    //        {
    //
    //            int x = 0;
    //
    //            while (x < texture.width)
    //            {
    //
    //                Color color = cameraTexture.GetPixel(x, y);
    //
    //                texture.SetPixel(x, y, color);
    //
    //                ++x;
    //
    //            }
    //
    //            ++y;
    //
    //        }
    //
    //        texture.Apply();
    //
    //        byte[] pngData = texture.EncodeToPNG();
    //
    //        //存入集合list2
    //        //list2.Add(texture);
    //        File.WriteAllBytes(Application.dataPath + "/shexiang/" + num + ".png", pngData);
    //        num++;
    //    } 
    public Texture2D GetPhoto()
    {
        Texture2D texture;
        texture = new Texture2D(cameraTexture.width, cameraTexture.height,TextureFormat.RGB24, false);
        int y = 0;

        while (y < texture.height)
        {
            int x = 0;
            while (x < texture.width)
            {
                Color color = cameraTexture.GetPixel(x, y);
                texture.SetPixel(x, y, color);
                ++x;
            }
            ++y;
        }
        texture.Apply();
        return texture;
    }
    /*public IEnumerator GetPhoto()
    {

        yield return new WaitForFixedUpdate();
        Texture2D texture;
        texture = new Texture2D(cameraTexture.width, cameraTexture.height);
        int y = 0;

        while (y < texture.height)
        {
            int x = 0;
            while (x < texture.width)
            {
                Color color = cameraTexture.GetPixel(x, y);
                texture.SetPixel(x, y, color);
                ++x;
            }
            ++y;
        }
        texture.Apply();
        //		Texture2D ti = null;
        //		ti = texture;
        st1.realtexs.Add(texture);
        //将照片存入指定ID文件夹下
        / *
        string prjpath = Application.dataPath+"/"+"user1";
        if (!System .IO .File.Exists (prjpath ) ) {
            Directory .CreateDirectory (prjpath );
            byte[] pngData = texture.EncodeToPNG();
            File.WriteAllBytes(prjpath + "/" + num + ".png", pngData);
            num++;
                }
        * /
        //if missing ,saving.

        / *
                if (Onpath ==true ) {
                    prjpath = Application.persistentDataPath +"/"+QRlogin ._instance .user .id+"/"+System .DateTime .Now .Year.ToString () + "_" + System .DateTime .Now.Month.ToString () + "_" + System .DateTime .Now .Day.ToString () + "_" + System .DateTime .Now.Hour + "_" + System .DateTime .Now.Minute;
                    Onpath =false ;
                    downpath =prjpath ;
                }* /

        / *if (!System .IO .File.Exists (prjpath)) {
			
            Directory .CreateDirectory (prjpath);
        }* /

        //		if (!System .IO .File.Exists (prjpath)) {
        //			
        //			Directory .CreateDirectory (prjpath);
        //			byte[] pngData = texture.EncodeToPNG ();
        //			File.WriteAllBytes (prjpath + "/" + num + ".png", pngData);
        //			num++;
        //			st1 .IsSave =false ;
        //		} else {
        //			byte[] pngData = texture.EncodeToPNG ();
        //			File.WriteAllBytes (prjpath + "/" + num + ".png", pngData);
        //			num++;
        //			st1 .IsSave =false ;
        //		}



        //        byte[] pngData = texture.EncodeToPNG();
        //
        //        //存入集合list2
        //        //list2.Add(texture);
        //        File.WriteAllBytes(Application.dataPath + "/shexiang/" + num + ".png", pngData);
        //        num++;
    }*/
}
