using UnityEngine;
using System.Collections;

public class Layout : MonoBehaviour
{
	static string str_layout = ""; 
	static bool isNextLine = true;
	static GUIStyle style = new GUIStyle ();

	void Start ()
	{
		style.normal.textColor = Color.white;
		style.fontSize = 35;
	}

	void OnGUI ()
	{
		GUILayout.TextField (str_layout, style);
	}
	
	public static void Next (string str)
	{
		str_layout += str + "  ";
		isNextLine = false;
	}
	
	public static void NextLine (string str)
	{
		str_layout += isNextLine ? str + "\n" : "\n" + str + "\n";
		isNextLine = true;
	}

	public static void Replace (string str)
	{
		str_layout = str;
	}
		
	public static void Clear ()
	{
		str_layout = "";
		isNextLine = true;
	}


}
