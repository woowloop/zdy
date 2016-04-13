using UnityEngine;
using System.Collections;

public class DisplayCube : MonoBehaviour {
    Animator mov;
    float time;
	// Use this for initialization
	void Start () {
	mov=this.gameObject.GetComponent<Animator>()as Animator;

	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    mov.speed = 0;
        //}
        if (Input.GetKey(KeyCode.A))
        {
            mov.speed = -0.5f;
            time += mov.speed*Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            mov.speed = 0.5f;
            time += mov.speed * Time.deltaTime;
        }
        else
        {
            mov.speed = 0;
        }
        print(time);

	}
}
