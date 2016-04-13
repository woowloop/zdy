using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class TopScore : MonoBehaviour {
    private string url;
    private XmlDocument xmlDoc;
    private XmlNodeList levelNodeList;
    //private NumCrtl nc;
    //private NumCrtl nc1;
    //public GameObject BestScore;
    //public GameObject OverBestScore;
    //public GameObject ConfusionBombEffect;
    //public bool IsConfusionBombEffect;
    XmlElement xe;
    float time;
    public GameObject trophy;
	// Use this for initialization
	void Start () {
        //nc = BestScore.GetComponent<NumCrtl>();
        //nc1 = OverBestScore.GetComponent<NumCrtl>();
        xmlDoc = new XmlDocument();
        url = Application.streamingAssetsPath+"/TopScore.xml";
        xmlDoc.Load(url);
        levelNodeList = xmlDoc.SelectNodes("/levels/video");
	}
	
	// Update is called once per frame
	void Update () {
        //if (xe != null)
        //{
        //    if (Scoring_Tony1.scorenum > int.Parse(xe.InnerText))
        //    {
                //if (IsConfusionBombEffect)
                //{
                    //GameObject ConfusionBombEffectClone = Instantiate(ConfusionBombEffect, ConfusionBombEffect.transform.position, ConfusionBombEffect.transform.rotation) as GameObject;
                //    Destroy(ConfusionBombEffectClone, 6);
                //    IsConfusionBombEffect = false;
                //}
                //BestScore.SetActive(false);
                //OverBestScore.SetActive(true);
                //nc1.num = Scoring_Tony.scorenum.ToString();
        //    }
        //}
        if (time < Time.time)
        {
            trophy.SetActive(false);
        }
	}
    public void Receive(int[]mess)
    {
        int i = mess[0];
        int j = mess[1];
        xe = (XmlElement)levelNodeList[j];
        //if (i == 0)
        //{
        //    BestScore.SetActive(true);
        //    OverBestScore.SetActive(false);
        //    //nc.num = xe.InnerText;
        //}
         if (i == 1)
        {
            if (Scoring_Tony1.scorenum > int.Parse(xe.InnerText))
            {
                trophy.SetActive(true);
                time = Time.time + 2;
                xe.InnerText = Scoring_Tony1.scorenum.ToString();
                xmlDoc.Save(url);
            }
        }
    }
    void OnDestroy()
    {
        if (xe!=null)
        {
            if (Scoring_Tony1.scorenum > int.Parse(xe.InnerText))
            {
                xe.InnerText = Scoring_Tony1.scorenum.ToString();
                xmlDoc.Save(url);
            }
        }
    }
}
