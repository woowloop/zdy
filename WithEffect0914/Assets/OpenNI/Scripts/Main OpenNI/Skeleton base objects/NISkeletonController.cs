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
using System.Collections.Generic;
using OpenNI;

///@brief Component to control skeleton movement by the user's motion.
/// 
/// This class controls the skeleton supplied to it. The user needs to drag & drop the
/// relevant joints (head, legs, shoulders etc.) and on update this will query OpenNI to get
/// the skeleton updated positions and rotate everything accordingly.
/// @ingroup SkeletonBaseObjects
public class NISkeletonController : MonoBehaviour
{
		/// @brief The array of joints to control.
		/// 
		/// These transforms are what the user should drag & drop to in order to connect the skeleton 
		/// controller component to the skeleton it needs to control.
		/// @note not all transforms are currently supported in practice and therefore not all
		/// are necessary. Furthermore, if only some of the transforms are dragged, only those transforms will be
		/// moved. This means that in order for everything to work properly, all "rigged" joints need to be included
		/// (by "rigged" we mean those that will move all the important things in the model)
		public Transform[] m_jointTransforms;

		/// @brief If this is true the joint positions will be updated
		public bool m_updateJointPositions = false;
		/// @brief If this is true the entire game object will move
		public bool m_updateRootPosition = false;
		/// @brief If this is true the joint orientation will be updated
		public bool m_updateOrientation = true;
		/// @brief The speed in which the orientation can change
		public float m_rotationDampening = 15.0f;
		/// @brief Scale for the positions
		public float m_scale = 0.001f;
		/// @brief Speed for movement of the centeral position
		public float m_speed = 1.0f;

		/// @brief The user to player mapper (to figure out the user ID for each player).
		public NIPlayerManager m_playerManager;

		/// @brief Which player this skeleton follows
		public int m_playerNumber;

		/// Holds a line debugger which shows the lines connecting the joints. If null, nothing is
		/// drawn.
		public NISkeletonControllerLineDebugger m_linesDebugger;
    
		/// Activates / deactivate the game object (skeleton and all sub objects)
		/// @param state on true sets to active, on false sets to inactive
		public Transform ReferencedManFoot;
		public Transform ReferencedManHead;
		public Transform ReferencedManKnee;
		public Transform ReferencedManShoulder;
		public Transform ReferencedManHand;
		public Transform ReferencedManElbow;
		Scoring_Tony1 st;
		private int isHandDirXti = 0;
		private int isHandDirYti = 0;
		private int isHandDirZti = 0;
		private int isHandDirXYti = 0;
		private int isHandDirXZti = 0;
		private int isHandDirYZti = 0;
		private int isHandDirXYZti = 0;
		private Vector3 Handxpos;
		private Vector3 Handypos;
		private Vector3 Handzpos;
		private Vector3 Handxypos;
		private Vector3 Handxzpos;
		private Vector3 Handyzpos;
		private Vector3 Handxyzpos;
		private int isFootDirXti = 0;
		private int isFootDirYti = 0;
		private int isFootDirZti = 0;
		private int isFootDirXYti = 0;
		private int isFootDirXZti = 0;
		private int isFootDirYZti = 0;
		private int isFootDirXYZti = 0;
		private Vector3 Footxpos;
		private Vector3 Footypos;
		private Vector3 Footzpos;
		private Vector3 Footxypos;
		private Vector3 Footxzpos;
		private Vector3 Footyzpos;
		private Vector3 Footxyzpos;
		private int isElbowDirXti = 0;
		private int isElbowDirYti = 0;
		private int isElbowDirZti = 0;
		private int isElbowDirXYti = 0;
		private int isElbowDirXZti = 0;
		private int isElbowDirYZti = 0;
		private int isElbowDirXYZti = 0;
		private Vector3 Elbowxpos;
		private Vector3 Elbowypos;
		private Vector3 Elbowzpos;
		private Vector3 Elbowxypos;
		private Vector3 Elbowxzpos;
		private Vector3 Elbowyzpos;
		private Vector3 Elbowxyzpos;
		private int isShoulderDirXti = 0;
		private int isShoulderDirYti = 0;
		private int isShoulderDirZti = 0;
		private int isShoulderDirXYti = 0;
		private int isShoulderDirXZti = 0;
		private int isShoulderDirYZti = 0;
		private int isShoulderDirXYZti = 0;
		private Vector3 Shoulderxpos;
		private Vector3 Shoulderypos;
		private Vector3 Shoulderzpos;
		private Vector3 Shoulderxypos;
		private Vector3 Shoulderxzpos;
		private Vector3 Shoulderyzpos;
		private Vector3 Shoulderxyzpos;
		private int isHeadDirXti = 0;
		private int isHeadDirYti = 0;
		private int isHeadDirZti = 0;
		private int isHeadDirXYti = 0;
		private int isHeadDirXZti = 0;
		private int isHeadDirYZti = 0;
		private int isHeadDirXYZti = 0;
		private Vector3 Headxpos;
		private Vector3 Headypos;
		private Vector3 Headzpos;
		private Vector3 Headxypos;
		private Vector3 Headxzpos;
		private Vector3 Headyzpos;
		private Vector3 Headxyzpos;
		private int isKneeDirXti = 0;
		private int isKneeDirYti = 0;
		private int isKneeDirZti = 0;
		private int isKneeDirXYti = 0;
		private int isKneeDirXZti = 0;
		private int isKneeDirYZti = 0;
		private int isKneeDirXYZti = 0;
		private Vector3 Kneexpos;
		private Vector3 Kneeypos;
		private Vector3 Kneezpos;
		private Vector3 Kneexypos;
		private Vector3 Kneexzpos;
		private Vector3 Kneeyzpos;
		private Vector3 Kneexyzpos;

