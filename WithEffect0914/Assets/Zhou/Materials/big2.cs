using UnityEngine;
using System.Collections;

public class big2 : MonoBehaviour {
	private PlayerPixels pp;
	// Use this for initialization
	void Start () {
		
		pp = GameObject.Find ("PlaneYZ").GetComponent<PlayerPixels> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.renderer.material.mainTexture = pp.gameObject.renderer.material.mainTexture;
	}
}
