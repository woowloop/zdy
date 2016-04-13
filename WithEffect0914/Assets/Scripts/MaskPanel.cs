
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MaskPanel : MonoBehaviour {


    public static MaskPanel _instance;
    public UITexture uiTexMaskPic;
    Coroutine myCR=null;
    Color cOrg;
	// Use this for initialization
	void Awake () 
    {
        _instance = this;
        if (uiTexMaskPic)
        {
            cOrg = _instance.uiTexMaskPic.color;
        }
	}
    void Start()
    {
        HideMask();
    }
	public static void ShowMask(WWW www=null)
    {
        if (_instance.uiTexMaskPic != null)
        {
            if (_instance.myCR!=null)
            {
                _instance.StopCoroutine(_instance.myCR);
                _instance.myCR = null;
            }
            Color c = _instance.cOrg;
            _instance.uiTexMaskPic.color = new Color(c.r, c.g, c.b, 0);
            DOTween.To(() => _instance.uiTexMaskPic.color, x => _instance.uiTexMaskPic.color = x, c, 0.1f);
            if (www != null)
            {
                _instance.myCR = _instance.StartCoroutine(_instance.LoopDectWWW(www));
            }
        }
    }
    IEnumerator LoopDectWWW(WWW www)
    {
        if (www.error == null && www.progress==1)
        {
            HideMask();
        }
        yield return new WaitForSeconds(0.2f);
        myCR=StartCoroutine(LoopDectWWW(www));
    }
    public static void HideMask()
    {
        if (_instance.uiTexMaskPic != null)
        {
            if (_instance.myCR != null)
            {
                _instance.StopCoroutine(_instance.myCR);
                _instance.myCR = null;
            }
            Color c = _instance.uiTexMaskPic.color;
            c = new Color(c.r, c.g, c.b, 0);
            DOTween.To(() => _instance.uiTexMaskPic.color, x => _instance.uiTexMaskPic.color = x, c, 0.1f);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
