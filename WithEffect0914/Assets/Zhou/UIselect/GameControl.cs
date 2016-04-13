using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	public GameObject VideoPlayer;
	public GameObject ViedoPlayerAndroid;
	// Use this for initialization
	void Awake ()
	{
		#if UNITY_EDITOR
		VideoPlayer.SetActive(true);
		ViedoPlayerAndroid.SetActive(false);
		#endif

		#if UNITY_ANDROID
		VideoPlayer.SetActive(false);
		ViedoPlayerAndroid.SetActive(true);
		#endif
	}
}
