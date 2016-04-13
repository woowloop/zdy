using UnityEngine;
using System.Collections;

public class Circlebig : MonoBehaviour {
	public GameObject   position1;
	public GameObject   position2;
	public GameObject   position3;
	float x,y,x1,y1;
	// Use this for initialization
	void Start () {

		x = (1.18825f - 0.07949f)/5;
		Debug.Log (x + "x");
		//y = position1.transform .position  .y - position2.transform .position  .y;
		y = (1.18825f - 0.07949f)/5;
		x1 = position3 .transform .localScale .x;
		y1 = position3 .transform .localScale .y;
		position3.transform .position  = new Vector3 ((position1.transform .position  .x + position2.transform .position  .x) / 2f,(position1.transform .position  .y + position2.transform .position  .y) / 2f,-8.04f);
	}
	
	// Update is called once per frame
	void Update () {

		position3.transform .position  = new Vector3 (Mathf .Abs((position1.transform .position  .x + position2.transform .position  .x) / 2f),Mathf .Abs ((position1.transform .position  .y + position2.transform .position  .y) / 2f),-8.04f);
		position3 .transform .localScale = new Vector3 (( position1.transform .position  .x-position2.transform .position  .x)*x1/x ,0.45f,( position1.transform .position  .x-position2.transform .position  .x)*x1/x);
		//Debug.Log (position3 .transform .localScale + "position3 .transform .localScale");
	}
}