		//判定是否可用
		public static bool valid = false;
		public static bool furtherValid = false;
		internal Vector3 trans;

		public void SetSkeletonActive (bool state)
		{
				gameObject.SetActiveRecursively (state);
		}

		/// mono-behavior Initialization
		public void Start ()
		{
				if (st == null)
						st = FindObjectOfType (typeof(Scoring_Tony1)) as Scoring_Tony1;
				if (m_playerManager == null)
						m_playerManager = FindObjectOfType (typeof(NIPlayerManager)) as NIPlayerManager;
				if (m_playerManager == null)
						throw new System.Exception ("Must have a player manager to control the skeleton!");
				int jointCount = Enum.GetNames (typeof(SkeletonJoint)).Length + 1; // Enum starts at 1
				m_jointsInitialRotations = new Quaternion[jointCount];
				// save all initial rotations
				// NOTE: Assumes skeleton model is in "T" pose since all rotations are relative to that pose
				foreach (SkeletonJoint j in Enum.GetValues(typeof(SkeletonJoint))) {
						if ((int)j >= m_jointTransforms.Length)
								continue; // if we increased the number of joints since the initialization.
						if (m_jointTransforms [(int)j]) {
								// we will store the relative rotation of each joint from the game object rotation
								// we need this since we will be setting the joint's rotation (not localRotation) but we 
								// still want the rotations to be relative to our game object
								// Quaternion.Inverse(transform.rotation) gives us the rotation needed to offset the game object's rotation
								m_jointsInitialRotations [(int)j] = Quaternion.Inverse (transform.rotation) * m_jointTransforms [(int)j].rotation;
								if (m_linesDebugger != null) {
										m_linesDebugger.InitJoint (j);
								}
						}
				}
				m_originalRootPosition = transform.localPosition;
				// start out in calibration pose
				RotateToCalibrationPose ();
		}


		/// mono-behavior update (called once per frame)
		public void Update ()
		{
				furtherValid = false;
				if (m_playerManager == null || m_playerManager.Valid == false)
						return; // we can do nothing.

				NISelectedPlayer player = m_playerManager.GetPlayer (m_playerNumber);
				if (player == null || player.Valid == false || player.Tracking == false) {
						RotateToCalibrationPose (); // we don't have anything to work with.
						valid = false;
						return;
				}
				Vector3 skelPos = Vector3.zero;
				SkeletonJointTransformation skelTrans;
				if (player.GetReferenceSkeletonJointTransform (SkeletonJoint.Torso, out skelTrans)) {
						if (skelTrans.Position.Confidence < 0.5f) {
								player.RecalcReferenceJoints (); // we NEED the torso to be good.
								valid = false;
						}
						if (skelTrans.Position.Confidence >= 0.5f) {
								skelPos = NIConvertCoordinates.ConvertPos (skelTrans.Position.Position);
						}
				}
				UpdateSkeleton (player, skelPos);
		}

