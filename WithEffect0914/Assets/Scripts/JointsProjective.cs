using UnityEngine;
using System.Collections;
using OpenNI;

public class JointsProjective : MonoBehaviour {
	Vector3 endPoint;
	NIPlayerManager m_playerManager;
	NISelectedPlayer player;
	//节点数量
	const int count = 15;
	//各节点位置
	internal Vector3[] jointsPosition = new Vector3[count];
	internal Vector3[] projectivePosition = new Vector3[count];
	//建立一对一的数据Joint部位对应
	int[] trans=new int[count];
	Ray[] ray = new Ray[count];

	VDraw vDraw;
	

	// Use this for initialization
	void Start () 
	{
		trans = new int[count]{1,2,3,6,7,9,12,13,15,17,18,20,21,22,24};
		if (m_playerManager == null)
			m_playerManager = FindObjectOfType(typeof(NIPlayerManager)) as NIPlayerManager;
		if (m_playerManager == null)
			throw new System.Exception("Must have a player manager to control the skeleton!");
		for (int i=0; i<count; i++)
			ray [i] = new Ray (Vector3.zero,Vector3.zero);
		endPoint = GameObject.Find ("A_ReferencePoint").transform.position;
		vDraw = new VDraw ();
		vDraw.InitializeSkeletons ();
	}

	// Update is called once per frame
	void Update () 
	{
		player = m_playerManager.GetPlayer (0);
		if (player == null || player.Valid == false || player.Tracking==false)
			return;
		//当前节点位置
		SkeletonJointPosition curpos;

		for (int i=0; i<count; i++) 
		{
			if(player.GetSkeletonJointPosition((SkeletonJoint)(trans[i]),out curpos))
			{
				jointsPosition[i]=NIConvertCoordinates.ConvertPos(curpos.Position);
			}
		}

		Projective ();
		vDraw.DrawSkeleton (projectivePosition);
	}

	//对坐标进行映射
	void Projective()
	{
		RaycastHit hit;
		for (int i=0; i<count; i++) 
		{
			ray[i].origin=jointsPosition[i];
			ray[i].direction=endPoint-jointsPosition[i];

			if (Physics.Raycast(ray[i], out hit) && hit.collider.tag=="Projection")
				projectivePosition[i]=hit.point;
			else
			{
				if(i!=0)
					projectivePosition[i]=projectivePosition[i-1];
			}
		}
	}

	//主要骨骼节点
	public enum MainJoint
	{
		Head,
		Neck,
		Torso,
		LeftShoulder,
		LeftElbow,
		LeftHand,
		RightShoulder,
		RightElbow,
		RightHand,
		LeftHip,
		LeftKnee,
		LeftFoot,
		RightHip,
		RightKnee,
		RightFoot
	}
}
