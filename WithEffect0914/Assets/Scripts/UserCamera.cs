using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserCamera : MonoBehaviour {

	// Use this for initialization

    public static UserCamera _instance;

    WebCamTexture cameraTexture;
    string cameraName = "";
    public string prjpath;
    public string downpath;

    void Awake()
    {
        //StartShowCam();
        _instance = this;
    }
	void Start () 
    {
        //StartShowCam("");
        XMLDecode._instance.OnDecodeXmlComplete += StartShowCam;
        //SelectCoursePannel._instance.OnEnterGamePlay += StartShowCam;
        TestMobileTexture._instance.OnMoviePlayFinsh += StopCam;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StopCam()
    {
        if (cameraTexture)
        {
            cameraTexture.Stop();
        }
    }
    public void StartShowCam(ShowMovieInfo smi)
    {
        StartCoroutine(OpenCam());
        prjpath = Application.persistentDataPath + "/" + QRlogin._instance.user.id + "/" + System.DateTime.Now.Year.ToString() + "_" + System.DateTime.Now.Month.ToString() + "_" + System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Hour + "_" + System.DateTime.Now.Minute;
        downpath = prjpath;
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
            GetComponent<UITexture>().mainTexture = cameraTexture;
            cameraTexture.Play();

        }

    }
    public Texture2D GetPhoto()
    {
        Texture2D texture;
        texture = new Texture2D(cameraTexture.width, cameraTexture.height, TextureFormat.RGB24, false);
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
}
