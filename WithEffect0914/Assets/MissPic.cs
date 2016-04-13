using UnityEngine;
using System.Collections;

public class MissPic : MonoBehaviour {

    Animator MissAni;

    void Awake()
    {
        MissAni=GetComponent<Animator>();
        gameObject.SetActive(false);
    }
    
    void Start () {
	
	}
	

	void Update () {
      
       
           
        
	}
    //显示并播放动画方法
    public void ShowFlash()
    {
        gameObject.SetActive(true);
        MissAni.SetTrigger("Show");
    }
}
