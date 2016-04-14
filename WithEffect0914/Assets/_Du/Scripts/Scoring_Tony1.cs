using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using OpenNI;
using MMT;
using System.IO;

public enum _EPISORT
{
    USER = 0,
    MOVIE = 1
}
public class Scoring_Tony1 : MonoBehaviour
{
    public List<LevelsCtrl> levels;//关卡实例
    //public NISkeletonController nsc;
    //public GameObject TPOSS;
    //保存图片的临时变量
    //private Texture2D _mytexture;
    //private int NamePic=0;
    //private int num=0;
    public PlayerPixels pp;
    public TopScore topscore;
    private Transform FootcolParent;//cube的父物体
    private Transform ElbowcolParent;
    private Transform HeadcolParent;
    private Transform ShouldercolParent;
    private Transform HandcolParent;
    private Transform KneecolParent;
    //public UISprite version;
    private List<GameObject> childCubes = new List<GameObject>();//用来存储实例化出来的cube
    //public float playtime = 0;//视频播放的时间
    public GradeHandle_Tony _root;
    public static int lianji = 0;
    public int num1 = 0, num2 = 0, num3 = 0, num4 = 0, num5 = 0, num6 = 0;
    public int num11 = 0, num22 = 0, num33 = 0, num44 = 0, num55 = 0, num66 = 0;
    //public HUDText hudtext;
    bool isCanDetection = true;
    float Movetime;
    float Effecttime;
    public GameObject scoreeffect;
    InstrumentPanel ip;
   // int[] message;
    bool IsStart;
    public bool Isplay;

    public bool IsSave = false;

    public GameObject ShenDuTu;
    public GameObject misseffect;
    public GameObject goodeffect;
    public GameObject greateffect;
    public GameObject perfecteffect;
    public NumCrtl score;
    public NumCrtl bestscore;
    public static int scorenum = 0;
   // private int j;
    private float dtime = 1;
    //public MobileMovieTexture _mmt;
    public bool isHeadDirX = false;
    public bool isHeadDirY = false;
    public bool isHeadDirZ = false;
    public bool isHeadDirXY = false;
    public bool isHeadDirYZ = false;
    public bool isHeadDirXZ = false;
    public bool isHeadDirXYZ = false;

    public bool isHandDirX = false;
    public bool isHandDirY = false;
    public bool isHandDirZ = false;
    public bool isHandDirXY = false;
    public bool isHandDirYZ = false;
    public bool isHandDirXZ = false;
    public bool isHandDirXYZ = false;

    public bool isElbowDirX = false;
    public bool isElbowDirY = false;
    public bool isElbowDirZ = false;
    public bool isElbowDirXY = false;
    public bool isElbowDirYZ = false;
    public bool isElbowDirXZ = false;
    public bool isElbowDirXYZ = false;

    public bool isShoulderDirX = false;
    public bool isShoulderDirY = false;
    public bool isShoulderDirZ = false;
    public bool isShoulderDirXY = false;
    public bool isShoulderDirYZ = false;
    public bool isShoulderDirXZ = false;
    public bool isShoulderDirXYZ = false;

    public bool isFootDirX = false;
    public bool isFootDirY = false;
    public bool isFootDirZ = false;
    public bool isFootDirXY = false;
    public bool isFootDirYZ = false;
    public bool isFootDirXZ = false;
    public bool isFootDirXYZ = false;

    public bool isKneeDirX = false;
    public bool isKneeDirY = false;
    public bool isKneeDirZ = false;
    public bool isKneeDirXY = false;
    public bool isKneeDirYZ = false;
    public bool isKneeDirXZ = false;
    public bool isKneeDirXYZ = false;

    public bool hasshowhandl = false;
    public bool hasshowhandr = false;
    public bool hasshowelbowl = false;
    public bool hasshowelbowr = false;
    public bool hasshowshoulderl = false;
    public bool hasshowshoulderr = false;
    public bool hasshowkneel = false;
    public bool hasshowkneer = false;
    public bool hasshowfootl = false;
    public bool hasshowfootr = false;
    public bool hasshowhead = false;

    public Transform torso;
    public bool canplay;
    public bool ismiss;
    public string curMovieName="";//在TestMovileTexture中赋值



    private float misstimer = 0.2f;
    private float misstime = 0.2f;
    MissPic missPic;
    private ShowEuler showeuler;
    private Transform gradeEffectPosition;
    //public static List<int> missPicsList = new List<int>();
    //public static List<float> missStartTimeList = new List<float>();
    //float missStartTime;
    //int missPicId;
    public GameObject combolabel;
    private GameObject uiroot;
    public static bool zhuanye = true;
    public static bool zhuangye2 = false;
    //int oo = 0;
    public GameObject Effectplanekk;
    public GameObject effect2;
    public GameObject RGB;
    public GameObject Planyz;
    public GameObject Elur;
    MeshRenderer planeYZRender;
    public static bool badE = false;
    public static bool goodE = false;
    public static bool greatE = false;
    public static bool perfectE = false;
    private bool ishasphoto;
    int nDetectMotionIndex = 0;
    int nPerDetectMotionIndex = -1;
    [HideInInspector]
    //public List<float> realtimes;

    public List<Texture2D>[] picArr = new List<Texture2D>[2];
    //[HideInInspector]
    //public List<Texture2D> realtexs = new List<Texture2D> ();
    //[HideInInspector]
    //public List<Texture2D> realusetexs = new List<Texture2D>();
    ///[HideInInspector]
    //public List<Texture2D> movieusetexs = new List<Texture2D>();

    public float usertime = 0f;
    //public List<int> missindexs = new List<int>(); 
    //public List<string > missstring = new List<string >(); 
    //public bool isrecord = false;
    //public Material blend;
    //public Material noblend;
    public static bool isCompleteCreatePic = false;
    public static Scoring_Tony1 _instance;

