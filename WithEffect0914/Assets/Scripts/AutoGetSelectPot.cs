using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class AutoGetSelectPot : MonoBehaviour
{
    enum _EnDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    // Use this for initialization
    UIGrid uiGrid = null;
    int nIndex = 0;
    int nLine = 0;
    int nIndexPre = 0;
    bool canSelect = true;
    public UIScrollBar uiScrollBar;
   /* public UIScrollView uiScrollView;
    [Tooltip("宽度修正")]
    public float scrollCorrectX = 0;
    [Tooltip("高度修正")]
    public float scrollCorrectY = 0;*/
    public delegate void SelectItemEventHandler(Transform transPre, Transform transCur, int nIndex);
    public event SelectItemEventHandler OnSelectItem;
    public delegate void ClickItemEventHandler(Transform transCur, int nIndex);
    public event ClickItemEventHandler OnClickItem;

    public delegate void ToTheEndItemEventHandler(Transform transCur, int nIndex);
    public event ToTheEndItemEventHandler OnToTheEndItemEvent;
    public void NotifySelectItem(Transform transPre, Transform transCur, int nIndex)
    {
        //Debug.Log(":>>"+nIndex);
        if (OnSelectItem != null)
        {
            OnSelectItem(transPre, transCur, nIndex);
        }
    }
    public void NotifyClickItem(Transform transCur, int nIndex)
    {
        if (OnClickItem != null)
        {
            OnClickItem(transCur, nIndex);
        }
    }
    public void NotifyToTheEndItem(Transform transCur, int nIndex)
    {
        if (OnToTheEndItemEvent != null)
        {
            OnToTheEndItemEvent(transCur, nIndex);
        }
    }
    void Start()
    {
        Init();
    }
    public void SetInputInvain()
    {
        canSelect = false;
    }
    public bool Init()
    {
        canSelect = true;
        if (uiScrollBar)
        {
            uiScrollBar.value = 0;
        }
        //nIndex = 0;
        bool nRet = false;
        uiGrid = GetComponent<UIGrid>();
        if (uiGrid)
        {
            nRet = true;
        }
        return nRet;
    }
    void AdjustPostion(_EnDirection eDir, int nIndex)
    {
        if (uiScrollBar && uiGrid)
        {
            if (uiGrid.GetChildList().Count>1)
            {
                int nCurLine = nIndex / uiGrid.maxPerLine;
                float fVal;
                fVal = nCurLine / (float)((uiGrid.GetChildList().Count - 1) / uiGrid.maxPerLine);
                DOTween.To(() => uiScrollBar.value, x => uiScrollBar.value = x, fVal, 0.25f);
            }
            //Debug.Log(uiScrollBar.value);
        }
    }
    /*void AdjustPostion(_EnDirection eDir, int nIndex,int n)
    {
        if (uiScrollView && uiGrid)
        {
            int nCurLine = nIndex / uiGrid.maxPerLine;
            if (uiScrollView.movement == UIScrollView.Movement.Vertical)
            {
                float fVal = uiScrollView.gameObject.GetComponent<UIPanel>().GetViewSize().y;
                Debug.Log((int)(uiGrid.GetChildList().Count / uiGrid.maxPerLine));
                fVal = ((int)(uiGrid.GetChildList().Count / uiGrid.maxPerLine) * uiGrid.cellHeight + scrollCorrectY) / fVal;
                fVal /= (int)(uiGrid.GetChildList().Count / uiGrid.maxPerLine);
                if (nLine != nCurLine)
                {
                    if (nCurLine == 0)
                    {
                        uiScrollView.ResetPosition();
                    }
                    switch (eDir)
                    {
                        case _EnDirection.UP:
                            uiScrollView.Scroll(fVal / uiScrollView.scrollWheelFactor);
                            break;
                        case _EnDirection.DOWN:
                            uiScrollView.Scroll(-fVal / uiScrollView.scrollWheelFactor);
                            break;
                        case _EnDirection.LEFT:
                            uiScrollView.Scroll(fVal / uiScrollView.scrollWheelFactor);
                            break;
                        case _EnDirection.RIGHT:
                            uiScrollView.Scroll(-fVal / uiScrollView.scrollWheelFactor);
                            break;
                        default:
                            break;
                    }
                    nLine = nCurLine;
                }

            }
            else if (uiScrollView.movement == UIScrollView.Movement.Horizontal)
            {
                float fVal = uiScrollView.gameObject.GetComponent<UIPanel>().GetViewSize().x;
                Debug.Log(uiScrollView.scrollWheelFactor + "::" + fVal + "::" + ((int)(uiGrid.GetChildList().Count / uiGrid.maxPerLine) * uiGrid.cellWidth));
                fVal = ((int)(uiGrid.GetChildList().Count / uiGrid.maxPerLine) * uiGrid.cellWidth + scrollCorrectX) / fVal;
                fVal /= (int)(uiGrid.GetChildList().Count / uiGrid.maxPerLine);
                //fVal *= 2;
                if (nLine != nCurLine)
                {
                    if (nCurLine == 0)
                    {
                        uiScrollView.ResetPosition();
                    }
                    switch (eDir)
                    {
                        case _EnDirection.UP:
                            uiScrollView.Scroll(-fVal / uiScrollView.scrollWheelFactor);
                            break;
                        case _EnDirection.DOWN:
                            uiScrollView.Scroll(fVal / uiScrollView.scrollWheelFactor);
                            break;
                        case _EnDirection.LEFT:
                            uiScrollView.Scroll(-fVal / uiScrollView.scrollWheelFactor);
                            break;
                        case _EnDirection.RIGHT:
                            uiScrollView.Scroll(fVal / uiScrollView.scrollWheelFactor);
                            break;
                        default:
                            break;
                    }
                    nLine = nCurLine;
                }
            }

        }
    }*/
    void SelectTest(int nIndex)
    {
        uiGrid.GetChild(nIndexPre).GetComponent<TweenScale>().PlayReverse();
        uiGrid.GetChild(nIndex).GetComponent<TweenScale>().PlayForward();
        nIndexPre = nIndex;
    }
    // Update is called once per frame
    void Update()
    {
        if (canSelect&&uiGrid && uiGrid.GetChildList().Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                NotifyClickItem(uiGrid.GetChild(Mathf.Abs(nIndex)), nIndex);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (uiGrid.arrangement == UIGrid.Arrangement.Horizontal)
                {
                    if (nIndex + 1 < uiGrid.GetChildList().Count)
                    {
                        nIndex++;
                        nIndex = nIndex % uiGrid.GetChildList().Count;
                    }
                    else
                    {
                        NotifyToTheEndItem(uiGrid.GetChild(Mathf.Abs(nIndex)), nIndex);
                    }
                }
                else
                {
                    if (nIndex + uiGrid.maxPerLine < uiGrid.GetChildList().Count)
                    {
                        nIndex += uiGrid.maxPerLine;
                        nIndex = nIndex % uiGrid.GetChildList().Count;
                    }
                    else
                    {
                        NotifyToTheEndItem(uiGrid.GetChild(Mathf.Abs(nIndex)), nIndex);
                    }
                }
                AdjustPostion(_EnDirection.RIGHT, nIndex);
                NotifySelectItem(uiGrid.GetChild(Mathf.Abs(nIndexPre)), uiGrid.GetChild(Mathf.Abs(nIndex)), nIndex);
                nIndexPre = nIndex;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (uiGrid.arrangement == UIGrid.Arrangement.Horizontal)
                {
                    if (nIndex - 1 >= 0)
                    {
                        nIndex--;
                    }
                }
                else
                {
                    if (nIndex - uiGrid.maxPerLine >= 0)
                    {
                        nIndex -= uiGrid.maxPerLine;
                        nIndex = nIndex % uiGrid.GetChildList().Count;
                    }
                }
                AdjustPostion(_EnDirection.LEFT, nIndex);
                NotifySelectItem(uiGrid.GetChild(Mathf.Abs(nIndexPre)), uiGrid.GetChild(Mathf.Abs(nIndex)), nIndex);
                nIndexPre = nIndex;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (uiGrid.arrangement == UIGrid.Arrangement.Horizontal)
                {
                    if (nIndex + uiGrid.maxPerLine < uiGrid.GetChildList().Count)
                    {
                        nIndex += uiGrid.maxPerLine;
                        nIndex = nIndex % uiGrid.GetChildList().Count;
                    }
                    else
                    {
                        NotifyToTheEndItem(uiGrid.GetChild(Mathf.Abs(nIndex)), nIndex);
                    }
                }
                else
                {
                    if (nIndex + 1 < uiGrid.GetChildList().Count)
                    {
                        nIndex++;
                        nIndex = nIndex % uiGrid.GetChildList().Count;
                    }
                    else
                    {
                        NotifyToTheEndItem( uiGrid.GetChild(Mathf.Abs(nIndex)),nIndex);
                    }
                }
                AdjustPostion(_EnDirection.DOWN, nIndex);
                NotifySelectItem(uiGrid.GetChild(Mathf.Abs(nIndexPre)), uiGrid.GetChild(Mathf.Abs(nIndex)), nIndex);
                nIndexPre = nIndex;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (uiGrid.arrangement == UIGrid.Arrangement.Horizontal)
                {
                    if (nIndex - uiGrid.maxPerLine >= 0)
                    {
                        nIndex -= uiGrid.maxPerLine;
                        nIndex = nIndex % uiGrid.GetChildList().Count;
                    }
                }
                else
                {
                    if (nIndex - 1 >= 0)
                    {
                        nIndex--;
                    }
                    /*if (nIndex < 0)
                    {
                        nIndex = uiGrid.GetChildList().Count - 1;
                    }*/
                }
                AdjustPostion(_EnDirection.UP, nIndex);
                NotifySelectItem(uiGrid.GetChild(Mathf.Abs(nIndexPre)), uiGrid.GetChild(Mathf.Abs(nIndex)), nIndex);
                nIndexPre = nIndex;
            }
        }
    }
}
