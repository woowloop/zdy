using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using OpenNI;
using System;
public enum MoveGrade
{
    invalid = 0,
    miss = 1,
    bad = 2,
    good = 3,
    perfect = 4
}
public enum MoveTowards
{
    invalid = 0,
    dirX = 1,
    dirY = 2,
    dirZ = 3,
    dirXY = 4,
    dirXZ = 5,
    dirYZ = 6,
    dirXYZ = 7
}
[Serializable]
public class Movement
{
    public int order;
    public float starttime;
    public float endtime;
    //public bool IsUpdateRoot;
    public List<SingleMove> smoves;
    public Movement()
    {
        order = 0;
        starttime = 0;
        endtime = 0;
        smoves = new List<SingleMove>();
    }
}
[Serializable]
public class SingleMove
{
    public SkeletonJoint skeleton;
    public List<CubeObj> cubes;
    public MoveGrade grade;
    public MoveTowards dir;
    public float waittime;
    public SingleMove()
    {
        skeleton = SkeletonJoint.Invalid;
        dir = MoveTowards.invalid;
        waittime = 0;
        cubes = new List<CubeObj>();
        grade = MoveGrade.invalid;
    }
}
[Serializable]
public class CubeObj
{
    public int ballnum;
    public Vector3 ballposition;
    public Vector3 ballballrotation;
    public CubeObj()
    {
        ballnum = 0;
        ballposition = Vector3.zero;
        ballballrotation = Vector3.zero;
    }
}
[Serializable]
public class LevelsCtrl
{
    public string moviename;
    public List<Movement> moves;
}
public class XMLDecode : MonoBehaviour 
{

    List<LevelsCtrl> levels;
    private Scoring_Tony1 st1;

    public delegate void DecodeXmlComplete(ShowMovieInfo smi);
    public event DecodeXmlComplete OnDecodeXmlComplete;

    List<Movement> retLsMt = new List<Movement>();
    public static XMLDecode _instance;
	// Use this for initialization

