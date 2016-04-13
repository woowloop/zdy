using UnityEngine;
using System.Collections;

public class PrefabGridScript : MonoBehaviour {

	private TweenScale mytween;
	void Awake()
	{
		mytween = transform .Find ("GirdPrefab").GetComponent <TweenScale > ();
	}
	
	void OnHover(bool ishover)
	{
		if (ishover) {
			mytween .PlayForward ();
		} else {
			mytween.PlayReverse ();
		}
	}
}
