using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class AddTexture : MonoBehaviour
{
    class ShowTexInf
    {
        public int wrongCount;
        public int completeCount;
        public string recordTime;
        public string calorie;
        public string courseName;
        public int nIndex;
        public Texture2D userPic;
        public Texture2D moviePic;
    }
    public static AddTexture _instance;
    public AutoGetSelectPot autoSelectInf = null;
    // public UIGrid gird;
    public GameObject towPicShowPre;
    public GameObject picListGrid;
    //public GameObject texture;
    //public GameObject prefab;
    // public List<Texture2D> maint = new List<Texture2D>();
    // public List<Texture2D> maint1 = new List<Texture2D>();
    public List<GameObject> label1 = new List<GameObject>();
    //  public GameObject a1;
    public List<GameObject> label2 = new List<GameObject>();
    //private Scoring_Tony1 st;
    // public int j = -1, k = -1;
    public TweenScale thispannal;
    public GameObject pannal;

    public UILabel dateLable;
    public UILabel desLable;
    public UILabel correctInfLable;
    //public GameObject texturebig1,texturebig2;
    private UITexture textureBigUser;
    private UITexture textureBigMovie;
    private TweenAlpha bigUserAlpha;
    private TweenAlpha bigMovieAlpha;
    bool isShowBigPic = false;

    List<ShowTexInf> lsPicInf = new List<ShowTexInf>();

    private bool isHistoryView = false;
    int hisPicMaxIndex=1;
    int hisPicIndex = 1;
    Coroutine myCRForLoopLoadHisPic=null;
    bool isLoadingHisPic = false;
    //private bool isDownLoad = false;
    void Awake()
    {
        textureBigUser = transform.Find("Panel/bigTextureUser").GetComponent<UITexture>();
        textureBigMovie = transform.Find("Panel/bigTextureMovie").GetComponent<UITexture>();
        bigUserAlpha = transform.Find("Panel/bigTextureUser").GetComponent<TweenAlpha>();
        bigMovieAlpha = transform.Find("Panel/bigTextureMovie").GetComponent<TweenAlpha>();
        HidebigTure();
        _instance = this;
    }
    // Use this for initialization
    void Start()
    {
        if (picListGrid == null)
        {
            picListGrid = transform.Find("PicListGrid").gameObject;
        }
        if (picListGrid == null)
        {
            Debug.LogError("picListGrid No Find");
        }
        else
        {
            autoSelectInf = picListGrid.GetComponent<AutoGetSelectPot>();
            if (autoSelectInf)
            {
                autoSelectInf.OnSelectItem += SelectPic;
                autoSelectInf.OnClickItem += ShowbigTure;
                autoSelectInf.OnToTheEndItemEvent += LoadNextPage;
            }
        }
    }
    void SelectPic(Transform tr1, Transform tr2, int nIndex)
    {
        HidebigTure();
//        Debug.Log(nIndex+"::" + lsHisTexInf.Count);
        if (nIndex < lsPicInf.Count)
        {
            if (dateLable && desLable && correctInfLable)
            {
                dateLable.text = "日期:" + lsPicInf[nIndex].recordTime;
                desLable.text = "课程:" + lsPicInf[nIndex].courseName + "\n共消耗卡路里:" + lsPicInf[nIndex].calorie + "\n错误:" + lsPicInf[nIndex].wrongCount + "个";
            }
        }
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
    public void ShowbigTure(Transform tra, int index)
    {
        if (isLoadingHisPic)
        {
            return;
        }
        isShowBigPic = true;/*
        List<Texture2D>[] lsPicArr;
        if (isHistoryView)
        {
            lsPicArr = HistoryPicture._instance.lsHisPicArr;
        }
        else
            lsPicArr = Scoring_Tony1._instance.picArr;*/

        if (index < lsPicInf.Count && gameObject.activeSelf)
        {
            pannal.SetActive(true);
            textureBigUser.mainTexture = lsPicInf[index].moviePic;
            textureBigMovie.mainTexture = lsPicInf[index].userPic;
        }
     /*   if (lsPicArr != null && lsPicArr.Length == 2)
        {
            if (gameObject.activeSelf && index < lsPicArr[(int)_EPISORT.USER].Count && index < lsPicArr[(int)_EPISORT.MOVIE].Count)
            {
                pannal.SetActive(true);
                textureBigUser.mainTexture = lsPicArr[(int)_EPISORT.MOVIE][index];
                textureBigMovie.mainTexture = lsPicArr[(int)_EPISORT.USER][index];
            }
        }*/

    }
    public void LoadNextPage(Transform trs, int index)
    {
        if (isHistoryView && !isLoadingHisPic && hisPicIndex < hisPicMaxIndex)
        {
            Debug.Log("ent nextPage");
            MaskPanel.ShowMask();
            myCRForLoopLoadHisPic = StartCoroutine(LoopLoadHisPic(++hisPicIndex));
        }
    }
    public void HidebigTure()
    {
        isShowBigPic = false;
        pannal.SetActive(false);
        //texturebig1.gameObject .SetActive (false  );
        //texturebig2.gameObject .SetActive (false  );

    }
    // Update is called once per frame
    //初始化label的方法
    public void InitLabel()
    {
        thispannal.PlayForward();
        for (int a = 0; a < Scoring_Tony1._instance.picArr[(int)_EPISORT.USER].Count; a++)
        {
            if (a < 5)
            {
                label1[a].SetActive(true);
                label2[a].SetActive(true);
            }
        }
        for (int i = Scoring_Tony1._instance.picArr[(int)_EPISORT.USER].Count; i < 5; i++)
        {
            label1[i].SetActive(false);
            label2[i].SetActive(false);
        }

        for (int a = 0; a < 5; a++)
        {
            if (a < 5)
            {
                label1[a].SetActive(true);
                label2[a].SetActive(true);
            }
        }
    }
    public void InitLabelHisPic()
    {
        thispannal.PlayForward();
        for (int a = 0; a < lsPicInf.Count; a++)
        {
            if (a < 5)
            {
                label1[a].SetActive(true);
                label2[a].SetActive(true);
            }
        }
        for (int i = lsPicInf.Count; i < 5; i++)
        {
            label1[i].SetActive(false);
            label2[i].SetActive(false);
        }

        for (int a = 0; a < 5; a++)
        {
            if (a < 5)
            {
                label1[a].SetActive(true);
                label2[a].SetActive(true);
            }
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isShowBigPic)
            {
                HidebigTure();
            }
            else
            {
                ClearAndExit();
            }
        }
    }
    //关闭图片页面的方法
    IEnumerator DelaySet()
    {
        yield return new WaitForSeconds(0.25f);
        CurveScore._instance.isCanEsc = true;
    }
    IEnumerator HidePannal(GameObject go)
    {
        yield return new WaitForSeconds(0.6f);
        go.SetActive(false);
    }
    public void ClearAndExit()
    {
        List<GameObject> lst = new List<GameObject>();
        for (int i = 0; i < picListGrid.transform.childCount; i++)
        {
            lst.Add(picListGrid.transform.GetChild(i).gameObject);
        }
        foreach (var item in lst)
        {
            Destroy(item);
        }
        lst.Clear();
        picListGrid.transform.DetachChildren();
        lsPicInf.Clear();
        MaskPanel.HideMask();
        StopAllCoroutines();
        HidebigTure();
        thispannal.PlayReverse();
        StartCoroutine(DelaySet());
    }
    IEnumerator LoopLoadHisPic(int nPage)
    {
        isLoadingHisPic = true;
        yield return null;
        string strUrl = QRlogin.getHisPicInfUrl + QRlogin.UserToken + "&index=" + nPage;
        Debug.Log(strUrl);
        WWW www = new WWW(strUrl);
        yield return www;
        if (www.error == null)
        {
            LitJson.JsonMapper.ToObject<CourseDetail.HisPicInf>(www.text);
            if (CourseDetail.HisPicInf._Instance != null && CourseDetail.HisPicInf._Instance.description == "success")
            {
                MaskPanel.HideMask();
                string calorie;
                int completeCount;
                string courseName;
                string recordTime;
                int wrongCount;
                hisPicMaxIndex = CourseDetail.HisPicInf._Instance.detail.totalPage;
                //for (int i = 0; i < CourseDetail.HisPicInf._Instance.detail.list.Count; i++)
                for (int i = 0; i < 2; i++)
                {
                    calorie = CourseDetail.HisPicInf._Instance.detail.list[i].calorie;
                    completeCount = CourseDetail.HisPicInf._Instance.detail.list[i].completecount;
                    courseName = CourseDetail.HisPicInf._Instance.detail.list[i].coursename;
                    recordTime = CourseDetail.HisPicInf._Instance.detail.list[i].recordtime.Replace(':', '-');
                    wrongCount = CourseDetail.HisPicInf._Instance.detail.list[i].wrongcount;
                    if (nPage==1)
                    {
                        recordTime = "2016-4-12 15:39:1";
                    }
                    if (nPage==2)
                    {
                        recordTime = "2016-4-12 15:43:7";
                    }
                    string path = Application.persistentDataPath + "/" + QRlogin.UserID + "/" + recordTime.Replace(':', '-');
                    //string path = Application.persistentDataPath + "/" + "29fe17471ff14e38bf80c967ba379eb1" + "/" + recordTime.Replace(':', '-'); ;
                   // Debug.Log("path:" + path);
                    if (System.IO.Directory.Exists(path))
                    {
                        for (int j = 0; ; j++)
                        {
                            string pathSub = path + "/" + j.ToString() + ".jpg";
                            string pathSub2 = path + "/" + j.ToString() + "_T" + ".jpg";
                            if (System.IO.File.Exists(pathSub) && System.IO.File.Exists(pathSub2))
                            {
                                yield return new WaitForSeconds(0.1f);
                                WWW wwwSub = new WWW("file:///" + pathSub);
                                WWW wwwSub2 = new WWW("file:///" + pathSub2);
                                yield return wwwSub;
                                yield return wwwSub2;
                                if (wwwSub.error == null && wwwSub2.error == null)
                                {
                                    ShowTexInf sti = new ShowTexInf();
                                    sti.calorie = calorie;
                                    sti.completeCount = completeCount;
                                    sti.recordTime = recordTime;
                                    sti.wrongCount = wrongCount;
                                    sti.courseName = courseName;
                                    sti.nIndex = j;
                                    sti.userPic = wwwSub.texture;
                                    sti.moviePic = wwwSub2.texture;
                                    UIGrid uiGridForPicList = picListGrid.GetComponent<UIGrid>();
                                    if (uiGridForPicList && towPicShowPre)
                                    {
                                        GameObject obj = NGUITools.AddChild(picListGrid, towPicShowPre);
                                        UITexture uiUserPic = obj.transform.FindChild("UserPic").GetComponent<UITexture>();
                                        UITexture uiMoviePic = obj.transform.FindChild("MoviePic").GetComponent<UITexture>();
                                        UILabel lab = obj.transform.FindChild("NumLabel").GetComponent<UILabel>();
                                        uiUserPic.mainTexture = sti.userPic;
                                        uiMoviePic.mainTexture = sti.moviePic;
                                        lsPicInf.Add(sti);

                                        lab.text = (lsPicInf.Count + 1).ToString("000");
                                        obj.name = lsPicInf.Count.ToString("000");
                                        uiGridForPicList.repositionNow = true; 
                                        UiManage.ShadeColorForUITex(uiUserPic);
                                        UiManage.ShadeColorForUITex(uiMoviePic);
                                    }
                                    else
                                    {
                                        Debug.LogError("uiGridForPicList/towPicShowPre is Empty");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                isLoadingHisPic = false;
            }
        }
        else
        {
            myCRForLoopLoadHisPic=StartCoroutine(LoopLoadHisPic(nPage));
        }
    }
    public void OnHisChoose()
    {
        CurveScore._instance.isCanEsc = false;
        if (autoSelectInf)
        {
            autoSelectInf.Init();
        }
        lsPicInf.Clear();
        hisPicIndex = 1;
        hisPicMaxIndex = 1;
        isHistoryView = true;
        HidebigTure();
        thispannal.PlayForward();
        MaskPanel.ShowMask();
        myCRForLoopLoadHisPic=StartCoroutine(LoopLoadHisPic(hisPicIndex));
        InitLabelHisPic();
    }
    public void OnDetailsChoose()
    {
        CurveScore._instance.isCanEsc = false;
        if (autoSelectInf)
        {
            autoSelectInf.Init();
        }
        lsPicInf.Clear();
        hisPicIndex = 1;
        hisPicMaxIndex = 1;
        isHistoryView = false;
        HidebigTure();
        LoadCurPic();
        //invisible();
        thispannal.PlayForward();
    }
    void LoadCurPic()
    {
        if (towPicShowPre && picListGrid && Scoring_Tony1._instance.picArr[(int)_EPISORT.USER].Count == Scoring_Tony1._instance.picArr[(int)_EPISORT.MOVIE].Count)
        {
            for (int i = 0; i < Scoring_Tony1._instance.picArr[(int)_EPISORT.USER].Count; i++)
            {
                GameObject obj = NGUITools.AddChild(picListGrid, towPicShowPre);
                UITexture uiUserPic = obj.transform.FindChild("UserPic").GetComponent<UITexture>();
                UITexture uiMoviePic = obj.transform.FindChild("MoviePic").GetComponent<UITexture>();
                UILabel lab = obj.transform.FindChild("NumLabel").GetComponent<UILabel>();
                lab.text = (i + 1).ToString("000");
                obj.name = i.ToString("000");
                uiUserPic.mainTexture = Scoring_Tony1._instance.picArr[(int)_EPISORT.USER][i];
                uiMoviePic.mainTexture = Scoring_Tony1._instance.picArr[(int)_EPISORT.MOVIE][i];
                picListGrid.GetComponent<UIGrid>().repositionNow = true;

                ShowTexInf sti = new ShowTexInf();
                sti.completeCount = 1;
                sti.recordTime = QRlogin.CurTime;
                sti.wrongCount = Scoring_Tony1._instance.num1 + Scoring_Tony1._instance.num2 + Scoring_Tony1._instance.num3 + Scoring_Tony1._instance.num4 + Scoring_Tony1._instance.num5;
                sti.nIndex = i;
                sti.courseName = Scoring_Tony1._instance.curMovieName;
                sti.userPic = Scoring_Tony1._instance.picArr[(int)_EPISORT.USER][i];
                sti.moviePic = Scoring_Tony1._instance.picArr[(int)_EPISORT.MOVIE][i];
                lsPicInf.Add(sti);
               /* sti.calorie = calorie;
                sti.completeCount = completeCount;
                sti.recordTime = recordTime;
                sti.wrongCount = wrongCount;
                sti.courseName = courseName;
                sti.nIndex = j;
                sti.userPic = wwwSub.texture;
                sti.moviePic = wwwSub2.texture;*/
            }
        }
    }
    /*void invisible()
    {
        if (towPicShowPre && picListGrid && Scoring_Tony1._instance.picArr[(int)_EPISORT.USER].Count == Scoring_Tony1._instance.picArr[(int)_EPISORT.MOVIE].Count)
        {
            for (int i = 0; i < Scoring_Tony1._instance.picArr[(int)_EPISORT.USER].Count; i++)
            {
                GameObject obj = NGUITools.AddChild(picListGrid, towPicShowPre);
                UITexture uiUserPic = obj.transform.FindChild("UserPic").GetComponent<UITexture>();
                UITexture uiMoviePic = obj.transform.FindChild("MoviePic").GetComponent<UITexture>();
                UILabel lab = obj.transform.FindChild("NumLabel").GetComponent<UILabel>();
                lab.text = (i + 1).ToString("000");
                obj.name = i.ToString("000");
                uiUserPic.mainTexture = Scoring_Tony1._instance.picArr[(int)_EPISORT.USER][i];
                uiMoviePic.mainTexture = Scoring_Tony1._instance.picArr[(int)_EPISORT.MOVIE][i];
            }
            picListGrid.GetComponent<UIGrid>().repositionNow = true;
        }
    }*/
   /* void invisibleHisPic()
    {
        //Debug.Log("ent hispic " + HistoryPicture._instance.lsHisPicArr[(int)_EPISORT.USER].Count);
        if (towPicShowPre && picListGrid && HistoryPicture._instance.lsHisPicArr[(int)_EPISORT.USER].Count == HistoryPicture._instance.lsHisPicArr[(int)_EPISORT.MOVIE].Count)
        {
            for (int i = 0; i < HistoryPicture._instance.lsHisPicArr[(int)_EPISORT.USER].Count; i++)
            {
                GameObject obj = NGUITools.AddChild(picListGrid, towPicShowPre);
                UITexture uiUserPic = obj.transform.FindChild("UserPic").GetComponent<UITexture>();
                UITexture uiMoviePic = obj.transform.FindChild("MoviePic").GetComponent<UITexture>();
                UILabel lab = obj.transform.FindChild("NumLabel").GetComponent<UILabel>();
                lab.text = (i + 1).ToString("000");
                obj.name = i.ToString("000");
                uiUserPic.mainTexture = HistoryPicture._instance.lsHisPicArr[(int)_EPISORT.USER][i];
                uiMoviePic.mainTexture = HistoryPicture._instance.lsHisPicArr[(int)_EPISORT.MOVIE][i];
            }
            picListGrid.GetComponent<UIGrid>().repositionNow = true;
            InitLabelHisPic();
        }
    }*/
}
