using UnityEngine;
using System.Collections;


public class WebCam : MonoBehaviour {
	
	public string deviceName;
	WebCamTexture tex;
	// Use this for initialization
	IEnumerator Start ()
	{
		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
		if(Application.HasUserAuthorization(UserAuthorization.WebCam))
		{
			WebCamDevice[] devices = WebCamTexture.devices;
			deviceName = devices[0].name;
			tex = new WebCamTexture(deviceName, 800, 450, 30);
			renderer.material.mainTexture = tex;
			tex.Play();
		}
	}
}
