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
using System;
using OpenNI;
using System.Collections.Generic;
using System.IO;
using System.Collections;

/// @brief a base class for debug utilities which show a texture (such as depth and map).
/// 
/// This class is aimed at being extended. It represents a viewer utility which
/// can be extended to show a window with any kind of texture (such as image map, depth map etc.)
/// @ingroup OpenNIViewerUtilities
public class OpenNIShadow_Edward : MonoBehaviour
{
    public Vector3 m_rootPosition; 
    public static Vector3 m_originalRootPosition;

    private bool isFindTopIndex;

    public bool isRenderLeftArm;
    public bool isRenderRightArm;
    public bool isRenderLeftLeg;
    public bool isRenderRightLeg;

    private ArrayList arrayList = new ArrayList();
    private int torsoY;
    private int torsoX;
    private int cursorRightX;
    private GameObject objMove;

   // private MoveModel move;

    private GameObject m_plane;
    /// a link to the object with the NI context
    public OpenNISettingsManager m_context;
    /// the image will appear inside this rectangle.
    public Rect m_placeToDraw;

    public NIPlayerManager m_playerManager;
    /// @brief Which player this skeleton follows
    public int m_playerNumber;

    /// an enum to tell us where to snap the place to draw
    public enum ScreenSnap
    {
        UpperLeftCorner,    //< the base position (x,y) is an offset from the upper left corner
        UpperRightCorner,   //< the base position (x,y) is an offset from the upper right corner
        LowerLeftCorner,    //< the base position (x,y) is an offset from the lower left corner
        LowerRightCorner    //< the base position (x,y) is an offset from the lower right corner
    };

    /// tells us how to handle @ref m_placeToDraw. The nearest corner centeral position (x,y) of @ref m_placeToDraw
    /// is considered to be relative to the corner of the snap so that the relevant corner will be of that
    /// distance from the corner of the screen.
    public ScreenSnap m_snap;



    /// This is the factor in which we will reduce the received image. A factor of 1
    /// means we use all pixels, a factor of 2 means we use only half the pixels in each
    /// direction.
    public int m_factor;

    /// the texture we will use to build the image into.
    protected Texture2D m_mapTexture;

    /// this is where we will put the texture values before inserting them to the texture itself.
    protected Color[] m_mapPixels;

    /// how many pixels in the x axis
    protected int XRes;
    /// how many pixels in the y axis
    protected int YRes;

    /// holds true if we are valid
    protected bool m_valid = false;

    /// holds the colors to show users in. If more users exist then color then they will be cycled through.
    public List<Color> UserColors;
    /// holds the background color (the color used for the background of everything @b NOT a user).
    public Color m_backgroundColor;
    /// used to access the the data 
    protected SceneMetaData m_metaData;

    /// holds the last frame we processed. We should only change the texture if the frame changed...
    protected int m_lastProcessedImageFrameId = -1;

    /// this method should be overridden to set the internal texture and size
    /// (this will be entered into imageMapTexture, XRes and YRes). 
    /// @param refText (output) The texture created
    /// @param[out] xSize (output) the calculated size along the x axis
    /// @param[out] ySize (output) the calculated size along the y axis
    /// @return true on success and false on failure.
    /// @note this is a good place to put tests if externals are valid.
    protected virtual bool InitTexture(out Texture2D refText, out int xSize, out int ySize)
    {
        refText = null;
        xSize = -1;
        ySize = -1;
        NIOpenNICheckVersion.Instance.ValidatePrerequisite();
        // make sure we have an image to work with
        if (m_context.UserSkeletonValid == false)
        {
            m_context.m_Logger.Log("Invalid users node", NIEventLogger.Categories.Initialization, NIEventLogger.Sources.Skeleton, NIEventLogger.VerboseLevel.Errors);
            return false;
        }
        if (m_factor <= 0)
        {
            m_context.m_Logger.Log("Illegal factor", NIEventLogger.Categories.Initialization, NIEventLogger.Sources.Skeleton, NIEventLogger.VerboseLevel.Errors);
            return false;
        }
        // initialize the meta data object...
        m_metaData = m_context.UserGenrator.UserNode.GetUserPixels(0);
        // update the resolution by the factor
        ySize = m_metaData.YRes / m_factor;
        xSize = m_metaData.XRes / m_factor;
        Debug.LogError(xSize + "--" + ySize + "");
        //GUI.depth = 100;
        // create the texture
        refText = new Texture2D(xSize, ySize, TextureFormat.ARGB32, false);
        // create a new meta data object.

        gameObject.renderer.material.mainTexture = refText;

        return true;
    }