    public void NotifyDecodeXmlComplete(ShowMovieInfo smi)
    {
        if (OnDecodeXmlComplete!=null)
        {
            OnDecodeXmlComplete(smi);
        }
    }
     void Awake()
    {
        _instance = this;
    }
	void Start () 
    {
        st1 = GameObject.Find("Cube1").GetComponent<Scoring_Tony1>() as Scoring_Tony1;
        // openNIRadarViewer = GameObject.Find("NIRadarViewer") as GameObject;
        levels = st1.levels;
        List<XmlNode> xmlNodeList = new List<XmlNode>();
	}
    public List<Movement> DecodeXML(ShowMovieInfo smi, string textPath = "posestarttime")
    {
        StartCoroutine(ReadInAndroid(smi));
        retLsMt.Clear();
        return retLsMt;
    }
	// Update is called once per frame
	void Update () 
    {
	}
    void ReadXml(WWW www)
    {
        /*
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(www.text);
        Movement mt = new Movement();
        XmlNodeList video = doc.SelectSingleNode("video").ChildNodes;
        levels[0].moviename = video[0].InnerText;
        XmlNodeList moves = video[1].ChildNodes;

        XmlNodeList move = moves[0].ChildNodes;
        XmlNodeList smoves = move[3].ChildNodes;


        for (int n = 0; n < smoves.Count; n++)
			{
				XmlNodeList smove = smoves[n].ChildNodes;
				SingleMove sm = new SingleMove();
				levels[0].moves[m].smoves.Add(sm);
				if(smove[0].InnerText=="LeftHand")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.LeftHand;
				else if(smove[0].InnerText=="RightHand")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.RightHand;
				else if(smove[0].InnerText=="LeftFoot")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.LeftFoot;
				else if(smove[0].InnerText=="RightFoot")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.RightFoot;
				else if(smove[0].InnerText=="LeftElbow")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.LeftElbow;
				else if(smove[0].InnerText=="RightElbow")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.RightElbow;
				else if(smove[0].InnerText=="LeftKnee")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.LeftKnee;
				else if(smove[0].InnerText=="RightKnee")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.RightKnee;
				else if(smove[0].InnerText=="RightShoulder")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.RightShoulder;
				else if(smove[0].InnerText=="LeftShoulder")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.LeftShoulder;
				else if(smove[0].InnerText=="Head")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.Head;

				if(smove[1].InnerText=="dirX")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirX;
				}
				else if(smove[1].InnerText=="dirY")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirY;
				}
				else if(smove[1].InnerText=="dirZ")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirZ;
				}
				else if(smove[1].InnerText=="dirXY")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirXY;
				}
				else if(smove[1].InnerText=="dirXZ")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirXZ;
				}
				else if(smove[1].InnerText=="dirYZ")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirYZ;
				}
				else if(smove[1].InnerText=="dirXYZ")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirXYZ;
				}

				levels[0].moves[m].smoves[n].waittime = float.Parse(smove[2].InnerText);
				XmlNodeList cubes = smove[3].ChildNodes;
				for (int a = 0; a < 3; a++)
				{
					XmlNodeList cube = cubes[a].ChildNodes;
					CubeObj co = new CubeObj();
					levels[0].moves[m].smoves[n].cubes.Add(co);
					levels[0].moves[m].smoves[n].cubes[a].ballnum = int.Parse(cube[0].InnerText);
					XmlNodeList ballposition=cube[1].ChildNodes;
					levels[0].moves[m].smoves[n].cubes[a].ballposition = new Vector3(float.Parse(ballposition[0].InnerText), float.Parse(ballposition[1].InnerText), float.Parse(ballposition[2].InnerText));
                    XmlNodeList ballballrotation = cube[2].ChildNodes;
                    levels[0].moves[m].smoves[n].cubes[a].ballballrotation = new Vector3(float.Parse(ballballrotation[0].InnerText), float.Parse(ballballrotation[1].InnerText), float.Parse(ballballrotation[2].InnerText));
				}
			}
		}*/
    }
    void listreadxml(WWW www)
	{
		XmlDocument doc = new XmlDocument();
		//doc.Load(Application.streamingAssetsPath+"/level.xml");
		doc.LoadXml (www.text );
		XmlNodeList video = doc.SelectSingleNode("video").ChildNodes;
		levels[0].moviename = video[0].InnerText;
        Debug.Log("moviename>>" + levels[0].moviename);
		XmlNodeList moves = video[1].ChildNodes;
		for (int m = 0; m < moves.Count; m++)
		{
			XmlNodeList move = moves[m].ChildNodes;
			Movement mt = new Movement();
			levels[0].moves.Add(mt);
			levels[0].moves[m].order = int.Parse(move[0].InnerText);
            //levels[0].moves[m].starttime = float.Parse(move[1].InnerText);
            //levels[0].moves[m].endtime = float.Parse(move[2].InnerText);
			/*if(move[3].InnerText=="dirX")
			{
				levels[0].moves[m].dir=MoveTowards.dirX;
			}
			else if(move[3].InnerText=="dirY")
			{
				levels[0].moves[m].dir=MoveTowards.dirY;
			}
			else if(move[3].InnerText=="dirZ")
			{
				levels[0].moves[m].dir=MoveTowards.dirZ;
			}
            else if (move[3].InnerText == "dirXY")
            {
                levels[0].moves[m].dir = MoveTowards.dirXY;
            }
            else if (move[3].InnerText == "dirXZ")
            {
                levels[0].moves[m].dir = MoveTowards.dirXZ;
            }
            else if (move[3].InnerText == "dirYZ")
            {
                levels[0].moves[m].dir = MoveTowards.dirYZ;
            }
            else if (move[3].InnerText == "dirXYZ")
            {
                levels[0].moves[m].dir = MoveTowards.dirXYZ;
            }*/
			XmlNodeList smoves = move[3].ChildNodes;
			for (int n = 0; n < smoves.Count; n++)
			{
				XmlNodeList smove = smoves[n].ChildNodes;
				SingleMove sm = new SingleMove();
				levels[0].moves[m].smoves.Add(sm);
				if(smove[0].InnerText=="LeftHand")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.LeftHand;
				else if(smove[0].InnerText=="RightHand")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.RightHand;
				else if(smove[0].InnerText=="LeftFoot")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.LeftFoot;
				else if(smove[0].InnerText=="RightFoot")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.RightFoot;
				else if(smove[0].InnerText=="LeftElbow")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.LeftElbow;
				else if(smove[0].InnerText=="RightElbow")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.RightElbow;
				else if(smove[0].InnerText=="LeftKnee")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.LeftKnee;
				else if(smove[0].InnerText=="RightKnee")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.RightKnee;
				else if(smove[0].InnerText=="RightShoulder")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.RightShoulder;
				else if(smove[0].InnerText=="LeftShoulder")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.LeftShoulder;
				else if(smove[0].InnerText=="Head")
					levels[0].moves[m].smoves[n].skeleton = SkeletonJoint.Head;

				if(smove[1].InnerText=="dirX")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirX;
				}
				else if(smove[1].InnerText=="dirY")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirY;
				}
				else if(smove[1].InnerText=="dirZ")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirZ;
				}
				else if(smove[1].InnerText=="dirXY")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirXY;
				}
				else if(smove[1].InnerText=="dirXZ")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirXZ;
				}
				else if(smove[1].InnerText=="dirYZ")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirYZ;
				}
				else if(smove[1].InnerText=="dirXYZ")
				{
					levels[0].moves[m].smoves[n].dir=MoveTowards.dirXYZ;
				}

				levels[0].moves[m].smoves[n].waittime = float.Parse(smove[2].InnerText);
				XmlNodeList cubes = smove[3].ChildNodes;
				for (int a = 0; a < 3; a++)
				{
					XmlNodeList cube = cubes[a].ChildNodes;
					CubeObj co = new CubeObj();
					levels[0].moves[m].smoves[n].cubes.Add(co);
					levels[0].moves[m].smoves[n].cubes[a].ballnum = int.Parse(cube[0].InnerText);
					XmlNodeList ballposition=cube[1].ChildNodes;
					levels[0].moves[m].smoves[n].cubes[a].ballposition = new Vector3(float.Parse(ballposition[0].InnerText), float.Parse(ballposition[1].InnerText), float.Parse(ballposition[2].InnerText));
                    XmlNodeList ballballrotation = cube[2].ChildNodes;
                    levels[0].moves[m].smoves[n].cubes[a].ballballrotation = new Vector3(float.Parse(ballballrotation[0].InnerText), float.Parse(ballballrotation[1].InnerText), float.Parse(ballballrotation[2].InnerText));
				}
			}
		}
	}
