/****************************************************************************
*                                                                           *
*  OpenNI Unity Toolkit                                                     *
*  Copyright (C) 2011 PrimeSense Ltd.                                       *
*                                                                           *
*                                                                           *
*  OpenNI is free software: you can redistribute it and/or modify           *
*  it under the terms of the GNU Lesser General Public License as published *
*  by the Free Software Foundation, either version 3 of the License, or     *
*  (at your option) any later version.                                      *
*                                                                           *
*  OpenNI is distributed in the hope that it will be useful,                *
*  but WITHOUT ANY WARRANTY; without even the implied warranty of           *
*  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the             *
*  GNU Lesser General Public License for more details.                      *
*                                                                           *
*  You should have received a copy of the GNU Lesser General Public License *
*  along with OpenNI. If not, see <http://www.gnu.org/licenses/>.           *
*                                                                           *
****************************************************************************/
using UnityEngine;
using OpenNI;
using System.Collections.Generic;

/// @brief A utility to show the users pixels
/// 
/// This is aimed as a basic utility and implementation sample to show the users pixels for debugging.
/// If one wants to show the users in the game, a better, more complete solution should be used.
/// @note this is aimed at debugging and NOT for showing the user. It is a quick implementation 
/// and not an efficient one.
/// @ingroup OpenNIViewerUtilities
using System.Collections;


public class PlayerPixels : MonoBehaviour
{
	public static PlayerPixels _instance;
    public OpenNISettingsManager m_context;
    /// holds the colors to show users in. If more users exist then color then they will be cycled through.
    public List<Color> UserColors;
    /// holds the background color (the color used for the background of everything @b NOT a user).
    public Color m_backgroundColor;

	public Color deepcolor;
    public Color invalidcolor;
    /// used to access the the data 
    protected SceneMetaData m_metaData;
	//public Material blend;
	public Material noblend;
    /// holds the last frame we processed. We should only change the texture if the frame changed...
    protected int m_lastProcessedImageFrameId = -1;
	private Scoring_Tony1 st1;
    /// This is the factor in which we will reduce the received image. A factor of 1
    /// means we use all pixels, a factor of 2 means we use only half the pixels in each
    /// direction.
    public int m_factor;
	public int xDirHide=2;

    public Transform lefttop;
    public Transform rightdown;
	public Color backcolor;

    /// the texture we will use to build the image into.
    protected Texture2D m_mapTexture;

//    /// this is where we will put the texture values before inserting them to the texture itself.
//    protected Color[] m_mapPixels;

    /// how many pixels in the x axis
    protected int XRes;
    /// how many pixels in the y axis
    protected int YRes;

    /// holds true if we are valid
    protected bool m_valid = false;

    EdgePixelsSequence sequence;
	MainInterface mainInterface;

	bool ifHideEdge = false;//是否隐藏边缘

	Color color=Color.blue;
	GameObject planyz;
	bool key=false ;
	public bool changethird=false ;

	public  float tm1=20f, tm2=5f,tm3=5f;
	public Material yinngzi,lightback;
	public GameObject Effectpannal4;

    /// this method should be overridden to set the internal texture and size
    /// (this will be entered into imageMapTexture, XRes and YRes). 
    /// @param refText (output) The texture created
    /// @param[out] xSize (output) the calculated size along the x axis
    /// @param[out] ySize (output) the calculated size along the y axis
    /// @return true on success and false on failure.
    /// @note this is a good place to put tests if externals are valid.
    protected  bool BaseInitTexture(out Texture2D refText, out int xSize, out int ySize)
    {
        refText = null;
        xSize = -1;
        ySize = -1;
        return true;
    }
    protected  bool InitTexture(out Texture2D refText, out int xSize, out int ySize)
    {
        NIOpenNICheckVersion.Instance.ValidatePrerequisite();
        if (BaseInitTexture(out refText, out xSize, out ySize) == false)
            return false;
        // make sure we have an image to work with
        if (m_context.UserSkeletonValid == false)
        {
            m_context.m_Logger.Log("Invalid users node", NIEventLogger.Categories.Initialization, NIEventLogger.Sources.Skeleton, NIEventLogger.VerboseLevel.Errors);
            return false;
        }
        if (m_factor <= 0)
        {
            m_context.m_Logger.Log("Illegal factor", NIEventLogger.Categories.Initialization, NIEventLogger.Sources.Skeleton, NIEventLogger.VerboseLevel.Errors);
			m_factor = 1;
        }
        // initialize the meta data object...
        m_metaData = m_context.UserGenrator.UserNode.GetUserPixels(0);
        // update the resolution by the factor
        ySize = m_metaData.YRes / m_factor;
        xSize = m_metaData.XRes / m_factor;
        // create the texture
        refText = new Texture2D(xSize, ySize, TextureFormat.ARGB32, false);
        // create a new meta data object.
        gameObject.renderer.material.mainTexture = refText;
        return true;
    }
    void InternalStart()
    {
        if (m_context == null)
            m_context = FindObjectOfType(typeof(OpenNISettingsManager)) as OpenNISettingsManager;
        if (m_context == null || m_context.Valid == false)
        {
            string str = "Context is invalid";
            if (m_context == null)
                str = "Context is null";
            Debug.Log(str);
            m_valid = false;
            return;
        }
        if (InitTexture(out m_mapTexture, out XRes, out YRes) == false || m_mapTexture == null)
        {
            m_context.m_Logger.Log("Failed to init texture", NIEventLogger.Categories.Initialization, NIEventLogger.Sources.BaseObjects, NIEventLogger.VerboseLevel.Errors);
            m_valid = false;
            return;
        }

        m_valid = true;


        //预设面板为黑色
		SetBackgroundApply ();

    }

