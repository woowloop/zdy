using UnityEngine;
using System.Collections;

public class ControlColoredSlider : MonoBehaviour {

    // Use this for initialization
    UISlider slider;
    public Texture2D[] pics;
    public UITexture picSprite;
    int n = 0;
    float time = 0;
    void Awake()
    {
        slider = GetComponent<UISlider>();
    }
	void Start () {
	
	}
    void FixedUpdate ()
    {
        if (pics.Length==5)
        {
            picSprite.mainTexture = pics[n];
            time += Time.deltaTime;
            if (time >= 0.05f)
            {
                n++;
                time = 0;
            }
            if (n == 5)
            {
                n = 0;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
