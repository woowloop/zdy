using UnityEngine;
using System.Collections;

public class ScoreEffect_Tony : MonoBehaviour {
    //int ti = 0;
    public float time;

	void Start () {
        Destroy(this.gameObject,time);
	}
	
	void Update () {
        //ti++;

        //transform.position = Vector3.Lerp(new Vector3(1.1f, 0.3f, -8.5f), new Vector3(1.1f, 0.46f, -8.5f), 0.05f * ti);
        //Vector3 temp = Vector3.Lerp(new Vector3(221,11,198),new Vector3(255,255,255),0.1f*ti);
        //if(ti==20){
        //    ti = 0;
        //    Destroy(gameObject);          
        //}
	}
}
