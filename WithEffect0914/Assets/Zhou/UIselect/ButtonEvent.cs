using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ButtonEvent : MonoBehaviour {
    public List<GameObject> objneedclose = new List<GameObject>();
    public List<GameObject> objneedopen = new List<GameObject>();
    public ButtonStatus statetexs;
	private HandAniPlay hand;
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
public class ButtonStatus
{
    public string Bright;
	public string Dark;
}