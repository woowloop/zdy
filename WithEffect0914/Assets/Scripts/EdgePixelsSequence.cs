using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EdgePixelsSequence :MonoBehaviour
{
//	定义用于画边缘的点
	[HideInInspector]
	internal List<Vector2[]> pointsReady;
	//所有点集合
	bool[,] points;
	//已排列的点列表
	List<List<Vector2>> pointsOrdered;
	//开始点 X Y 坐标
	int breakPointX=0;
	int breakPointY=0;
	//X Y 轴偏移
	internal float xOffset=0;
	internal float yOffset=0;
	//画线的像素比例
	internal float scale=0;
    //X方向隐藏量
    int xDirHide;

	List<Vector2> breakPoints;


	//List 数量
	int listNum=0;
	[HideInInspector]
	//画线条数
	internal int drawLineNum=0;
	//X Y 长度
	int xLeng=0;
	int yLeng=0;

	VDraw drawEdge;

	public EdgePixelsSequence(float factor,int xDirHide)
	{
		xLeng = (int)(320f / factor);
		yLeng = (int)(240f / factor);
        this.xDirHide = xDirHide;
		points=new bool[xLeng,yLeng];
		pointsOrdered = new List<List<Vector2>> ();
		pointsReady=new List<Vector2[]>();

		breakPoints = new List<Vector2>();

		InitializePoints ();

		drawEdge = new VDraw ();
		drawEdge.InitializeEdges ();
	}

	//添加边缘点
	public void AddEdgePixel(int x,int y)
	{
		points [x, y] = true;	
	}
	
	public void OrderDraw(Color color)
	{
		//排序
		OrderSequence();
		//数据特殊格式化
		SetPixelForDrawEdge ();
		//批量绘制线段
		drawEdge.DrawEdge(pointsReady,drawLineNum,color);
		//ShowDebug();
		Clear();

	}

	//清空和归零
	public void Clear()
	{
		ClearPointsOrdered ();
		InitializePoints ();
	}

	public void HideEdge()
	{
		drawEdge.HideEdge ();
	}

	//已排序点数据类型转化
	void SetPixelForDrawEdge ()
	{
		int count = 0;
		drawLineNum = 0;

		float curX;
		float curY;
		float preX;
		float preY;


		for (int i = 0; i < listNum; i++) 
		{
			count=pointsOrdered[i].Count;
			if(count>10)
			{
				drawLineNum++;
				pointsReady.Add(new Vector2[count]);

				for(int j=0;j<count;j++)
				{
					curX = xOffset+scale*pointsOrdered[i][j].x;
					curY = yOffset-scale*pointsOrdered[i][j].y;

					if (j==0) 
					{
						pointsReady[drawLineNum-1][j] = new Vector2(curX,curY);
						continue;
					} 
					else 
					{
						preX = pointsReady[drawLineNum-1][j-1].x;
						preY = pointsReady[drawLineNum-1][j-1].y;
						if ((Mathf.Abs(curX-preX))>scale*5 || (Mathf.Abs(curY-preY))>scale*5) {
							//Debug.LogError("deltaX:" + Mathf.Abs(curX-preX) + "--deltaY:" + Mathf.Abs(curY-preY));
							pointsReady[drawLineNum-1][j]=new Vector2(preX,preY);
							continue;
						} 
						else 
						{
							pointsReady[drawLineNum-1][j] = new Vector2(curX,curY);
							continue;
						}
					}


				}
			}
		}

	}
	
	public void ShowDebug()
	{
		int count = 0;
		for (int i=0; i<drawLineNum; i++) 
		{
			count=pointsReady[i].Length;
			for(int j=0;j<count;j++)
			{
				Debug.LogError("第"+i+"条："+j+"个点"+pointsReady[i][j]);
			}
		}
	}

	//清空已排列的点序列List
	public void ClearPointsOrdered()
	{
		listNum = 0;
		drawLineNum = 0;

		for(int i=0;i<listNum;i++)
		{
			pointsOrdered[i].Clear();
		}
		pointsOrdered.Clear ();
		
		for(int i=0;i<drawLineNum;i++)
		{
			pointsReady[i]=null;
		}
		pointsReady.Clear ();
	}   

	//排列点并写进pointsOrdered
	public void OrderSequence()
	{
		while(IfNextPointExitst())
		{
			listNum++;
			pointsOrdered.Add(new List<Vector2>());
			SearchNextPixel(breakPointX,breakPointY);
		}

	}


//初始化points
	void InitializePoints()
	{
		for(int i=0;i<xLeng;i++)
		{
			for(int j=0;j<yLeng;j++)
			{
				points[i,j]=false;
			}
		}
	}



	//扫描开始断点
	public bool IfNextPointExitst()
	{
		int count=0;
		
		for (int j=2; j<yLeng-2; j++)
		{
			for(int i=xDirHide;i<xLeng-xDirHide;i++)
			{

				if(points[i,j])
				{
					if(points[i-1,j])
						count++;
					
					if(points[i+1,j])
						count++;
					
					if(points[i,j-1])
						count++;
					
					if(points[i,j+1])
						count++;
					
					if(points[i-1,j-1])
						count++;
					
					if(points[i-1,j+1])
						count++;
					
					if(points[i+1,j-1])
						count++;
					
					if(points[i+1,j+1])
						count++;
					
					if(count==2)
					{
						breakPointX=i;
						breakPointY=j;
						return true;
					}
				}
			}
		}
		return false;
	}

	//查找下一个Pixel
	void SearchNextPixel(int x,int y)
	{
		//Debug.Log ("递归："+x+"  "+y);
		if (x < xDirHide || x > xLeng - xDirHide-1 || y < 2 || y > yLeng - 3)
			return;

		if (points [x, y]==false) 
			return;

		points [x, y] = false;
		pointsOrdered [listNum-1].Add(new Vector2 (x,y));

		SearchNextPixel (x-1,y);
		SearchNextPixel (x+1,y);
		SearchNextPixel (x,y+1);
		SearchNextPixel (x,y-1);
		SearchNextPixel (x-1,y-1);
		SearchNextPixel (x-1,y+1);
		SearchNextPixel (x+1,y-1);
		SearchNextPixel (x+1,y+1);
	}

	
	//设定画线位置和缩放
	public void SetOffsetScale(Transform leftTop,Transform rightDown)
	{
		Vector3 offset1 = Camera.main.WorldToScreenPoint (leftTop.position);
		Vector3 offset2 = Camera.main.WorldToScreenPoint (rightDown.position);
		xOffset = offset1.x;
		yOffset = offset1.y;
		scale = Mathf.Abs(offset2.x - offset1.x) / xLeng;
	}

}




