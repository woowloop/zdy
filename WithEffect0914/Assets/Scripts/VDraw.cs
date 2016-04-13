using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vectrosity;
using OpenNI;

public class VDraw : MonoBehaviour{
	//线条样式
	public Material style;

	//画多条边缘线
	VectorLine[] edgeLines;
	Vector2[] edgePoints;

	//画多条骨骼线
	VectorLine[] skeletonLines;
	Vector3[][] skeletonPoints;
	Vector2[][] skeletonPoints2D;

	public VDraw()
	{
	}

	//初始化点边缘List表
	public void InitializeEdges()
	{
		edgeLines=new VectorLine[10];
		edgePoints = new Vector2[400];

		for(int i=0;i<10;i++)
		{
			edgeLines[i]=new VectorLine("DrawEdge "+i,edgePoints,Color.green,style,3f,LineType.Discrete);
		}
	}

	//初始化点骨骼List表
	public void InitializeSkeletons()
	{
		skeletonLines = new VectorLine[5];
		skeletonPoints=new Vector3[5][]{new Vector3[2],new Vector3[4],new Vector3[4],new Vector3[5],new Vector3[5]};

		skeletonLines [0] = new VectorLine ("skeletonLines0",skeletonPoints[0],Color.red,null,5f,LineType.Continuous);
		skeletonLines [1] = new VectorLine ("skeletonLines1",skeletonPoints[1],Color.red,null,5f,LineType.Continuous);
		skeletonLines [2] = new VectorLine ("skeletonLines2",skeletonPoints[2],Color.red,null,5f,LineType.Continuous);
		skeletonLines [3] = new VectorLine ("skeletonLines3",skeletonPoints[3],Color.red,null,5f,LineType.Continuous);
		skeletonLines [4] = new VectorLine ("skeletonLines4",skeletonPoints[4],Color.red,null,5f,LineType.Continuous);
	}

	//初始化点骨骼List表
	public void InitializeSkeletons2D()
	{
		skeletonLines = new VectorLine[5];
		skeletonPoints2D=new Vector2[5][]{new Vector2[2],new Vector2[4],new Vector2[4],new Vector2[5],new Vector2[5]};
		
		skeletonLines [0] = new VectorLine ("skeletonLines0",skeletonPoints2D[0],Color.red,null,5f,LineType.Continuous);
		skeletonLines [1] = new VectorLine ("skeletonLines1",skeletonPoints2D[1],Color.red,null,5f,LineType.Continuous);
		skeletonLines [2] = new VectorLine ("skeletonLines2",skeletonPoints2D[2],Color.red,null,5f,LineType.Continuous);
		skeletonLines [3] = new VectorLine ("skeletonLines3",skeletonPoints2D[3],Color.red,null,5f,LineType.Continuous);
		skeletonLines [4] = new VectorLine ("skeletonLines4",skeletonPoints2D[4],Color.red,null,5f,LineType.Continuous);
	}

	//画多条边缘线
	public void DrawEdge(List<Vector2[]> pixelsReady,int drawLineNum,Color color)
	{
		if (drawLineNum == 0)
			return;

		if (drawLineNum > 10)
			drawLineNum = 10;

		for(int i=0;i<drawLineNum;i++)
		{
			edgeLines[i].SetColor(color);

			edgeLines[i].MakeSpline(pixelsReady[i]);

			edgeLines[i].Draw();
		}

		for(int i=drawLineNum;i<10;i++)
		{
			edgeLines[i].MakeSpline(new Vector2[2]{Vector2.zero,Vector2.zero});
			edgeLines[i].Draw();
		}
	}
	//隐藏边缘线
	public void HideEdge()
	{
		for(int i=0;i<10;i++)
		{
			edgeLines[i].MakeSpline(new Vector2[2]{Vector2.zero,Vector2.zero});
			edgeLines[i].Draw();
		}
	}

