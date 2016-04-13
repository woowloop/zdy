using UnityEngine;
using System.Collections;
using System;

public class StarEff : MonoBehaviour {
    public Texture2D[] stars;
    int StarNum=0;
    int markcount = 0;
    int continuationcount=0;
    float zerorate=0;
    bool iszero;
    int zerocount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Instrument(float mark, float fullmark)
    {
        StarNum = (int)Math.Floor((mark / fullmark) * 10);
        //print(StarNum);
        GetComponent<UITexture>().mainTexture=stars[StarNum];
    }
    public void BackZero()
    {
        GetComponent<UITexture>().mainTexture = stars[0];
    }
    public void Receive(int mark)
    {
        markcount++;
        if (mark == 0)
        {
            zerocount++;
            if (iszero)
            {
                continuationcount++;
            }
            iszero = true;
        }
        else
        {
            iszero = false;
        }
    }
}