    /// A method for initialization. It is called from the mono-behavior start method.
    /// @note if an extending class overwrite start, they should either call base.Start or simply call this 
    /// method!
    protected virtual void InternalStart()
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
        m_mapPixels = new Color[XRes * YRes];
        m_valid = true;
    }

    /// @brief Mono behavior start.
    public void Start()
    {
        //if (move == null)
        //    move = FindObjectOfType(typeof(MoveModel)) as MoveModel;
        if (m_playerManager == null)
            m_playerManager = FindObjectOfType(typeof(NIPlayerManager)) as NIPlayerManager;
        if (m_playerManager == null)
            throw new System.Exception("Must have a player manager to control the skeleton!");

        torsoX = 300;
        torsoY = 300;

        isRenderLeftArm = false;
        isRenderRightArm = false;
        isRenderLeftLeg = false;
        isRenderRightLeg = false;



        InternalStart();
    }

    /// Internal calculates the texture for the current frame and write it to the internal texture
    protected virtual void CalcTexture()
    {
        // we need to make sure everything is valid, otherwise we can't do anything...
        if (m_context.Valid == false || m_context.UserSkeletonValid == false)
            return; // we can't do anything...
        // check we have a new frame.
        if (m_metaData.FrameID >= m_lastProcessedImageFrameId)
        {
            m_lastProcessedImageFrameId = m_metaData.FrameID;
            WriteUserTexture();
        }
    }

    /// Update is called once per frame by mono-behavior
    /// @note if an extending class create a new Update method they should either call base.Update or call
    /// CalcTexture.
    public void Update()
    {       
        if (m_valid)
        {
            CalcTexture();

        }

    }

    /// @brief Scale for the positions
    public float m_scale = 1f;




    /// a method to write the image data to the texture.
    protected void WriteUserTexture()
    {
        // the size of the target data
        int i = XRes * YRes - 1;
        // the array which holds the image
        UInt16MapData imageData = m_metaData.GetLabelMap();

        int topIndex_X = 0, topIndex_Y = 0;


        // loop over the target array (x and y).
        for (int y = YRes; y > 0; --y)
        {
            for (int x = 0; x < XRes; ++x, i--) // the position is from end to start because of difference in coordinate systems
            {
                // we transform the RGB24Pixel data (Received from the image) to a Color.
                int pixel = imageData[x * m_factor, y * m_factor];

                if (pixel == 0)
                {
                    m_mapPixels[i] = m_backgroundColor;
                }
                else
                {
                    if (m_context.UserGenrator.IsTracking(pixel))
                    {

                        if (isRenderLeftArm || isRenderLeftLeg || isRenderRightArm || isRenderRightLeg)//()
                        {
                            if (isRenderLeftArm)
                            {
                                if (x < 120 && y < 40)
                                {
                                    m_mapPixels[i] = Color.red;
                                }
                                else
                                {
                                    m_mapPixels[i] = Color.blue;
                                }
                            }
                            else if (isRenderLeftLeg)
                            {
                                if (x < 155 && y > 140)
                                {
                                    m_mapPixels[i] = Color.red;
                                }
                                else
                                {
                                    m_mapPixels[i] = Color.blue;
                                }
                            }
                            else if (isRenderRightArm)
                            {
                                if (x > 120 && y < 40)
                                {
                                    m_mapPixels[i] = Color.red;
                                }
                                else
                                {
                                    m_mapPixels[i] = Color.blue;
                                }
                            }
                            else if (isRenderRightLeg)
                            {
                                if (x > 165 && y > 140)
                                {
                                    m_mapPixels[i] = Color.red;
                                }
                                else
                                {
                                    m_mapPixels[i] = Color.blue;
                                }
                            }

                        }
                        else
                        {
                            m_mapPixels[i] = Color.blue;
                        }
                    }
                }
            }
        }
        m_mapTexture.SetPixels(m_mapPixels);
        m_mapTexture.Apply();
    }



}
