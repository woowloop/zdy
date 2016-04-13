using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowEuler : MonoBehaviour {
	private Transform SphereElbowL;
	private Transform SphereElbowR;
	private Transform SphereHandL;
	private Transform SphereHandR;
	private Transform SphereShoulderL;
	private Transform SphereShoulderR;
	private Transform SphereKneeR;
	private Transform SphereKneeL;
	private Transform SphereFootR;
	private Transform SphereFootL;
	private Transform SphereHead;


	private Vector3 elbowhandl;
	private Vector3 elbowhandr;
	private Vector3 elbowshoulderl;
	private Vector3 elbowshoulderr;
	private int lefteuler;
	private int righteuler;
	public TextMesh leftelbow;
	public TextMesh rightelbow;
    public TextMesh leftHip,rightHip;
    private int leftKneeAngel, rightKneeAngel;

    private Vector3 leftKneeFoot, rightKneeFoot, leftKneeWaist, rightKneeWaist;

	public bool isshowHead;
	public bool isshowHandR;
	public bool isshowHandL;
	public bool isshowElbowR;
	public bool isshowElbowL;
	public bool isshowShoulderR;
	public bool isshowShoulderL;
	public bool isshowKneeR;
	public bool isshowKneeL;
	public bool isshowFootR;
	public bool isshowFootL;

	public bool isshowWrongHead;
	public bool isshowWrongHandR;
	public bool isshowWrongHandL;
	public bool isshowWrongElbowR;
	public bool isshowWrongElbowL;
	public bool isshowWrongShoulderR;
	public bool isshowWrongShoulderL;
	public bool isshowWrongKneeR;
	public bool isshowWrongKneeL;
	public bool isshowWrongFootR;
	public bool isshowWrongFootL;

	private GameObject ElbowLRightPic;
	private GameObject ElbowLWrongPic;
	private GameObject ElbowRRightPic;
	private GameObject ElbowRWrongPic;
	private GameObject FootLRightPic;
	private GameObject FootLWrongPic;
	private GameObject FootRRightPic;
	private GameObject FootRWrongPic;
	private GameObject HeadRightPic;
	private GameObject HeadWrongPic;
	private GameObject KneeLRightPic;
	private GameObject KneeLWrongPic;
	private GameObject KneeRWrongPic;
	private GameObject KneeRRightPic;

	private GameObject HandLRightPic;
	private GameObject HandRRightPic;
	private GameObject HandLWrongPic;
	private GameObject HandRWrongPic;
	private GameObject ShoulderLRightPic;
	private GameObject ShoulderLWrongPic;
	private GameObject ShoulderRRightPic;
	private GameObject ShoulderRWrongPic;

	private NIRadarViewerUtility nrv;

    public GameObject sphereHipL, sphereHipR;
	//public List<Texture2D> movietexs = new List<Texture2D>();

    //定义几个标签的位置
    //public GameObject leftShoulderSign, leftElbowSign, leftHandSign;
    //Transform[] leftElbowPoints;
    //LineRenderer lineRenderer;


	void Awake () 
	{
		SphereElbowL = GameObject.Find ("SphereElbowL").transform;
		SphereElbowR = GameObject.Find ("SphereElbowR").transform;
		SphereHandL = GameObject.Find ("SphereL").transform;
		SphereHandR = GameObject.Find ("SphereR").transform;
		SphereShoulderL = GameObject.Find ("SphereShoulderL").transform;
		SphereShoulderR = GameObject.Find ("SphereShoulderR").transform;
		SphereKneeR = GameObject.Find ("SphereKneeR").transform;
		SphereKneeL = GameObject.Find ("SphereKneeL").transform;
		SphereFootR = GameObject.Find ("SphereFootR").transform;
		SphereFootL = GameObject.Find ("SphereFootL").transform;
		SphereHead = GameObject.Find ("SphereHead").transform;
		ElbowLRightPic = GameObject.Find ("ElbowLRightPic");
		ElbowLWrongPic = GameObject.Find ("ElbowLWrongPic");
		ElbowRRightPic = GameObject.Find ("ElbowRRightPic");
		ElbowRWrongPic = GameObject.Find ("ElbowRWrongPic");
		FootLRightPic = GameObject.Find ("FootLRightPic");
		FootLWrongPic = GameObject.Find ("FootLWrongPic");
		FootRRightPic = GameObject.Find ("FootRRightPic");
		FootRWrongPic = GameObject.Find ("FootRWrongPic");
		HeadRightPic = GameObject.Find ("HeadRightPic");
		HeadWrongPic = GameObject.Find ("HeadWrongPic");
		KneeLRightPic = GameObject.Find ("KneeLRightPic");
		KneeLWrongPic = GameObject.Find ("KneeLWrongPic");
		KneeRRightPic = GameObject.Find ("KneeRRightPic");
		KneeRWrongPic = GameObject.Find ("KneeRWrongPic");
		HandLRightPic = GameObject.Find ("HandLRightPic");
		HandLWrongPic = GameObject.Find ("HandLWrongPic");
		HandRRightPic = GameObject.Find ("HandRRightPic");
		HandRWrongPic = GameObject.Find ("HandRWrongPic");
		ShoulderLRightPic = GameObject.Find ("ShoulderLRightPic");
		ShoulderLWrongPic = GameObject.Find ("ShoulderLWrongPic");
		ShoulderRRightPic = GameObject.Find ("ShoulderRRightPic");
		ShoulderRWrongPic = GameObject.Find ("ShoulderRWrongPic");
		nrv = GameObject.Find ("NIRadarViewer").GetComponent<NIRadarViewerUtility> ();

        //lineRenderer=GetComponent<LineRenderer>();

        
	}

	void Start()
	{
		isshowWrongHead = false;
		isshowWrongHandR = false;
		isshowWrongHandL = false;
		isshowWrongElbowR = false;
		isshowWrongElbowL = false;
		isshowWrongShoulderR = false;
		isshowWrongShoulderL = false;
		isshowWrongKneeR = false;
		isshowWrongKneeL = false;
		isshowWrongFootR = false;
		isshowWrongFootL = false;
		//LoadMoviePng ();
	}
	
	// Update is called once per frame
	void Update () 
	{
        //print(leftShoulderSign.transform);
		if (nrv.users.Length > 0) 
		{

            if (SphereShoulderL.GetComponent<JointTracker>().isOk && SphereElbowL.GetComponent<JointTracker>().isOk && SphereHandL.GetComponent<JointTracker>().isOk)
            {
                leftelbow.gameObject.SetActive(true);
                leftelbow.transform.position = new Vector3(SphereElbowL.position.x , SphereElbowL.position.y, SphereElbowL.position.z-0.1f);

                //位置分别与左肩膀、左肘、左手的位置一致
                //leftShoulderSign.transform.position = new Vector3(SphereShoulderL.transform.position.x - 0.5f, SphereShoulderL.transform.position.y, SphereShoulderL.transform.position.z-0.5f);
                //leftElbowSign.transform.position = new Vector3(SphereElbowL.transform.position.x - 0.5f, SphereElbowL.transform.position.y, SphereElbowL.transform.position.z - 0.5f);
                //leftHandSign.transform.position = new Vector3(SphereHandL.transform.position.x - 0.5f, SphereHandL.transform.position.y, SphereHandL.transform.position.z - 0.5f);

                //连线
                //iTween.DrawLine(leftElbowPoints);
                //lineRenderer.enabled = true;
                //lineRenderer.SetPosition(0, leftShoulderSign.transform.position);
                //lineRenderer.SetPosition(1, leftElbowSign.transform.position);
                //lineRenderer.SetPosition(2, leftHandSign.transform.position);

            }

            if (SphereShoulderR.GetComponent<JointTracker>().isOk && SphereElbowR.GetComponent<JointTracker>().isOk && SphereHandR.GetComponent<JointTracker>().isOk)
            {
                rightelbow.gameObject.SetActive(true);
                rightelbow.transform.position = new Vector3(SphereElbowR.position.x, SphereElbowR.position.y, SphereElbowR.position.z-0.1f);
            }

            if (sphereHipL.GetComponent<JointTracker>().isOk && SphereKneeL.GetComponent<JointTracker>().isOk && SphereFootL.GetComponent<JointTracker>().isOk)
            {
                leftHip.gameObject.SetActive(true);
				leftHip.transform.position = new Vector3(SphereKneeL.position.x - 0.17f, SphereKneeL.position.y, SphereKneeL.position.z-0.1f);
            }

            if (sphereHipR.GetComponent<JointTracker>().isOk && SphereKneeR.GetComponent<JointTracker>().isOk && SphereFootR.GetComponent<JointTracker>().isOk)
            {
                rightHip.gameObject.SetActive(true);
				rightHip.transform.position = new Vector3(SphereKneeR.position.x + 0.05f, SphereKneeR.position.y, SphereKneeR.position.z-0.1f);
            }


			elbowhandl = SphereHandL.position - SphereElbowL.position;
			elbowhandr = SphereHandR.position - SphereElbowR.position;
			elbowshoulderl = SphereShoulderL.position - SphereElbowL.position;
			elbowshoulderr = SphereShoulderR.position - SphereElbowR.position;
			lefteuler = (int)Vector3.Angle (elbowshoulderl, elbowhandl);
			righteuler = (int)Vector3.Angle (elbowshoulderr, elbowhandr);
			leftelbow.text = lefteuler.ToString()+"°";
            rightelbow.text = righteuler.ToString() + "°";

            leftKneeFoot = SphereFootL.position - SphereKneeL.position;
            rightKneeFoot = SphereFootR.position - SphereKneeR.position;
            leftKneeWaist = sphereHipL.transform.position - SphereKneeL.position;
            rightKneeWaist = sphereHipR.transform.position - SphereKneeR.position;
            leftKneeAngel = (int)Vector3.Angle(leftKneeFoot, leftKneeWaist);
            rightKneeAngel = (int)Vector3.Angle(rightKneeFoot, rightKneeWaist);
            leftHip.text = leftKneeAngel.ToString() + "°";
            rightHip.text = rightKneeAngel.ToString() + "°";

            if (isshowHandR && SphereHandR.GetComponent<JointTracker>().isOk)
            {
                HandRRightPic.SetActive(true);
                StartCoroutine(waitRighthandR());
                isshowHandR = false;
            }
            if (isshowHandL && SphereHandL.GetComponent<JointTracker>().isOk)
            {
                HandLRightPic.SetActive(true);
                StartCoroutine(waitRighthandL());
                isshowHandL = false;
            }
            if (isshowElbowR && SphereElbowR.GetComponent<JointTracker>().isOk)
            {
                ElbowRRightPic.SetActive(true);
                StartCoroutine(waitRightelbowR());
                isshowElbowR = false;
            }
            if (isshowElbowL && SphereElbowL.GetComponent<JointTracker>().isOk)
            {
                ElbowLRightPic.SetActive(true);
                StartCoroutine(waitRightelbowL());
                isshowElbowL = false;
            }
            if (isshowShoulderR && SphereShoulderR.GetComponent<JointTracker>().isOk)
            {
                ShoulderRRightPic.SetActive(true);
                StartCoroutine(waitRightshoulderR());
                isshowShoulderR = false;
            }
            if (isshowShoulderL && SphereShoulderL.GetComponent<JointTracker>().isOk)
            {
                ShoulderLRightPic.SetActive(true);
                StartCoroutine(waitRightshoulderL());
                isshowShoulderL = false;
            }
            if (isshowKneeR && SphereKneeR.GetComponent<JointTracker>().isOk)
            {
                KneeRRightPic.SetActive(true);
                StartCoroutine(waitRightkneeR());
                isshowKneeR = false;
            }
            if (isshowKneeL && SphereKneeL.GetComponent<JointTracker>().isOk)
            {
                KneeLRightPic.SetActive(true);
                StartCoroutine(waitRightkneeL());
                isshowKneeL = false;
            }
            if (isshowFootR && SphereFootR.GetComponent<JointTracker>().isOk)
            {
                FootRRightPic.SetActive(true);
                StartCoroutine(waitRightfootR());
                isshowFootR = false;
            }
            if (isshowFootL && SphereFootL.GetComponent<JointTracker>().isOk)
            {
                FootLRightPic.SetActive(true);
                StartCoroutine(waitRightfootL());
                isshowFootL = false;
            }
            if (isshowHead && SphereHead.GetComponent<JointTracker>().isOk)
            {
                HeadRightPic.SetActive(true);
                StartCoroutine(waitRighthead());
                isshowHead = false;
            }

            if (isshowWrongHandR && SphereHandR.GetComponent<JointTracker>().isOk)
            {
                HandRWrongPic.SetActive(true);
                StartCoroutine(waitWronghandR());
                isshowWrongHandR = false;
            }
            if (isshowWrongHandL && SphereHandL.GetComponent<JointTracker>().isOk)
            {
                HandLWrongPic.SetActive(true);
                StartCoroutine(waitWronghandL());
                isshowWrongHandL = false;
            }
            if (isshowWrongElbowR && SphereElbowR.GetComponent<JointTracker>().isOk)
            {
                ElbowRWrongPic.SetActive(true);
                StartCoroutine(waitWrongelbowR());
                isshowWrongElbowR = false;
            }
            if (isshowWrongElbowL && SphereElbowL.GetComponent<JointTracker>().isOk)
            {
                ElbowLWrongPic.SetActive(true);
                StartCoroutine(waitWrongelbowL());
                isshowWrongElbowL = false;
            }
            if (isshowWrongShoulderR && SphereShoulderR.GetComponent<JointTracker>().isOk)
            {
                ShoulderRWrongPic.SetActive(true);
                StartCoroutine(waitWrongshoulderR());
                isshowWrongShoulderR = false;
            }
            if (isshowWrongShoulderL && SphereShoulderL.GetComponent<JointTracker>().isOk)
            {
                ShoulderLWrongPic.SetActive(true);
                StartCoroutine(waitWrongshoulderL());
                isshowWrongShoulderL = false;
            }
            if (isshowWrongKneeR && SphereKneeR.GetComponent<JointTracker>().isOk)
            {
                KneeRWrongPic.SetActive(true);
                StartCoroutine(waitWrongkneeR());
                isshowWrongKneeR = false;
            }
            if (isshowWrongKneeL && SphereKneeL.GetComponent<JointTracker>().isOk)
            {
                KneeLWrongPic.SetActive(true);
                StartCoroutine(waitWrongKneeL());
                isshowWrongKneeL = false;
            }
            if (isshowWrongFootR && SphereFootR.GetComponent<JointTracker>().isOk)
            {
                FootRWrongPic.SetActive(true);
                StartCoroutine(waitWrongfootR());
                isshowWrongFootR = false;
            }
            if (isshowWrongFootL && SphereFootL.GetComponent<JointTracker>().isOk)
            {
                FootLWrongPic.SetActive(true);
                StartCoroutine(waitWrongfootL());
                isshowWrongFootL = false;
            }
            if (isshowWrongHead && SphereHead.GetComponent<JointTracker>().isOk)
            {
                HeadWrongPic.SetActive(true);
                StartCoroutine(waitWronghead());
                isshowWrongHead = false;
            }
		}
		else
		{
			leftelbow.gameObject.SetActive (false);
			rightelbow.gameObject.SetActive (false);
            leftHip.gameObject.SetActive(false);
            rightHip.gameObject.SetActive(false);

            ElbowLRightPic.SetActive(false);
            ElbowLWrongPic.SetActive(false);
            ElbowRRightPic.SetActive(false);
            ElbowRWrongPic.SetActive(false);
            FootLRightPic.SetActive(false);
            FootLWrongPic.SetActive(false);
            FootRRightPic.SetActive(false);
            FootRWrongPic.SetActive(false);
            HeadRightPic.SetActive(false);
            HeadWrongPic.SetActive(false);
            KneeLRightPic.SetActive(false);
            KneeLWrongPic.SetActive(false);
            KneeRRightPic.SetActive(false);
            KneeRWrongPic.SetActive(false);
            HandLRightPic.SetActive(false);
            HandLWrongPic.SetActive(false);
            HandRRightPic.SetActive(false);
            HandRWrongPic.SetActive(false);
            ShoulderLRightPic.SetActive(false);
            ShoulderLWrongPic.SetActive(false);
            ShoulderRRightPic.SetActive(false);
            ShoulderRWrongPic.SetActive(false);
           
		}

		
	}

	IEnumerator waitRighthandR()
	{
		yield return new WaitForSeconds (0.4f);
		HandRRightPic.SetActive (false);
	}
	IEnumerator waitWronghandR()
	{
		yield return new WaitForSeconds (0.4f);
		HandRWrongPic.SetActive (false);
	}
	IEnumerator waitRighthandL()
	{
		yield return new WaitForSeconds (0.4f);
		HandLRightPic.SetActive (false);
	}
	IEnumerator waitWronghandL()
	{
		yield return new WaitForSeconds (0.4f);
		HandLWrongPic.SetActive (false);
	}
	IEnumerator waitRightelbowR()
	{
		yield return new WaitForSeconds (0.4f);
		ElbowRRightPic.SetActive (false);
	}
	IEnumerator waitWrongelbowR()
	{
		yield return new WaitForSeconds (0.4f);
		ElbowRWrongPic.SetActive (false);
	}
	IEnumerator waitRightelbowL()
	{
		yield return new WaitForSeconds (0.4f);
		ElbowLRightPic.SetActive (false);
	}
	IEnumerator waitWrongelbowL()
	{
		yield return new WaitForSeconds (0.4f);
		ElbowLWrongPic.SetActive (false);
	}
	IEnumerator waitRightshoulderR()
	{
		yield return new WaitForSeconds (0.4f);
		ShoulderRRightPic.SetActive (false);
	}
	IEnumerator waitWrongshoulderR()
	{
		yield return new WaitForSeconds (0.4f);
		ShoulderRWrongPic.SetActive (false);
	}
	IEnumerator waitRightshoulderL()
	{
		yield return new WaitForSeconds (0.4f);
		ShoulderLRightPic.SetActive (false);
	}
	IEnumerator waitWrongshoulderL()
	{
		yield return new WaitForSeconds (0.4f);
		ShoulderLWrongPic.SetActive (false);
	}
	IEnumerator waitRighthead()
	{
		yield return new WaitForSeconds (0.4f);
		HeadRightPic.SetActive (false);
	}
	IEnumerator waitWronghead()
	{
		yield return new WaitForSeconds (0.4f);
		HeadWrongPic.SetActive (false);
	}
	IEnumerator waitRightkneeR()
	{
		yield return new WaitForSeconds (0.4f);
		KneeRRightPic.SetActive (false);
	}
	IEnumerator waitWrongkneeR()
	{
		yield return new WaitForSeconds (0.4f);
		KneeRWrongPic.SetActive (false);
	}
	IEnumerator waitRightkneeL()
	{
		yield return new WaitForSeconds (0.4f);
		KneeLRightPic.SetActive (false);
	}
	IEnumerator waitWrongKneeL()
	{
		yield return new WaitForSeconds (0.4f);
		KneeLWrongPic.SetActive (false);
	}
	IEnumerator waitRightfootR()
	{
		yield return new WaitForSeconds (0.4f);
		FootRRightPic.SetActive (false);
	}
	IEnumerator waitWrongfootR()
	{
		yield return new WaitForSeconds (0.4f);
		FootRWrongPic.SetActive (false);
	}
	IEnumerator waitRightfootL()
	{
		yield return new WaitForSeconds (0.4f);
		FootLRightPic.SetActive (false);
	}
	IEnumerator waitWrongfootL()
	{
		yield return new WaitForSeconds (0.4f);
		FootLWrongPic.SetActive (false);
	}
// 	void LoadMoviePng()
// 	{
// 		Texture2D[] moviepngs = Resources.LoadAll <Texture2D>("VideoPics");
// 		foreach (Texture2D item in moviepngs) 
// 		{
// 			movietexs.Add(item);
// 		}
// 	}

}