		/// @brief updates the root position
		/// 
		/// This method updates the root position and if m_updateRootPosition is true, also move the entire transform
		/// @note we do not update if we do not have a high enough confidence!
		/// @param skelRoot the new central position
		/// @param centerOffset the offset we should use on the center (when moving the root). 
		/// This is usually the starting position (so the skeleton will not "jump" when doing the first update
		protected void UpdateRoot (SkeletonJointPosition skelRoot, Vector3 centerOffset)
		{
				if (skelRoot.Confidence < 0.5f)
						return; // we are not confident enough!
				m_rootPosition = NIConvertCoordinates.ConvertPos (skelRoot.Position);
				m_rootPosition -= centerOffset;
				m_rootPosition *= m_scale * m_speed;
				m_rootPosition = transform.rotation * m_rootPosition;
				m_rootPosition += m_originalRootPosition; 
				Vector3 referHandpos = m_rootPosition;
				Vector3 referFootpos = m_rootPosition;
				Vector3 referElbowpos = m_rootPosition;
				Vector3 referHeadpos = m_rootPosition;
				Vector3 referKneepos = m_rootPosition;
				Vector3 referShoulderpos = m_rootPosition;
				/*referhandpos = ReturnNewPos (m_rootPosition, Handxpos, Handypos, Handzpos, Handxypos, Handyzpos, Handxzpos, Handxyzpos, st.isHandDirX, st.isHandDirY, st.isHandDirZ, st.isHandDirXY, st.isHandDirYZ, st.isHandDirXZ, st.isHandDirXYZ, isHandDirXti, isHandDirYti, isHandDirZti, isHandDirXYti, isHandDirYZti, isHandDirXZti, isHandDirXYZti);
		referfootpos = ReturnNewPos (m_rootPosition, Footxpos, Footypos, Footzpos, Footxypos, Footyzpos, Footxzpos, Footxyzpos, st.isFootDirX, st.isFootDirY, st.isFootDirZ, st.isFootDirXY, st.isFootDirYZ, st.isFootDirXZ, st.isFootDirXYZ, isFootDirXti, isFootDirYti, isFootDirZti, isFootDirXYti, isFootDirYZti, isFootDirXZti, isFootDirXYZti);
		referelbowpos = ReturnNewPos (m_rootPosition, Elbowxpos, Elbowypos, Elbowzpos, Elbowxypos, Elbowyzpos, Elbowxzpos, Elbowxyzpos, st.isElbowDirX, st.isElbowDirY, st.isElbowDirZ, st.isElbowDirXY, st.isElbowDirYZ, st.isElbowDirXZ, st.isElbowDirXYZ, isElbowDirXti, isElbowDirYti, isElbowDirZti, isElbowDirXYti, isElbowDirYZti, isElbowDirXZti, isElbowDirXYZti);
		referkneepos = ReturnNewPos (m_rootPosition, Kneexpos, Kneeypos, Kneezpos, Kneexypos, Kneeyzpos, Kneexzpos, Kneexyzpos, st.isKneeDirX, st.isKneeDirY, st.isKneeDirZ, st.isKneeDirXY, st.isKneeDirYZ, st.isKneeDirXZ, st.isKneeDirXYZ, isKneeDirXti, isKneeDirYti, isKneeDirZti, isKneeDirXYti, isKneeDirYZti, isKneeDirXZti, isKneeDirXYZti);
		referheadpos = ReturnNewPos (m_rootPosition, Headxpos, Headypos, Headzpos, Headxypos, Headyzpos, Headxzpos, Headxyzpos, st.isHeadDirX, st.isHeadDirY, st.isHeadDirZ, st.isHeadDirXY, st.isHeadDirYZ, st.isHeadDirXZ, st.isHeadDirXYZ, isHeadDirXti, isHeadDirYti, isHeadDirZti, isHeadDirXYti, isHeadDirYZti, isHeadDirXZti, isHeadDirXYZti);
		refershoulderpos = ReturnNewPos (m_rootPosition, Shoulderxpos, Shoulderypos, Shoulderzpos, Shoulderxypos, Shoulderyzpos, Shoulderxzpos, Shoulderxyzpos, st.isShoulderDirX, st.isShoulderDirY, st.isShoulderDirZ, st.isShoulderDirXY, st.isShoulderDirYZ, st.isShoulderDirXZ, st.isShoulderDirXYZ, isShoulderDirXti, isShoulderDirYti, isShoulderDirZti, isShoulderDirXYti, isShoulderDirYZti, isShoulderDirXZti, isShoulderDirXYZti);
         */
				if (st.isHandDirX) {
						isHandDirXti++;
						if (isHandDirXti == 1) {
								Handxpos = referHandpos;
						}
						referHandpos.x = Handxpos.x;		
				} else {
						isHandDirXti = 0;	
				}
				if (st.isHandDirY) {
						isHandDirYti++;
						if (isHandDirYti == 1) {
								Handypos = referHandpos;
						}
						referHandpos.y = Handypos.y;		
				} else {
						isHandDirYti = 0;	
				}
				if (st.isHandDirZ) {
						isHandDirZti++;
						if (isHandDirZti == 1) {
								Handzpos = referHandpos;
						}
						referHandpos.z = Handzpos.z;		
				} else {
						isHandDirZti = 0;	
				}
		
				if (st.isHandDirXY) {
						isHandDirXYti++;
						if (isHandDirXYti == 1) {
								Handxypos = referHandpos;
						}
						referHandpos.x = Handxypos.x;
						referHandpos.y = Handxypos.y;
				} else {
						isHandDirXYti = 0;
				}
		
				if (st.isHandDirXZ) {
						isHandDirXZti++;
						if (isHandDirXZti == 1) {
								Handxzpos = referHandpos;
						}
						referHandpos.x = Handxzpos.x;
						referHandpos.z = Handxzpos.z;
				} else {
						isHandDirXZti = 0;
				}
		
				if (st.isHandDirYZ) {
						isHandDirYZti++;
						if (isHandDirYZti == 1) {
								Handyzpos = referHandpos;
						}
						referHandpos.y = Handyzpos.y;
						referHandpos.z = Handyzpos.z;
				} else {
						isHandDirYZti = 0;
				}
		
		
				if (st.isHandDirXYZ) {
						isHandDirXYZti++;
						if (isHandDirXYZti == 1) {
								Handxyzpos = referHandpos;
						}
						referHandpos.y = Handxyzpos.y;
						referHandpos.z = Handxyzpos.z;
						referHandpos.x = Handxyzpos.x;
				} else {
						isHandDirXYZti = 0;
				}


				if (st.isElbowDirX) {
						isElbowDirXti++;
						if (isElbowDirXti == 1) {
								Elbowxpos = referElbowpos;
						}
						referElbowpos.x = Elbowxpos.x;		
				} else {
						isElbowDirXti = 0;	
				}
				if (st.isElbowDirY) {
						isElbowDirYti++;
						if (isElbowDirYti == 1) {
								Elbowypos = referElbowpos;
						}
						referElbowpos.y = Elbowypos.y;		
				} else {
						isElbowDirYti = 0;	
				}
				if (st.isElbowDirZ) {
						isElbowDirZti++;
						if (isElbowDirZti == 1) {
								Elbowzpos = referElbowpos;
						}
						referElbowpos.z = Elbowzpos.z;		
				} else {
						isElbowDirZti = 0;	
				}
		
				if (st.isElbowDirXY) {
						isElbowDirXYti++;
						if (isElbowDirXYti == 1) {
								Elbowxypos = referElbowpos;
						}
						referElbowpos.x = Elbowxypos.x;
						referElbowpos.y = Elbowxypos.y;
				} else {
						isElbowDirXYti = 0;
				}
		
				if (st.isElbowDirXZ) {
						isElbowDirXZti++;
						if (isElbowDirXZti == 1) {
								Elbowxzpos = referElbowpos;
						}
						referElbowpos.x = Elbowxzpos.x;
						referElbowpos.z = Elbowxzpos.z;
				} else {
						isElbowDirXZti = 0;
				}
		
				if (st.isElbowDirYZ) {
						isElbowDirYZti++;
						if (isElbowDirYZti == 1) {
								Elbowyzpos = referElbowpos;
						}
						referElbowpos.y = Elbowyzpos.y;
						referElbowpos.z = Elbowyzpos.z;
				} else {
						isElbowDirYZti = 0;
				}
		
		
				if (st.isElbowDirXYZ) {
						isElbowDirXYZti++;
						if (isElbowDirXYZti == 1) {
								Elbowxyzpos = referElbowpos;
						}
						referElbowpos.y = Elbowxyzpos.y;
						referElbowpos.z = Elbowxyzpos.z;
						referElbowpos.x = Elbowxyzpos.x;
				} else {
						isElbowDirXYZti = 0;
				}

				if (st.isHeadDirX) {
						isHeadDirXti++;
						if (isHeadDirXti == 1) {
								Headxpos = referHeadpos;
						}
						referHeadpos.x = Headxpos.x;		
				} else {
						isHeadDirXti = 0;	
				}
				if (st.isHeadDirY) {
						isHeadDirYti++;
						if (isHeadDirYti == 1) {
								Headypos = referHeadpos;
						}
						referHeadpos.y = Headypos.y;		
				} else {
						isHeadDirYti = 0;	
				}
				if (st.isHeadDirZ) {
						isHeadDirZti++;
						if (isHeadDirZti == 1) {
								Headzpos = referHeadpos;
						}
						referHeadpos.z = Headzpos.z;		
				} else {
						isHeadDirZti = 0;	
				}
		
				if (st.isHeadDirXY) {
						isHeadDirXYti++;
						if (isHeadDirXYti == 1) {
								Headxypos = referHeadpos;
						}
						referHeadpos.x = Headxypos.x;
						referHeadpos.y = Headxypos.y;
				} else {
						isHeadDirXYti = 0;
				}
		
				if (st.isHeadDirXZ) {
						isHeadDirXZti++;
						if (isHeadDirXZti == 1) {
								Headxzpos = referHeadpos;
						}
						referHeadpos.x = Headxzpos.x;
						referHeadpos.z = Headxzpos.z;
				} else {
						isHeadDirXZti = 0;
				}
		
				if (st.isHeadDirYZ) {
						isHeadDirYZti++;
						if (isHeadDirYZti == 1) {
								Headyzpos = referHeadpos;
						}
						referHeadpos.y = Headyzpos.y;
						referHeadpos.z = Headyzpos.z;
				} else {
						isHeadDirYZti = 0;
				}
		
		
				if (st.isHeadDirXYZ) {
						isHeadDirXYZti++;
						if (isHeadDirXYZti == 1) {
								Headxyzpos = referHeadpos;
						}
						referHeadpos.y = Headxyzpos.y;
						referHeadpos.z = Headxyzpos.z;
						referHeadpos.x = Headxyzpos.x;
				} else {
						isHeadDirXYZti = 0;
				}

				if (st.isShoulderDirX) {
						isShoulderDirXti++;
						if (isShoulderDirXti == 1) {
								Shoulderxpos = referShoulderpos;
						}
						referShoulderpos.x = Shoulderxpos.x;		
				} else {
						isShoulderDirXti = 0;	
				}
				if (st.isShoulderDirY) {
						isShoulderDirYti++;
						if (isShoulderDirYti == 1) {
								Shoulderypos = referShoulderpos;
						}
						referShoulderpos.y = Shoulderypos.y;		
				} else {
						isShoulderDirYti = 0;	
				}
				if (st.isShoulderDirZ) {
						isShoulderDirZti++;
						if (isShoulderDirZti == 1) {
								Shoulderzpos = referShoulderpos;
						}
						referShoulderpos.z = Shoulderzpos.z;		
				} else {
						isShoulderDirZti = 0;	
				}
		
				if (st.isShoulderDirXY) {
						isShoulderDirXYti++;
						if (isShoulderDirXYti == 1) {
								Shoulderxypos = referShoulderpos;
						}
						referShoulderpos.x = Shoulderxypos.x;
						referShoulderpos.y = Shoulderxypos.y;
				} else {
						isShoulderDirXYti = 0;
				}
		
				if (st.isShoulderDirXZ) {
						isShoulderDirXZti++;
						if (isShoulderDirXZti == 1) {
								Shoulderxzpos = referShoulderpos;
						}
						referShoulderpos.x = Shoulderxzpos.x;
						referShoulderpos.z = Shoulderxzpos.z;
				} else {
						isShoulderDirXZti = 0;
				}
		
				if (st.isShoulderDirYZ) {
						isShoulderDirYZti++;
						if (isShoulderDirYZti == 1) {
								Shoulderyzpos = referShoulderpos;
						}
						referShoulderpos.y = Shoulderyzpos.y;
						referShoulderpos.z = Shoulderyzpos.z;
				} else {
						isShoulderDirYZti = 0;
				}
		
		
				if (st.isShoulderDirXYZ) {
						isShoulderDirXYZti++;
						if (isShoulderDirXYZti == 1) {
								Shoulderxyzpos = referShoulderpos;
						}
						referShoulderpos.y = Shoulderxyzpos.y;
						referShoulderpos.z = Shoulderxyzpos.z;
						referShoulderpos.x = Shoulderxyzpos.x;
				} else {
						isShoulderDirXYZti = 0;
				}

				if (st.isKneeDirX) {
						isKneeDirXti++;
						if (isKneeDirXti == 1) {
								Kneexpos = referKneepos;
						}
						referKneepos.x = Kneexpos.x;		
				} else {
						isKneeDirXti = 0;	
				}
				if (st.isKneeDirY) {
						isKneeDirYti++;
						if (isKneeDirYti == 1) {
								Kneeypos = referKneepos;
						}
						referKneepos.y = Kneeypos.y;		
				} else {
						isKneeDirYti = 0;	
				}
				if (st.isKneeDirZ) {
						isKneeDirZti++;
						if (isKneeDirZti == 1) {
								Kneezpos = referKneepos;
						}
						referKneepos.z = Kneezpos.z;		
				} else {
						isKneeDirZti = 0;	
				}
		
				if (st.isKneeDirXY) {
						isKneeDirXYti++;
						if (isKneeDirXYti == 1) {
								Kneexypos = referKneepos;
						}
						referKneepos.x = Kneexypos.x;
						referKneepos.y = Kneexypos.y;
				} else {
						isKneeDirXYti = 0;
				}
		
				if (st.isKneeDirXZ) {
						isKneeDirXZti++;
						if (isKneeDirXZti == 1) {
								Kneexzpos = referKneepos;
						}
						referKneepos.x = Kneexzpos.x;
						referKneepos.z = Kneexzpos.z;
				} else {
						isKneeDirXZti = 0;
				}
		
				if (st.isKneeDirYZ) {
						isKneeDirYZti++;
						if (isKneeDirYZti == 1) {
								Kneeyzpos = referKneepos;
						}
						referKneepos.y = Kneeyzpos.y;
						referKneepos.z = Kneeyzpos.z;
				} else {
						isKneeDirYZti = 0;
				}
		
		
				if (st.isKneeDirXYZ) {
						isKneeDirXYZti++;
						if (isKneeDirXYZti == 1) {
								Kneexyzpos = referKneepos;
						}
						referKneepos.y = Kneexyzpos.y;
						referKneepos.z = Kneexyzpos.z;
						referKneepos.x = Kneexyzpos.x;
				} else {
						isKneeDirXYZti = 0;
				}

				if (st.isFootDirX) {
						isFootDirXti++;
						if (isFootDirXti == 1) {
								Footxpos = referFootpos;
						}
						referFootpos.x = Footxpos.x;		
				} else {
						isFootDirXti = 0;	
				}
				if (st.isFootDirY) {
						isFootDirYti++;
						if (isFootDirYti == 1) {
								Footypos = referFootpos;
						}
						referFootpos.y = Footypos.y;		
				} else {
						isFootDirYti = 0;	
				}
				if (st.isFootDirZ) {
						isFootDirZti++;
						if (isFootDirZti == 1) {
								Footzpos = referFootpos;
						}
						referFootpos.z = Footzpos.z;		
				} else {
						isFootDirZti = 0;	
				}
		
				if (st.isFootDirXY) {
						isFootDirXYti++;
						if (isFootDirXYti == 1) {
								Footxypos = referFootpos;
						}
						referFootpos.x = Footxypos.x;
						referFootpos.y = Footxypos.y;
				} else {
						isFootDirXYti = 0;
				}
		
				if (st.isFootDirXZ) {
						isFootDirXZti++;
						if (isFootDirXZti == 1) {
								Footxzpos = referFootpos;
						}
						referFootpos.x = Footxzpos.x;
						referFootpos.z = Footxzpos.z;
				} else {
						isFootDirXZti = 0;
				}
		
				if (st.isFootDirYZ) {
						isFootDirYZti++;
						if (isFootDirYZti == 1) {
								Footyzpos = referFootpos;
						}
						referFootpos.y = Footyzpos.y;
						referFootpos.z = Footyzpos.z;
				} else {
						isFootDirYZti = 0;
				}
		
		
				if (st.isFootDirXYZ) {
						isFootDirXYZti++;
						if (isFootDirXYZti == 1) {
								Footxyzpos = referFootpos;
						}
						referFootpos.y = Footxyzpos.y;
						referFootpos.z = Footxyzpos.z;
						referFootpos.x = Footxyzpos.x;
				} else {
						isFootDirXYZti = 0;
				}
				if (m_updateRootPosition) {
						transform.position = m_rootPosition;
						ReferencedManFoot.position = referFootpos;
						ReferencedManElbow.position = referElbowpos;
						ReferencedManHand.position = referHandpos;
						ReferencedManKnee.position = referKneepos;
						ReferencedManHead.position = referHeadpos;
						ReferencedManShoulder.position = referShoulderpos;
				}
		}	
		/// @brief updates a single joint
		/// 
		/// This method updates a single joint. The decision of what to update (orientation, position)
		/// depends on m_updateOrientation and m_updateJointPositions. Only joints with high confidence
		/// are updated. @note it is possible to update only position or only orientation even though both
		/// are expected if the confidence of one is low.
		/// @param centerOffset the new central position
		/// @param joint the joint we want to update
		/// @param skelTrans the new transformation of the joint
		protected void UpdateJoint (SkeletonJoint joint, SkeletonJointTransformation skelTrans, SkeletonJointPosition centerOffset)
		{
				// make sure something is hooked up to this joint
				if ((int)joint >= m_jointTransforms.Length || !m_jointTransforms [(int)joint]) {
						return;
				}
				// if we have debug lines to draw we need to collect the data.
				if (m_linesDebugger != null) {
						Vector3 pos = CalcJointPosition (joint, ref skelTrans, ref centerOffset) + transform.position;
						float posConf = skelTrans.Position.Confidence;
						Quaternion rot = CalcRotationForJoint (joint, ref skelTrans, ref centerOffset);
						float rotConf = skelTrans.Orientation.Confidence;
						m_linesDebugger.UpdateJointInfoForJoint (joint, pos, posConf, rot, rotConf);

				}
        
				// modify orientation (if needed and confidence is high enough)
				if (m_updateOrientation && skelTrans.Orientation.Confidence >= 0.5) {
						m_jointTransforms [(int)joint].rotation = CalcRotationForJoint (joint, ref skelTrans, ref centerOffset);
				}

				// modify position (if needed, and confidence is high enough)
				if (m_updateJointPositions && skelTrans.Position.Confidence >= 0.5f) {
						m_jointTransforms [(int)joint].localPosition = CalcJointPosition (joint, ref skelTrans, ref centerOffset);
				}
		}

