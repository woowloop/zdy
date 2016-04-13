using UnityEngine;
using System.Collections;

public class AddTex : MonoBehaviour {

    private GameObject playyz;
	// Use this for initialization
	void Start () {
        playyz = GameObject.Find("PlaneYZ");
	}
	
	// Update is called once per frame
	void Update () {
        this.renderer.material.mainTexture = playyz.renderer.material.mainTexture;
	}
}
