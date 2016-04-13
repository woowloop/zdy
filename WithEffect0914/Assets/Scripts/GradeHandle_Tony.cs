using UnityEngine;
using System.Collections;

public class GradeHandle_Tony : MonoBehaviour {
    public string lhandi = null;
    public string rhandi = null;
    public string rfooti = null;
    public string lfooti = null;
	public string lelbowi = null;
	public string relbowi = null;
	public string lkneei = null;
	public string rkneei = null;
	public string rshoulderi = null;
	public string lshoulderi = null;
	public string headi = null;
	private Scoring_Tony1 st1;
	private ShowEuler showeuler;

	void Awake()
	{
		showeuler = GameObject.Find ("JointSpheres").GetComponent<ShowEuler> ();
		st1 = GameObject.Find("Cube1").GetComponent<Scoring_Tony1>() as Scoring_Tony1;

        //jointTrackers[1] = GameObject.FindWithTag("SphereElbowL").GetComponent<JointTracker>();
        //jointTrackers[2] = GameObject.FindWithTag("SphereElbowR").GetComponent<JointTracker>();
        //jointTrackers[3] = GameObject.FindWithTag("SphereFootL").GetComponent<JointTracker>();
        //jointTrackers[4] = GameObject.FindWithTag("SphereFootR").GetComponent<JointTracker>();
        //jointTrackers[5] = GameObject.FindWithTag("SphereHead").GetComponent<JointTracker>();
        //jointTrackers[6] = GameObject.FindWithTag("SphereKneeL").GetComponent<JointTracker>();
        //jointTrackers[7] = GameObject.FindWithTag("SphereKneeR").GetComponent<JointTracker>();
        //jointTrackers[8] = GameObject.FindWithTag("SphereL").GetComponent<JointTracker>();
        //jointTrackers[9] = GameObject.FindWithTag("SphereR").GetComponent<JointTracker>();
        //jointTrackers[10] = GameObject.FindWithTag("SphereShoulderL").GetComponent<JointTracker>();
        //jointTrackers[11] = GameObject.FindWithTag("SphereShoulderR").GetComponent<JointTracker>();
	}

	void Start()
	{
		showeuler.isshowHead = false;
		showeuler.isshowHandR = false;
		showeuler.isshowHandL = false;
		showeuler.isshowHandR = false;
		showeuler.isshowElbowR = false;
		showeuler.isshowElbowL = false;
		showeuler.isshowShoulderR = false;
		showeuler.isshowShoulderL = false;
		showeuler.isshowKneeR = false;
		showeuler.isshowKneeL = false;
		showeuler.isshowFootR = false;
		showeuler.isshowFootL = false;
	}

	void Update ()
	{
        if ((lhandi.Contains("1") || lhandi.Contains("2") || lhandi.Contains("3")) && !st1.hasshowhandl) 
		{
			showeuler.isshowHandL = true;
			st1.hasshowhandl = true;
		}
        else if ((rhandi.Contains("1") || rhandi.Contains("2") || rhandi.Contains("3")) && !st1.hasshowhandr)
		{
			showeuler.isshowHandR = true;
			st1.hasshowhandr = true;
		}
        else if ((lelbowi.Contains("1") || lelbowi.Contains("2") || lelbowi.Contains("3")) && !st1.hasshowelbowl)
		{
			showeuler.isshowElbowL = true;
			st1.hasshowelbowl = true;
		}
        else if ((relbowi.Contains("1") || relbowi.Contains("2") || relbowi.Contains("3")) && !st1.hasshowelbowr)
		{
			showeuler.isshowElbowR = true;
			st1.hasshowelbowr = true;
		}
        else if ((lshoulderi.Contains("1") || lshoulderi.Contains("2") || lshoulderi.Contains("3")) && !st1.hasshowshoulderl )
		{
			showeuler.isshowShoulderL = true;
			st1.hasshowshoulderl = true;
		}
        else if ((rshoulderi.Contains("1") || rshoulderi.Contains("2") || rshoulderi.Contains("3")) && !st1.hasshowelbowr)
		{
			showeuler.isshowShoulderR = true;
            st1.hasshowshoulderr = true;
		}
        else if ((lkneei.Contains("1") || lkneei.Contains("2") || lkneei.Contains("3")) && !st1.hasshowkneel)
		{
			showeuler.isshowKneeL = true;
			st1.hasshowkneel = true;
		}
        else if ((rkneei.Contains("1") || rkneei.Contains("2") || rkneei.Contains("3")) && !st1.hasshowkneer)
		{
			showeuler.isshowKneeR = true;
			st1.hasshowkneer = true;
		}
        else if ((lfooti.Contains("1") || lfooti.Contains("2") || lfooti.Contains("3")) && !st1.hasshowfootl)
		{
			showeuler.isshowFootL = true;
			st1.hasshowfootl = true;
		}
        else if ((rfooti.Contains("1") || rfooti.Contains("2") || rfooti.Contains("3")) && !st1.hasshowfootr )
		{
			showeuler.isshowFootR = true;
			st1.hasshowfootr = true;
		}
        else if ((headi.Contains("1") || headi.Contains("2") || headi.Contains("3")) && !st1.hasshowhead)
		{
			showeuler.isshowHead = true;
			st1.hasshowhead = true;
		}
	
	}

}
