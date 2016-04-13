using UnityEngine;
using System.Collections;

public class UIMoviePart : MonoBehaviour {

	// Use this for initialization
    MMT.MobileMovieTexture m_movieTexture=null;
    public static UIMoviePart _instance=null;
    public bool AbsolutePath
    {
        get
        {
            return  m_movieTexture.AbsolutePath;
        }
        set
        {
            m_movieTexture.AbsolutePath = value;
        }
    }
	void Start ()
    {
        _instance = this;
        m_movieTexture = GetComponent<MMT.MobileMovieTexture>();
        //m_movieTexture.LoopCount = 0;
        //m_movieTexture.Path ="MovieSamples/zdy2min.ogv";
       // Debug.Log(Application.persistentDataPath);
        //Debug.Log("paht::"+m_movieTexture.Path);
        //m_movieTexture.Play();
	}
    void OnEnable()
    {
        //Debug.LogError("OnEnable");
        _instance = this;
    }
    public void PlayMovieForUI(string strPath)
    {
        if (!m_movieTexture)
        {
            m_movieTexture = GetComponent<MMT.MobileMovieTexture>();
        }
        if (m_movieTexture.IsPlaying)
        {
            m_movieTexture.Pause = false;
            //Debug.Log("isPlaying");
            //m_movieTexture.Stop();

        }
        m_movieTexture.LoopCount = -1;
        m_movieTexture.Path = strPath;
        //m_movieTexture.playPosition = 0;
        m_movieTexture.Play();
        StartCoroutine(DelayUpdateTexture());
        //GetComponent<UITexture>().depth = 5;
    }
    IEnumerator DelayUpdateTexture()
    {
        yield return new WaitForSeconds(0.5f);
        UITexture uiTex = GetComponent<UITexture>();
        if (uiTex)
        {
            Texture t = uiTex.mainTexture;
            uiTex.mainTexture = null;
            uiTex.mainTexture = t;
        }
    }
    public void PauseMovieForUI()
    {
        if (m_movieTexture)
        {
            m_movieTexture.Pause = true;
        }
    }
    public void KillMovieForUI()
    {
        if (m_movieTexture)
        {
            m_movieTexture.Stop();
            m_movieTexture = null;
        }
    }
    public void StopMovieForUI()
    {
        if (m_movieTexture && m_movieTexture.IsPlaying)
        {
            //m_movieTexture.
            //m_movieTexture.Play();
            m_movieTexture.Stop();
            //m_movieTexture.enabled = false;
            //m_movieTexture.RemoveTextures(m_movieTexture.renderer.material);
        }
    }
    // Update is called once per frame
	void Update () 
    {
	}
}
