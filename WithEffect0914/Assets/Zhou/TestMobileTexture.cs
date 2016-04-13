using UnityEngine;
using System.Collections;
using MMT;
using System.Collections.Generic;
using System.Threading;

[RequireComponent(typeof(MobileMovieTexture))]
public class TestMobileTexture : MonoBehaviour
{
    public static TestMobileTexture _instance;
    public Camera cameraForMovie=null;
    public UISlider movieProgress;
    //private GameObject version;
    private MobileMovieTexture m_movieTexture;

    private GameObject startdu;
    private GameObject jingdu;
    private GameObject enddu;
    //private float timer;
    private Vector3 timevector;
    private GUIText movielengthGui;
    private GUIText currentmovielengthGui;
    private int movielengthGuimin;
    private int movielengthGuisec;
    private int currentmovielengthGuimin;
    private int currentmovielengthGuisec;
    private Scoring_Tony1 st1;

    private string _postdateurl;

    public struct _MovieInfo
    {
        public float movieLength
        {
            get
            {
                if (_instance && _instance.m_movieTexture)
                    return (float)_instance.m_movieTexture.Duration;
                else
                    return 0;
            }
        }
        public int movieWidth
        {
            get
            {
                if (_instance && _instance.m_movieTexture)
                    return _instance.m_movieTexture.Width;
                else
                    return 0;
            }
        }
        public int movieHeight
        {
            get
            {
                if (_instance && _instance.m_movieTexture)
                    return _instance.m_movieTexture.Height;
                else
                    return 0;
            }
        }
        public float movieCurProgress
        {
            get
            {
                if (_instance && _instance.m_movieTexture)
                    return (float)_instance.m_movieTexture.PlayPosition;
                else
                    return 0;
            }
        }
        public float movieStartTime
        {
            get
            {
                return 3;
            }
        }
    }

    public bool isbegin;
    public NumCrtl score;
    public AudioClip sound2;
    public _MovieInfo movieInf = new _MovieInfo();
    //public string path1;

    public bool canCreateVideo, canCreateRGB;
    public GameObject missPic, totalScore, logo;
    float progress;

    public delegate void MoviePlayFinsh();
    public event MoviePlayFinsh OnMoviePlayFinsh;
    public delegate void MoviePlayStart();
    public event MoviePlayFinsh OnMoviePlayStart;

    //private Queue<Texture2D> textureQ = new Queue<Texture2D>();
    //private Thread thrGenerateTex=null;
    Rect rect;
    RenderTexture renderTex;
    void Awake()
    {
        _instance = this;
        //path1 = "file://D://with0906effect//WithEffect//Assets//Photo//" + "0" + ".jpg";
        m_movieTexture = GetComponent<MobileMovieTexture>();
        m_movieTexture.LoopCount = 0;
        startdu = GameObject.Find("StartDu");
        jingdu = GameObject.Find("JingDu");
        enddu = GameObject.Find("EndDu");
        movielengthGui = GameObject.Find("MovieLengthGui").GetComponent<GUIText>();
        currentmovielengthGui = GameObject.Find("CurrentMovieLengthGui").GetComponent<GUIText>();
        //m_movieTexture.onFinished += OnFinished;
        //version  = GameObject.Find("Version");
        //  canCreateRGB = transform.parent.Find("MainInterface").GetComponent<ScreenShot>().canCreate;

    }
    public void NotifyMoviePlayFinsh()
    {
        if (OnMoviePlayFinsh != null)
        {
            OnMoviePlayFinsh();
        }
    }
    public void NotifyMoviePlayStart()
    {
        if (OnMoviePlayStart != null)
        {
            OnMoviePlayStart();
        }
    }
    void Start()
    {
        isbegin = false;
        _postdateurl = "http://shapejoy.duapp.com/api/fit/trainPushToClient";
        timevector = enddu.transform.localPosition - jingdu.transform.localPosition;
       // movielengthGui.text = KeepDot2(movielengthGuimin) + ":" + KeepDot2(movielengthGuisec);
        if (st1 == null)
        {
            st1 = GameObject.FindObjectOfType(typeof(Scoring_Tony1)) as Scoring_Tony1;
        }
        XMLDecode._instance.OnDecodeXmlComplete += AutoPlayVideo;
        //SelectCoursePannel._instance.OnEnterGamePlay += AutoPlayVideo;
        //CurveScore._instance.OnRestartGame += AutoPlayVideo;
        m_movieTexture.onFinished += OnFinished;

        if (cameraForMovie == null)
        {
            cameraForMovie = GameObject.Find("CameraForMovie").camera;
        }
        //rect = new Rect(Screen.width * 0f, Screen.height * 0f, Screen.width * 1f, Screen.height * 1f);
        //rect = new Rect(Screen.width * 0f, Screen.height * 0f, 1024, 768);
        if (cameraForMovie)
        {
            rect = cameraForMovie.pixelRect;
            renderTex = new RenderTexture((int)rect.width, (int)rect.height, 0);
        }
        //Debug.Log("<>" + Screen.height + "<>" + Screen.width);

        //播放视频的方法
        //AutoPlayVideo();
        //StartCoroutine (Starplay ());
    }

