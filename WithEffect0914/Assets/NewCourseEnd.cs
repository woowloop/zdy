using UnityEngine;
using System.Collections;

public class NewCourseEnd : MonoBehaviour {

    public static NewCourseEnd _instance;
	//private GameObject version;
    private Scoring_Tony1 st1;
    UILabel kcalNum, scoreNum;
    UISprite timeRing, scoreRing;
    bool showTimeRate = false,
    showScoreRate = false;
	//showCurve=false;
    public CurveScore curveScore;

    void Awake()
    {
        _instance = this;
        st1 = GameObject.FindObjectOfType(typeof(Scoring_Tony1)) as Scoring_Tony1;
        kcalNum=transform.Find("Kcal/Num").GetComponent<UILabel>();
        scoreNum = transform.Find("Score/Num").GetComponent<UILabel>();
        timeRing = transform.Find("Time").GetComponent<UISprite>();
        scoreRing = transform.Find("Score").GetComponent<UISprite>();
        //version  = GameObject.Find("Version");
        TestMobileTexture._instance.OnMoviePlayFinsh += Show;
        gameObject.SetActive(false);
    }
    
    void Start () {
	}
	

	void Update () {

        //print("Scoring_Tony1.scorenum" + Scoring_Tony1.scorenum);

        ////按下方向左键，返回，按下方向右键，进入回放界面
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    Return();
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    //显示回放界面方法
        //  //  Feedback._instance.ShowPlayer();
        //    //显示曲线界面
        //    curveScore.SetActive(true);
        //    gameObject.SetActive(false);
        //}
        kcalNum.text = Scoring_Tony1.scorenum/10 + "";
        scoreNum.text = (Scoring_Tony1.scorenum / 3.6f) .ToString("f0");
        Debug.Log("ST:"+Scoring_Tony1.scorenum);
        if (showTimeRate==false)
        {
            print("时间可以开始跑了");
        //time圆环跑到50%
        timeRing.fillAmount +=0.25f * Time.deltaTime;
        if (0.5f - timeRing.fillAmount < 0.01f)
        {
            //print("时间可以停止跑了");
            timeRing.fillAmount = 0.5f;
            showTimeRate = true;
        }
        }
        if (showScoreRate == false)
        {
            print("正确率可以开始跑了");
            scoreRing.fillAmount +=Scoring_Tony1.scorenum / 360f * Time.deltaTime;
            if (Scoring_Tony1.scorenum / 360f - scoreRing.fillAmount < 0.01f)
            {
                //print("正确率可以停止跑了");
                scoreRing.fillAmount = Scoring_Tony1.scorenum / 360f;
                showScoreRate = true;
            }
        }

	}
    //显示方法
    public void Show()
    {
        gameObject.SetActive(true);
        StartCoroutine(AutoCurveScore());
		//version.SetActive (false);
    }
    //返回方法
    /*
    public void Return()
    {
        //重新播放
        //st1.Isplay = true;
        //清空列表
        // ScreenRgb._instance.list2.Clear();
        //Feedback._instance.missPics.Clear();
        //清空小图片列表方法
        //Feedback._instance.ClearSmallPic();

//        TestMobileTexture._instance.AutoPlayVideo();
//        ScreenRgb._instance.StartShowCam();
    }*/
    //等待2秒，自动进入曲线界面
    IEnumerator AutoCurveScore()
    {
        yield return new WaitForSeconds(5);
        //显示曲线界面
        curveScore.Show();
        showTimeRate = false;
        showScoreRate = false;
        timeRing.fillAmount = 0;
        scoreRing.fillAmount = 0;
        gameObject.SetActive(false);
        

    }
}
