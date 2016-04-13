using System.Xml;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum DIR
{
	INVALID,
	dirX,
	dirY,
	dirZ,
    dirXY,
    dirXZ,
    dirYZ,
    dirXYZ
}

public class AddCube : MonoBehaviour {

	//public  bool updaterootpso;
	public  DIR dir;
	private TweenPosition modposui;
	private GameObject[] cubegos;
	private XmlDocument doc = new XmlDocument() ;
	private XmlElement cubes;
	private XmlElement smoves;
	private List<int> orders = new List<int>();
	private int orderindex;
	private UIInput uiinput;
	void Awake()
	{
		uiinput = GameObject.Find("LabelInput").GetComponent<UIInput>();
		modposui = GameObject.Find("xml").GetComponent<TweenPosition>();
	}

	void Start()
	{
		/*if (PlayerPrefs.HasKey ("orderindex")) 
		{
			orderindex = PlayerPrefs.GetInt ("orderindex");
		}
		else 
		{
			orderindex = 1;
		}*/

		orderindex = GetOrderIndex ();
	}

	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.Q))
		{
			modposui.PlayForward();
		}
		if (Input.GetKeyDown (KeyCode.W))
		{
			modposui.PlayReverse();
		}

		if (Input.GetKeyDown (KeyCode.E))
		{
			addTime(dir);
			cubegos = GameObject.FindGameObjectsWithTag ("cube");
			for (int i = 0; i < cubegos.Length; i++) 
			{
				if (cubegos [i].name.Contains ("righthand1"))
				{
					addSke ("RightHand");
				}
			}
			for (int i = 0; i < cubegos.Length; i++) 
			{
				switch (cubegos [i].name) 
				{
					case "cuberighthand1":
						addCube (cubegos [i].transform, 1);
						break;
					case "cuberighthand2":
						addCube (cubegos [i].transform, 2);
						break;
					case "cuberighthand3":
						addCube (cubegos [i].transform, 3);
						break;
					default:
						break;
				}
			}

			for (int i = 0; i < cubegos.Length; i++) 
			{
				if (cubegos [i].name.Contains ("lefthand1"))
				{
					addSke ("LeftHand");
				}
			}
			for (int i = 0; i < cubegos.Length; i++) 
			{
				switch (cubegos [i].name) 
				{
					case "cubelefthand1":
						addCube (cubegos [i].transform, 1);
						break;
					case "cubelefthand2":
						addCube (cubegos [i].transform, 2);
						break;
					case "cubelefthand3":
						addCube (cubegos [i].transform, 3);
						break;
					default:
						break;
				}
			}

			for (int i = 0; i < cubegos.Length; i++)
			{
				if (cubegos [i].name.Contains ("rightfoot1")) 
				{
					addSke ("RightFoot");
				}
			}
			for (int i = 0; i < cubegos.Length; i++) 
			{
				switch (cubegos [i].name)
				{
					case "cuberightfoot1":
						addCube (cubegos [i].transform, 1);
						break;
					case "cuberightfoot2":
						addCube (cubegos [i].transform, 2);
						break;
					case "cuberightfoot3":
						addCube (cubegos [i].transform, 3);
						break;
					default:
						break;
				}
			}

			for (int i = 0; i < cubegos.Length; i++) 
			{
				if (cubegos [i].name.Contains ("leftfoot1")) 
				{
					addSke ("LeftFoot");
				}
			}
			for (int i = 0; i < cubegos.Length; i++) 
			{
				switch (cubegos [i].name) 
				{
					case "cubeleftfoot1":
						addCube (cubegos [i].transform, 1);
						break;
					case "cubeleftfoot2":
						addCube (cubegos [i].transform, 2);
						break;
					case "cubeleftfoot3":
						addCube (cubegos [i].transform, 3);
						break;
					default:
						break;
				}
			}

			for (int i = 0; i < cubegos.Length; i++) 
			{
				if (cubegos [i].name.Contains ("leftelbow1")) 
				{
					addSke ("LeftElbow");
				}
			}
			for (int i = 0; i < cubegos.Length; i++) 
			{
				switch (cubegos [i].name) 
				{
				case "cubeleftelbow1":
					addCube (cubegos [i].transform, 1);
					break;
				case "cubeleftelbow2":
					addCube (cubegos [i].transform, 2);
					break;
				case "cubeleftelbow3":
					addCube (cubegos [i].transform, 3);
					break;
				default:
					break;
				}
			}

			for (int i = 0; i < cubegos.Length; i++) 
			{
				if (cubegos [i].name.Contains ("rightelbow1")) 
				{
					addSke ("RightElbow");
				}
			}
			for (int i = 0; i < cubegos.Length; i++) 
			{
				switch (cubegos [i].name) 
				{
				case "cuberightelbow1":
					addCube (cubegos [i].transform, 1);
					break;
				case "cuberightelbow2":
					addCube (cubegos [i].transform, 2);
					break;
				case "cuberightelbow3":
					addCube (cubegos [i].transform, 3);
					break;
				default:
					break;
				}
			}


			for (int i = 0; i < cubegos.Length; i++) 
			{
				if (cubegos [i].name.Contains ("leftknee1")) 
				{
					addSke ("LeftKnee");
				}
			}
			for (int i = 0; i < cubegos.Length; i++) 
			{
				switch (cubegos [i].name) 
				{
				case "cubeleftknee1":
					addCube (cubegos [i].transform, 1);
					break;
				case "cubeleftknee2":
					addCube (cubegos [i].transform, 2);
					break;
				case "cubeleftknee3":
					addCube (cubegos [i].transform, 3);
					break;
				default:
					break;
				}
			}


			for (int i = 0; i < cubegos.Length; i++) 
			{
				if (cubegos [i].name.Contains ("rightknee1")) 
				{
					addSke ("RightKnee");
				}
			}
			for (int i = 0; i < cubegos.Length; i++) 
			{
				switch (cubegos [i].name) 
				{
				case "cuberightknee1":
					addCube (cubegos [i].transform, 1);
					break;
				case "cuberightknee2":
					addCube (cubegos [i].transform, 2);
					break;
				case "cuberightknee3":
					addCube (cubegos [i].transform, 3);
					break;
				default:
					break;
				}
			}
		}
	}
	
	
	void addTime(DIR dir)
	{
		doc.Load(Application.streamingAssetsPath+"/level_man.xml");
		XmlElement video = doc.DocumentElement;
		XmlElement moves = null;
		for (int i = 0; i < video.ChildNodes.Count; i++)
		{
			if (video.ChildNodes[i].Name == "moves")
			{
				moves = (XmlElement)video.ChildNodes[i];
			}
		}
		XmlElement move = doc.CreateElement ("move");
		XmlElement order = doc.CreateElement("order");
		order.InnerText = orderindex.ToString();
		orderindex ++;
		//PlayerPrefs.SetInt ("orderindex",orderindex);
		XmlElement starttime = doc.CreateElement("starttime");
		XmlElement endtime = doc.CreateElement("endtime");
		XmlElement movdir = doc.CreateElement("dir");
		movdir.InnerText = dir.ToString();
	 	smoves = doc.CreateElement("smoves");
		move.AppendChild(order);
		move.AppendChild(starttime);
		move.AppendChild(endtime);
		move.AppendChild(movdir);
		move.AppendChild(smoves);
		moves.AppendChild(move);
		doc.Save(Application.streamingAssetsPath + "/level_man.xml");
	}

	void addSke(string skename)
	{
		XmlElement smove = doc.CreateElement("smove");
		XmlElement skeleton = doc.CreateElement("skeleton");
		skeleton.InnerText = skename;
		cubes = doc.CreateElement("cubes");
		smove.AppendChild(skeleton);
		smove.AppendChild(cubes);
		smoves.AppendChild(smove);
		doc.Save(Application.streamingAssetsPath + "/level_man.xml");
	}

	void addCube(Transform cubepos, int index)
	{
		XmlElement cube = doc.CreateElement("cube");
		XmlElement ballnum = doc.CreateElement("ballnum");
		ballnum.InnerText = index.ToString();
		XmlElement ballposition = doc.CreateElement("ballposition");
		XmlElement x = doc.CreateElement("x");
		x.InnerText = cubepos.localPosition.x.ToString();
		XmlElement y = doc.CreateElement("y");
		y.InnerText = cubepos.localPosition.y.ToString ();
		XmlElement z = doc.CreateElement("z");
		z.InnerText = cubepos.localPosition.z.ToString ();
		ballposition.AppendChild(x);
		ballposition.AppendChild(y);
		ballposition.AppendChild(z);
		XmlElement ballrotation = doc.CreateElement("ballrotation");
		XmlElement x1 = doc.CreateElement("x1");
		x1.InnerText = cubepos.localEulerAngles.x.ToString ();
		XmlElement y1 = doc.CreateElement("y1");
		y1.InnerText =  cubepos.localEulerAngles.y.ToString ();
		XmlElement z1 = doc.CreateElement("z1");
		z1.InnerText =  cubepos.localEulerAngles.z.ToString ();
		ballrotation.AppendChild(x1);
		ballrotation.AppendChild(y1);
		ballrotation.AppendChild(z1);
		cube.AppendChild(ballnum);
		cube.AppendChild(ballposition);
		cube.AppendChild(ballrotation);
		cubes.AppendChild(cube);
		doc.Save(Application.streamingAssetsPath + "/level_man.xml");
	}


	int GetOrderIndex()
	{
		doc.Load(Application.streamingAssetsPath+"/level_man.xml");
		XmlNodeList orderNodeList = doc.SelectNodes("/video/moves/move/order");
		if (orderNodeList.Count > 0) 
		{
			return (int.Parse(orderNodeList[orderNodeList.Count-1].InnerText) + 1);
		}
		else
		{
			return 1;
		}
	}


}


