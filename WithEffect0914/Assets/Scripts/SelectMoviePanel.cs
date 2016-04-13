using UnityEngine;
using System.Collections;
using CourseDetail;
using System.Collections.Generic;
using DG.Tweening;

public class SelectMoviePanel : MonoBehaviour
{

    public AutoGetSelectPot autoSelectInf = null;
    // Use this for initialization
    public UILabel MovieDetailInf;
    public GameObject MovieList;
    public GameObject MovieTexturePrefab;


    List<MovieInf> lsMISub = new List<MovieInf>();
    public static SelectMoviePanel _instance;

    Queue<Coroutine> QuCR = new Queue<Coroutine>();
    class MovieInf
    {
        public ShowMovieInfo smi;
        public GameObject obj;
    }
    bool isCanGetInput = true;
    bool isLoadComp = false;
    void OnEnable()
    {
        isLoadComp = true;
        isCanGetInput = true;
        if (autoSelectInf)
        {
            autoSelectInf.Init();
        }
    }
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        if (MovieList == null)
        {
            MovieList = transform.Find("MovieList").gameObject;
        }
        if (MovieList == null)
        {
            Debug.LogError("MovieList No Find");
        }
        else
        {
            autoSelectInf = MovieList.GetComponent<AutoGetSelectPot>();
            if (autoSelectInf)
            {
                autoSelectInf.OnSelectItem += MovieSelect;
                autoSelectInf.OnClickItem += StartPlayMovie;
            }
            //             for (int i = 0; i < MovieList.transform.childCount; i++)
            //             {
            //                 MovieInf mif = new MovieInf();
            //                 mif.obj = MovieList.transform.GetChild(i).gameObject;
            //                 mif.nID = i;
            //                 mif.isSelect = false;
            //                 lsMISub.Add(mif);
            //             }
        }

        if (MovieTexturePrefab == null)
        {
            Debug.LogError("MovieTexturePrefab No Find");
        }
    }
    public void AddMovieToList(List<ShowMovieInfo> lsSMI)
    {
        lsMISub.Clear();
        List<Transform> lsT = MovieList.GetComponent<UIGrid>().GetChildList();
        foreach (var item in lsT)
        {
            MovieList.GetComponent<UIGrid>().RemoveChild(item);
            Destroy(item.gameObject);
        }
        MovieList.transform.DetachChildren();
        isLoadComp = false;
        StartCoroutine(AddMovieToListByOrder(lsSMI));
    }
    IEnumerator AddMovieToListByOrder(List<ShowMovieInfo> lsSMI)
    {
        yield return new WaitForSeconds(0.5f);
        //Debug.Log("lsSMI.Count is:"+lsSMI.Count);
        for (int i = 0; i < lsSMI.Count; i++)
        {
            GameObject obj = Instantiate(MovieTexturePrefab) as GameObject;
            MovieList.GetComponent<UIGrid>().AddChild(obj.transform);
            obj.transform.localScale = Vector3.one;
            UILabel textUI = obj.transform.Find("MovieNameLabel").GetComponent<UILabel>();
            if (textUI)
            {
                textUI.text = lsSMI[i].coursename.Split(' ')[0];
            }
            MovieInf mif = new MovieInf();
            mif.smi = lsSMI[i];
            mif.obj = obj;
            lsMISub.Add(mif);
            StartCoroutine(LoadMoviePic(obj, QRlogin.moviePicUrl + lsSMI[i].courselogo));
            yield return new WaitForSeconds(0.2f);
        }
        isLoadComp = true;
    }
    void MovieSelect(Transform tr1, Transform tr2, int nIndex)
    {
        if (UIMoviePart._instance)
        {
            UIMoviePart._instance.StopMovieForUI();
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
            MovieInf mi = GetMI(tr2.gameObject);
            if (MovieDetailInf)
            {
                MovieDetailInf.text = mi.smi.describe;
            }
            Coroutine cr = null;
            cr = StartCoroutine(StartPlayMovieAuto(mi));
            QuCR.Enqueue(cr);
        }
    }
    IEnumerator LoadMoviePic(GameObject obj, string url)
    {
        WWW www = new WWW(url);
        yield return www;
        UITexture uiTex = obj.GetComponent<UITexture>();
        if (uiTex && www.error == null)
        {
            uiTex.mainTexture = (Texture2D)www.texture;

            Color c = uiTex.color;
            uiTex.color = new Color(c.r, c.g, c.b, 0);
            DOTween.To(() => uiTex.color, x => uiTex.color = x, c, 0.5f);
        }
        //avatar .mainTexture = (Texture2D )www.texture;
    }
    IEnumerator StartPlayMovieAuto(MovieInf mi)
    {
        MovieInf miS = mi;
        while (QuCR.Count > 0)
        {
            Coroutine cr = QuCR.Dequeue();
            StopCoroutine(cr);
        }
        yield return new WaitForSeconds(2);
        if (UIMoviePart._instance)
        {
            if (mi != null)
            {

                Debug.Log(miS.smi.coursename + "<-->" + miS.smi.videourl + "--" + miS.smi.isAbsolutePath);
                UIMoviePart._instance.AbsolutePath = miS.smi.isAbsolutePath;
                UIMoviePart._instance.PlayMovieForUI(miS.smi.videourl);
            }
        }
    }
    MovieInf GetMI(GameObject obj)
    {
        MovieInf mi = null;
        foreach (var item in lsMISub)
        {
            if (item.obj == obj)
            {
                mi = item;
            }
        }
        return mi;
    }
    void StartPlayMovie(Transform trans, int nIndex)
    {
        MovieInf mi = GetMI(trans.gameObject);
        if (isCanGetInput && mi != null)
        {
            Debug.Log(mi.smi.xmlUrl);
            if (System.IO.File.Exists(mi.smi.xmlUrl) && System.IO.File.Exists(mi.smi.videourl))
            {
                if (autoSelectInf)
                {
                    autoSelectInf.SetInputInvain();
                }
                isCanGetInput = false;
                UIMoviePart._instance.StopMovieForUI();
                XMLDecode._instance.DecodeXML(mi.smi);
                UiManage.UIHideByPanel(gameObject, 4);
                UiManage._instance.HideUIMask(true);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isCanGetInput && isLoadComp)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Layout.Replace("ESC");
                MaskPanel.HideMask();
                StopAllCoroutines();
                Debug.Log("ESC");
                UIMoviePart._instance.StopMovieForUI();
                isCanGetInput = false;
                UiManage.UIShowByPanel(UiManage._instance.selectCoursePannel, gameObject, 0.5f, 0.5f);
            }
        }
    }
}
