using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Collections;

public class ModCube : MonoBehaviour {

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
	}
	// Use this for initialization
	void Start () 
	{
		cubegos = GameObject.FindGameObjectsWithTag ("cube");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void LoadOrderData()
	{
		foreach (var cube in cubegos) 
		{
			cube.SetActive(false);
		}
		string selectorderindex = uiinput.label.text;
		doc.Load(Application.streamingAssetsPath+"/level_man.xml");
		XmlNodeList orderNodeList = doc.SelectNodes("/video/moves/move/order");
		if (orderNodeList != null) 
		{
			foreach (XmlNode ordernode in orderNodeList)
			{
				if(ordernode.InnerText == selectorderindex)
				{
					XmlNodeList skeletonnodelist = ordernode.SelectNodes("../smoves/smove/skeleton");
					foreach (XmlNode skeletonnode in skeletonnodelist)
					{
						if(skeletonnode.InnerText == "RightHand")
						{
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberighthand1",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberighthand2",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberighthand3",x,y,z,x1,y1,z1);
								}
							}
						}
						
						
						
						if(skeletonnode.InnerText == "LeftHand")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubelefthand1",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubelefthand2",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubelefthand3",x,y,z,x1,y1,z1);
								}
							}
						}
						
						
						if(skeletonnode.InnerText == "RightFoot")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberightfoot1",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberightfoot2",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberightfoot3",x,y,z,x1,y1,z1);
								}
							}
						}
						
						if(skeletonnode.InnerText == "LeftFoot")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubeleftfoot1",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubeleftfoot2",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubeleftfoot3",x,y,z,x1,y1,z1);
								}
							}
						}


						if(skeletonnode.InnerText == "RightElbow")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberightelbow1",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberightelbow2",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberightelbow3",x,y,z,x1,y1,z1);
								}
							}
						}

						if(skeletonnode.InnerText == "LeftElbow")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubeleftelbow1",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubeleftelbow2",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubeleftelbow3",x,y,z,x1,y1,z1);
								}
							}
						}

						if(skeletonnode.InnerText == "RightKnee")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberightknee1",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberightknee2",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cuberightknee3",x,y,z,x1,y1,z1);
								}
							}
						}

						if(skeletonnode.InnerText == "LeftKnee")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubeleftknee1",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubeleftknee2",x,y,z,x1,y1,z1);
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									float x = float.Parse(ballposition.SelectSingleNode("x").InnerText);
									float y = float.Parse(ballposition.SelectSingleNode("y").InnerText);
									float z = float.Parse(ballposition.SelectSingleNode("z").InnerText);
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									float x1 = float.Parse(ballrotation.SelectSingleNode("x1").InnerText);
									float y1 = float.Parse(ballrotation.SelectSingleNode("y1").InnerText);
									float z1 = float.Parse(ballrotation.SelectSingleNode("z1").InnerText);
									SetCubeTransform("cubeleftknee3",x,y,z,x1,y1,z1);
								}
							}
						}
					}
				}
			}
		}
	}
	
	
	void SetCubeTransform(string goname,float x,float y,float z,float x1,float y1,float z1)
	{
		//cubegos = GameObject.FindGameObjectsWithTag ("cube");
		for(int i = 0; i < cubegos.Length; i++)
		{
			if(cubegos[i].name == goname)
			{
				cubegos[i].SetActive(true);
				cubegos[i].transform.localPosition = new Vector3(x,y,z);
				cubegos[i].transform.localEulerAngles = new Vector3(x1,y1,z1);
			}
		}
	}
	
	public void ChangeOrderData()
	{
		string selectorderindex = uiinput.label.text;
		doc.Load(Application.streamingAssetsPath+"/level_man.xml");
		XmlNodeList orderNodeList = doc.SelectNodes("/video/moves/move/order");


		if (orderNodeList != null) 
		{
			foreach (XmlNode ordernode in orderNodeList)
			{
				if(ordernode.InnerText == selectorderindex)
				{
					XmlNodeList skeletonnodelist = ordernode.SelectNodes("../smoves/smove/skeleton");
					foreach (XmlNode skeletonnode in skeletonnodelist)
					{
						if(skeletonnode.InnerText == "RightHand")
						{
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberighthand1").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberighthand1").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberighthand1").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberighthand1").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberighthand1").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberighthand1").ToString();
									
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberighthand2").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberighthand2").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberighthand2").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberighthand2").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberighthand2").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberighthand2").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberighthand3").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberighthand3").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberighthand3").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberighthand3").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberighthand3").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberighthand3").ToString();
								}
							}
						}
						
						
						
						if(skeletonnode.InnerText == "LeftHand")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubelefthand1").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubelefthand1").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubelefthand1").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubelefthand1").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubelefthand1").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubelefthand1").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubelefthand2").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubelefthand2").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubelefthand2").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubelefthand2").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubelefthand2").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubelefthand2").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubelefthand3").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubelefthand3").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubelefthand3").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubelefthand3").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubelefthand3").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubelefthand3").ToString();
								}
							}
						}
						
						
						if(skeletonnode.InnerText == "RightFoot")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberightfoot1").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberightfoot1").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberightfoot1").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberightfoot1").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberightfoot1").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberightfoot1").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberightfoot2").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberightfoot2").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberightfoot2").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberightfoot2").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberightfoot2").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberightfoot2").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberightfoot3").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberightfoot3").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberightfoot3").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberightfoot3").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberightfoot3").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberightfoot3").ToString();
								}
							}
						}
						
						if(skeletonnode.InnerText == "LeftFoot")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubeleftfoot1").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubeleftfoot1").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubeleftfoot1").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubeleftfoot1").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubeleftfoot1").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubeleftfoot1").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubeleftfoot2").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubeleftfoot2").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubeleftfoot2").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubeleftfoot2").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubeleftfoot2").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubeleftfoot2").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubeleftfoot3").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubeleftfoot3").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubeleftfoot3").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubeleftfoot3").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubeleftfoot3").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubeleftfoot3").ToString();
								}
							}
						}

						if(skeletonnode.InnerText == "RightElbow")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberightelbow1").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberightelbow1").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberightelbow1").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberightelbow1").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberightelbow1").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberightelbow1").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberightelbow2").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberightelbow2").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberightelbow2").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberightelbow2").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberightelbow2").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberightelbow2").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberightelbow3").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberightelbow3").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberightelbow3").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberightelbow3").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberightelbow3").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberightelbow3").ToString();
								}
							}
						}

						if(skeletonnode.InnerText == "LeftElbow")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubeleftelbow1").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubeleftelbow1").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubeleftelbow1").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubeleftelbow1").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubeleftelbow1").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubeleftelbow1").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubeleftelbow2").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubeleftelbow2").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubeleftelbow2").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubeleftelbow2").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubeleftelbow2").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubeleftelbow2").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubeleftelbow3").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubeleftelbow3").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubeleftelbow3").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubeleftelbow3").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubeleftelbow3").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubeleftelbow3").ToString();
								}
							}
						}

						if(skeletonnode.InnerText == "RightKnee")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberightknee1").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberightknee1").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberightknee1").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberightknee1").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberightknee1").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberightknee1").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberightknee2").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberightknee2").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberightknee2").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberightknee2").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberightknee2").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberightknee2").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cuberightknee3").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cuberightknee3").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cuberightknee3").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cuberightknee3").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cuberightknee3").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cuberightknee3").ToString();
								}
							}
						}

						if(skeletonnode.InnerText == "LeftKnee")
						{
							
							XmlNodeList ballnumlist = skeletonnode.SelectNodes("../cubes/cube/ballnum");
							foreach (XmlNode ballnum in ballnumlist)
							{
								if(int.Parse(ballnum.InnerText) == 1)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubeleftknee1").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubeleftknee1").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubeleftknee1").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubeleftknee1").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubeleftknee1").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubeleftknee1").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 2)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubeleftknee2").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubeleftknee2").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubeleftknee2").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubeleftknee2").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubeleftknee2").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubeleftknee2").ToString();
								}
								if(int.Parse(ballnum.InnerText) == 3)
								{
									XmlNode ballposition = ballnum.SelectSingleNode("../ballposition");
									ballposition.SelectSingleNode("x").InnerText = GetCubeTransformPosX("cubeleftknee3").ToString();
									ballposition.SelectSingleNode("y").InnerText = GetCubeTransformPosY("cubeleftknee3").ToString();
									ballposition.SelectSingleNode("z").InnerText = GetCubeTransformPosZ("cubeleftknee3").ToString();
									
									
									XmlNode ballrotation = ballnum.SelectSingleNode("../ballrotation");
									ballrotation.SelectSingleNode("x1").InnerText = GetCubeTransformScaX("cubeleftknee3").ToString();
									ballrotation.SelectSingleNode("y1").InnerText = GetCubeTransformScaY("cubeleftknee3").ToString();
									ballrotation.SelectSingleNode("z1").InnerText = GetCubeTransformScaZ("cubeleftknee3").ToString();
								}
							}
						}

					}
				}
			}
		}
		doc.Save(Application.streamingAssetsPath + "/level_man.xml");
	}
	
	float GetCubeTransformPosX(string goname)
	{
		float posx = 0f;
		cubegos = GameObject.FindGameObjectsWithTag ("cube");
		for(int i = 0; i < cubegos.Length; i++)
		{
			if(cubegos[i].name == goname)
			{
				posx = cubegos[i].transform.localPosition.x;
				break;
			}
		}
		return posx;
	}
	
	float GetCubeTransformPosY(string goname)
	{
		float posy = 0f;
		cubegos = GameObject.FindGameObjectsWithTag ("cube");
		for(int i = 0; i < cubegos.Length; i++)
		{
			if(cubegos[i].name == goname)
			{
				posy =  cubegos[i].transform.localPosition.y;
				break;
			}
		}
		return posy;
	}
	
	float GetCubeTransformPosZ(string goname)
	{
		float posz = 0f;
		cubegos = GameObject.FindGameObjectsWithTag ("cube");
		for(int i = 0; i < cubegos.Length; i++)
		{
			if(cubegos[i].name == goname)
			{
				posz =  cubegos[i].transform.localPosition.z;
			}
		}
		return posz;
	}
	
	float GetCubeTransformScaX(string goname)
	{
		float scax = 0f;
		cubegos = GameObject.FindGameObjectsWithTag ("cube");
		for(int i = 0; i < cubegos.Length; i++)
		{
			if(cubegos[i].name == goname)
			{
				scax =  cubegos[i].transform.localEulerAngles.x;
			}
		}
		return scax;
	}
	
	float GetCubeTransformScaY(string goname)
	{
		float scay = 0f;
		cubegos = GameObject.FindGameObjectsWithTag ("cube");
		for(int i = 0; i < cubegos.Length; i++)
		{
			if(cubegos[i].name == goname)
			{
				scay =  cubegos[i].transform.localEulerAngles.y;
			}
		}
		return scay;
	}
	
	float GetCubeTransformScaZ(string goname)
	{
		float scaz = 0f;
		cubegos = GameObject.FindGameObjectsWithTag ("cube");
		for(int i = 0; i < cubegos.Length; i++)
		{
			if(cubegos[i].name == goname)
			{
				scaz =  cubegos[i].transform.localEulerAngles.z;
			}
		}
		return scaz;
	}

	/*void RemoveCube(int orderindex)
	{
		doc.Load(Application.streamingAssetsPath+"/level.xml");
		XmlNodeList orderNodeList = doc.SelectNodes("/video/moves/move/order");
		if (orderNodeList != null) 
		{
			foreach (XmlNode ordernode in orderNodeList)
			{
				if(ordernode.InnerText == orderindex.ToString())
				{
					XmlNodeList skeletonnodelist = ordernode.SelectNodes("../smoves/smove");
					foreach (XmlNode skeletonnode in skeletonnodelist)
					{
						skeletonnode.RemoveAll();
					}
				}
			}
		}
		doc.Save(Application.streamingAssetsPath + "/level.xml");
	}*/


	/*void AddCube(int orderindex)
	{
		doc.Load(Application.streamingAssetsPath+"/level.xml");
		XmlNodeList orderNodeList = doc.SelectNodes("/video/moves/move/order");
		if (orderNodeList != null) 
		{
			foreach (XmlNode ordernode in orderNodeList)
			{
				if(ordernode.InnerText == orderindex.ToString())
				{
					XmlNodeList skeletonnodelist = ordernode.SelectNodes("../smoves/smove");
					foreach (XmlNode skeletonnode in skeletonnodelist)
					{
						skeletonnode.RemoveAll();
					}
				}
			}
		}
		doc.Save(Application.streamingAssetsPath + "/level.xml");
	}*/
}
