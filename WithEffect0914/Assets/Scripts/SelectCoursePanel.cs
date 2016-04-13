using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CourseDetail;
using DG.Tweening;

public class ShowMovieInfo
{

    //public string pushtime;
    //public int id;
    public string videourl;
    public string xmlUrl;
    public string audioUrl;
    public string courselogo;
    public int courseid;
    //public string trainid;
    //public string traintime;
    public string coursename;
    public bool finished;
    public double calorie;
    public string describe;
    public bool isAbsolutePath;

}
public class SelectCoursePanel : MonoBehaviour
{
    public AutoGetSelectPot autoSelectInf = null;
    // Use this for initialization
    class CCourseInf
    {
        public CourseTypeInf cti;
        public int nID;
        public GameObject obj;
        public int nTypeID;
        public bool isSelect;
    }
    int nCount = 0;
    List<CCourseInf> lsCourse = new List<CCourseInf>();
    bool isCanGetInput = true;
    bool isLoadComp = true;


    public static SelectCoursePanel _instance;

    public GameObject CourseList;
    public GameObject CoursePrefab;

    void Awake()
    {
        _instance = this;
    }
    void OnEnable()
    {
        isCanGetInput = true;
        isLoadComp = true;
        if (autoSelectInf)
        {
            autoSelectInf.Init();
        }
    }
    void Start()
    {

        if (CourseList == null)
        {
            CourseList = transform.Find("CourseList").gameObject;
        }
        if (CourseList == null)
        {
            Debug.LogError("MovieList No Find");
        }
        autoSelectInf = CourseList.GetComponent<AutoGetSelectPot>();
        if (autoSelectInf)
        {
            autoSelectInf.OnSelectItem += CourseSelect;
            autoSelectInf.OnClickItem += SwitchCourse;
        }
        // CourseSelect(GetCourseById((int)_ECourseClassify.Advise));
    }
    void CourseSelect(Transform tr1, Transform tr2, int nIndex)
    {
        if (tr1 != null)
        {
            TweenScale ts = tr1.GetComponent<TweenScale>();
            if (ts)
            {
                ts.PlayReverse();
            }
        }
        if (tr2 != null)
        {
            TweenScale ts = tr2.GetComponent<TweenScale>();
            if (ts)
            {
                ts.PlayForward();
            }
        }
    }
    public void AddCourseToList(List<CourseTypeInf> lsSMI)
    {
        lsCourse.Clear();
        List<Transform> lsT = CourseList.GetComponent<UIGrid>().GetChildList();
        foreach (var item in lsT)
        {
            CourseList.GetComponent<UIGrid>().RemoveChild(item);
            Destroy(item.gameObject);
        }
        CourseList.transform.DetachChildren();
        isLoadComp = false;
        lsT.Clear();
        StartCoroutine(AddCourseToListByOrder(lsSMI));
    }

