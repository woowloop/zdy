using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class ParseXml : MonoBehaviour {
	public static ParseXml _instance;
	private XmlDocument doc = new XmlDocument() ;
	public List<ScoreList> scorelists  = new List<ScoreList>();

	//private int index;
	// Use this for initialization

	void Start () 
	{
		_instance = this;
		//scorelist = doc.SelectSingleNode("scorelist");
		//index = 1;
		RefreshList ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			//CanAddScore();
		}
	}

	public void CanAddScore(string path,int score)
	{
		//int newscore = Random.Range(0,10000);
		//Debug.Log (newscore + "newscore");
		//Debug.Log (GetOrderIndex() + "GetOrderIndex()");
		if(GetOrderIndex() < 10)
		{
			//addScore("123",newscore);
			addScore(path,score);
		}
		else
		{
			RefreshList();
			//去除最小的
			if(score > scorelists [scorelists.Count - 1].score)
			{
				addScore(path,score);
				//addScore("123",newscore);
				RemoveScoreList();
			}
		}
	}

	public void addScore(string path,int score)
	{
		doc.Load(Application.streamingAssetsPath+"/score.xml");
		XmlElement ScoreNum = doc.DocumentElement;
		XmlElement scorelist = doc.CreateElement ("scorelist");
		//index = GetOrderIndex ();
		//scorelist.SetAttribute ("index", index.ToString());
		//index ++;
		XmlElement myphoto = doc.CreateElement ("MyPhoto");
		myphoto.InnerText = path;
		XmlElement myscore = doc.CreateElement("MyScore");
		myscore.InnerText = score.ToString ();

		ScoreNum.AppendChild (scorelist);
		scorelist.AppendChild (myphoto);
		scorelist.AppendChild (myscore);
		doc.Save(Application.streamingAssetsPath + "/score.xml");
	}

	void RemoveScoreList()
	{
		int needdeletescore = scorelists [scorelists.Count - 1].score;
		//Debug.Log (needdeletescore + "needdeletescore");
		//Debug.Log (scorelists.Count + "scorelists.Count");
		doc.Load(Application.streamingAssetsPath+"/score.xml");
		XmlElement ScoreNum = doc.DocumentElement;
		XmlNodeList orderNodeList = ScoreNum.ChildNodes;
		foreach (XmlNode xn in orderNodeList)
		{
			if (xn.SelectSingleNode("MyScore").InnerText == needdeletescore.ToString())
			{
				ScoreNum.RemoveChild(xn);
				//scorelists.Remove(scorelists [scorelists.Count - 1]);
				break;
			}
		}
		doc.Save (Application.streamingAssetsPath+"/score.xml");
		RefreshList ();
	}


	void RefreshList()
	{
		scorelists.Clear ();
		doc.Load(Application.streamingAssetsPath+"/score.xml");
		XmlElement ScoreNum = doc.DocumentElement;
		XmlNodeList orderNodeList = ScoreNum.ChildNodes;
		foreach(XmlNode xn in orderNodeList)
		{
			string name = xn.SelectSingleNode("MyPhoto").InnerText;
			int score =int.Parse(xn.SelectSingleNode("MyScore").InnerText);
			ScoreList sl = new ScoreList(name,score);
			scorelists.Add(sl);
		}
		scorelists.Sort (new ScoreCompare ());
	}

	int GetOrderIndex()
	{
		doc.Load(Application.streamingAssetsPath+"/score.xml");
		XmlElement ScoreNum = doc.DocumentElement;
		XmlNodeList orderNodeList = ScoreNum.ChildNodes;
		return orderNodeList.Count;
		/*if (orderNodeList.Count > 0) 
		{
			XmlElement xe = (XmlElement)orderNodeList[orderNodeList.Count-1];
			return (int.Parse(xe.GetAttribute("index")));
		}
		else
		{
			return 1;
		}*/
	}
}


public class ScoreList
{
	public string name;
	public int score;
	public ScoreList(string name,int score)
	{
		this.name = name;
		this.score = score;
	}
}

public class ScoreCompare:IComparer<ScoreList>
{
	public int Compare(ScoreList a,ScoreList b)
	{
		return b.score.CompareTo (a.score);
	}
}

