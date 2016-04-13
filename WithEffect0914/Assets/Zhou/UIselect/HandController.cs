using UnityEngine;
using System.Collections;

public class HandController : MonoBehaviour {

	Transform _righthand;
	Transform _torso;
	Transform _lefthip;
	Transform _righthip;
	Transform  _rightshoulder;
	Transform _leftshoulder;
	Vector3 ptorso;
	Vector3 pmedium;
	//Manager man;
	bool isstart = false;
	Vector3 rightpos;
	Vector3 leftpos;
	int lti = 0,rti = 0;
	float x,y;
	Transform hand;
	void Start () {
		//man = GameObject.Find("manager").GetComponent<Manager>();
		_righthand = GameObject.Find("RightHand").transform;
		_torso = GameObject.Find("Spine_3").transform;
		_lefthip = GameObject.Find ("L_Hip").transform;
		_righthip = GameObject.Find ("R_Hip").transform;
		_rightshoulder = GameObject.Find("R_Arm").transform;
		_leftshoulder = GameObject.Find("L_Arm").transform;

		ptorso = _torso.position;
		Vector3 plefthip =_righthip.position;
		Vector3 prighthip = _lefthip.position;
		pmedium = (plefthip+prighthip)/2;



	}

	void Update () {

		if(((_righthand.position.x-_rightshoulder.position.x)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x))<0.5f&&
		   ((_righthand.position.x-_rightshoulder.position.x)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x))>0){
			x = 1220f*((_righthand.position.x-_rightshoulder.position.x)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x));
		}
		else{
			if(((_righthand.position.x-_rightshoulder.position.x)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x))>-0.5f&&
		   		((_righthand.position.x-_rightshoulder.position.x)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x))<0){

				x = 1220f*((_righthand.position.x-_rightshoulder.position.x)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x));
			}else{
				if(((_righthand.position.x-_rightshoulder.position.x)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x))>0.5f){
					x = 610;
				}
				if(((_righthand.position.x-_rightshoulder.position.x)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x))<-0.5f){
					x = -610;
				}
			}
		}
		if(_righthand.position.y>pmedium.y&&_righthand.position.y<_torso.position.y){
			if((Mathf.Abs(_righthand.position.y-_torso.position.y)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x))<(0.5f)){
				y = 310-(620*((Mathf.Abs(_righthand.position.y-_torso.position.y)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x))));
			}
			if((Mathf.Abs(_righthand.position.y-_torso.position.y)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x))>(0.5f)){
				y = (620*(1-((Mathf.Abs(_righthand.position.y-_torso.position.y)/Mathf.Abs(_leftshoulder.position.x-_rightshoulder.position.x)))))-310;
			}
		}else{
			if(_righthand.position.y>_torso.position.y){
				y = 310;
			}
			if(_righthand.position. y< pmedium.y){
				y =-310;
			}
		}
		transform.localPosition = new Vector3(x,y,0);


	}
}
