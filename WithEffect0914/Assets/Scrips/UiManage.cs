using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UiManage : MonoBehaviour
{

    public static UiManage _instance;
    private UILabel zhidao;
	NISkeletonController  jointsProjective;
    public GameObject startPannel, userInforPannel, selectMoviePanel, selectCoursePannel;
    private bool verify = true;
    public GameObject UIMask;
    void Awake()
    {
        _instance = this;
        jointsProjective = FindObjectOfType(typeof(NISkeletonController)) as NISkeletonController;
    }
    public static void ShadeColorForUITex(UITexture uiTex, float time = 0.5f)
    {
        if (uiTex)
        {
            Color c = uiTex.color;
            uiTex.color = new Color(c.r, c.g, c.b, 0);
            DOTween.To(() => uiTex.color, x => uiTex.color = x, c, time);
        }
    }
    void Update()
    {
        if (TestMobileTexture._instance.isbegin == true)
        {
            ZhiDao();
        }
    }
    void Start()
    {
        zhidao = GameObject.Find("Zhidao").GetComponent<UILabel>();
        QRlogin._instance.OnLoginSucceed += StartShowUserInf;
     /*   if (QRlogin._instance.user.NickName != null)
        {
            Debug.Log(QRlogin._instance.user.NickName);
            StartCoroutine(UiShow(userInforPannel, startPannel, 3, 0.3f));
            //StartCoroutine (UiShow (goalSettingPannel, userInforPannel, 5, 0.3f));
        }
        else
        {
            ZxingDraw._instance.DrawCode();
        }*/

    }
   /* void Update()
    {
        if ((QRlogin._instance.user.NickName != null || true) && verify == true)
        {
            Debug.Log(QRlogin._instance.user.NickName);
            ZxingDraw._instance.CalCode();
            StartCoroutine(UiShow(userInforPannel, startPannel, 3, 0.3f));
            StartCoroutine(UiShow(goalSettingPannel, userInforPannel, 5, 0.3f));
            verify = false;
        }
    }*/

    void ZhiDao()
    {
        if (NISkeletonController.furtherValid)
        {
            bool valid_forward = jointsProjective.trans.z < -1300;
            bool valid_left = jointsProjective.trans.x > -500f;
            bool valid_right = jointsProjective.trans.x < 500f;
            zhidao.text = valid_forward ? valid_left ? valid_right ? "" : "往左站" : "往右站" : valid_left ? valid_right ? "往后站" : "往后右方" : "往后左方";
        }
        else
            zhidao.text = "没有目标";

    }

    void StartShowUserInf()
    {
        //QRlogin._instance.OnLoginSucceed -= StartShowUserInf;
        //StartCoroutine(UiShow(userInforPannel, startPannel, 3, 0.3f));
        UIShowByPanel(userInforPannel, startPannel, 2f, 2f);
        //StartCoroutine(UiShow(goalSettingPannel, userInforPannel, 5, 0.3f));
    }
    public static void UIShowByPanel(GameObject showObj, GameObject hideObj, float showTime, float hideTime)
    {
        showObj.SetActive(true);
        UIPanel uiShow = showObj.GetComponent<UIPanel>();
        UIPanel uiHide = hideObj.GetComponent<UIPanel>();
        if (uiShow)
        {
            uiShow.alpha = 0;
            DOTween.To(() => uiShow.alpha, x => uiShow.alpha = x, 1, showTime);
        }
        if (uiHide)
        {
            DOTween.To(() => uiHide.alpha, x => uiHide.alpha = x, 0, hideTime).OnComplete(() => { hideObj.SetActive(false); });
        }else 
        {
            hideObj.SetActive(false);
        }
    }
    public static void UIHideByPanel(GameObject hideObj, float hideTime)
    {
        UIPanel uiHide = hideObj.GetComponent<UIPanel>();
        if (uiHide)
        {
            DOTween.To(() => uiHide.alpha, x => uiHide.alpha = x, 0, hideTime).OnComplete(() => { hideObj.SetActive(false); });
        }
        else
        {
            hideObj.SetActive(false);
        }
    }

    public void HideUIMask(bool isHide)
    {
        if (UIMask)
        {
            UIMask.SetActive(!isHide);
        }
    }
   /* public IEnumerator UiShow(GameObject showObj, GameObject hideObj, float showTime, float hideTime)
    {
        yield return new WaitForSeconds(showTime);
        showObj.SetActive(true);
        yield return new WaitForSeconds(hideTime);
        hideObj.SetActive(false);
    }*/
}
