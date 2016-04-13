using UnityEngine;
using System.Collections;

public class SmallMissPic : MonoBehaviour {

    UITexture smallTexure;
    public int id;
    Color startColor;
    int idInMissPics;
    GameObject whitePlan;


    void Awake()
    {
        smallTexure=GetComponent<UITexture>();
        whitePlan = transform.Find("White").gameObject; 
    }
    
    void Start () {
        whitePlan.SetActive(false);
	}

	void Update () {
	
	}
    //显示图片方法（参数为ID）
    //显示截取的RGB图片集合的第ID个
    public void ShowSmallPic(int id, int idInMissPics)
    {
        this.id = id;
        this.idInMissPics = idInMissPics;
       // smallTexure.mainTexture = ScreenRgb._instance.list2[id];
        StartCoroutine(GetMissPic(id));
    }
    public void OnClick()
    {
        Feedback._instance.PlayBackPng(id,idInMissPics);
        //颜色变化
        whitePlan.SetActive(true);
    }
    //颜色恢复方法
    public void ColorRecover()
    {
        whitePlan.SetActive(false);
    }
    IEnumerator GetMissPic(int id)
    {
        string path2 = "file:///" + Application.dataPath + "/shexiang/" + id + ".png";
        WWW wwww2 = new WWW(path2);
        yield return wwww2;
        // t = (Texture)wwww.texture;
        smallTexure.mainTexture = wwww2.texture;
    }
}