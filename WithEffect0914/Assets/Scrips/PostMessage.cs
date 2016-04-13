using UnityEngine;
using System.Collections;
using LitJson ;
using System;

public class PostMessage : MonoBehaviour {

	public static PostMessage _instance;
	private Scoring_Tony1 st1;
	public Message message=new Message ();
	public Detail detail=new Detail();
	//private string _postdateurl;
	void Awake()
	{
		_instance = this;
	}
	void Start()
	{
		if (st1 == null)
		{
			st1 = GameObject.FindObjectOfType(typeof(Scoring_Tony1)) as Scoring_Tony1;
		}
		//_postdateurl = "http://192.168.1.188:8080/EDServer/api/fit/trainPushToClient";
	}
//	void Update()
//	{
//		if (Input .GetKey (KeyCode.A )) {
//			StartCoroutine (sendMissNum() );
//				}
//	}
	double Calorie (float _METs, float kg, float minutes, float _RER)
	{ 
		return Math.Round (_METs * 3.5 * kg * minutes * _RER / 1000/60, 2);
	}
	public string json1()
	{
		message .courseId = 42;
		message .coursePushId = 0;
		message .calorie = Calorie (5,(float)QRlogin ._instance .user .weight ,TestMobileTexture ._instance.movieInf.movieLength ,4.924f);
		message .correct_center = 0;
		message .wrong_center = 0;

		message .correct_left_up= 0;
		message .wrong_left_up= 0;
		message .correct_left_hand = st1 .num11 - st1 .num1; 
		message .wrong_left_hand= st1 .num1;
		message .correct_left_elbow= st1 .num33 - st1 .num3; 
		message .wrong_left_elbow= st1 .num3;

		message .correct_right_up= 0;
		message .wrong_right_up= 0;
		message .correct_right_hand= st1 .num22 - st1 .num2; 
		message .wrong_right_hand= st1 .num2;
		message .correct_right_elbow= st1 .num44 - st1 .num4; 
		message .wrong_right_elbow= st1 .num4;

		message .correct_left_down= 0;
		message .wrong_left_down= 0;
		message .correct_left_foot= st1 .num55 - st1 .num5; 
		message .wrong_left_foot= st1 .num5;

		message .correct_right_down= 0;
		message .wrong_right_down= 0;
		message .correct_right_foot= st1 .num66 - st1 .num6; 
		message .wrong_right_foot= st1 .num6;

		return JsonMapper .ToJson (message );
	}
	public string json2()
	{
		detail .LeftHand = 0;
		detail .RightHand = 0;
		detail .LeftElbow = 0;
		detail .RightElbow = 0;
		detail .LeftFoot = 0;
		detail .RightFoot = 0;
//		detail .LeftHand = 0;
//		detail .RightHand = 0;
//		detail .LeftElbow = 0;
//		detail .RightElbow =0;
//		detail .LeftFoot =0;
//		detail .RightFoot = 0;
		return JsonMapper .ToJson (detail);
	}
//	IEnumerator sendMissNum() 
//	{
//		WWWForm form = new WWWForm ();
//		form.AddField("token","f1dd89f028c94507a85cb3266803c333" );
//		form.AddField("source","shapejoy_v1");
//		form.AddField("Message",json1()  );
//		form.AddField("Detail",json2() );
//		WWW www = new WWW (_postdateurl ,form);
//		while (!www.isDone)
//		{
//			yield return new WaitForEndOfFrame();
//		}
//		if (www.error != null)
//		{
//			Debug.LogError(www.error);
//		}
//	}

}
public class Message
{
	public int courseId;
	public int coursePushId;
	public double calorie;
	
	
	public int correct_center;
	public int wrong_center;
	
	public int correct_left_up;
	public int wrong_left_up;
	public int correct_left_hand;
	public int wrong_left_hand;
	public int correct_left_elbow;
	public int wrong_left_elbow;
	
	public int correct_right_up;
	public int wrong_right_up;
	public int correct_right_hand;
	public int wrong_right_hand;
	public int correct_right_elbow;
	public int wrong_right_elbow;
	
	public int correct_left_down;
	public int wrong_left_down;
	public int correct_left_foot;
	public int wrong_left_foot;
	
	public int correct_right_down;
	public int wrong_right_down;
	public int correct_right_foot;
	public int wrong_right_foot;

}
public class Detail
{
	public int LeftHand;
	public int RightHand;
	public int LeftElbow;
	public int RightElbow;
	public int LeftFoot;
	public int RightFoot;
}
