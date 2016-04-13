using UnityEngine;
using System.Collections;

public class NewInterface : MonoBehaviour {

    public static NewInterface _instance;

    //public UILabel usernameinpannal;
    UISlider movieProgress;
    public UISprite egneryEfx;
    bool showOne = false, showTwo = false, showThree = false, showFour = false, showFive = false;
    public EnemyEffect enemyEffect;

    void Awake()
    {
        _instance = this;
        movieProgress = transform.Find("BottonBg/MovieProgress").GetComponent<UISlider>();
        egneryEfx = transform.Find("EnergyBox/EgneryEfx").GetComponent<UISprite>();
    }
    
    void Start () 
    {/*
        if (usernameinpannal == null)
            usernameinpannal = GameObject.Find("NewInterface/Top/UserName").GetComponent<UILabel>();
            usernameinpannal.text = QRlogin._instance.user.NickName;*/
	}
	

	void Update () {
        movieProgress.value = TestMobileTexture._instance.movieInf.movieCurProgress / TestMobileTexture._instance.movieInf.movieLength;

        if (Scoring_Tony1.scorenum > 0 && Scoring_Tony1.scorenum <= 20  && egneryEfx.fillAmount<0.2f)
        {
           
            egneryEfx.fillAmount += (1f / 15f) * Time.deltaTime;
            if (0.2f - egneryEfx.fillAmount < 0.01f)
                egneryEfx.fillAmount = 0.2f;
            if (showOne == false)
            {
                //enemyEffect.gameObject.SetActive(true);
                //enemyEffect.playFlash = true;
                showOne = true;
            }
        }
        else if (Scoring_Tony1.scorenum > 20 && Scoring_Tony1.scorenum <= 40  && egneryEfx.fillAmount < 0.4f)
        {

            
            egneryEfx.fillAmount += (1f / 15f) * Time.deltaTime;
            if (0.4f - egneryEfx.fillAmount < 0.01f)
                egneryEfx.fillAmount = 0.4f;
            if (showTwo == false)
            {
                //enemyEffect.gameObject.SetActive(true);
                //enemyEffect.playFlash = true;
                showTwo = true;
            }
        }
        else if (Scoring_Tony1.scorenum > 40 && Scoring_Tony1.scorenum <= 60 && egneryEfx.fillAmount < 0.6f)
        {
           
            egneryEfx.fillAmount += (1f / 15f) * Time.deltaTime;
            if (0.6f - egneryEfx.fillAmount < 0.01f)
                egneryEfx.fillAmount = 0.6f;
            if (showThree == false)
            {
                //enemyEffect.gameObject.SetActive(true);
                //enemyEffect.playFlash = true;
                showThree = true;
            }
        }
        else if (Scoring_Tony1.scorenum > 60 && Scoring_Tony1.scorenum <= 80  && egneryEfx.fillAmount < 0.8f)
        {
            
            egneryEfx.fillAmount += (1f / 15f) * Time.deltaTime;
            if (0.8f - egneryEfx.fillAmount < 0.01f)
                egneryEfx.fillAmount = 0.8f;
            if (showFour == false)
            {
                //enemyEffect.gameObject.SetActive(true);
                //enemyEffect.playFlash = true;
                showFour = true;
            }
        }
        else if (Scoring_Tony1.scorenum > 80 && Scoring_Tony1.scorenum <= 120  && egneryEfx.fillAmount < 1f)
        {
           
            egneryEfx.fillAmount += (1f / 15f) * Time.deltaTime;
            if (1f - egneryEfx.fillAmount < 0.01f)
                egneryEfx.fillAmount = 1f;
            if (showFive == false)
            {
                //enemyEffect.gameObject.SetActive(true);
                //enemyEffect.playFlash = true;
                showFive = true;
            }
        }

	}
}
