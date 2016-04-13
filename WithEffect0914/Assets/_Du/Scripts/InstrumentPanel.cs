using UnityEngine;
using System;
using System.Collections;
using MMT;

public class InstrumentPanel : MonoBehaviour {
    public Texture2D[] stars;
    int StarNum;
    public GameObject tx;
    int ti = 0;
    Vector3 currenteuler;
    int markcount;
    int zerocount;
    int continuationcount;
    float zerorate;
    bool iszero;
    MobileMovieTexture _mmt;
	// Use this for initialization
	void Start () {
        _mmt = GameObject.Find("ViedoPlayerAndroid").GetComponent<MobileMovieTexture>();
	}
	
	// Update is called once per frame
	void Update () {

       // print(transform.position);
        //if (continuationcount >= 3 )
        //{
        //    if (markcount > 0)
        //    {
        //        zerorate = zerocount / markcount;
        //        print(zerorate);
        //        markcount = 0;
        //        zerorate = 0;
        //        continuationcount = 0;
        //        iszero = false;
        //        Time.timeScale = 0;
        //    }
        //}
        //else if (!_mmt.isPlaying)
        //{
        //    if (markcount > 0)
        //    {
        //        zerorate = zerocount / markcount;
        //        print(zerorate);
        //        markcount = 0;
        //        zerorate = 0;
        //        continuationcount = 0;
        //        iszero = false;
        //    }
        //}
	}
    public void Instrument(float mark, float fullmark)
    {
        StarNum =(int)Math.Floor((mark / fullmark)*10);
        //print(StarNum);
        this.renderer.material.mainTexture = stars[StarNum]; 
    }
    public void BackZero()
    {
        this.renderer.material.mainTexture=stars[0];
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