		/// This rotates the skeleton to the requested calibration position.
		/// @note it assumes the initial position is a "T" position and orients accordingly (returning
		/// everything to its base and then rotating the arms).
		public void RotateToCalibrationPose ()
		{
				foreach (SkeletonJoint j in Enum.GetValues(typeof(SkeletonJoint))) {
						if ((int)j < m_jointTransforms.Length && m_jointTransforms [(int)j] != null) {
								m_jointTransforms [(int)j].rotation = transform.rotation * m_jointsInitialRotations [(int)j];
						}
				}
				// calibration pose is skeleton base pose ("T") with both elbows bent in 90 degrees
				Transform elbow = m_jointTransforms [(int)SkeletonJoint.RightElbow];
				if (elbow != null)
						elbow.rotation = transform.rotation * Quaternion.Euler (0, 135, 0) * m_jointsInitialRotations [(int)SkeletonJoint.RightElbow];
				elbow = m_jointTransforms [(int)SkeletonJoint.LeftElbow];
				if (elbow != null)
						elbow.rotation = transform.rotation * Quaternion.Euler (0, -135, 0) * m_jointsInitialRotations [(int)SkeletonJoint.LeftElbow];
				if (m_updateJointPositions) {
						// we want to position the skeleton in a calibration pose. We will therefore position select
						// joints
						UpdateJointPosition (SkeletonJoint.Torso, 0, 0, 0);
						UpdateJointPosition (SkeletonJoint.Head, 0, 450, 0);
						UpdateJointPosition (SkeletonJoint.LeftShoulder, -150, 250, 0);
						UpdateJointPosition (SkeletonJoint.RightShoulder, 150, 250, 0);
						UpdateJointPosition (SkeletonJoint.LeftElbow, -450, 250, 0);
						UpdateJointPosition (SkeletonJoint.RightElbow, 450, 250, 0);
						UpdateJointPosition (SkeletonJoint.LeftHand, -450, 450, 0);
						UpdateJointPosition (SkeletonJoint.RightHand, 450, 450, 0);
						UpdateJointPosition (SkeletonJoint.LeftHip, -100, -250, 0);
						UpdateJointPosition (SkeletonJoint.RightHip, 100, -250, 0);
						UpdateJointPosition (SkeletonJoint.LeftKnee, -100, -700, 0); 
						UpdateJointPosition (SkeletonJoint.RightKnee, 100, -700, 0); 
						UpdateJointPosition (SkeletonJoint.LeftFoot, -100, -1150, 0);
						UpdateJointPosition (SkeletonJoint.RightFoot, 100, -1150, 0);

				}
		}