	void Awake()
	{
		_instance = this;
		st1 = GameObject.Find("Cube1").GetComponent<Scoring_Tony1>() as Scoring_Tony1;
		mainInterface = FindObjectOfType (typeof(MainInterface)) as MainInterface;
	}

    public void Start()
    {
		planyz = GameObject .FindWithTag ("planyz");
		backcolor = Color .black;
		deepcolor =Color .yellow ;
		sequence = new EdgePixelsSequence(m_factor,xDirHide);
		sequence.SetOffsetScale(lefttop,rightdown);
        InternalStart();
    }

	public void SetOffsetScale()
	{
		sequence.SetOffsetScale(lefttop,rightdown);
		}

    public void Update()
    {
//		if (Input.GetKeyDown (KeyCode.B )) {
//
//			deepcolor =Color .black   ;
//			backcolor =Color .white ;
//			planyz.SetActive (false );
//
//				}
		//改变模式
		/*
	if (changethird == true) 
		{
			tm1 -= Time .deltaTime;

			if (tm1 < 0) 
			{
//				ChangMode ();
//				//Invoke ("ChangMode", 3f);
//				Invoke ("ChangMode1", 5f);
//				Invoke ("ChangMode",20f);//20
//				tm1 = 40f;//40
			}
		}
		*/
		if (!mainInterface.showShendu)
			sequence.HideEdge ();

		if (Input.GetKeyDown (KeyCode.Alpha8)) 
		{
			Scoring_Tony1 .zhuangye2 =false ;
			PlayerPixels ._instance .deepcolor =Color .yellow  ;
			PlayerPixels ._instance .backcolor =Color .black  ;
			mainInterface.showViewTag = (mainInterface.showViewTag + 1) % 3;
			ifHideEdge = !ifHideEdge;
			if (mainInterface.showViewTag != 2)
			{
                Scoring_Tony1.zhuanye = true;
				sequence.HideEdge();
				SetBackgroundApply();
			}
			this.renderer.material .shader = Shader .Find("Mobile/Particles/Additive");
		}

		if (m_valid)
			CalcTexture ();
		else
			sequence.HideEdge ();
    }

    
    void CalcTexture()
    {
        // we need to make sure everything is valid, otherwise we can't do anything...
        if (m_context.Valid == false || m_context.UserSkeletonValid == false)
            return; // we can't do anything...
        // check we have a new frame.
        if (m_metaData.FrameID >= m_lastProcessedImageFrameId)
        {
            m_lastProcessedImageFrameId = m_metaData.FrameID;
            WriteUserTexture();

            if (TestMobileTexture._instance && TestMobileTexture._instance.movieInf.movieCurProgress> 0)
			{
//				sequence.SetOffsetScale(lefttop,rightdown);
				sequence.OrderDraw(GetColor(st1.ismiss));
			}
			else
				sequence.HideEdge();

        }
    }

