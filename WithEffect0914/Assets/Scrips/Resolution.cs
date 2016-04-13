using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour
{
	Camera mainCamera;
	public Camera[] uiCameras;
	void Awake ()
	{
		//Screen.SetResolution(1280, 800, true, 60);
		mainCamera = Camera.mainCamera;
		//  float screenAspect = 1280 / 720;  现在android手机的主流分辨。
		//  mainCamera.aspect --->  摄像机的长宽比（宽度除以高度）
		mainCamera.aspect = 1.78f;
		for (int i=0; i<uiCameras.Length; i++)
			uiCameras [i].aspect = 1.78f;
	}
}