//	IEnumerator ReadtextAndroid()
//	{
//		string mPath;
//		#if UNITY_EDITOR 
//		mPath = "file://" +Application.streamingAssetsPath+"/posestarttime.txt";
//		#elif UNITY_ANDROID 
//		mPath = Application.streamingAssetsPath+"/posestarttime.txt";
//		#endif
//		
//		WWW www = new WWW (mPath );
//		yield return www;
//		listreadtxt(www);
//
//	}
    /*
    void ReadTxt_MovieTimePer(List<Movement> retLsMt)
    {
        
        if (retLsMt!=null)
        {
            TextAsset loadtext = (TextAsset)Resources.Load("posestarttime");
            string sr1 = loadtext.text;
            string[] strArray = sr1.Split('\n');
            for (int d = 0; d < strArray.Length; d++)
            {
                if (d % 2 == 0)
                {
                    retLsMt.starttime = float.Parse(strArray[d]);
                    //Debug .Log (strArray [d]+"start");
                }
                else
                {
                    levels[0].moves[(int)b].endtime = float.Parse(strArray[d]);
                    //Debug .Log (strArray [d]+"end");
                }

                b += 0.5f;
            }
        }
    }*/
    void listreadtxt()
    {
        int i = 0;
        float j = 0, b = 0;
        TextAsset loadtext = (TextAsset)Resources.Load("posestarttime");
        string sr1 = loadtext.text;
        string[] strArray = sr1.Split('\n');
        for (int d = 0; d < strArray.Length; d++)
        {
            if (d % 2 == 0)
            {
                levels[0].moves[(int)b].starttime = float.Parse(strArray[d]);
                //Debug .Log (strArray [d]+"start");
            }
            else
            {
                levels[0].moves[(int)b].endtime = float.Parse(strArray[d]);
                //Debug .Log (strArray [d]+"end");
            }

            b += 0.5f;
        }
    }
    IEnumerator ReadInAndroid(ShowMovieInfo smi)
    {
        //Layout.Next("XMLDecode " + smi.xmlUrl);
        Debug.Log("XMLDecode " + smi.xmlUrl);
        string sPath;
        sPath = "file:///" + smi.xmlUrl;
#if UNITY_EDITOR
        sPath = "file:///" + smi.xmlUrl;
#elif UNITY_ANDROID 
		sPath = Application.streamingAssetsPath+ "/" + path;
#endif

        WWW www = new WWW(sPath);
        yield return www;
        if (www.error == null)
        {
            listreadxml(www);
            listreadtxt();
            NotifyDecodeXmlComplete(smi);
        }
        else
        {
            //Layout.Next("XMLDecode Error");
        }
        
    }
}