	int trackedID = 0;
	void ChangMode()
	{
		this.renderer.material .shader = Shader .Find("Mobile/Particles/Additive");
		Effectpannal4 .SetActive (false );
		//this.renderer.material = yinngzi;
		Scoring_Tony1 .zhuangye2 =false ;
		Scoring_Tony1.zhuanye = false ;
		PlayerPixels ._instance .deepcolor =Color .yellow  ;
		PlayerPixels ._instance .backcolor =Color .black  ;
		//mainInterface.showViewTag = (mainInterface.showViewTag + 1) % 3;
		mainInterface.showViewTag = 2;
		ifHideEdge = !ifHideEdge;
		if (mainInterface.showViewTag != 2)
		{
			Scoring_Tony1.zhuanye = false ;
			sequence.HideEdge();
			SetBackgroundApply();
		}

	}
	void ChangMode1()
	{
		Effectpannal4 .SetActive (true  );
		this.renderer.material .shader = Shader .Find("FX PACK 1/Energy Ball");
		Scoring_Tony1 .zhuangye2 =false ;
		Scoring_Tony1.zhuanye = false ;
		PlayerPixels ._instance .deepcolor =Color .yellow  ;
		PlayerPixels ._instance .backcolor =Color .black  ;
//		mainInterface.showViewTag = (mainInterface.showViewTag + 1) % 3;
		mainInterface.showViewTag = 0;
		ifHideEdge = !ifHideEdge;
		if (mainInterface.showViewTag != 2)
		{
			Scoring_Tony1.zhuanye = false ;
			sequence.HideEdge();
			SetBackgroundApply();
		}
		StartCoroutine (Change ());
		//this.renderer.material .shader = Shader .Find("FX PACK 1/Energy Ball");
	}

    /// a method to write the image data to the texture.
	IEnumerator Change()
	{
		yield return new WaitForSeconds (5f);
		Effectpannal4 .SetActive (false  );
		st1.ChangeMode2 ();
	}
    void WriteUserTexture()
    {
		
		if (mainInterface.showViewTag == 2) {
			sequence.HideEdge ();
			return;
		}

		if (mainInterface.showViewTag == 1)
			SetBackgroundPixel ();

        // the size of the target data
        int i = XRes * YRes - 1;
        // the array which holds the image
        UInt16MapData imageData = m_metaData.GetLabelMap();

        // loop over the target array (x and y).
        for (int y = 0; y < YRes; ++y)
        {
            for (int x = 0; x < XRes; ++x, i--) // the position is from end to start because of difference in coordinate systems
            {
				int pixel = imageData[x * m_factor, y * m_factor];
				if(pixel != 0)
                {
					if (m_context.UserGenrator.IsTracking(pixel))
                    {
						trackedID = pixel;
						if(mainInterface.showViewTag == 1)
							{
								m_mapTexture.SetPixel(x,y,GetColor(st1.ismiss));
								//边缘颜色
								if (x>xDirHide-1 && x < XRes-xDirHide && y>1 && y < YRes-2)
								{
									if (imageData[(int)(((x-1) * m_factor)), (int)((y * m_factor))] != trackedID || imageData[(int)(((x+1) * m_factor)), (int)((y * m_factor))] != trackedID || x == xDirHide || x == XRes - xDirHide-1)
									{
										m_mapTexture.SetPixel(x,y,GetColor(st1.ismiss) );
									}
									else if (imageData[(int)((x * m_factor)), (int)(((y-1) * m_factor))] != trackedID || imageData[(int)((x * m_factor)), (int)(((y+1) * m_factor))] != trackedID || y == 2 || y == YRes - 3)
									{
										m_mapTexture.SetPixel(x,y,GetColor(st1.ismiss) );
									}
								}
							}
							else
							{
								//边缘颜色
								if (x>xDirHide-1 && x < XRes-xDirHide && y>1 && y < YRes-2)
								{
									if (imageData[(int)(((x-1) * m_factor)), (int)((y * m_factor))] != trackedID || imageData[(int)(((x+1) * m_factor)), (int)((y * m_factor))] != trackedID || x == xDirHide || x == XRes - xDirHide-1)
									{
											sequence.AddEdgePixel(x,y);
									}
									else if (imageData[(int)((x * m_factor)), (int)(((y-1) * m_factor))] != trackedID || imageData[(int)((x * m_factor)), (int)(((y+1) * m_factor))] != trackedID || y == 2 || y == YRes - 3)
									{
											sequence.AddEdgePixel(x,y);
									}
								}
							}

					}
                   
				}

            }
        }

		if (mainInterface.showViewTag == 1)
			m_mapTexture.Apply();


    }

	//设定背景颜色
	void SetBackgroundPixel()
	{
		//预设面板为黑色
		for (int y = 0; y < YRes; ++y)
		{
			for (int x = 0; x < XRes; ++x) // the position is from end to start because of difference in coordinate systems
			{
				m_mapTexture.SetPixel(x, y, backcolor );
			}
		}

	}

	void SetBackgroundApply() {
		//预设面板为黑色
		for (int y = 0; y < YRes; ++y)
		{
			for (int x = 0; x < XRes; ++x) // the position is from end to start because of difference in coordinate systems
			{
				m_mapTexture.SetPixel(x, y, backcolor );
			}
		}
		m_mapTexture.Apply();
	}

	Color GetColor(bool ifMiss)
	{
		if (ifMiss)
			return Color.red;
		else 
			return deepcolor ;
	}
}
