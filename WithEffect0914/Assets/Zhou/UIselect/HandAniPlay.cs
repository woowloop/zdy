using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandAniPlay : MonoBehaviour {
	public int mFPS = 30;
	public string mPrefix = "";
	
	public UISprite mSprite;
	public float mDelta = 0f;
	public int mIndex = 0;
	public bool mActive = true;
	public List<string> mSpriteNames = new List<string>();
	public bool isstay = false;
	/// <summary>
	/// Number of frames in the animation.
	/// </summary>
	
	public int frames { get { return mSpriteNames.Count; } }
	
	/// <summary>
	/// Animation framerate.
	/// </summary>
	
	public int framesPerSecond { get { return mFPS; } set { mFPS = value; } }
	
	/// <summary>
	/// Set the name prefix used to filter sprites from the atlas.
	/// </summary>
	
	public string namePrefix { get { return mPrefix; } set { if (mPrefix != value) { mPrefix = value; RebuildSpriteList(); } } }
	
	/// <summary>
	/// Set the animation to be looping or not
	/// </summary>
	
	
	public bool isPlaying { get { return mActive; } }
	
	/// <summary>
	/// Rebuild the sprite list first thing.
	/// </summary>
	
	protected virtual void Start () { RebuildSpriteList(); }
	
	/// <summary>
	/// Advance the sprite animation process.
	/// </summary>



	void Update ()
	{
		if (isstay) 
		{
			if (mActive && mSpriteNames.Count > 1 && Application.isPlaying && mFPS > 0) 
			{
				mDelta += RealTime.deltaTime;
				float rate = 1f / mFPS;
		
				if (rate < mDelta) 
				{
		
					mDelta = (rate > 0f) ? mDelta - rate : 0f;
	
					if (++mIndex >= mSpriteNames.Count) 
					{
							mIndex = 0;
							mActive = false;
					}
					if (mActive) 
					{
						mSprite.spriteName = mSpriteNames [mIndex];
					}
				}
			}
		} 
		else 
		{
			mSprite.spriteName = "hand0";
			mIndex = 0;
		}
	}
	
	/// <summary>
	/// Rebuild the sprite list after changing the sprite name.
	/// </summary>
	
	public void RebuildSpriteList ()
	{
		if (mSprite == null) mSprite = GetComponent<UISprite>();
		mSpriteNames.Clear();
		
		if (mSprite != null && mSprite.atlas != null)
		{
			List<UISpriteData> sprites = mSprite.atlas.spriteList;
			
			for (int i = 0, imax = sprites.Count; i < imax; ++i)
			{
				UISpriteData sprite = sprites[i];
				
				if (string.IsNullOrEmpty(mPrefix) || sprite.name.StartsWith(mPrefix))
				{
					mSpriteNames.Add(sprite.name);
				}
			}
			mSpriteNames.Sort();
		}
	}
	
	/// <summary>
	/// Reset the animation to the beginning.
	/// </summary>
	
	public void Play () { mActive = true; }
	
	/// <summary>
	/// Pause the animation.
	/// </summary>
	
	public void Pause () { mActive = false; }
	
	/// <summary>
	/// Reset the animation to frame 0 and activate it.
	/// </summary>
	
	public void ResetToBeginning ()
	{
		mActive = true;
		mIndex = 0;
		
		if (mSprite != null && mSpriteNames.Count > 0)
		{
			mSprite.spriteName = mSpriteNames[mIndex];
		}
	}
}