	//画骨骼线
	public void DrawSkeleton(Vector3[] jointsPosition)
	{
		skeletonPoints [0] = new Vector3[] {
			jointsPosition [(int)JointsProjective.MainJoint.Neck],
			jointsPosition [(int)JointsProjective.MainJoint.Head]
		};
		
		skeletonPoints [1] = new Vector3[] {
			jointsPosition [(int)JointsProjective.MainJoint.Neck],
			jointsPosition [(int)JointsProjective.MainJoint.LeftShoulder],
			jointsPosition [(int)JointsProjective.MainJoint.LeftElbow],
			jointsPosition [(int)JointsProjective.MainJoint.LeftHand]
		};
		
		skeletonPoints [2] = new Vector3[] {
			jointsPosition [(int)JointsProjective.MainJoint.Neck],
			jointsPosition [(int)JointsProjective.MainJoint.RightShoulder],
			jointsPosition [(int)JointsProjective.MainJoint.RightElbow],
			jointsPosition [(int)JointsProjective.MainJoint.RightHand]
		};
		
		skeletonPoints [3] = new Vector3[] {
			jointsPosition [(int)JointsProjective.MainJoint.LeftShoulder],
			jointsPosition [(int)JointsProjective.MainJoint.Torso],
			jointsPosition [(int)JointsProjective.MainJoint.RightHip],
			jointsPosition [(int)JointsProjective.MainJoint.RightKnee],
			jointsPosition [(int)JointsProjective.MainJoint.RightFoot]
		};
		
		skeletonPoints [4] = new Vector3[] {
			jointsPosition [(int)JointsProjective.MainJoint.RightShoulder],
			jointsPosition [(int)JointsProjective.MainJoint.Torso],
			jointsPosition [(int)JointsProjective.MainJoint.LeftHip],
			jointsPosition [(int)JointsProjective.MainJoint.LeftKnee],
			jointsPosition [(int)JointsProjective.MainJoint.LeftFoot]
		};

		
		skeletonLines [0].MakeSpline (skeletonPoints[0]);
		skeletonLines [1].MakeSpline (skeletonPoints[1]);
		skeletonLines [2].MakeSpline (skeletonPoints[2]);
		skeletonLines [3].MakeSpline (skeletonPoints[3]);
		skeletonLines [4].MakeSpline (skeletonPoints[4]);
		
		skeletonLines [0].Draw ();
		skeletonLines [1].Draw ();
		skeletonLines [2].Draw ();
		skeletonLines [3].Draw ();
		skeletonLines [4].Draw ();
	}

	//画2D骨骼线
	public void DrawSkeleton2D(Vector2[] jointsPosition)
	{
		skeletonPoints2D [0] = new Vector2[] {
			jointsPosition [(int)JointsProjective.MainJoint.Neck],
			jointsPosition [(int)JointsProjective.MainJoint.Head]
		};

		skeletonPoints2D [1] = new Vector2[] {
			jointsPosition [(int)JointsProjective.MainJoint.Neck],
			jointsPosition [(int)JointsProjective.MainJoint.LeftShoulder],
			jointsPosition [(int)JointsProjective.MainJoint.LeftElbow],
			jointsPosition [(int)JointsProjective.MainJoint.LeftHand]
		};

		skeletonPoints2D [2] = new Vector2[] {
			jointsPosition [(int)JointsProjective.MainJoint.Neck],
			jointsPosition [(int)JointsProjective.MainJoint.RightShoulder],
			jointsPosition [(int)JointsProjective.MainJoint.RightElbow],
			jointsPosition [(int)JointsProjective.MainJoint.RightHand]
		};

		skeletonPoints2D [3] = new Vector2[] {
			jointsPosition [(int)JointsProjective.MainJoint.LeftShoulder],
			jointsPosition [(int)JointsProjective.MainJoint.Torso],
			jointsPosition [(int)JointsProjective.MainJoint.RightHip],
			jointsPosition [(int)JointsProjective.MainJoint.RightKnee],
			jointsPosition [(int)JointsProjective.MainJoint.RightFoot]
		};

		skeletonPoints2D [4] = new Vector2[] {
			jointsPosition [(int)JointsProjective.MainJoint.RightShoulder],
			jointsPosition [(int)JointsProjective.MainJoint.Torso],
			jointsPosition [(int)JointsProjective.MainJoint.LeftHip],
			jointsPosition [(int)JointsProjective.MainJoint.LeftKnee],
			jointsPosition [(int)JointsProjective.MainJoint.LeftFoot]
		};

		skeletonLines [0].MakeSpline (skeletonPoints2D[0]);
		skeletonLines [1].MakeSpline (skeletonPoints2D[1]);
		skeletonLines [2].MakeSpline (skeletonPoints2D[2]);
		skeletonLines [3].MakeSpline (skeletonPoints2D[3]);
		skeletonLines [4].MakeSpline (skeletonPoints2D[4]);

		skeletonLines [0].Draw ();
		skeletonLines [1].Draw ();
		skeletonLines [2].Draw ();
		skeletonLines [3].Draw ();
		skeletonLines [4].Draw ();
	}
	
}