    private Coroutine LoopCalcCr=null;
    void Awake()
    {
        missPic = GameObject.FindWithTag("MissPic").GetComponent<MissPic>();
        gradeEffectPosition = transform.Find("GradeEffectPosition");
        showeuler = GameObject.Find("JointSpheres").GetComponent<ShowEuler>();
        uiroot = GameObject.Find("UI Root");
        AvoidBlock();
        planeYZRender = Planyz.GetComponent<MeshRenderer>();
        picArr[(int)_EPISORT.USER] = new List<Texture2D>();
        picArr[(int)_EPISORT.MOVIE] = new List<Texture2D>();
        _instance = this;
    }
    void Start()
    {
        ip = GameObject.Find("star").GetComponent<InstrumentPanel>();
        FootcolParent = GameObject.Find("Footcolliders").transform;
        HandcolParent = GameObject.Find("Handcolliders").transform;
        HeadcolParent = GameObject.Find("Headcolliders").transform;
        ElbowcolParent = GameObject.Find("Elbowcolliders").transform;
        ShouldercolParent = GameObject.Find("Shouldercolliders").transform;
        KneecolParent = GameObject.Find("Kneecolliders").transform;
        //        _root = GameObject.Find("Root").GetComponent<GradeHandle_Tony>();
//         //message = new int[2];
//         if (_mmt==null)
//         {
//             _mmt = GameObject.Find("ViedoPlayerAndroid").GetComponent<MobileMovieTexture>();
//         }
        canplay = false;
        ismiss = false;
        ishasphoto = false;
        //realtimes = new List<float> (){37.6f,41.4f,45.1f,48.9f,51.8f,53.1f,55.6f,57.6f,59.5f,61.5f,63.4f,65.4f,68.3f,72.1f,75.9f,79.6f,82.4f,84.5f,86.3f,88f,
        //		90f,92.2f,93.9f,96.1f,98.9f,102.8f,106.5f,110.5f,113.3f,115.2f,117.1f,119.2f,121.0f,122.8f,124.77f,125.8f};
        EffectRgb();
//        CurveScore._instance.OnRestartGame += ReStart;
        TestMobileTexture._instance.OnMoviePlayFinsh += ClearAndSavePic;
        //SelectCoursePannel._instance.OnEnterGamePlay += CalcMotion;

        TestMobileTexture._instance.OnMoviePlayStart += CalcMotion;
        //TestMobileTexture._instance.o
        // InvokeRepeating("ScanMotion",0.2f,0.1f);
        //Time.timeScale=0.1f;
    }
    void CalcMotion()
    {

       // Feedback._instance.missPics.Clear();
        foreach (var item in picArr)
        {
            item.Clear();
        }
        usertime = 0f;
        num1 = 0;
        num2 = 0;
        num3 = 0;
        num4 = 0;
        num5 = 0;
        num6 = 0;
        num11 = 0;
        num22 = 0;
        num33 = 0;
        num44 = 0;
        num55 = 0;
        num66 = 0;
        nDetectMotionIndex = 0;
        nPerDetectMotionIndex = -1;
        StopCoroutine("LoopCalcMotion");
        LoopCalcCr=StartCoroutine(LoopCalcMotion());
    }
    IEnumerator LoopCalcMotion()
    {
//        Debug.Log("LoopCalcMotion");
        yield return new WaitForFixedUpdate();
        float m = GetMoveCubeNum(0, nDetectMotionIndex);
        //Debug.Log("::>"+levels[j].moves[n].endtime+0.1f);
       // Debug.Log(TestMobileTexture._instance.movieInf.movieCurProgress);
        if ((float)TestMobileTexture._instance.movieInf.movieCurProgress > (levels[0].moves[nDetectMotionIndex].endtime + 0.1f) && nDetectMotionIndex < levels[0].moves.Count)
        {
            #region
            if (isCanDetection)
            {
                isCanDetection = false;

                bool isTask = false;
                Effecttime = 1.5f;
                string temp = null;
                foreach (SingleMove s in levels[0].moves[nDetectMotionIndex].smoves)
                {
                    temp += "" + s.skeleton;
                }
                float grade1 = 0;
                if (temp.Contains("LeftHand"))
                {
                    num11++;
                    HandleAfterScoring(_root.lhandi);
                    grade1 += HandleAfterScoring(_root.lhandi) * m;
                    if (HandleAfterScoring(_root.lhandi) == 0)
                    {
                        showeuler.isshowWrongHandL = true;
                        num1++;
                        isTask = true;
                        //GetRealTex();
                    }
                }
                if (temp.Contains("RightHand"))
                {
                    num22++;
                    HandleAfterScoring(_root.rhandi);
                    grade1 += HandleAfterScoring(_root.rhandi) * m;
                    if (HandleAfterScoring(_root.rhandi) == 0)
                    {
                        showeuler.isshowWrongHandR = true;
                        num2++;
                        isTask = true;
                        //GetRealTex();
                    }
                }
                if (temp.Contains("LeftFoot"))
                {
                    num55++;
                    HandleAfterScoring(_root.lfooti);
                    grade1 += HandleAfterScoring(_root.lfooti) * m;
                    if (HandleAfterScoring(_root.lfooti) == 0)
                    {
                        showeuler.isshowWrongFootL = true;
                        num5++;
                        isTask = true;
                        //GetRealTex();
                    }
                }
                if (temp.Contains("RightFoot"))
                {
                    num66++;
                    HandleAfterScoring(_root.rfooti);
                    grade1 += HandleAfterScoring(_root.rfooti) * m;
                    if (HandleAfterScoring(_root.rfooti) == 0)
                    {
                        showeuler.isshowWrongFootR = true;
                        num6++;
                        isTask = true;
                        //GetRealTex();
                    }
                }

                if (temp.Contains("RightElbow"))
                {
                    num44++;
                    HandleAfterScoring(_root.relbowi);
                    grade1 += HandleAfterScoring(_root.relbowi) * m;
                    if (HandleAfterScoring(_root.relbowi) == 0)
                    {
                        showeuler.isshowWrongElbowR = true;
                        num4++;
                        isTask = true;
                        //GetRealTex();
                    }
                }
                if (temp.Contains("LeftElbow"))
                {
                    num33++;
                    HandleAfterScoring(_root.lelbowi);
                    grade1 += HandleAfterScoring(_root.lelbowi) * m;
                    if (HandleAfterScoring(_root.lelbowi) == 0)
                    {
                        showeuler.isshowWrongElbowL = true;
                        num3++;
                        isTask = true;
                        //GetRealTex();
                    }
                }
                if (temp.Contains("RightKnee"))
                {
                    HandleAfterScoring(_root.rkneei);
                    grade1 += HandleAfterScoring(_root.rkneei) * m;
                    if (HandleAfterScoring(_root.rkneei) == 0)
                    {
                        showeuler.isshowWrongKneeR = true;
                        isTask = true;
                        //GetRealTex();
                    }
                }
                if (temp.Contains("LeftKnee"))
                {
                    HandleAfterScoring(_root.lkneei);
                    grade1 += HandleAfterScoring(_root.lkneei) * m;
                    if (HandleAfterScoring(_root.lkneei) == 0)
                    {
                        showeuler.isshowWrongKneeL = true;
                        isTask = true;
                        //GetRealTex();
                    }
                }
                if (temp.Contains("RightShoulder"))
                {
                    HandleAfterScoring(_root.rshoulderi);
                    grade1 += HandleAfterScoring(_root.rshoulderi) * m;
                    if (HandleAfterScoring(_root.rshoulderi) == 0)
                    {
                        showeuler.isshowShoulderR = true;
                        isTask = true;
                        //GetRealTex();
                    }
                }
                if (temp.Contains("LeftShoulder"))
                {
                    HandleAfterScoring(_root.lshoulderi);
                    grade1 += HandleAfterScoring(_root.lshoulderi) * m;
                    if (HandleAfterScoring(_root.lshoulderi) == 0)
                    {
                        showeuler.isshowShoulderL = true;
                        isTask = true;
                        //GetRealTex();
                    }
                }
                if (temp.Contains("Head"))
                {
                    HandleAfterScoring(_root.headi);
                    grade1 += HandleAfterScoring(_root.headi) * m;
                    if (HandleAfterScoring(_root.headi) == 0)
                    {
                        showeuler.isshowWrongHead = true;
                        isTask = true;
                        //GetRealTex();
                    }
                }
                if (isTask)
                {
                    GetRealTex();
                }
                int grade = (int)Math.Floor(grade1);
                // ip.SendMessage("Receive", grade);
                HandleGrade(grade);
                if (grade == 0)
                {

                    //GameObject misseffectClone = Instantiate(misseffect, gradeEffectPosition.position, gradeEffectPosition.rotation) as GameObject;
                    //misseffectClone.transform.parent = gradeEffectPosition;
                    //misseffectClone.transform.localEulerAngles = Vector3.zero;
                    //misseffectClone.transform.localScale = Vector3.one;
                    if (zhuangye2 == true)
                    {
                        PlayerPixels._instance.backcolor.a = 0;
                        badE = true;
                    }
                    lianji = 0;
                    misseffect.SetActive(true);
                    StartCoroutine(HideEffect(misseffect));

                    //显示MISS图片方法
                    //missPic.ShowFlash();
                    //得到开始时间
                    //missStartTime = levels[0].moves[0].starttime;
                    //兑换成图片ID
                    //missPicId = (int)Math.Floor(1267 / 127 * missStartTime);
                    //把MISS的图片ID存入集合1
                    //把开始时间存入集合2
                    //missPicsList.Add(missPicId);
                    //missStartTimeList.Add(missStartTime);
                    ismiss = true;
                    StartCoroutine(WaitMissTime());
                }
                else if (grade > 0 && grade <= 5)
                {
                    lianji = 0;

                    //hudtext.Add("COMBO:"+lianji,Color.green,1f);
                    //							if(zhuanye ==false )
                    //							{
                    //							EffectPlane._instance.RandomEffect ();
                    //							}
                    if (zhuangye2 == true)
                    {
                        PlayerPixels._instance.backcolor.a = 0;
                        Debug.Log("zhuagye2");
                        goodE = true;
                    }
                    if (zhuanye == false)
                    {
                        EffectPlane._instance.GoodEffect();
                        Debug.Log("zhuagye2");
                    }
                    //							else
                    //							{
                    //								EffectPlane ._instance .HideALL();
                    //							}
                    goodeffect.SetActive(true);
                    StartCoroutine(HideEffect(goodeffect));

                }
                else if (grade > 5 && grade < 9)
                {
                    //GameObject greateffectClone = Instantiate(greateffect,gradeEffectPosition.position, gradeEffectPosition.rotation) as GameObject;
                    //greateffectClone.transform.parent = gradeEffectPosition;
                    //greateffectClone.transform.localEulerAngles = Vector3.zero;
                    //greateffectClone.transform.localScale = Vector3.one;
                    if (zhuangye2 == true)
                    {
                        PlayerPixels._instance.backcolor.a = 0;
                        greatE = true;
                    }
                    if (zhuanye == false)
                    {
                        lianji++;
                        AddCombo();
                        //hudtext.Add("COMBO:"+lianji,Color.green,1f);
                        //EffectPlane ._instance .RandomEffect ();
                        EffectPlane._instance.GreatEffect();
                        //EffectPlane ._instance .LianjiEffect ();
                    }
                    //							else
                    //							{
                    //								EffectPlane ._instance .HideALL();
                    //							}
                    greateffect.SetActive(true);
                    StartCoroutine(HideEffect(greateffect));
                }
                else
                {
                    //GameObject perfecteffectClone = Instantiate(perfecteffect, gradeEffectPosition.position, gradeEffectPosition.rotation) as GameObject;
                    //perfecteffectClone.transform.parent = gradeEffectPosition;
                    //perfecteffectClone.transform.localEulerAngles = Vector3.zero;
                    //perfecteffectClone.transform.localScale = Vector3.one;
                    if (zhuangye2 == true)
                    {
                        PlayerPixels._instance.backcolor.a = 0;

                        perfectE = true;
                    }
                    if (zhuanye == false)
                    {
                        lianji++;
                        AddCombo();
                        //hudtext.Add("COMBO:"+lianji,Color.green,1f);
                        //EffectPlane ._instance .RandomEffect ();
                        //EffectPlane ._instance .LianjiEffect ();
                        EffectPlane._instance.PerfectEffect();
                    }
                    //							else
                    //							{
                    //								EffectPlane ._instance .HideALL();
                    //							}
                    //EffectPlane ._instance .PerfectEffect ();
                    perfecteffect.SetActive(true);
                    StartCoroutine(HideEffect(perfecteffect));
                }
            }
            #endregion
        }
        int nCurIndex = GetMoveNum(0, (float)TestMobileTexture._instance.movieInf.movieCurProgress);
        if (nCurIndex != -1 && nPerDetectMotionIndex != nCurIndex)
        {
            nPerDetectMotionIndex = nDetectMotionIndex = nCurIndex;
            #region
            isCanDetection = true;
            Movetime = -1;
            _root.lhandi = "";
            _root.rhandi = "";
            _root.lfooti = "";
            _root.rfooti = "";
            _root.relbowi = "";
            _root.lelbowi = "";
            _root.rkneei = "";
            _root.lkneei = "";
            _root.rshoulderi = "";
            _root.lshoulderi = "";
            _root.headi = "";
            hasshowhandl = false;
            hasshowhandr = false;
            hasshowelbowl = false;
            hasshowelbowr = false;
            hasshowshoulderl = false;
            hasshowshoulderr = false;
            hasshowkneel = false;
            hasshowkneer = false;
            hasshowfootl = false;
            hasshowfootr = false;
            hasshowhead = false;
            if (HeadcolParent.childCount != 0)
            {
                foreach (GameObject g1 in childCubes)
                {
                    Destroy(g1);
                }
                childCubes.Clear();
            }
            if (ElbowcolParent.childCount != 0)
            {
                foreach (GameObject g1 in childCubes)
                {
                    Destroy(g1);
                }
                childCubes.Clear();
            }
            if (ShouldercolParent.childCount != 0)
            {
                foreach (GameObject g1 in childCubes)
                {
                    Destroy(g1);
                }
                childCubes.Clear();
            }
            if (KneecolParent.childCount != 0)
            {
                foreach (GameObject g1 in childCubes)
                {
                    Destroy(g1);
                }
                childCubes.Clear();
            }
            if (HandcolParent.childCount != 0)
            {
                foreach (GameObject g1 in childCubes)
                {
                    Destroy(g1);
                }
                childCubes.Clear();
            }
            if (FootcolParent.childCount != 0)
            {
                foreach (GameObject g1 in childCubes)
                {
                    Destroy(g1);
                }
                childCubes.Clear();
            }

            foreach (SingleMove sm1 in levels[0].moves[nDetectMotionIndex].smoves)
            {
                if (sm1.skeleton.ToString().Contains("Head"))
                {
                    //GetDir(sm1.dir,isHeadDirX,isHeadDirY,isHeadDirZ,isHeadDirXY,isHeadDirYZ,isHeadDirXZ,isHeadDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isHeadDirX = true;
                        isHeadDirY = false;
                        isHeadDirZ = false;
                        isHeadDirXY = false;
                        isHeadDirYZ = false;
                        isHeadDirXZ = false;
                        isHeadDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isHeadDirX = false;
                        isHeadDirY = true;
                        isHeadDirZ = false;
                        isHeadDirXY = false;
                        isHeadDirYZ = false;
                        isHeadDirXZ = false;
                        isHeadDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isHeadDirX = false;
                        isHeadDirY = false;
                        isHeadDirZ = true;
                        isHeadDirXY = false;
                        isHeadDirYZ = false;
                        isHeadDirXZ = false;
                        isHeadDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isHeadDirX = false;
                        isHeadDirY = false;
                        isHeadDirZ = false;
                        isHeadDirXY = true;
                        isHeadDirYZ = false;
                        isHeadDirXZ = false;
                        isHeadDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isHeadDirX = false;
                        isHeadDirY = false;
                        isHeadDirZ = false;
                        isHeadDirXY = false;
                        isHeadDirYZ = false;
                        isHeadDirXZ = true;
                        isHeadDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isHeadDirX = false;
                        isHeadDirY = false;
                        isHeadDirZ = false;
                        isHeadDirXY = false;
                        isHeadDirYZ = true;
                        isHeadDirXZ = false;
                        isHeadDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isHeadDirX = false;
                        isHeadDirY = false;
                        isHeadDirZ = false;
                        isHeadDirXY = false;
                        isHeadDirYZ = false;
                        isHeadDirXZ = false;
                        isHeadDirXYZ = true;
                    }
                    StartCoroutine(WaitHead(sm1));
                }
                if (sm1.skeleton.ToString().Contains("LeftHand"))
                {
                    //GetDir(sm1.dir,isHandDirX,isHandDirY,isHandDirZ,isHandDirXY,isHandDirYZ,isHandDirXZ,isHandDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isHandDirX = true;
                        isHandDirY = false;
                        isHandDirZ = false;
                        isHandDirXY = false;
                        isHandDirYZ = false;
                        isHandDirXZ = false;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isHandDirX = false;
                        isHandDirY = true;
                        isHandDirZ = false;
                        isHandDirXY = false;
                        isHandDirYZ = false;
                        isHandDirXZ = false;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isHandDirX = false;
                        isHandDirY = false;
                        isHandDirZ = true;
                        isHandDirXY = false;
                        isHandDirYZ = false;
                        isHandDirXZ = false;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isHandDirX = false;
                        isHandDirY = false;
                        isHandDirZ = false;
                        isHandDirXY = true;
                        isHandDirYZ = false;
                        isHandDirXZ = false;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isHandDirX = false;
                        isHandDirY = false;
                        isHandDirZ = false;
                        isHandDirXY = false;
                        isHandDirYZ = false;
                        isHandDirXZ = true;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isHandDirX = false;
                        isHandDirY = false;
                        isHandDirZ = false;
                        isHandDirXY = false;
                        isHandDirYZ = true;
                        isHandDirXZ = false;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isHandDirX = false;
                        isHandDirY = false;
                        isHandDirZ = false;
                        isHandDirXY = false;
                        isHandDirYZ = false;
                        isHandDirXZ = false;
                        isHandDirXYZ = true;
                    }
                    StartCoroutine(WaitLeftHand(sm1));
                }

                if (sm1.skeleton.ToString().Contains("RightHand"))
                {
                    //GetDir(sm1.dir,isHandDirX,isHandDirY,isHandDirZ,isHandDirXY,isHandDirYZ,isHandDirXZ,isHandDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isHandDirX = true;
                        isHandDirY = false;
                        isHandDirZ = false;
                        isHandDirXY = false;
                        isHandDirYZ = false;
                        isHandDirXZ = false;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isHandDirX = false;
                        isHandDirY = true;
                        isHandDirZ = false;
                        isHandDirXY = false;
                        isHandDirYZ = false;
                        isHandDirXZ = false;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isHandDirX = false;
                        isHandDirY = false;
                        isHandDirZ = true;
                        isHandDirXY = false;
                        isHandDirYZ = false;
                        isHandDirXZ = false;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isHandDirX = false;
                        isHandDirY = false;
                        isHandDirZ = false;
                        isHandDirXY = true;
                        isHandDirYZ = false;
                        isHandDirXZ = false;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isHandDirX = false;
                        isHandDirY = false;
                        isHandDirZ = false;
                        isHandDirXY = false;
                        isHandDirYZ = false;
                        isHandDirXZ = true;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isHandDirX = false;
                        isHandDirY = false;
                        isHandDirZ = false;
                        isHandDirXY = false;
                        isHandDirYZ = true;
                        isHandDirXZ = false;
                        isHandDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isHandDirX = false;
                        isHandDirY = false;
                        isHandDirZ = false;
                        isHandDirXY = false;
                        isHandDirYZ = false;
                        isHandDirXZ = false;
                        isHandDirXYZ = true;
                    }
                    StartCoroutine(WaitRightHand(sm1));
                }

