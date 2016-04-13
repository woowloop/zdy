using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    UILabel currenNum;

    void Awake()
    {
        currenNum = transform.Find("CurrenNum").GetComponent<UILabel>();
    }
    
    void Start () {
	
	}
	
	
	void Update () {
       // print(Scoring_Tony1.scorenum);

        if (Scoring_Tony1.scorenum != 0)
            currenNum.text = Scoring_Tony1.scorenum + "";
        else
            currenNum.text = 0 + "";
	}
}
