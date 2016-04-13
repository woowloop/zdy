using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NumCrtl : MonoBehaviour {
    public string num = "0";
    public List<GameObject> digitals = new List<GameObject>();
    Vector3 firstpos = new Vector3(-0.535f,-0.178f,0.01f);
    Vector3 offset =new Vector3( 0.015f,0,0);
    List<GameObject> grades = new List<GameObject>();
    string currentnum = "0";
	void Start () {
        CreateScoreText(num);
	}
	
	void Update () {
        if (num != currentnum)
        {
            currentnum = num;
            ClearList(grades);
            CreateScoreText(num);

        }
	}
    void CreateScoreText(string str)
    {
        for (int m = 0; m < str.Length; m++)
        {
            GameObject source = digitals[int.Parse(str.Substring(str.Length - 1 - m, 1))];
           // GameObject temp = Instantiate(source) as GameObject;
            //temp.transform.parent = source.transform.parent;
            //temp.transform.localScale = source.transform.localScale;
            //temp.transform.localEulerAngles = source.transform.localEulerAngles;
            //temp.SetActive(true);
            //temp.transform.localPosition = firstpos + offset * m;
            //grades.Add(temp);
        }
    }
    void ClearList(List<GameObject> lis)
    {
        foreach (GameObject go in lis)
        {
            Destroy(go);
        }
        lis.Clear();
    }
}
