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

/// @brief A utility to show the RGB image. 
/// 
/// This is aimed as a basic utility and implementation sample to show the RBG input for debugging.
/// If one wants to show the RGB image in the game, a better, more complete solution
/// should be used.
/// @note this is aimed at debugging and NOT for showing the user. It is a quick implementation 
/// and not an efficient one
/// @ingroup OpenNIViewerUtilities
using System.Collections;
using System.IO;


public class PlayerImages : MonoBehaviour
{
	public static PlayerImages _instance;
	public OpenNISettingsManager m_context;
	/// used to access the the data 
	protected ImageMetaData m_metaData;
	public bool m_valid = false;
	/// holds the last frame we processed. We should only change the texture if the frame changed...
	protected int m_lastProcessedImageFrameId = -1;
	protected Texture2D m_imageTexture;
	/// how many pixels in the x axis
	protected int XRes;
	/// how many pixels in the y axis
	protected int YRes;
	protected Color[] m_mapPixels;
	public int m_factor;
	private Scoring_Tony1 st1;
	private int num=0;
	private string prjpath;
	public string downpath;
	public bool Onpath=false ;
	void InternalStart ()
	{
		if (m_context == null)
			m_context = FindObjectOfType (typeof(OpenNISettingsManager)) as OpenNISettingsManager;
		if (m_context == null || m_context.Valid == false) {
			string str = "Context is invalid";
			if (m_context == null)
				str = "Context is null";
			Debug.Log (str);
			m_valid = false;
			return;
		}
		if (InitTexture (out m_imageTexture, out XRes, out YRes) == false || m_imageTexture == null) {
			m_context.m_Logger.Log ("Failed to init texture", NIEventLogger.Categories.Initialization, NIEventLogger.Sources.BaseObjects, NIEventLogger.VerboseLevel.Errors);
			m_valid = false;
			return;
		}
		m_mapPixels = new Color[XRes * YRes];
		m_valid = true;
	}

	void Awake()
	{
		_instance = this;
	}
	public void Start ()
	{
		InternalStart ();
		st1 =GameObject .Find ("Cube1").GetComponent <Scoring_Tony1 >();

	}

	public void Update ()
	{
		if (m_valid)
			CalcTexture ();
	}


	protected  bool BaseInitTexture (out Texture2D refText, out int xSize, out int ySize)
	{
		refText = null;
		xSize = -1;
		ySize = -1;
		return true;
	}

	protected  bool InitTexture (out Texture2D refText, out int xSize, out int ySize)
	{
		NIOpenNICheckVersion.Instance.ValidatePrerequisite ();
		if (BaseInitTexture (out refText, out xSize, out ySize) == false)
			return false;
		// make sure we have an image to work with
		if (m_context.ImageValid == false) {
			m_context.m_Logger.Log ("Invalid image", NIEventLogger.Categories.Initialization, NIEventLogger.Sources.Image, NIEventLogger.VerboseLevel.Errors);
			return false;
		}
		if (m_factor <= 0) {
			m_context.m_Logger.Log ("Illegal factor", NIEventLogger.Categories.Initialization, NIEventLogger.Sources.Image, NIEventLogger.VerboseLevel.Errors);
			return false;
		}
		// get the resolution from the image
		//MapOutputMode mom = m_context.Image.Image.MapOutputMode;
		// update the resolution by the factor

		m_metaData = m_context.Image.Image.GetMetaData ();
		ySize = m_metaData.YRes / m_factor;
		xSize = m_metaData.XRes / m_factor;
		// create the texture
		refText = new Texture2D (xSize, ySize, TextureFormat.RGB24, false);
		// create a new meta data object.
		return true;
	}
	
	
	protected  void CalcTexture ()
	{
		//base.CalcTexture();
		// we need to make sure everything is valid, otherwise we can't do anything...
		if (m_context.Valid == false || m_context.ImageValid == false)
			return; // we can't do anything...
		// update the meta data
		m_context.Image.Image.GetMetaData (m_metaData);
		// check we have a new frame.
		if (m_metaData.FrameID >= m_lastProcessedImageFrameId) {
			m_lastProcessedImageFrameId = m_metaData.FrameID;
			WriteImageTexture ();

		}
	}
	
	/// a method to write the image data to the texture.
	protected void WriteImageTexture ()
	{
		// the size of the target data
		int i = XRes * YRes - 1;
		// the array which holds the image
		MapData<RGB24Pixel> imageData = m_metaData.GetRGB24ImageMap ();
		Color colorElement = Color.black; // just an initialization
		
		// loop over the target array (x and y).
		for (int y = 0; y < YRes; ++y) {
			for (int x = 0; x < XRes; ++x, i--) { // the position is from end to start because of difference in coordinate systems
				int ind = x * m_factor + imageData.XRes * y * m_factor; // this is the index of the current point in the original data
				// we transform the RGB24Pixel data (Received from the image) to a Color.
				RGB24Pixel pixel = imageData [ind];
				colorElement.r = ((float)pixel.Red) / 255.0f;
				colorElement.g = ((float)pixel.Green) / 255.0f;
				colorElement.b = ((float)pixel.Blue) / 255.0f;
				m_mapPixels [i] = colorElement;
			}
		}
		m_imageTexture.SetPixels (m_mapPixels);
		m_imageTexture.Apply ();
		gameObject.renderer.material.mainTexture = m_imageTexture;
	}
	public Texture2D texture;
	public  IEnumerator GetPhoto()
	{
		
		yield return new WaitForFixedUpdate();
		
		texture = new Texture2D (m_imageTexture .width ,m_imageTexture .height );
		int y = 0;
		
		while (y < texture.height)
		{
			
			int x = 0;
			
			while (x < texture.width)
			{
				
				Color color = m_imageTexture.GetPixel(x, y);
				
				texture.SetPixel(x, y, color);
				
				++x;
				
			}
			
			++y;
			
		}
		
		texture.Apply();
		//		Texture2D ti = null;
		//		ti = texture;
		//st1.realtexs .Add (texture  );
		//将照片存入指定ID文件夹下

		//string prjpath = Application.persistentDataPath +"/"+"user1";
		if (Onpath ==true ) {
			prjpath = Application.persistentDataPath +"/"+QRlogin ._instance .user .id+"/"+System .DateTime .Now .Year.ToString () + "_" + System .DateTime .Now.Month.ToString () + "_" + System .DateTime .Now .Day.ToString () + "_" + System .DateTime .Now.Hour + "_" + System .DateTime .Now.Minute;
			Onpath =false ;
			downpath =prjpath ;
				}

		if (!System .IO .File.Exists (prjpath)) {
	
					Directory .CreateDirectory (prjpath);
					byte[] pngData = texture.EncodeToPNG ();
					File.WriteAllBytes (prjpath + "/" + num + ".png", pngData);
					num++;
				} else {
					byte[] pngData = texture.EncodeToPNG ();
					File.WriteAllBytes (prjpath + "/" + num + ".png", pngData);
					num++;
				}

		//        byte[] pngData = texture.EncodeToPNG();
		//
		//        //存入集合list2
		//        //list2.Add(texture);
		//        File.WriteAllBytes(Application.dataPath + "/shexiang/" + num + ".png", pngData);
		//        num++;
	}     
}
