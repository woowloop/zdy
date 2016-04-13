using UnityEngine;
using System.Collections;

public class GoalPrefab : MonoBehaviour {
	
	UITexture uitexure;
	UILabel goalName;
	public Color highlightColor,darkColor;

	void Awake () {
		uitexure=GetComponent<UITexture>();
		goalName=transform.Find("GoalName").GetComponent<UILabel>();
	}
	
	//显示图片和文字的方法
	public IEnumerator GetGoalPic(string name)
	{
        string path = "";
		#if UNITY_EDITOR 
		path ="file:///" +Application.streamingAssetsPath + "/GoalPics/" + name + ".png";
		#elif UNITY_ANDROID 
		path =Application.streamingAssetsPath + "/GoalPics/" + name + ".png";
		#endif
		WWW www = new WWW(path);
		yield return www;
		uitexure.mainTexture = www.texture;
		goalName.text = name;
	}

	//	高亮显示的方法：图片和文字颜色高亮。
	public void HighLight()
	{
		uitexure.color = highlightColor;
		goalName.color = highlightColor;
	}
	//	灰暗显示的方法：图片和颜色灰暗。
	public void DarkLight()
	{
		uitexure.color = darkColor;
		goalName.color = darkColor;
	}

}