		/// @brief updates the skeleton
		/// 
		/// This method is responsible for updating the skeleton based on new information.
		/// It is called by an external manager with the correct user which controls this specific skeleton.
		/// @param player The player object for the player controlling us.
		/// @param centerOffset the offset we should use on the center (when moving the root). 
		/// This is usually the starting position (so the skeleton will not "jump" when doing the first update
		public void UpdateSkeleton (NISelectedPlayer player, Vector3 centerOffset)
		{
				if (player.Valid == false) {
						valid = false;
						return; // irrelevant player
				}
				if (player.Tracking == false) {
						valid = false;
						return; // not tracking
				}
				// we use the  torso as root
				SkeletonJointTransformation skelTrans;
				if (player.GetSkeletonJoint (SkeletonJoint.Torso, out skelTrans) == false) {
						valid = false;
			// we don't have joint information so we simply return...
						return;
				} else {
						trans = NIConvertCoordinates.ConvertPos (skelTrans.Position.Position);
			
						valid = (trans.z > -1300 || Mathf.Abs (trans.x) > 500f) ? false : true;
						furtherValid = true;
				}

				UpdateRoot (skelTrans.Position, centerOffset);

				// update each joint with data from OpenNI
				foreach (SkeletonJoint joint in Enum.GetValues(typeof(SkeletonJoint))) {
						SkeletonJointTransformation skelTransJoint;
						if (player.GetSkeletonJoint (joint, out skelTransJoint) == false)
								continue; // irrelevant joint
						UpdateJoint (joint, skelTransJoint, skelTrans.Position);
				}
		}

