using UnityEngine;
using System.Collections;

public class Video : MonoBehaviour {

    public GameObject camera;
	
	void Start () {
	
	}
	
	
	void Update () {
        
	
	}
    public void OnClick()
    {
        print("1");
        if (Input.GetMouseButtonDown(0))
        {
           transform.parent.Find("Feedback").GetComponent<Feedback>().start = true;
            print("2");
        }
    }
    void OnMouseEnter()
    {
        print("3");
        if (Input.GetMouseButtonDown(0))
        {
            transform.parent.Find("Feedback").GetComponent<Feedback>().start = true;
            print("4");
        }
    }
}
