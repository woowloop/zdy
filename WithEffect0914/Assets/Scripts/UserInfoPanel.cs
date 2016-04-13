using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CourseTypeInf
{
    public int nID;
    public string name;
}
public class UserInfoPanel : MonoBehaviour
{
   // private TweenScale tweenname;
    private bool reShow = false;
    private string rename = null;

    public bool isShow = true;
    public UITexture avatar;
    public UILabel wechatId;
    public UILabel gender;
    public UILabel age;
    public UILabel height;
    public UILabel weight;
    public UILabel username;

    private string urlpath;

    bool isCanGetInput = true;
    void Awake()
    {
        if (avatar == null)
            avatar = transform.Find("UserInfoPanal/avatar").GetComponent<UITexture>();
        if (wechatId == null)
            wechatId = transform.Find("UserInfoPanal/WeChatID").GetComponent<UILabel>();
        if (gender == null)
            gender = transform.Find("UserInfoPanal/Gender").GetComponent<UILabel>();
        if (age == null)
            age = transform.Find("UserInfoPanal/Age").GetComponent<UILabel>();
        if (height == null)
            height = transform.Find("UserInfoPanal/Height").GetComponent<UILabel>();
        if (weight == null)
            weight = transform.Find("UserInfoPanal/Weight").GetComponent<UILabel>();
        if (username == null)
            username = GameObject.Find("UserName").GetComponent<UILabel>();
    }
    void Start()
    {
        QRlogin._instance.OnLoginSucceed += DrawUserInfo;
       // QRlogin._instance.OnLoginSucceed += StartShowUserInf;
      //  gameObject.SetActive(false);
    }
    void OnEnable()
    {
        isCanGetInput = true;
        if (ZxingDraw._instance && !ZxingDraw._instance.isShow)
        {
            ZxingDraw._instance.DrawCode();
        }
    }
    void DrawUserInfo()
    {
        //gameObject.SetActive(true);
        rename = QRlogin._instance.user.NickName;
      //  QRlogin._instance.isShow = false;
        wechatId.text = "ID:" + QRlogin._instance.user.NickName;
        Debug.Log(QRlogin._instance.user.NickName);
        username.text = QRlogin._instance.user.NickName;
        if (QRlogin._instance.user.gender == true)
        {
            gender.text = "Gender:Male";
        }
        else
        {
            gender.text = "Gender:Female";
        }
        age.text = "Age:" + QRlogin._instance.user.age.ToString();
        height.text = "Height:" + QRlogin._instance.user.height.ToString() + "cm";
        weight.text = "Weight:" + ((int)QRlogin._instance.user.weight).ToString() + "kg";
        urlpath = QRlogin._instance.user.avatar;
        if (urlpath != null)
        {
            if (!urlpath.StartsWith("http://"))
            {
                urlpath = "http://shapejoy.duapp.com/" + urlpath;
            }
            StartCoroutine(LoadAvatar(urlpath));
        }
    }
    IEnumerator LoadAvatar(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            avatar.mainTexture = (Texture2D)www.texture;
        }
        //avatar .mainTexture = (Texture2D )www.texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanGetInput)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                Debug.Log("ESC");
                isCanGetInput = false;
                //UiManage._instance.UIShowByPanel(UiManage._instance.startPannel, gameObject, 0.5f, 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                MaskPanel.ShowMask();
                if (CourseDetail.CourseType._Instance != null && CourseDetail.CourseType._Instance.IsInitOk)
                {
                    MaskPanel.HideMask();
                    ZxingDraw._instance.DestroyCode();

                    List<CourseTypeInf> lsCT = new List<CourseTypeInf>();
                    lsCT.Clear();
                    CourseTypeInf ci2 = new CourseTypeInf();
                    ci2.nID = -1;
                    ci2.name = "今日计划";
                    lsCT.Add(ci2);
                    isCanGetInput = false;
                    UiManage.UIShowByPanel(UiManage._instance.selectCoursePannel, UiManage._instance.userInforPannel, 1, 1f);
                    foreach (var item in CourseDetail.CourseType._Instance.detail)
                    {
                        CourseDetail.CourseType.DetailType dt = item;
                        CourseTypeInf ci = new CourseTypeInf();
                        ci.nID = dt.id;
                        ci.name = dt.name;
                        lsCT.Add(ci);
                    }
                    SelectCoursePanel._instance.AddCourseToList(lsCT);
                }
            }
        }
    }
}
