using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ButtonEventPlay : MonoBehaviour {
    public List<GameObject> objneedclose = new List<GameObject>();
    public List<GameObject> objneedopen = new List<GameObject>();
	public ButtonStatusPlay statetexs;
	public Camera maincamera;
	private HandAniPlay hand;
	private float movespeed = 5f;
    //UnityEngine.Object[] pics;
    //float ti = 0;
    //int n = 0;
    //ReturnHandling model;
    public bool isstay = false;
    //int[] xpostions;
    //public GameObject contents;
    //bool ismoving = false;
    //int movingti = 0;
    void Start()
    {
		hand = GameObject.Find ("hand").GetComponent<HandAniPlay> ();
		hand.enabled = false;
		maincamera.transform.position = new Vector3 (0, 3, -15);
    }
    void Update()
    {
		if (!isstay) 
		{
			gameObject.GetComponent<UISprite> ().spriteName = statetexs.Bright;
		}
	}
    void OnTriggerStay()
    {
        print("trigger stay");
        isstay = true;
		hand.enabled = true;
		hand.isstay = true;
		gameObject.GetComponent<UISprite>().spriteName = statetexs.Dark;
		if(!hand.isPlaying)
		{
			foreach (GameObject go1 in objneedopen)
			{
				go1.SetActive(true);                
			}
			foreach (GameObject go2 in objneedclose)
			{
				go2.SetActive(false);
			}
			maincamera.transform.position = Vector3.Lerp(maincamera.transform.position,new Vector3(0,1,-10),Time.deltaTime*movespeed);
		}
    }
    void OnTriggerExit()
    {
		hand.ResetToBeginning ();
		hand.enabled = false;
        isstay = false;
		hand.isstay = false;
		gameObject.GetComponent<UISprite>().spriteName = statetexs.Bright;
     
    }
    void OnDisable()
    {
		hand.ResetToBeginning ();
		hand.enabled = false;
		isstay = false;
		hand.isstay = false;
		gameObject.GetComponent<UISprite>().spriteName = statetexs.Bright;
    }

}
[Serializable]
public class ButtonStatusPlay
{
    public string Bright;
	public string Dark;
}