		/// @brief a utility method to update joint position 
		/// 
		/// This utility method receives a joint and unscaled position (x,y,z) and moves the joint there.
		/// it makes sure the joint has been attached and that scale is applied.
		/// @param joint The joint to update (the method makes sure it is legal)
		/// @param xPos The unscaled position along the x axis (scale will be applied)
		/// @param yPos The unscaled position along the y axis (scale will be applied)
		/// @param zPos The unscaled position along the z axis (scale will be applied)
		protected void UpdateJointPosition (SkeletonJoint joint, float xPos, float yPos, float zPos)
		{
				if (((int)joint) >= m_jointTransforms.Length || m_jointTransforms [(int)joint] == null)
						return; // an illegal joint
				Vector3 tmpPos = Vector3.zero;
				tmpPos.x = xPos;
				tmpPos.y = yPos;
				tmpPos.z = zPos;
				tmpPos *= m_scale;
				m_jointTransforms [(int)joint].localPosition = tmpPos;
		}

		/// @brief Utility method to calculate the rotation of a joint
		/// 
		/// This method receives joint information and calculates the rotation of the joint in Unity
		/// coordinate system.
		/// @param centerOffset the new central position
		/// @param joint the joint we want to calculate the rotation for
		/// @param skelTrans the new transformation of the joint
		/// @return the rotation of the joint in Unity coordinate system
		protected Quaternion CalcRotationForJoint (SkeletonJoint joint, ref SkeletonJointTransformation skelTrans, ref SkeletonJointPosition centerOffset)
		{
				// In order to convert the skeleton's orientation to Unity orientation we will
				// use the Quaternion.LookRotation method to create the relevant rotation Quaternion. 
				// for Quaternion.LookRotation to work it needs a "forward" vector and an "upward" vector.
				// These are generally the "Z" and "Y" axes respectively in the sensor's coordinate
				// system. The orientation received from the skeleton holds these values in their 
				// appropriate members.

				// Get the forward axis from "z".
				Point3D sensorForward = Point3D.ZeroPoint;
				sensorForward.X = skelTrans.Orientation.Z1;
				sensorForward.Y = skelTrans.Orientation.Z2;
				sensorForward.Z = skelTrans.Orientation.Z3;
				// convert it to Unity
				Vector3 worldForward = NIConvertCoordinates.ConvertPos (sensorForward);
				worldForward *= -1.0f; // because the Unity "forward" axis is opposite to the world's "z" axis.
				if (worldForward.magnitude == 0)
						return Quaternion.identity; // we don't have a good point to work with.
				// Get the upward axis from "Y".
				Point3D sensorUpward = Point3D.ZeroPoint;
				sensorUpward.X = skelTrans.Orientation.Y1;
				sensorUpward.Y = skelTrans.Orientation.Y2;
				sensorUpward.Z = skelTrans.Orientation.Y3;
				// convert it to Unity
				Vector3 worldUpwards = NIConvertCoordinates.ConvertPos (sensorUpward);
				if (worldUpwards.magnitude == 0)
						return Quaternion.identity; // we don't have a good point to work with.
				Quaternion jointRotation = Quaternion.LookRotation (worldForward, worldUpwards);

				Quaternion newRotation = transform.rotation * jointRotation * m_jointsInitialRotations [(int)joint];

				// we try to limit the speed of the change.
				return Quaternion.Slerp (m_jointTransforms [(int)joint].rotation, newRotation, Time.deltaTime * m_rotationDampening);
		}

