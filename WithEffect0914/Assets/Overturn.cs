using UnityEngine;
using System.Collections;

public class Overturn : MonoBehaviour {

    float x, y, z;

	void Start () {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;
	
	}
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            transform.localScale = new Vector3(-x,y,z);
            x =transform.localScale.x;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            transform.localScale = new Vector3(x, y, -z);
            z = transform.localScale.z;
        }
	}
}
