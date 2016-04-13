using UnityEngine;
using System.Collections;

public class SetSelfHide : MonoBehaviour {

    float passedti = 0;
	void Start () 
	{
        //Destroy(this.gameObject, 1.5f);
	}
	
	void Update () {
        passedti += Time.deltaTime;
		//Debug.Log (passedti + "passedti");
        if (passedti > 1)
        {
            passedti = 0;
            Destroy(this.gameObject, 1);
        }
	}
}
