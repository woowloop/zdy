using UnityEngine;
using System.Collections;

public class ColoredSlider : MonoBehaviour {

    UISlider slider;
    public UISprite sprite;
    public GameObject pic, Thumb;
    int n=0;
    float time = 0;
    UITexture picSprite;
    public Texture2D[] pics;


    void Awake()
    {
        slider=GetComponent<UISlider>();
        picSprite=pic.GetComponent<UITexture>();
    }
    
    void Start () {
	
	}
	

	void FixedUpdate () {

        
        slider.value = sprite.fillAmount;
        pic.transform.position = new Vector3(Thumb.transform.position.x , Thumb.transform.position.y, Thumb.transform.position.z);

        picSprite.mainTexture = pics[n];
        time += Time.deltaTime;
        if (time >= 0.05f)
        {
            n++;
            time = 0;
            
        }
        if (n ==5)
        {


            n = 0;

        }

	}
}