    IEnumerator AddCourseToListByOrder(List<CourseTypeInf> lsSMI)
    {
        yield return new WaitForSeconds(0.5f);
        //Debug.Log("lsSMI.Count is:"+lsSMI.Count);
        for (int i = 0; i < lsSMI.Count; i++)
        {
            GameObject obj = Instantiate(CoursePrefab) as GameObject;
            CourseList.GetComponent<UIGrid>().AddChild(obj.transform);
            obj.transform.localScale = Vector3.one;
            UILabel textUI = obj.transform.Find("CourseLabel").GetComponent<UILabel>();
            if (textUI)
            {
                textUI.text = lsSMI[i].name;
            }
            CCourseInf mif = new CCourseInf();
            mif.cti = lsSMI[i];
            mif.obj = obj;
            mif.nID = i;
            mif.isSelect = false;
            lsCourse.Add(mif);
            UISprite uiSpr = obj.GetComponent<UISprite>();
            if (uiSpr)
            {
                StarShadeColor(uiSpr);
            }

            //StartCoroutine(LoadMoviePic(obj, QRlogin.moviePicUrl + lsSMI[i].courselogo));
            yield return new WaitForSeconds(0.25f);
        }
        isLoadComp = true;
    }
    void StarShadeColor(UISprite uis)
    {
        UISprite uisb = uis;
        Color c = new Color();
        c.b = Random.Range(0.0f, 1.0f);
        c.g = Random.Range(0.0f, 1.0f);
        c.r = Random.Range(0.0f, 1.0f);
        c.a = 1;
        uisb.color = new Color(c.r, c.g, c.b, 0);
        DOTween.To(() => uisb.color, x => uisb.color = x, c, 2f);
    }
    // Update is called once per frame
    void Update()
    {
        if (isCanGetInput)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("ESC");
                MaskPanel.HideMask();
                StopAllCoroutines();
                isCanGetInput = false;
                UiManage.UIShowByPanel(UiManage._instance.userInforPannel, gameObject, 0.5f, 0.5f);
            }
        }
    }
    IEnumerator LoadMovieListById(int nID)
    {
        string strUrl = QRlogin.courseMovieByTypeUrl + nID;
        Debug.Log("LoadMovieList:"+strUrl);
        while (true)
        {
            WWW www = new WWW(strUrl);
            yield return www;
            if (www.error == null)
            {
                isCanGetInput = false;
                LitJson.JsonMapper.ToObject<CourseDetailArr_2>(www.text);
                if (CourseDetailArr_2._Instance.detail != null && CourseDetailArr_2._Instance.description == "success")
                {
                    MaskPanel.HideMask();
                    CourseDetailArr_2._Instance.IsInitOk = true;
                    List<ShowMovieInfo> lsSMI = new List<ShowMovieInfo>();
                    lsSMI.Clear();
                    foreach (var item in CourseDetailArr_2._Instance.detail)
                    {
                        ShowMovieInfo smi = new ShowMovieInfo();
                        double.TryParse(item.calorie, out smi.calorie);

                        smi.courselogo = item.logo;
                        smi.coursename = item.coursename;
                        smi.isAbsolutePath = true;
                        smi.xmlUrl = "c:/course/" + item.video.Split('.')[0] + ".xml";
                        //smi.id = cp.id;
                        //smi.pushtime = cp.pushtime;
                        smi.audioUrl = "c:/course/" + item.video.Split('.')[0] + ".mp3";
                       // smi.finished = item.finished;
                        smi.videourl = "c:/course/" + item.video.Split('.')[0] + ".ogg";
                        smi.describe = item.coursedescrip;

                        Debug.Log(smi.coursename + "<-->" + smi.videourl);
                        lsSMI.Add(smi);
                    }
                    UiManage.UIShowByPanel(UiManage._instance.selectMoviePanel, gameObject, 1, 1);
                    //SelectMoviePlanel smp = UiManage._instance.selectMoviePanel as SelectMoviePlanel;
                    SelectMoviePanel._instance.AddMovieToList(lsSMI);
                    break;
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
    void SwitchCourse(Transform trans, int nIndex)
    {
        CCourseInf ci = null;
        foreach (var item in lsCourse)
        {
            if (item.obj.transform == trans)
            {
                ci = item;
            }
        }
        //Debug.Log("lscourse len>" + lsCourse.Count + "<>" + ci.cti.name + "<>" + isCanGetInput);
        if (ci != null && isCanGetInput)
        {
            if (autoSelectInf)
            {
                autoSelectInf.SetInputInvain();
            }
            MaskPanel.ShowMask();
            isCanGetInput = false;
            if (ci.cti.nID == -1)
            {
                Debug.Log("郑多燕");
                if (CourseDetail.CourseDetailArr.Instance != null && CourseDetail.CourseDetailArr.Instance.IsInitOk)
                {
                    MaskPanel.HideMask();
                    List<ShowMovieInfo> lsSMI = new List<ShowMovieInfo>();
                    lsSMI.Clear();
                    isCanGetInput = false;
                    /*ShowMovieInfo smi2 = new ShowMovieInfo();
                    smi2.calorie = 10;
                    smi2.videourl = "MovieSamples/zdy2min.ogv";
                    smi2.courselogo = "";
                    smi2.unfinished = false;
                    smi2.coursename = "郑多燕";
                    smi2.xmlUrl = "MovieSamples/level.xml";
                    lsSMI.Add(smi2);*/
                    foreach (var item in CourseDetailArr.Instance.detail)
                    {
                        CoursePush cp = item.coursePush;
                        ShowMovieInfo smi = new ShowMovieInfo();
                        smi.calorie = cp.calorie;
                        smi.courseid = cp.courseid;
                        smi.courselogo = cp.courselogo;
                        smi.coursename = cp.coursename;
                        smi.describe = cp.coursedescrip;
                       // smi.describe = "test";
                       // smi.coursename = "nk s";
                       // cp.videourl="1/11/42.mp4";

                        smi.isAbsolutePath = true;
                        smi.xmlUrl = "c:/course/" + cp.videourl.Split('.')[0] + ".xml";
                        //smi.id = cp.id;
                        //smi.pushtime = cp.pushtime;
                        smi.audioUrl = "c:/course/" + cp.videourl.Split('.')[0] + ".mp3";
                        smi.finished = cp.finished;
                        smi.videourl = "c:/course/" + cp.videourl.Split('.')[0] + ".ogg";

                        Debug.Log(smi.coursename + "<-->" + smi.videourl);
                        lsSMI.Add(smi);
                    }
                    UiManage.UIShowByPanel(UiManage._instance.selectMoviePanel, gameObject, 1, 1);
                    //SelectMoviePlanel smp = UiManage._instance.selectMoviePanel as SelectMoviePlanel;
                    SelectMoviePanel._instance.AddMovieToList(lsSMI);
                }
            }
            else
            {
                StartCoroutine(LoadMovieListById(ci.cti.nID));
            }
        }
    }

}
