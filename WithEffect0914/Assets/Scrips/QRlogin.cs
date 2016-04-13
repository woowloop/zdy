using UnityEngine;
using System.Collections;
using ZXing;
using ZXing.QrCode;
using LitJson;
using CourseDetail;

public class QRlogin : MonoBehaviour 
{
	public static QRlogin _instance;
    static string userToken;// = "ff960b6d9ae0480c881668173ba207a8";
    public static string UserToken
    {
        get
        {
            //return userToken;
            return "ff960b6d9ae0480c881668173ba207a8";
        }
    }
    static string userID = "29fe17471ff14e38bf80c967ba379eb1";
    public static string UserID
    {
        get
        {
            return userID;
        }
    }
	//public bool isShow=false ;
	public User user = new User ();
//	private static string authorizeUrl = "http://192.168.1.188:8080/EDServer/api/user/validAuthorize?devicereg="+SystemInfo.deviceUniqueIdentifier;
//	private static string url = "http://192.168.1.188:8080/EDServer/user/authorize?devicereg="+SystemInfo.deviceUniqueIdentifier;
    public static string authorizeUrl = "http://shapejoy.duapp.com/api/user/validAuthorize?devicereg=" + SystemInfo.deviceUniqueIdentifier;
    public static readonly string adviseCourseUrl = "http://shapejoy.duapp.com/api/fit/todayCoursePlan?token=";
    public static readonly string moviePicUrl = "http://7xnqok.com1.z0.glb.clouddn.com/";
    public static readonly string courseTypeUrl = "http://shapejoy.duapp.com/course/getCourseTrainType";
    public static readonly string courseMovieByTypeUrl = "http://shapejoy.duapp.com/course/getCourses?type=";
    public static readonly string getHisPicInfUrl = "http://shapejoy.duapp.com/api/fit/getPagingTraining?token=";
    static string localPicPath = "";
    public static string LocalPicPath
    {
        get
        {
            return localPicPath;
        }
        set
        {
            localPicPath = Application.persistentDataPath + "/" + QRlogin._instance.user.id + "/" + System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + System.DateTime.Now.Day.ToString() + " " + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + "-" + System.DateTime.Now.Second;
        }
    }

    public delegate void LoginSucceed();
    public event LoginSucceed OnLoginSucceed;
	//private bool run;

    public void NotifyLoginSucceed()
    {
        if (OnLoginSucceed!=null)
        {
            OnLoginSucceed();
        }
    }
	void Awake()
	{
        _instance = this;
	}
	// Use this for initialization
	void Start ()
    {
        StartAuthorize();
    }
    IEnumerator GetCourseType(string strUrl)
    {
        while (true)
        {
            WWW www = new WWW(strUrl);
            yield return www;
            Debug.Log(strUrl);
            if (www.error == null)
            {
                JsonMapper.ToObject<CourseType>(www.text);
                if (CourseType._Instance.detail != null && CourseType._Instance.description == "success")
                {
                    CourseType._Instance.IsInitOk = true;
                    break;
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator GetTodayCourse(string strUrl)
    {
        while (true)
        {
            WWW www = new WWW(strUrl);
            yield return www;
            Debug.Log(strUrl);
            if (www.error == null)
            {
                JsonMapper.ToObject<CourseDetailArr>(www.text);
                if (CourseDetailArr.Instance.detail!=null&&CourseDetailArr.Instance.description == "success")
                {
                    Debug.Log(CourseDetailArr.Instance.detail.Count);
                    CourseDetailArr.Instance.IsInitOk = true;
                    break;
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
	//打开登录界面后调用
	public void StartAuthorize() 
    {
        StartCoroutine(LoopVerifyAuthorize(authorizeUrl));
	}

/*
	public void StopAuthorize() 
    {
		run = false;
		StopCoroutine("PostData");
	}*/

	/*private void ValidAuthorize() {
		WWW www = new WWW (authorizeUrl);
		Debug.Log("开始验证");
		StartCoroutine (PostData (www));
	}*/

    IEnumerator LoopVerifyAuthorize(string postUrl)
    {
        yield return new WaitForSeconds(0.25f);
        Debug.Log(postUrl);
//         NotifyLoginSucceed();
//         StopAllCoroutines();
        WWW www = new WWW(postUrl);
        Debug.Log("开始验证...");
        yield return www;
        bool isVerifySucceed=false;
        if(www.error != null)
        {
            Debug.Log("验证失败 " + www.error);
        }
        else         {
            Debug.Log(www.text);
            Result result = JsonMapper.ToObject<Result>(www.text);
            if (result!=null&&result.Code == "200")
            {
                user = result.Detail;
                Debug.Log("验证成功 uname--->" + user.NickName);
                Debug.Log("验证成功 ID--->" + adviseCourseUrl + user.token);
                if (userToken!=user.token)
                {
                    userToken = user.token;
                    userID = user.id;
                    NotifyLoginSucceed();
                    StartCoroutine(GetTodayCourse(adviseCourseUrl + user.token));
                    StartCoroutine(GetCourseType(courseTypeUrl));
                }
                isVerifySucceed = true;
            }
        }
        if (!isVerifySucceed||true)
        {
            StartCoroutine(LoopVerifyAuthorize(postUrl));
        }
    }
	/*IEnumerator PostData(WWW www)
	{
		yield return www;
		if(www.error != null) {
			Debug.Log("验证失败 "+www.error);
			run = true;
		} else {
			Debug.Log(www.text);
			Result result = JsonMapper.ToObject<Result>(www.text);

			if (result.Code == "200") {
				run = false;
				user = result.Detail;
				isShow =true ;
				ZxingDraw ._instance .CalCode ();
				Debug.Log("验证成功 uname--->" + user.NickName);
			} else if (result.Code == "201") {
				run = true;
				isShow =false ;
			}
			Debug .Log (result.Code+"status");
		}


		if (run) {
			ValidAuthorize();
		}
	}*/




//	void OnGUI()
//	{
//		if(GUILayout.Button("开始"))
//		{
//			StartAuthorize();
//		}
//
//		if(GUILayout.Button("停止"))
//		{
//			StopAuthorize();
//		}
//
//		GUI.DrawTexture(new Rect(100, 100,256,256), encoded);
//	}
}
