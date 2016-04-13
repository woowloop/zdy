using UnityEngine;
using System.Collections;
using MMT;

[RequireComponent(typeof(MobileMovieTexture))]
public class CourseEnd : MonoBehaviour {

    public static CourseEnd _instance;
    UILabel calorie;
    private Scoring_Tony1 st1;
    public MobileMovieTexture mobileMovieTexture;
    public bool isReturn = false;
    GameObject feedback;

    void Awake()
    {
        _instance = this;
        calorie=transform.Find("Calorie").GetComponent<UILabel>();
        gameObject.SetActive(false);
        st1 = GameObject.FindObjectOfType(typeof(Scoring_Tony1)) as Scoring_Tony1;
        feedback = transform.parent.transform.Find("Feedback").gameObject;
    }
    
    void Start () {
	
	}
	
	
	void Update () {
       

	}
    //显示方法
    public void Show()
    {
        gameObject.SetActive(true);
        calorie.text = Scoring_Tony1.scorenum + "";
    }
    public void OnNextClick()
    {
        //显示回放界面方法
        Feedback._instance.ShowPlayer();
        gameObject.SetActive(false);
    }
    //点击返回方法
    public void Return()
    {
       // isReturn = true;
        //重新播放
        st1.Isplay = true;
        //清空列表
       // ScreenRgb._instance.list2.Clear();

        Feedback._instance.missPics.Clear();
        //清空小图片列表方法
        Feedback._instance.ClearSmallPic();
        

        gameObject.SetActive(false);
       
    }
}