		/// @brief Utility method to calculate the @b LOCAL position of a joint
		/// 
		/// This method receives joint information and calculates the @b LOCAL position rotation of the joint
		/// (compare to its parent transform) in Unity coordinate system.
		/// @param centerOffset the new central position
		/// @param joint the joint we want to calculate the position for
		/// @param skelTrans the new transformation of the joint
		/// @return the @b LOCAL position rotation of the joint (compare to its parent transform) in 
		/// Unity coordinate system
		protected Vector3 CalcJointPosition (SkeletonJoint joint, ref SkeletonJointTransformation skelTrans, ref SkeletonJointPosition centerOffset)
		{
				Vector3 v3pos = NIConvertCoordinates.ConvertPos (skelTrans.Position.Position);
				Vector3 v3Center = NIConvertCoordinates.ConvertPos (centerOffset.Position);
				v3pos -= v3Center;
				return v3pos * m_scale;
		}

		///  the initial rotations of the joints we move everything compared to this.
		protected Quaternion[] m_jointsInitialRotations;

		/// the current root position of the game object (movement is based on this).
		protected Vector3 m_rootPosition;

		/// the original (placed) root position of the game object.
		protected Vector3 m_originalRootPosition;

		Vector3 ReturnNewPos (Vector3 referpos, Vector3 xpos, Vector3 ypos, Vector3 zpos, Vector3 xypos, Vector3 yzpos, Vector3 xzpos, Vector3 xyzpos, bool isDirX, bool isDirY, bool isDirZ, bool isDirXY, bool isDirYZ, bool isDirXZ, bool isDirXYZ, int isDirXti, int isDirYti, int isDirZti, int isDirXYti, int isDirYZti, int isDirXZti, int isDirXYZti)
		{
				if (isDirX) {
						isDirXti++;
						if (isDirXti == 1) {
								xpos = referpos;
						}
						return new Vector3 (xpos.x, referpos.y, referpos.z);
				} else {
						isDirXti = 0;	
				}
				if (isDirY) {
						isDirYti++;
						if (isDirYti == 1) {
								ypos = referpos;
						}
						return new Vector3 (referpos.x, ypos.y, referpos.z);
				} else {
						isDirYti = 0;	
				}
				if (isDirZ) {
						isDirZti++;
						if (isDirZti == 1) {
								zpos = referpos;
						}
						return new Vector3 (referpos.x, referpos.y, zpos.z);
				} else {
						isDirZti = 0;	
				}
		
				if (isDirXY) {
						isDirXYti++;
						if (isDirXYti == 1) {
								xypos = referpos;
						}
						return new Vector3 (xypos.x, xypos.y, referpos.z);
				} else {
						isDirXYti = 0;
				}
		
				if (isDirXZ) {
						isDirXZti++;
						if (isDirXZti == 1) {
								xzpos = referpos;
						}
						return new Vector3 (xzpos.x, referpos.y, xzpos.z);
				} else {
						isDirXZti = 0;
				}
		
				if (isDirYZ) {
						isDirYZti++;
						if (isDirYZti == 1) {
								yzpos = referpos;
						}
						return new Vector3 (referpos.x, yzpos.y, yzpos.z);
				} else {
						isDirYZti = 0;
				}
		
		
				if (isDirXYZ) {
						isDirXYZti++;
						if (isDirXYZti == 1) {
								xyzpos = referpos;
						}
						return new Vector3 (xyzpos.x, xyzpos.y, xyzpos.z);
				} else {
						isDirXYZti = 0;
				}
				return referpos;
		}
}
