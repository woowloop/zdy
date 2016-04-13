using UnityEngine;
using System.Collections;

public class CurveScore : MonoBehaviour
{
    public AutoGetSelectPot autoSelectInf = null;
    public bool isCanEsc = true;

    public GameObject buttonList;
    public static CurveScore _instance;
    bool isCanGetInput = true;
    void Awake()
    {
        _instance = this;
        gameObject.SetActive(false);
    }
    void Start()
    {
        if (buttonList==null)
        {
            buttonList=transform.Find("ButtonList").gameObject;
        }
        if (buttonList)
        {
            autoSelectInf=buttonList.GetComponent<AutoGetSelectPot>();
            if (autoSelectInf)
            {
                autoSelectInf.OnSelectItem += SelectSprit;
                autoSelectInf.OnClickItem += EntSprit;
            }
        }
    }
    void OnEnable()
    {
        isCanGetInput = true;
    }
    /*
    public delegate void RestartGame();
    public event RestartGame OnRestartGame;
    public void NotifyRestartGame()
    {
        if (OnRestartGame!=null)
        {
            OnRestartGame();
        }
    }*/
    void SelectSprit(Transform tr1,Transform tr2, int nIndex)
    {

        TweenScale ts_old = tr1.GetComponent<TweenScale>();
        if (ts_old)
        {
            ts_old.PlayReverse();
        }
        TweenScale ts = tr2.GetComponent<TweenScale>();
        if (ts)
        {
            ts.PlayForward();
        }
    }
    void EntSprit(Transform tr1,int nIndex)
    {
        if (isCanGetInput && isCanEsc)
        {
            isCanEsc = false;
            UIButton uibtn = tr1.GetComponent<UIButton>();
            uibtn.SendMessage("OnClick");
        }
    }
    void Update()
    {
        if (isCanGetInput)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("ESC");
                if (isCanEsc)
                {
                    isCanGetInput = false;
                    UiManage.UIShowByPanel(UiManage._instance.selectMoviePanel, gameObject, 0.5f, 0.5f);
                    UiManage._instance.HideUIMask(false);
                }
            }
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