    void OnFinished(MobileMovieTexture sender)
    {
        Debug.Log(sender.Path + " has finished ");
        gameObject.GetComponent<AudioSource>().audio.Stop();
        m_movieTexture.Stop();
        jingdu.transform.localPosition = enddu.transform.localPosition;
        //NewCourseEnd._instance.Show();
        NewInterface._instance.egneryEfx.fillAmount = 0;
        Scoring_Tony1.lianji = 0;
        PlayerPixels._instance.changethird = false;
        StartCoroutine(UpLoadPlayState());
        QRlogin.LocalPicPath = "generateSavePath";
        //HistoryPicture._instance.GetNode();
        missPic.SetActive(false);
        totalScore.SetActive(false);
        isbegin = false;
        NotifyMoviePlayFinsh();
    }

    void Update()
    {
        if (isbegin)
        {
            if (movieProgress)
            {
                movieProgress.value = (float)m_movieTexture.PlayPosition;
            }
            currentmovielengthGuimin = (int)m_movieTexture.PlayPosition / 60;
            currentmovielengthGuisec = (int)m_movieTexture.PlayPosition % 60;
            currentmovielengthGui.text = KeepDot2(currentmovielengthGuimin) + ":" + KeepDot2(currentmovielengthGuisec);
            progress = (float)m_movieTexture.PlayPosition / (float)m_movieTexture.Duration;

            jingdu.transform.localPosition = new Vector3(startdu.transform.localPosition.x + timevector.x * progress, startdu.transform.localPosition.y + timevector.y * progress, startdu.transform.localPosition.z + timevector.z * progress);

        }
    }

    IEnumerator UpLoadPlayState()
    {

        if (QRlogin._instance.user.token != null)
        {
            WWWForm form = new WWWForm();
            form.AddField("token", QRlogin._instance.user.token);//"f1dd89f028c94507a85cb3266803c333"
            form.AddField("source", "shapejoy_v1");
            form.AddField("Message", PostMessage._instance.json1());
            form.AddField("Detail", "[]");
            WWW www = new WWW(_postdateurl, form);
            yield return www;
            Debug.Log("::::::>"+www.text);
            //		while (!www.isDone)
            //		{
            //			yield return new WaitForEndOfFrame();
            //		}
            if (www.error != null)
            {
                Debug.LogError(www.error);
            }
        }


    }

   /* void ResetProgress()
    {
        jingdu.transform.localPosition = startdu.transform.localPosition;
    }*/
    public Texture2D GetMoviePic()
    {
        if (cameraForMovie==null)
        {
            return null;
        }
        Texture2D texture2d = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);

        RenderTexture rt_old = cameraForMovie.targetTexture;
        cameraForMovie.targetTexture = renderTex;
        cameraForMovie.Render();
        RenderTexture.active = renderTex;
        texture2d.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素 
        texture2d.Apply();
        cameraForMovie.targetTexture = rt_old;
        RenderTexture.active = null; // JC: added to avoid errors
        /*byte[] bytes = screenShot.EncodeToPNG();
        string filename = "c:/Screenshot" + Time.time.ToString() + ".png";
        System.IO.File.WriteAllBytes(filename, bytes);*/
        return texture2d;

    }
   /* void ThreadForGetMovieSnapShoot()
    {
        while (true)
        {
            if (textureQ.Count > 0)
            {
                Texture2D texture2d = textureQ.Dequeue();
              //  Rect rect = new Rect(Screen.width * 0f, Screen.height * 0f, Screen.width * 1f, Screen.height * 1f);
              //  RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);
                RenderTexture rt_old = cameraForMovie.targetTexture;
                cameraForMovie.targetTexture = renderTex;
                cameraForMovie.Render();
                RenderTexture.active = renderTex;
                texture2d.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素 
                texture2d.Apply();
                cameraForMovie.targetTexture = rt_old;
                RenderTexture.active = null; // JC: added to avoid errors  
                //GameObject.Destroy(rt);
            }
            else
            {
                Thread.Sleep(10);
            }
        }
    }*/
    private string KeepDot2(int Num)
    {
        return Num.ToString("00");
    }
    //播放视频的方法
    public void AutoPlayVideo(ShowMovieInfo smi)
    {
        m_movieTexture.AbsolutePath = smi.isAbsolutePath;
        m_movieTexture.LoopCount = 0;
        m_movieTexture.Path = smi.videourl;

        Debug.Log("===>"+m_movieTexture.Duration);
        //XMLDecode._instance.DecodeXML("level.xml");
        logo.SetActive(false);
        score.num = "" + 0;
        //        Scoring_Tony.scorenum = 0;
        m_movieTexture.Play();
        gameObject.GetComponent<AudioSource>().audio.clip = sound2;
        gameObject.GetComponent<AudioSource>().audio.Play();
        Scoring_Tony1.scorenum = 0; 
        totalScore.SetActive(true); 
        PlayerPixels._instance.changethird = true;
        PlayerPixels._instance.tm1 = 20f;
        isbegin = true;
        StartCoroutine(DelayUpdateTexture());
        OnMoviePlayStart();
    }

    IEnumerator DelayUpdateTexture() 
    {
        yield return new WaitForSeconds(0.5f);
        movielengthGuimin = (int)m_movieTexture.Duration / 60;
        movielengthGuisec = (int)m_movieTexture.Duration % 60;
        movielengthGui.text = KeepDot2(movielengthGuimin) + ":" + KeepDot2(movielengthGuisec);
        Debug.Log("===>" + m_movieTexture.Duration);
        UITexture uiTex = GetComponent<UITexture>();
        if (uiTex)
        {
            Texture t = uiTex.mainTexture;
            uiTex.mainTexture = null;
            uiTex.mainTexture = t;
        }
    }
}