                if (sm1.skeleton.ToString().Contains("RightElbow"))
                {
                    //GetDir(sm1.dir,isElbowDirX,isElbowDirY,isElbowDirZ,isElbowDirXY,isElbowDirYZ,isElbowDirYZ,isElbowDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isElbowDirX = true;
                        isElbowDirY = false;
                        isElbowDirZ = false;
                        isElbowDirXY = false;
                        isElbowDirYZ = false;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isElbowDirX = false;
                        isElbowDirY = true;
                        isElbowDirZ = false;
                        isElbowDirXY = false;
                        isElbowDirYZ = false;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isElbowDirX = false;
                        isElbowDirY = false;
                        isElbowDirZ = true;
                        isElbowDirXY = false;
                        isElbowDirYZ = false;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isElbowDirX = false;
                        isElbowDirY = false;
                        isElbowDirZ = false;
                        isElbowDirXY = true;
                        isElbowDirYZ = false;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isElbowDirX = false;
                        isElbowDirY = false;
                        isElbowDirZ = false;
                        isElbowDirXY = false;
                        isElbowDirYZ = false;
                        isElbowDirXZ = true;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isElbowDirX = false;
                        isElbowDirY = false;
                        isElbowDirZ = false;
                        isElbowDirXY = false;
                        isElbowDirYZ = true;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isElbowDirX = false;
                        isElbowDirY = false;
                        isElbowDirZ = false;
                        isElbowDirXY = false;
                        isElbowDirYZ = false;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = true;
                    }
                    StartCoroutine(WaitRightElbow(sm1));
                }

                if (sm1.skeleton.ToString().Contains("LeftElbow"))
                {
                    //GetDir(sm1.dir,isElbowDirX,isElbowDirY,isElbowDirZ,isElbowDirXY,isElbowDirYZ,isElbowDirYZ,isElbowDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isElbowDirX = true;
                        isElbowDirY = false;
                        isElbowDirZ = false;
                        isElbowDirXY = false;
                        isElbowDirYZ = false;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isElbowDirX = false;
                        isElbowDirY = true;
                        isElbowDirZ = false;
                        isElbowDirXY = false;
                        isElbowDirYZ = false;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isElbowDirX = false;
                        isElbowDirY = false;
                        isElbowDirZ = true;
                        isElbowDirXY = false;
                        isElbowDirYZ = false;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isElbowDirX = false;
                        isElbowDirY = false;
                        isElbowDirZ = false;
                        isElbowDirXY = true;
                        isElbowDirYZ = false;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isElbowDirX = false;
                        isElbowDirY = false;
                        isElbowDirZ = false;
                        isElbowDirXY = false;
                        isElbowDirYZ = false;
                        isElbowDirXZ = true;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isElbowDirX = false;
                        isElbowDirY = false;
                        isElbowDirZ = false;
                        isElbowDirXY = false;
                        isElbowDirYZ = true;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isElbowDirX = false;
                        isElbowDirY = false;
                        isElbowDirZ = false;
                        isElbowDirXY = false;
                        isElbowDirYZ = false;
                        isElbowDirXZ = false;
                        isElbowDirXYZ = true;
                    }
                    StartCoroutine(WaitLeftElbow(sm1));
                }

                if (sm1.skeleton.ToString().Contains("LeftFoot"))
                {
                    //GetDir(sm1.dir,isFootDirX,isFootDirY,isFootDirZ,isFootDirXY,isFootDirYZ,isFootDirXZ,isFootDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isFootDirX = true;
                        isFootDirY = false;
                        isFootDirZ = false;
                        isFootDirXY = false;
                        isFootDirYZ = false;
                        isFootDirXZ = false;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isFootDirX = false;
                        isFootDirY = true;
                        isFootDirZ = false;
                        isFootDirXY = false;
                        isFootDirYZ = false;
                        isFootDirXZ = false;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isFootDirX = false;
                        isFootDirY = false;
                        isFootDirZ = true;
                        isFootDirXY = false;
                        isFootDirYZ = false;
                        isFootDirXZ = false;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isFootDirX = false;
                        isFootDirY = false;
                        isFootDirZ = false;
                        isFootDirXY = true;
                        isFootDirYZ = false;
                        isFootDirXZ = false;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isFootDirX = false;
                        isFootDirY = false;
                        isFootDirZ = false;
                        isFootDirXY = false;
                        isFootDirYZ = false;
                        isFootDirXZ = true;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isFootDirX = false;
                        isFootDirY = false;
                        isFootDirZ = false;
                        isFootDirXY = false;
                        isFootDirYZ = true;
                        isFootDirXZ = false;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isFootDirX = false;
                        isFootDirY = false;
                        isFootDirZ = false;
                        isFootDirXY = false;
                        isFootDirYZ = false;
                        isFootDirXZ = false;
                        isFootDirXYZ = true;
                    }
                    StartCoroutine(WaitLeftFoot(sm1));
                }


                if (sm1.skeleton.ToString().Contains("RightFoot"))
                {
                    //GetDir(sm1.dir,isFootDirX,isFootDirY,isFootDirZ,isFootDirXY,isFootDirYZ,isFootDirXZ,isFootDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isFootDirX = true;
                        isFootDirY = false;
                        isFootDirZ = false;
                        isFootDirXY = false;
                        isFootDirYZ = false;
                        isFootDirXZ = false;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isFootDirX = false;
                        isFootDirY = true;
                        isFootDirZ = false;
                        isFootDirXY = false;
                        isFootDirYZ = false;
                        isFootDirXZ = false;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isFootDirX = false;
                        isFootDirY = false;
                        isFootDirZ = true;
                        isFootDirXY = false;
                        isFootDirYZ = false;
                        isFootDirXZ = false;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isFootDirX = false;
                        isFootDirY = false;
                        isFootDirZ = false;
                        isFootDirXY = true;
                        isFootDirYZ = false;
                        isFootDirXZ = false;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isFootDirX = false;
                        isFootDirY = false;
                        isFootDirZ = false;
                        isFootDirXY = false;
                        isFootDirYZ = false;
                        isFootDirXZ = true;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isFootDirX = false;
                        isFootDirY = false;
                        isFootDirZ = false;
                        isFootDirXY = false;
                        isFootDirYZ = true;
                        isFootDirXZ = false;
                        isFootDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isFootDirX = false;
                        isFootDirY = false;
                        isFootDirZ = false;
                        isFootDirXY = false;
                        isFootDirYZ = false;
                        isFootDirXZ = false;
                        isFootDirXYZ = true;
                    }
                    StartCoroutine(WaitRightFoot(sm1));
                }


                if (sm1.skeleton.ToString().Contains("LeftShoulder"))
                {
                    //GetDir(sm1.dir,isShoulderDirX,isShoulderDirY,isShoulderDirZ,isShoulderDirXY,isShoulderDirYZ,isShoulderDirXZ,isShoulderDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isShoulderDirX = true;
                        isShoulderDirY = false;
                        isShoulderDirZ = false;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = true;
                        isShoulderDirZ = false;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = false;
                        isShoulderDirZ = true;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = false;
                        isShoulderDirZ = false;
                        isShoulderDirXY = true;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = false;
                        isShoulderDirZ = false;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = true;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = false;
                        isShoulderDirZ = false;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = true;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = false;
                        isShoulderDirZ = false;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = true;
                    }
                    StartCoroutine(WaitLeftShoulder(sm1));
                }



                if (sm1.skeleton.ToString().Contains("RightShoulder"))
                {
                    //GetDir(sm1.dir,isShoulderDirX,isShoulderDirY,isShoulderDirZ,isShoulderDirXY,isShoulderDirYZ,isShoulderDirXZ,isShoulderDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isShoulderDirX = true;
                        isShoulderDirY = false;
                        isShoulderDirZ = false;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = true;
                        isShoulderDirZ = false;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = false;
                        isShoulderDirZ = true;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = false;
                        isShoulderDirZ = false;
                        isShoulderDirXY = true;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = false;
                        isShoulderDirZ = false;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = true;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = false;
                        isShoulderDirZ = false;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = true;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isShoulderDirX = false;
                        isShoulderDirY = false;
                        isShoulderDirZ = false;
                        isShoulderDirXY = false;
                        isShoulderDirYZ = false;
                        isShoulderDirXZ = false;
                        isShoulderDirXYZ = true;
                    }
                    StartCoroutine(WaitRightShoulder(sm1));
                }

                if (sm1.skeleton.ToString().Contains("LeftKnee"))
                {
                    //GetDir(sm1.dir,isKneeDirX,isKneeDirY,isKneeDirZ,isKneeDirXY,isKneeDirYZ,isKneeDirYZ,isKneeDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isKneeDirX = true;
                        isKneeDirY = false;
                        isKneeDirZ = false;
                        isKneeDirXY = false;
                        isKneeDirYZ = false;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isKneeDirX = false;
                        isKneeDirY = true;
                        isKneeDirZ = false;
                        isKneeDirXY = false;
                        isKneeDirYZ = false;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isKneeDirX = false;
                        isKneeDirY = false;
                        isKneeDirZ = true;
                        isKneeDirXY = false;
                        isKneeDirYZ = false;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isKneeDirX = false;
                        isKneeDirY = false;
                        isKneeDirZ = false;
                        isKneeDirXY = true;
                        isKneeDirYZ = false;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isKneeDirX = false;
                        isKneeDirY = false;
                        isKneeDirZ = false;
                        isKneeDirXY = false;
                        isKneeDirYZ = false;
                        isKneeDirXZ = true;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isKneeDirX = false;
                        isKneeDirY = false;
                        isKneeDirZ = false;
                        isKneeDirXY = false;
                        isKneeDirYZ = true;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isKneeDirX = false;
                        isKneeDirY = false;
                        isKneeDirZ = false;
                        isKneeDirXY = false;
                        isKneeDirYZ = false;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = true;
                    }

                    StartCoroutine(WaitLeftKnee(sm1));
                }
                if (sm1.skeleton.ToString().Contains("RightKnee"))
                {
                    //GetDir(sm1.dir,isKneeDirX,isKneeDirY,isKneeDirZ,isKneeDirXY,isKneeDirYZ,isKneeDirYZ,isKneeDirXYZ);
                    if (sm1.dir == MoveTowards.dirX)
                    {
                        isKneeDirX = true;
                        isKneeDirY = false;
                        isKneeDirZ = false;
                        isKneeDirXY = false;
                        isKneeDirYZ = false;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirY)
                    {
                        isKneeDirX = false;
                        isKneeDirY = true;
                        isKneeDirZ = false;
                        isKneeDirXY = false;
                        isKneeDirYZ = false;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirZ)
                    {
                        isKneeDirX = false;
                        isKneeDirY = false;
                        isKneeDirZ = true;
                        isKneeDirXY = false;
                        isKneeDirYZ = false;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXY)
                    {
                        isKneeDirX = false;
                        isKneeDirY = false;
                        isKneeDirZ = false;
                        isKneeDirXY = true;
                        isKneeDirYZ = false;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXZ)
                    {
                        isKneeDirX = false;
                        isKneeDirY = false;
                        isKneeDirZ = false;
                        isKneeDirXY = false;
                        isKneeDirYZ = false;
                        isKneeDirXZ = true;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirYZ)
                    {
                        isKneeDirX = false;
                        isKneeDirY = false;
                        isKneeDirZ = false;
                        isKneeDirXY = false;
                        isKneeDirYZ = true;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = false;
                    }
                    if (sm1.dir == MoveTowards.dirXYZ)
                    {
                        isKneeDirX = false;
                        isKneeDirY = false;
                        isKneeDirZ = false;
                        isKneeDirXY = false;
                        isKneeDirYZ = false;
                        isKneeDirXZ = false;
                        isKneeDirXYZ = true;
                    }

                    StartCoroutine(WaitRightKnee(sm1));
                }
            }
            #endregion
        }
       
        LoopCalcCr = StartCoroutine(LoopCalcMotion());
    }
    void ClearAndSavePic()
    {
        StopAllCoroutines();
        //StopCoroutine("LoopCalcMotion");

        isHeadDirX = false;
        isHeadDirY = false;
        isHeadDirZ = false;
        isHeadDirXY = false;
        isHeadDirYZ = false;
        isHeadDirXZ = false;
        isHeadDirXYZ = false;

        isHandDirX = false;
        isHandDirY = false;
        isHandDirZ = false;
        isHandDirXY = false;
        isHandDirYZ = false;
        isHandDirXZ = false;
        isHandDirXYZ = false;

        isElbowDirX = false;
        isElbowDirY = false;
        isElbowDirZ = false;
        isElbowDirXY = false;
        isElbowDirYZ = false;
        isElbowDirXZ = false;
        isElbowDirXYZ = false;

        isShoulderDirX = false;
        isShoulderDirY = false;
        isShoulderDirZ = false;
        isShoulderDirXY = false;
        isShoulderDirYZ = false;
        isShoulderDirXZ = false;
        isShoulderDirXYZ = false;

        isFootDirX = false;
        isFootDirY = false;
        isFootDirZ = false;
        isFootDirXY = false;
        isFootDirYZ = false;
        isFootDirXZ = false;
        isFootDirXYZ = false;

        isKneeDirX = false;
        isKneeDirY = false;
        isKneeDirZ = false;
        isKneeDirXY = false;
        isKneeDirYZ = false;
        isKneeDirXZ = false;
        isKneeDirXYZ = false;
        ip.BackZero();
        ip.Instrument(scorenum, 1400);
        StartCoroutine(GetMissPics());
    }
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            MainInterface._instance.showViewTag = 2;
            EffectRgb();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            zhuanye = true;
            zhuangye2 = true;
            //PlayerPixels ._instance .deepcolor =Color .gray ;
            Elur.SetActive(false);
            RGB.SetActive(false);
            PlayerPixels._instance.deepcolor = new Color(0, 0, 0, 1);
            //PlayerPixels ._instance .deepcolor.a = 1;
            PlayerPixels._instance.backcolor = new Color(92f / 255, 92f / 255, 92f / 255, 1);
            PlayerPixels._instance.backcolor.a = 0;
            Effectplanekk.SetActive(false);
            Planyz.renderer.material.shader = Shader.Find("Mobile/Particles/Alpha Blended");
        }
        //if (!canplay)
        //return;
        if (_mmt.isPlaying)
        {
            Isplay = false;
            if (GetIndex() != -1)
            {
                j = GetIndex();
                //Debug.Log("aaaaaaaaaaa  " + levels[j].moves[levels[j].moves.Count - 1].endtime);
                playtime += Time.deltaTime;//(levels[j].moves[levels[j].moves.Count - 1].endtime - 0.1f)
                //                 if (TestMobileTexture._instance.movieInf.movieCurProgress >= TestMobileTexture._instance.movieInf.movieLength)
                //                 {
                // 					
                //                 }
                //if (Effecttime > 0)
                //{
                //    Effecttime -= Time.deltaTime;
                //    if (Effecttime <= 0)
                //    {
                //        Effecttime = -1;
                //        SetSelfHide[] effects = ShenDuTu.GetComponentsInChildren<SetSelfHide>();
                //        foreach (SetSelfHide effect in effects)
                //        {
                //            Destroy(effect.gameObject);
                //        }
                //    }
                //}
                float m = GetMoveCubeNum(j, n);
                //Debug.Log("::>"+levels[j].moves[n].endtime+0.1f);
                if (playtime > (levels[j].moves[n].endtime + 0.1f))
                {
                    onceti++;
                    if (onceti == 1)
                    {
                        bool isTask = false;
                        Effecttime = 1.5f;
                        string temp = null;
                        foreach (SingleMove s in levels[j].moves[n].smoves)
                        {
                            temp += "" + s.skeleton;
                        }
                        float grade1 = 0;
                        if (temp.Contains("LeftHand"))
                        {
                            num11++;
                            HandleAfterScoring(_root.lhandi);
                            grade1 += HandleAfterScoring(_root.lhandi) * m;
                            if (HandleAfterScoring(_root.lhandi) == 0)
                            {
                                showeuler.isshowWrongHandL = true;
                                num1++;
                                isTask = true;
                                //GetRealTex();
                            }
                        }
                        if (temp.Contains("RightHand"))
                        {
                            num22++;
                            HandleAfterScoring(_root.rhandi);
                            grade1 += HandleAfterScoring(_root.rhandi) * m;
                            if (HandleAfterScoring(_root.rhandi) == 0)
                            {
                                showeuler.isshowWrongHandR = true;
                                num2++;
                                isTask = true;
                                //GetRealTex();
                            }
                        }
                        if (temp.Contains("LeftFoot"))
                        {
                            num55++;
                            HandleAfterScoring(_root.lfooti);
                            grade1 += HandleAfterScoring(_root.lfooti) * m;
                            if (HandleAfterScoring(_root.lfooti) == 0)
                            {
                                showeuler.isshowWrongFootL = true;
                                num5++;
                                isTask = true;
                                //GetRealTex();
                            }
                        }
                        if (temp.Contains("RightFoot"))
                        {
                            num66++;
                            HandleAfterScoring(_root.rfooti);
                            grade1 += HandleAfterScoring(_root.rfooti) * m;
                            if (HandleAfterScoring(_root.rfooti) == 0)
                            {
                                showeuler.isshowWrongFootR = true;
                                num6++;
                                isTask = true;
                                //GetRealTex();
                            }
                        }

                        if (temp.Contains("RightElbow"))
                        {
                            num44++;
                            HandleAfterScoring(_root.relbowi);
                            grade1 += HandleAfterScoring(_root.relbowi) * m;
                            if (HandleAfterScoring(_root.relbowi) == 0)
                            {
                                showeuler.isshowWrongElbowR = true;
                                num4++;
                                isTask = true;
                                //GetRealTex();
                            }
                        }
                        if (temp.Contains("LeftElbow"))
                        {
                            num33++;
                            HandleAfterScoring(_root.lelbowi);
                            grade1 += HandleAfterScoring(_root.lelbowi) * m;
                            if (HandleAfterScoring(_root.lelbowi) == 0)
                            {
                                showeuler.isshowWrongElbowL = true;
                                num3++;
                                isTask = true;
                                //GetRealTex();
                            }
                        }
                        if (temp.Contains("RightKnee"))
                        {
                            HandleAfterScoring(_root.rkneei);
                            grade1 += HandleAfterScoring(_root.rkneei) * m;
                            if (HandleAfterScoring(_root.rkneei) == 0)
                            {
                                showeuler.isshowWrongKneeR = true;
                                isTask = true;
                                //GetRealTex();
                            }
                        }
                        if (temp.Contains("LeftKnee"))
                        {
                            HandleAfterScoring(_root.lkneei);
                            grade1 += HandleAfterScoring(_root.lkneei) * m;
                            if (HandleAfterScoring(_root.lkneei) == 0)
                            {
                                showeuler.isshowWrongKneeL = true;
                                isTask = true;
                                //GetRealTex();
                            }
                        }
                        if (temp.Contains("RightShoulder"))
                        {
                            HandleAfterScoring(_root.rshoulderi);
                            grade1 += HandleAfterScoring(_root.rshoulderi) * m;
                            if (HandleAfterScoring(_root.rshoulderi) == 0)
                            {
                                showeuler.isshowShoulderR = true;
                                isTask = true;
                                //GetRealTex();
                            }
                        }
                        if (temp.Contains("LeftShoulder"))
                        {
                            HandleAfterScoring(_root.lshoulderi);
                            grade1 += HandleAfterScoring(_root.lshoulderi) * m;
                            if (HandleAfterScoring(_root.lshoulderi) == 0)
                            {
                                showeuler.isshowShoulderL = true;
                                isTask = true;
                                //GetRealTex();
                            }
                        }
                        if (temp.Contains("Head"))
                        {
                            HandleAfterScoring(_root.headi);
                            grade1 += HandleAfterScoring(_root.headi) * m;
                            if (HandleAfterScoring(_root.headi) == 0)
                            {
                                showeuler.isshowWrongHead = true;
                                isTask = true;
                                //GetRealTex();
                            }
                        }
                        if (isTask)
                        {
                            GetRealTex();
                        }
                        int grade = (int)Math.Floor(grade1);
                        // ip.SendMessage("Receive", grade);
                        HandleGrade(grade);
                        if (grade == 0)
                        {

                            //GameObject misseffectClone = Instantiate(misseffect, gradeEffectPosition.position, gradeEffectPosition.rotation) as GameObject;
                            //misseffectClone.transform.parent = gradeEffectPosition;
                            //misseffectClone.transform.localEulerAngles = Vector3.zero;
                            //misseffectClone.transform.localScale = Vector3.one;
                            if (zhuangye2 == true)
                            {
                                PlayerPixels._instance.backcolor.a = 0;
                                badE = true;
                            }
                            lianji = 0;
                            misseffect.SetActive(true);
                            StartCoroutine(HideEffect(misseffect));

                            //显示MISS图片方法
                            //missPic.ShowFlash();
                            //得到开始时间
                            missStartTime = levels[j].moves[n].starttime;
                            //兑换成图片ID
                            missPicId = (int)Math.Floor(1267 / 127 * missStartTime);
                            //把MISS的图片ID存入集合1
                            //把开始时间存入集合2
                            //missPicsList.Add(missPicId);
                            //missStartTimeList.Add(missStartTime);
                            ismiss = true;
                            StartCoroutine(WaitMissTime());
                        }
                        else if (grade > 0 && grade <= 5)
                        {
                            //GameObject goodeffectClone = Instantiate(goodeffect, gradeEffectPosition.position, gradeEffectPosition.rotation) as GameObject;

                            //goodeffectClone.transform.parent = gradeEffectPosition;
                            //goodeffectClone.transform.localEulerAngles = Vector3.zero;
                            //goodeffectClone.transform.localScale = Vector3.one;
                            lianji = 0;

                            //hudtext.Add("COMBO:"+lianji,Color.green,1f);
                            //							if(zhuanye ==false )
                            //							{
                            //							EffectPlane._instance.RandomEffect ();
                            //							}
                            if (zhuangye2 == true)
                            {
                                PlayerPixels._instance.backcolor.a = 0;
                                Debug.Log("zhuagye2");
                                goodE = true;
                            }
                            if (zhuanye == false)
                            {
                                EffectPlane._instance.GoodEffect();
                                Debug.Log("zhuagye2");
                            }
                            //							else
                            //							{
                            //								EffectPlane ._instance .HideALL();
                            //							}
                            goodeffect.SetActive(true);
                            StartCoroutine(HideEffect(goodeffect));

                        }
                        else if (grade > 5 && grade < 9)
                        {
                            //GameObject greateffectClone = Instantiate(greateffect,gradeEffectPosition.position, gradeEffectPosition.rotation) as GameObject;
                            //greateffectClone.transform.parent = gradeEffectPosition;
                            //greateffectClone.transform.localEulerAngles = Vector3.zero;
                            //greateffectClone.transform.localScale = Vector3.one;
                            if (zhuangye2 == true)
                            {
                                PlayerPixels._instance.backcolor.a = 0;
                                greatE = true;
                            }
                            if (zhuanye == false)
                            {
                                lianji++;
                                AddCombo();
                                //hudtext.Add("COMBO:"+lianji,Color.green,1f);
                                //EffectPlane ._instance .RandomEffect ();
                                EffectPlane._instance.GreatEffect();
                                //EffectPlane ._instance .LianjiEffect ();
                            }
                            //							else
                            //							{
                            //								EffectPlane ._instance .HideALL();
                            //							}
                            greateffect.SetActive(true);
                            StartCoroutine(HideEffect(greateffect));
                        }
                        else
                        {
                            //GameObject perfecteffectClone = Instantiate(perfecteffect, gradeEffectPosition.position, gradeEffectPosition.rotation) as GameObject;
                            //perfecteffectClone.transform.parent = gradeEffectPosition;
                            //perfecteffectClone.transform.localEulerAngles = Vector3.zero;
                            //perfecteffectClone.transform.localScale = Vector3.one;
                            if (zhuangye2 == true)
                            {
                                PlayerPixels._instance.backcolor.a = 0;

                                perfectE = true;
                            }
                            if (zhuanye == false)
                            {
                                lianji++;
                                AddCombo();
                                //hudtext.Add("COMBO:"+lianji,Color.green,1f);
                                //EffectPlane ._instance .RandomEffect ();
                                //EffectPlane ._instance .LianjiEffect ();
                                EffectPlane._instance.PerfectEffect();
                            }
                            //							else
                            //							{
                            //								EffectPlane ._instance .HideALL();
                            //							}
                            //EffectPlane ._instance .PerfectEffect ();
                            perfecteffect.SetActive(true);
                            StartCoroutine(HideEffect(perfecteffect));
                        }
                    }
                }
                if (GetMoveNum(j, playtime) != -1)
                {
                    n = GetMoveNum(j, playtime);
                    if (n != ci)
                    {
                        onceti = 0;
                        once = 0;
                        Movetime = -1;
                        _root.lhandi = "";
                        _root.rhandi = "";
                        _root.lfooti = "";
                        _root.rfooti = "";
                        _root.relbowi = "";
                        _root.lelbowi = "";
                        _root.rkneei = "";
                        _root.lkneei = "";
                        _root.rshoulderi = "";
                        _root.lshoulderi = "";
                        _root.headi = "";
                        hasshowhandl = false;
                        hasshowhandr = false;
                        hasshowelbowl = false;
                        hasshowelbowr = false;
                        hasshowshoulderl = false;
                        hasshowshoulderr = false;
                        hasshowkneel = false;
                        hasshowkneer = false;
                        hasshowfootl = false;
                        hasshowfootr = false;
                        hasshowhead = false;
                        if (HeadcolParent.childCount != 0)
                        {
                            foreach (GameObject g1 in childCubes)
                            {
                                Destroy(g1);
                            }
                            childCubes.Clear();
                        }
                        if (ElbowcolParent.childCount != 0)
                        {
                            foreach (GameObject g1 in childCubes)
                            {
                                Destroy(g1);
                            }
                            childCubes.Clear();
                        }
                        if (ShouldercolParent.childCount != 0)
                        {
                            foreach (GameObject g1 in childCubes)
                            {
                                Destroy(g1);
                            }
                            childCubes.Clear();
                        }
                        if (KneecolParent.childCount != 0)
                        {
                            foreach (GameObject g1 in childCubes)
                            {
                                Destroy(g1);
                            }
                            childCubes.Clear();
                        }
                        if (HandcolParent.childCount != 0)
                        {
                            foreach (GameObject g1 in childCubes)
                            {
                                Destroy(g1);
                            }
                            childCubes.Clear();
                        }
                        if (FootcolParent.childCount != 0)
                        {
                            foreach (GameObject g1 in childCubes)
                            {
                                Destroy(g1);
                            }
                            childCubes.Clear();
                        }
                        ci = n;

                        foreach (SingleMove sm1 in levels[j].moves[n].smoves)
                        {
                            if (sm1.skeleton.ToString().Contains("Head"))
                            {
                                //GetDir(sm1.dir,isHeadDirX,isHeadDirY,isHeadDirZ,isHeadDirXY,isHeadDirYZ,isHeadDirXZ,isHeadDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isHeadDirX = true;
                                    isHeadDirY = false;
                                    isHeadDirZ = false;
                                    isHeadDirXY = false;
                                    isHeadDirYZ = false;
                                    isHeadDirXZ = false;
                                    isHeadDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isHeadDirX = false;
                                    isHeadDirY = true;
                                    isHeadDirZ = false;
                                    isHeadDirXY = false;
                                    isHeadDirYZ = false;
                                    isHeadDirXZ = false;
                                    isHeadDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isHeadDirX = false;
                                    isHeadDirY = false;
                                    isHeadDirZ = true;
                                    isHeadDirXY = false;
                                    isHeadDirYZ = false;
                                    isHeadDirXZ = false;
                                    isHeadDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isHeadDirX = false;
                                    isHeadDirY = false;
                                    isHeadDirZ = false;
                                    isHeadDirXY = true;
                                    isHeadDirYZ = false;
                                    isHeadDirXZ = false;
                                    isHeadDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isHeadDirX = false;
                                    isHeadDirY = false;
                                    isHeadDirZ = false;
                                    isHeadDirXY = false;
                                    isHeadDirYZ = false;
                                    isHeadDirXZ = true;
                                    isHeadDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isHeadDirX = false;
                                    isHeadDirY = false;
                                    isHeadDirZ = false;
                                    isHeadDirXY = false;
                                    isHeadDirYZ = true;
                                    isHeadDirXZ = false;
                                    isHeadDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isHeadDirX = false;
                                    isHeadDirY = false;
                                    isHeadDirZ = false;
                                    isHeadDirXY = false;
                                    isHeadDirYZ = false;
                                    isHeadDirXZ = false;
                                    isHeadDirXYZ = true;
                                }
                                StartCoroutine(WaitHead(sm1));
                            }
                            if (sm1.skeleton.ToString().Contains("LeftHand"))
                            {
                                //GetDir(sm1.dir,isHandDirX,isHandDirY,isHandDirZ,isHandDirXY,isHandDirYZ,isHandDirXZ,isHandDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isHandDirX = true;
                                    isHandDirY = false;
                                    isHandDirZ = false;
                                    isHandDirXY = false;
                                    isHandDirYZ = false;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isHandDirX = false;
                                    isHandDirY = true;
                                    isHandDirZ = false;
                                    isHandDirXY = false;
                                    isHandDirYZ = false;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isHandDirX = false;
                                    isHandDirY = false;
                                    isHandDirZ = true;
                                    isHandDirXY = false;
                                    isHandDirYZ = false;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isHandDirX = false;
                                    isHandDirY = false;
                                    isHandDirZ = false;
                                    isHandDirXY = true;
                                    isHandDirYZ = false;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isHandDirX = false;
                                    isHandDirY = false;
                                    isHandDirZ = false;
                                    isHandDirXY = false;
                                    isHandDirYZ = false;
                                    isHandDirXZ = true;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isHandDirX = false;
                                    isHandDirY = false;
                                    isHandDirZ = false;
                                    isHandDirXY = false;
                                    isHandDirYZ = true;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isHandDirX = false;
                                    isHandDirY = false;
                                    isHandDirZ = false;
                                    isHandDirXY = false;
                                    isHandDirYZ = false;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = true;
                                }
                                StartCoroutine(WaitLeftHand(sm1));
                            }

                            if (sm1.skeleton.ToString().Contains("RightHand"))
                            {
                                //GetDir(sm1.dir,isHandDirX,isHandDirY,isHandDirZ,isHandDirXY,isHandDirYZ,isHandDirXZ,isHandDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isHandDirX = true;
                                    isHandDirY = false;
                                    isHandDirZ = false;
                                    isHandDirXY = false;
                                    isHandDirYZ = false;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isHandDirX = false;
                                    isHandDirY = true;
                                    isHandDirZ = false;
                                    isHandDirXY = false;
                                    isHandDirYZ = false;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isHandDirX = false;
                                    isHandDirY = false;
                                    isHandDirZ = true;
                                    isHandDirXY = false;
                                    isHandDirYZ = false;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isHandDirX = false;
                                    isHandDirY = false;
                                    isHandDirZ = false;
                                    isHandDirXY = true;
                                    isHandDirYZ = false;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isHandDirX = false;
                                    isHandDirY = false;
                                    isHandDirZ = false;
                                    isHandDirXY = false;
                                    isHandDirYZ = false;
                                    isHandDirXZ = true;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isHandDirX = false;
                                    isHandDirY = false;
                                    isHandDirZ = false;
                                    isHandDirXY = false;
                                    isHandDirYZ = true;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isHandDirX = false;
                                    isHandDirY = false;
                                    isHandDirZ = false;
                                    isHandDirXY = false;
                                    isHandDirYZ = false;
                                    isHandDirXZ = false;
                                    isHandDirXYZ = true;
                                }
                                StartCoroutine(WaitRightHand(sm1));
                            }

                            if (sm1.skeleton.ToString().Contains("RightElbow"))
                            {
                                //GetDir(sm1.dir,isElbowDirX,isElbowDirY,isElbowDirZ,isElbowDirXY,isElbowDirYZ,isElbowDirYZ,isElbowDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isElbowDirX = true;
                                    isElbowDirY = false;
                                    isElbowDirZ = false;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = true;
                                    isElbowDirZ = false;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = false;
                                    isElbowDirZ = true;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = false;
                                    isElbowDirZ = false;
                                    isElbowDirXY = true;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = false;
                                    isElbowDirZ = false;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = true;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = false;
                                    isElbowDirZ = false;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = true;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = false;
                                    isElbowDirZ = false;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = true;
                                }
                                StartCoroutine(WaitRightElbow(sm1));
                            }

                            if (sm1.skeleton.ToString().Contains("LeftElbow"))
                            {
                                //GetDir(sm1.dir,isElbowDirX,isElbowDirY,isElbowDirZ,isElbowDirXY,isElbowDirYZ,isElbowDirYZ,isElbowDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isElbowDirX = true;
                                    isElbowDirY = false;
                                    isElbowDirZ = false;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = true;
                                    isElbowDirZ = false;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = false;
                                    isElbowDirZ = true;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = false;
                                    isElbowDirZ = false;
                                    isElbowDirXY = true;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = false;
                                    isElbowDirZ = false;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = true;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = false;
                                    isElbowDirZ = false;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = true;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isElbowDirX = false;
                                    isElbowDirY = false;
                                    isElbowDirZ = false;
                                    isElbowDirXY = false;
                                    isElbowDirYZ = false;
                                    isElbowDirXZ = false;
                                    isElbowDirXYZ = true;
                                }
                                StartCoroutine(WaitLeftElbow(sm1));
                            }

                            if (sm1.skeleton.ToString().Contains("LeftFoot"))
                            {
                                //GetDir(sm1.dir,isFootDirX,isFootDirY,isFootDirZ,isFootDirXY,isFootDirYZ,isFootDirXZ,isFootDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isFootDirX = true;
                                    isFootDirY = false;
                                    isFootDirZ = false;
                                    isFootDirXY = false;
                                    isFootDirYZ = false;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isFootDirX = false;
                                    isFootDirY = true;
                                    isFootDirZ = false;
                                    isFootDirXY = false;
                                    isFootDirYZ = false;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isFootDirX = false;
                                    isFootDirY = false;
                                    isFootDirZ = true;
                                    isFootDirXY = false;
                                    isFootDirYZ = false;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isFootDirX = false;
                                    isFootDirY = false;
                                    isFootDirZ = false;
                                    isFootDirXY = true;
                                    isFootDirYZ = false;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isFootDirX = false;
                                    isFootDirY = false;
                                    isFootDirZ = false;
                                    isFootDirXY = false;
                                    isFootDirYZ = false;
                                    isFootDirXZ = true;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isFootDirX = false;
                                    isFootDirY = false;
                                    isFootDirZ = false;
                                    isFootDirXY = false;
                                    isFootDirYZ = true;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isFootDirX = false;
                                    isFootDirY = false;
                                    isFootDirZ = false;
                                    isFootDirXY = false;
                                    isFootDirYZ = false;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = true;
                                }
                                StartCoroutine(WaitLeftFoot(sm1));
                            }


                            if (sm1.skeleton.ToString().Contains("RightFoot"))
                            {
                                //GetDir(sm1.dir,isFootDirX,isFootDirY,isFootDirZ,isFootDirXY,isFootDirYZ,isFootDirXZ,isFootDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isFootDirX = true;
                                    isFootDirY = false;
                                    isFootDirZ = false;
                                    isFootDirXY = false;
                                    isFootDirYZ = false;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isFootDirX = false;
                                    isFootDirY = true;
                                    isFootDirZ = false;
                                    isFootDirXY = false;
                                    isFootDirYZ = false;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isFootDirX = false;
                                    isFootDirY = false;
                                    isFootDirZ = true;
                                    isFootDirXY = false;
                                    isFootDirYZ = false;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isFootDirX = false;
                                    isFootDirY = false;
                                    isFootDirZ = false;
                                    isFootDirXY = true;
                                    isFootDirYZ = false;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isFootDirX = false;
                                    isFootDirY = false;
                                    isFootDirZ = false;
                                    isFootDirXY = false;
                                    isFootDirYZ = false;
                                    isFootDirXZ = true;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isFootDirX = false;
                                    isFootDirY = false;
                                    isFootDirZ = false;
                                    isFootDirXY = false;
                                    isFootDirYZ = true;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isFootDirX = false;
                                    isFootDirY = false;
                                    isFootDirZ = false;
                                    isFootDirXY = false;
                                    isFootDirYZ = false;
                                    isFootDirXZ = false;
                                    isFootDirXYZ = true;
                                }
                                StartCoroutine(WaitRightFoot(sm1));
                            }


                            if (sm1.skeleton.ToString().Contains("LeftShoulder"))
                            {
                                //GetDir(sm1.dir,isShoulderDirX,isShoulderDirY,isShoulderDirZ,isShoulderDirXY,isShoulderDirYZ,isShoulderDirXZ,isShoulderDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isShoulderDirX = true;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = true;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = true;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = true;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = true;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = true;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = true;
                                }
                                StartCoroutine(WaitLeftShoulder(sm1));
                            }



                            if (sm1.skeleton.ToString().Contains("RightShoulder"))
                            {
                                //GetDir(sm1.dir,isShoulderDirX,isShoulderDirY,isShoulderDirZ,isShoulderDirXY,isShoulderDirYZ,isShoulderDirXZ,isShoulderDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isShoulderDirX = true;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = true;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = true;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = true;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = true;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = true;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isShoulderDirX = false;
                                    isShoulderDirY = false;
                                    isShoulderDirZ = false;
                                    isShoulderDirXY = false;
                                    isShoulderDirYZ = false;
                                    isShoulderDirXZ = false;
                                    isShoulderDirXYZ = true;
                                }
                                StartCoroutine(WaitRightShoulder(sm1));
                            }

                            if (sm1.skeleton.ToString().Contains("LeftKnee"))
                            {
                                //GetDir(sm1.dir,isKneeDirX,isKneeDirY,isKneeDirZ,isKneeDirXY,isKneeDirYZ,isKneeDirYZ,isKneeDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isKneeDirX = true;
                                    isKneeDirY = false;
                                    isKneeDirZ = false;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = true;
                                    isKneeDirZ = false;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = false;
                                    isKneeDirZ = true;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = false;
                                    isKneeDirZ = false;
                                    isKneeDirXY = true;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = false;
                                    isKneeDirZ = false;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = true;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = false;
                                    isKneeDirZ = false;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = true;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = false;
                                    isKneeDirZ = false;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = true;
                                }

                                StartCoroutine(WaitLeftKnee(sm1));
                            }
                            if (sm1.skeleton.ToString().Contains("RightKnee"))
                            {
                                //GetDir(sm1.dir,isKneeDirX,isKneeDirY,isKneeDirZ,isKneeDirXY,isKneeDirYZ,isKneeDirYZ,isKneeDirXYZ);
                                if (sm1.dir == MoveTowards.dirX)
                                {
                                    isKneeDirX = true;
                                    isKneeDirY = false;
                                    isKneeDirZ = false;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirY)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = true;
                                    isKneeDirZ = false;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirZ)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = false;
                                    isKneeDirZ = true;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXY)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = false;
                                    isKneeDirZ = false;
                                    isKneeDirXY = true;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXZ)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = false;
                                    isKneeDirZ = false;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = true;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirYZ)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = false;
                                    isKneeDirZ = false;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = true;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = false;
                                }
                                if (sm1.dir == MoveTowards.dirXYZ)
                                {
                                    isKneeDirX = false;
                                    isKneeDirY = false;
                                    isKneeDirZ = false;
                                    isKneeDirXY = false;
                                    isKneeDirYZ = false;
                                    isKneeDirXZ = false;
                                    isKneeDirXYZ = true;
                                }

                                StartCoroutine(WaitRightKnee(sm1));
                            }
                        }
                    }
                }
                else
                {
                    isHeadDirX = false;
                    isHeadDirY = false;
                    isHeadDirZ = false;
                    isHeadDirXY = false;
                    isHeadDirYZ = false;
                    isHeadDirXZ = false;
                    isHeadDirXYZ = false;

                    isHandDirX = false;
                    isHandDirY = false;
                    isHandDirZ = false;
                    isHandDirXY = false;
                    isHandDirYZ = false;
                    isHandDirXZ = false;
                    isHandDirXYZ = false;

                    isElbowDirX = false;
                    isElbowDirY = false;
                    isElbowDirZ = false;
                    isElbowDirXY = false;
                    isElbowDirYZ = false;
                    isElbowDirXZ = false;
                    isElbowDirXYZ = false;

                    isShoulderDirX = false;
                    isShoulderDirY = false;
                    isShoulderDirZ = false;
                    isShoulderDirXY = false;
                    isShoulderDirYZ = false;
                    isShoulderDirXZ = false;
                    isShoulderDirXYZ = false;

                    isFootDirX = false;
                    isFootDirY = false;
                    isFootDirZ = false;
                    isFootDirXY = false;
                    isFootDirYZ = false;
                    isFootDirXZ = false;
                    isFootDirXYZ = false;

                    isKneeDirX = false;
                    isKneeDirY = false;
                    isKneeDirZ = false;
                    isKneeDirXY = false;
                    isKneeDirYZ = false;
                    isKneeDirXZ = false;
                    isKneeDirXYZ = false;
                }
            }
        }
        else
        {
            IsStart = true;
            playtime = 0;
            //dtime -= Time.deltaTime;
            //if (dtime <= 0)
            //{
            //    Isplay = true;
            //    dtime = 1;
            //}
        }*/
    }
    /*void FixedUpdate()
    {
        if(_mmt.isPlaying)
        {
            usertime += Time.fixedDeltaTime;
            //Debug.Log (usertime + "usertime");
            for(int i=0;i<realtimes.Count;i++)
            {
                if(Mathf.Abs(usertime - realtimes[i]) < 0.01f)
                {
                    //StartCoroutine(GetPhoto(CameraTrans.camera,new Rect(0, 0, Screen .width-10 , Screen .width-50 )));
                    //StartCoroutine(PlayerImages  ._instance . GetPhoto());
                    StartCoroutine(TakePicture());

                    //realtexs .Add (ScreenRgb ._instance.texture  );
                    Debug.Log("pai~~");
                }
            }
        }
    }*/
    IEnumerator TakePicture()
    {
        Debug.Log("TakePicture");
        yield return new WaitForFixedUpdate();
        Texture2D texture = ScreenRgb._instance.GetPhoto();
        picArr[(int)_EPISORT.USER].Add(texture);
        yield return new WaitForFixedUpdate();

        Texture2D texture2d = TestMobileTexture._instance.GetMoviePic();
        picArr[(int)_EPISORT.MOVIE].Add(texture2d);
    }
    //获取正在播放的视频在Levels里的索引值
    /*int GetIndex()
    {
       // Debug.Log("getindex " + _mmt.Path + "::" + levels[0].moviename);
        / *for (int i = 0; i < levels.Count; i++)
        {
            if (_mmt.Path.Contains(levels[i].moviename))
            {
                / *if (IsStart)
                {
                    message[0] = 0;
                    message[1] = i;
                    //  topscore.SendMessage("Receive", message);
                    ip.BackZero();
                    IsStart = false;
                }* /
                return i;
            }
        }* /
        return 0;
    }*/
    //通过视频的播放时间判断当前状态下属于某个动作
    int GetMoveNum(int i, float movieCurTime)
    {
        for (int k = 0; k < levels[i].moves.Count; k++)
        {
            if (movieCurTime > levels[i].moves[k].starttime && movieCurTime < levels[i].moves[k].endtime)
            {
                return k;
            }
        }
        return -1;
    }
    //通过视频的播放时间判断当前状态下属于某个动作的每个方块的分数
    float GetMoveCubeNum(int i, int n)
    {
//        Debug.Log("::->:" + levels[i].moves.Count + "<>" + n);
        float m = 10 / (((float)levels[i].moves[n].smoves.Count) * 3);
        return m;
    }
    //获取要加的分数
    int GetScoreNum(string a)
    {
        if (a == "1" || a == "13" || a == "23" || a == "32" || a == "321" || a == "3")
        {
            return 1;
        }
        if (a == "12")
        {
            return 2;
        }
        if (a == "123")
        {
            return 3;
        }
        return 0;
    }
    //得分后需要做的处理，显示得分效果及游戏总得分
    int HandleAfterScoring(string str)
    {
        int t = GetScoreNum(str);
        return t;
    }
    void HandleGrade(int b)
    {
        if (b != 0)
        {
            scoreeffect = Instantiate(Resources.Load("Prefabs/scoreeffect"), new Vector3(1f, 0.67f, -8.9f), Quaternion.identity) as GameObject;
            // scoreeffect.SetActive(true);
            scoreeffect.GetComponent<TextMesh>().text = "+" + b;
            scorenum += b;
            score.num = "" + scorenum;
        }
        ip.Instrument(b, 10);
    }

    public void EffectRgb()
    {
        Planyz.renderer.material.shader = Shader.Find("Mobile/Particles/Additive");
        zhuanye = false;
        zhuangye2 = false;
        Effectplanekk.SetActive(true);
        Elur.SetActive(false);
        RGB.SetActive(false);
        planeYZRender.enabled = true;
        //version.spriteName = "effect";
        PlayerPixels._instance.deepcolor = Color.yellow;
        PlayerPixels._instance.backcolor = Color.black;
        effect2.SetActive(false);
    }

    void GetDir(MoveTowards dir, bool isDirX, bool isDirY, bool isDirZ, bool isDirXY, bool isDirYZ, bool isDirXZ, bool isDirXYZ)
    {
        if (dir == MoveTowards.dirX)
        {
            isDirX = true;
            isDirY = false;
            isDirZ = false;
            isDirXY = false;
            isDirYZ = false;
            isDirXZ = false;
            isDirXYZ = false;
        }
        if (dir == MoveTowards.dirY)
        {
            isDirX = false;
            isDirY = true;
            isDirZ = false;
            isDirXY = false;
            isDirYZ = false;
            isDirXZ = false;
            isDirXYZ = false;
        }
        if (dir == MoveTowards.dirZ)
        {
            isDirX = false;
            isDirY = false;
            isDirZ = true;
            isDirXY = false;
            isDirYZ = false;
            isDirXZ = false;
            isDirXYZ = false;
        }
        if (dir == MoveTowards.dirXY)
        {
            isDirX = false;
            isDirY = false;
            isDirZ = false;
            isDirXY = true;
            isDirYZ = false;
            isDirXZ = false;
            isDirXYZ = false;
        }
        if (dir == MoveTowards.dirXZ)
        {
            isDirX = false;
            isDirY = false;
            isDirZ = false;
            isDirXY = false;
            isDirYZ = false;
            isDirXZ = true;
            isDirXYZ = false;
        }
        if (dir == MoveTowards.dirYZ)
        {
            isDirX = false;
            isDirY = false;
            isDirZ = false;
            isDirXY = false;
            isDirYZ = true;
            isDirXZ = false;
            isDirXYZ = false;
        }
        if (dir == MoveTowards.dirXYZ)
        {
            isDirX = false;
            isDirY = false;
            isDirZ = false;
            isDirXY = false;
            isDirYZ = false;
            isDirXZ = false;
            isDirXYZ = true;
        }
    }
    IEnumerator WaitMissTime()
    {
        yield return new WaitForSeconds(0.3f);
        ismiss = false;
        //Debug.Log("ismiss" + ismiss);
    }


    IEnumerator WaitLeftHand(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = HandcolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }
    IEnumerator WaitRightHand(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = HandcolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }
    IEnumerator WaitLeftElbow(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = ElbowcolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }
    IEnumerator WaitRightElbow(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = ElbowcolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }
    IEnumerator WaitLeftShoulder(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = ShouldercolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }
    IEnumerator WaitRightShoulder(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = ShouldercolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }
    IEnumerator WaitLeftKnee(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = KneecolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }
    IEnumerator WaitRightKnee(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = KneecolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }
    IEnumerator WaitLeftFoot(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = FootcolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }
    IEnumerator WaitRightFoot(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = FootcolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }


    IEnumerator WaitHead(SingleMove sm1)
    {
        yield return new WaitForSeconds(sm1.waittime);
        foreach (CubeObj co1 in sm1.cubes)
        {
            GameObject temp = Instantiate((GameObject)Resources.Load("Prefabs/sourcecube", typeof(GameObject))) as GameObject;
            //temp.transform.position = torso.position + co1.ballposition;
            temp.transform.parent = HeadcolParent;
            temp.transform.localPosition = co1.ballposition;
            temp.transform.localEulerAngles = co1.ballballrotation;
            temp.name = sm1.skeleton.ToString() + co1.ballnum;
            childCubes.Add(temp);
        }
    }
    IEnumerator HideEffect(GameObject effect)
    {
        yield return new WaitForSeconds(0.8f);
        effect.SetActive(false);
    }
    //偷偷实例化特效的方法
    void AvoidBlock()
    {
        GameObject go = Instantiate(goodeffect, this.gameObject.transform.position, Quaternion.identity) as GameObject;
        Destroy(go, 0.8f);
    }

    void AddCombo()
    {
        GameObject combo = NGUITools.AddChild(uiroot, combolabel);
        combo.transform.localPosition = new Vector3(448, 157, 0);
        UILabel combolabelnum = GameObject.Find("ComboLabel").GetComponent<UILabel>();
        combolabelnum.text = " : " + lianji;
    }
    void GetRealTex()
    {
        Debug.Log("GetRealTex");
        /*if((showeuler.isshowWrongElbowL || showeuler.isshowWrongElbowR || showeuler.isshowWrongFootL || showeuler.isshowWrongFootR || showeuler.isshowWrongHandL || showeuler.isshowWrongHandR || showeuler.isshowWrongHead || showeuler.isshowWrongKneeL 
            || showeuler.isshowKneeR || showeuler.isshowWrongShoulderL || showeuler.isshowWrongShoulderR )&& !ishasphoto)
        {
            //截图
            //StartCoroutine(GetPhoto());
            ishasphoto = true;
            //GetMovieUseTexs(n);
            missindexs.Add(n);
        }*/
        //		IsSave = true;
        //		StartCoroutine (ScreenRgb ._instance .GetPhoto ());
        /*
                if(!missindexs.Contains(n))
                {
                    Debug.Log("-->:"+n);
                    missindexs.Add(n);
                }*/
        StartCoroutine(TakePicture());

    }

    void GetMovieUseTexs(int index)
    {
        if (!System.IO.File.Exists(QRlogin.LocalPicPath))
        {
            Directory.CreateDirectory(QRlogin.LocalPicPath);
        }
        if (index < picArr[(int)_EPISORT.MOVIE].Count)
        {
            string savePath = QRlogin.LocalPicPath + "/" + index.ToString() + "_T" + ".jpg";
            Texture2D _mytexture;
            _mytexture = picArr[(int)_EPISORT.MOVIE][index];
            byte[] pngData = _mytexture.EncodeToJPG();
            File.WriteAllBytes(savePath, pngData);
        }
    }
    void GetRealUseTexs(int index)
    {
        if (!System.IO.File.Exists(QRlogin.LocalPicPath))
        {
            Directory.CreateDirectory(QRlogin.LocalPicPath);
        }
        if (index < picArr[(int)_EPISORT.USER].Count)
        {

            string savePath = QRlogin.LocalPicPath + "/" + index.ToString() + ".jpg";
            //Debug.Log(savePath);
            //picArr[(int)_EPISORT.USER][index].Compress(false);
            byte[] pngData = picArr[(int)_EPISORT.USER][index].EncodeToJPG();
            File.WriteAllBytes(savePath, pngData);
        }

    }
    IEnumerator GetMissPics()
    {
        //StartCoroutine (waittwosave ());
        Debug.Log(picArr[(int)_EPISORT.USER].Count);
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < picArr[(int)_EPISORT.USER].Count; i++)
        {
            Debug.Log("GetMissPics");
            GetMovieUseTexs(i);
            yield return new WaitForEndOfFrame();
            GetRealUseTexs(i);
            yield return new WaitForEndOfFrame();
        }
        isCompleteCreatePic = true;
        Debug.Log("isCompleteCreatePic");
    }
    public void ChangeMode2()
    {
        zhuanye = true;
        zhuangye2 = true;
        //PlayerPixels ._instance .deepcolor =Color .gray ;
        Elur.SetActive(false);
        //RGB .SetActive (false );
        PlayerPixels._instance.deepcolor = new Color(0, 0, 0, 1);
        //PlayerPixels ._instance .deepcolor.a = 1;
        PlayerPixels._instance.backcolor = new Color(92f / 255, 92f / 255, 92f / 255, 1);
        PlayerPixels._instance.backcolor.a = 0;
        Effectplanekk.SetActive(false);
        Planyz.renderer.material.shader = Shader.Find("Mobile/Particles/Alpha Blended");
    }

}
