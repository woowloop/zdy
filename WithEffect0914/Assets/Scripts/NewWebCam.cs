using UnityEngine;
using System.Collections;
using System.IO ;

public class NewWebCam : MonoBehaviour {
	public int num;
	public string deviceName;
	private float  alltime=0.1f;
	WebCamTexture tex;
	//public int num=0;
	// Use this for initialization
	void Start () {
		StartCoroutine(test());
	}
	void  Update()
	{	
		if (Input .GetKeyDown (KeyCode .M )) {
			StartCoroutine ( getTexture2dshexiang ());
		}
		if(Input .GetKey (KeyCode .Space ))
		{
			if (alltime >0) {
				alltime -=Time .deltaTime ;
				if (alltime <=0) {
					num++;
					StartCoroutine ( getTexture2dshexiang ());
					alltime =0.1f;
				}
			}
		}
	}
	IEnumerator test () {
		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
		if(Application.HasUserAuthorization(UserAuthorization.WebCam))
		{
			WebCamDevice[] devices = WebCamTexture.devices;
			deviceName = devices[0].name;
			tex = new WebCamTexture(deviceName, 400, 300, 12);
			renderer.material.mainTexture = tex;
			tex.Play();
			
			
			
		}
	}
	void OnGUI()
	{
		if (tex != null) {
			GUI.DrawTexture (new Rect (580, 150, 200, 180), tex);
			//GUI.DrawTexture (new Rect (200, 200, 200, 180), tex);
		}
	}
	IEnumerator  getTexture2dshexiang()
	{
		yield return new WaitForEndOfFrame();
		Texture2D t = new Texture2D(100, 90);//要保存图片的大小
		//截取的区域
		//t.ReadPixels(new Rect(250, 250, 100, 90), 0, 0, false);
		t.ReadPixels(new Rect(630, 300, 200, 180), 0, 0, false);
		t.Apply();
		//把图片数据转换为byte数组
		byte[] byt = t.EncodeToPNG();
		//然后保存为图片
		File.WriteAllBytes(Application.dataPath + "/Photo/" + num  + ".jpg", byt);
		num++;
		
	}
}