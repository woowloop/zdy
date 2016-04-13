using UnityEngine;
using System.Collections;

public class PlayMoviePanel : MonoBehaviour {

	// Use this for initialization
    //public GameObject MovieProgressbar;
    public UISlider controlColoredSlider;
    bool showOne = false, showTwo = false, showThree = false, showFour = false, showFive = false;
	void Start () {
        if (controlColoredSlider==null)
        {
            controlColoredSlider = transform.Find("DecoratePanel/Botton/ControlColoredSlider").GetComponent<UISlider>();
        }
        if (controlColoredSlider==null)
        {
            Debug.LogError("ControlColoredSlider No Find");
        }
        controlColoredSlider.value = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Scoring_Tony1.scorenum > 0 && Scoring_Tony1.scorenum <= 20 && controlColoredSlider.value < 0.2f)
        {

            controlColoredSlider.value += (1f / 15f) * Time.deltaTime;
            if (0.2f - controlColoredSlider.value < 0.01f)
                controlColoredSlider.value = 0.2f;
            if (showOne == false)
            {
                //enemyEffect.gameObject.SetActive(true);
                //enemyEffect.playFlash = true;
                showOne = true;
            }
        }
        else if (Scoring_Tony1.scorenum > 20 && Scoring_Tony1.scorenum <= 40 && controlColoredSlider.value < 0.4f)
        {


            controlColoredSlider.value += (1f / 15f) * Time.deltaTime;
            if (0.4f - controlColoredSlider.value < 0.01f)
                controlColoredSlider.value = 0.4f;
            if (showTwo == false)
            {
                //enemyEffect.gameObject.SetActive(true);
                //enemyEffect.playFlash = true;
                showTwo = true;
            }
        }
        else if (Scoring_Tony1.scorenum > 40 && Scoring_Tony1.scorenum <= 60 && controlColoredSlider.value < 0.6f)
        {

            controlColoredSlider.value += (1f / 15f) * Time.deltaTime;
            if (0.6f - controlColoredSlider.value < 0.01f)
                controlColoredSlider.value = 0.6f;
            if (showThree == false)
            {
                //enemyEffect.gameObject.SetActive(true);
                //enemyEffect.playFlash = true;
                showThree = true;
            }
        }
        else if (Scoring_Tony1.scorenum > 60 && Scoring_Tony1.scorenum <= 80 && controlColoredSlider.value < 0.8f)
        {

            controlColoredSlider.value += (1f / 15f) * Time.deltaTime;
            if (0.8f - controlColoredSlider.value < 0.01f)
                controlColoredSlider.value = 0.8f;
            if (showFour == false)
            {
                //enemyEffect.gameObject.SetActive(true);
                //enemyEffect.playFlash = true;
                showFour = true;
            }
        }
        else if (Scoring_Tony1.scorenum > 80 && Scoring_Tony1.scorenum <= 120 && controlColoredSlider.value < 1f)
        {

            controlColoredSlider.value += (1f / 15f) * Time.deltaTime;
            if (1f - controlColoredSlider.value < 0.01f)
                controlColoredSlider.value = 1f;
            if (showFive == false)
            {
                //enemyEffect.gameObject.SetActive(true);
                //enemyEffect.playFlash = true;
                showFive = true;
            }
        }
	}
}
