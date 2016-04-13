using UnityEngine;
using System.Collections;

public class MainInterface : MonoBehaviour {
	public GameObject effect2;
	public static MainInterface _instance;
	private int num=1,zi=0;
	private string stage,stage1;
    public bool showShendu = true;
	public GameObject Effectplanekk;
	public GameObject Effectplanekk2;
	public GameObject Effectplanekk3;
	public GameObject Elur;
	public GameObject effectbg;
    MeshRenderer planeYZRender;
    GameObject RGB;
	public int showViewTag = 2;//初始显示边缘
    void Awake()
    {
		_instance = this;
        planeYZRender=transform.Find("PlaneYZ").GetComponent<MeshRenderer>();
        RGB = transform.Find("RGB").gameObject;
        //初始RGB不显示
        RGB.SetActive(true );
    }

    
    void Start () {
		showViewTag = 2;
	}
	

	void Update () {
		if (Scoring_Tony1 .badE ==true ) {
			effect2.SetActive(true);
			Effectplanekk2 .SetActive (true );
			Effectplanekk3 .SetActive (true );
			LoadBad();
				}
		if (Scoring_Tony1 .goodE ==true ) {
			effect2.SetActive(true);
			Effectplanekk2 .SetActive (true );
			Effectplanekk3 .SetActive (true );
			LoadGood();
		}
		if (Scoring_Tony1 .greatE ==true ) {
			effect2.SetActive(true);
			Effectplanekk2 .SetActive (true );
			Effectplanekk3 .SetActive (true );
			LoadGreat();
		}
		if (Scoring_Tony1 .perfectE ==true ) {
			effect2.SetActive(true);
			Effectplanekk2 .SetActive (true );
			Effectplanekk3 .SetActive (true );
			LoadPerfect();
		}
//        if (showShendu)
//        {
//            //planeYZRender.enabled = true;
//            //RGB.SetActive(false);
//			return ;
//        }
//        else
//        {
//            planeYZRender.enabled = false;
//            RGB.SetActive(true);
//			Scoring_Tony1 .zhuanye  =true  ;
//			Effectplanekk .SetActive (false );
//			Elur .SetActive (true );
//        }

//        if (Input.GetKeyDown(KeyCode.Alpha1))
//        {
//            if (showShendu)
//                showShendu = false;
//            else
//                showShendu = true;
//        }
		if (Input .GetKeyDown (KeyCode .B )) {
			showViewTag = 1;
				}

		if (showViewTag != 2)
		{
			planeYZRender.enabled = true;
			RGB.SetActive (true );
			RGB.transform .localPosition =new Vector3 (1.106538f ,1.220674f,-7.078742f);
			effectbg.renderer.enabled = true;
		}
		else
		{
			RGB.SetActive (true );
			planeYZRender.enabled = false;
			RGB.transform .localPosition =new Vector3 (1.106538f ,1.220674f,-8.478742f);
			effectbg.renderer.enabled = false;
			Elur .SetActive (true );

		}
	}
	//位置指导

	void LoadBad()
	{
		num++;
		zi++;
		stage = num.ToString ();
		stage1 = zi.ToString ();
		Effectplanekk2.renderer .material .mainTexture = (Texture)Resources .Load ("Stage/Bad/"+stage );
		Effectplanekk3.renderer .material .mainTexture = (Texture)Resources .Load ("Stage/Badzi/"+stage1 );
		//Debug .Log (stage  );
		if (zi>1) {
			zi=0;
				}
		if (num>15) {
			num=0;
			Scoring_Tony1 .badE =false ;
			Effectplanekk2 .SetActive (false  );
			Effectplanekk3 .SetActive (false  );
			//PlayerPixels ._instance .backcolor.a = 255;
		}
	}
	void LoadGood()
	{
		num++;
		zi++;
		stage = num.ToString ();
		stage1 = zi.ToString ();
		Effectplanekk2.renderer .material .mainTexture = (Texture)Resources .Load ("Stage/Good/"+stage );
		Effectplanekk3.renderer .material .mainTexture = (Texture)Resources .Load ("Stage/Godzi/"+stage1 );
		//Debug .Log (stage  );
		if (zi>1) {
			zi=0;
		}
		if (num>15) {
			num=0;
			Scoring_Tony1 .goodE   =false ;
			Effectplanekk2 .SetActive (false  );
			Effectplanekk3 .SetActive (false  );
			//PlayerPixels ._instance .backcolor.a = 255;
		}
	}
	void LoadGreat()
	{
		num++;
		zi++;
		stage = num.ToString ();
		stage1 = zi.ToString ();
		Effectplanekk2.renderer .material .mainTexture = (Texture)Resources .Load ("Stage/Great1/"+stage );
		Effectplanekk3.renderer .material .mainTexture = (Texture)Resources .Load ("Stage/Gretzi/"+stage1 );
		//Debug .Log (stage  );
		if (zi>1) {
			zi=0;
		}
		if (num>8) {
			num=0;
			Scoring_Tony1 .greatE   =false ;
			Effectplanekk2 .SetActive (false  );
			Effectplanekk3 .SetActive (false  );
			//PlayerPixels ._instance .backcolor.a = 255;
		}
	}
	void LoadPerfect()
	{
		num++;
		zi++;
		stage = num.ToString ();
		stage1 = zi.ToString ();
		Effectplanekk2.renderer .material .mainTexture = (Texture)Resources .Load ("Stage/Perfect/"+stage );
		Effectplanekk3.renderer .material .mainTexture = (Texture)Resources .Load ("Stage/Perzi/"+stage1 );
		//Debug .Log (stage  );
		if (zi>1) {
			zi=0;
		}
		if (num>14) {
			num=0;
			Scoring_Tony1 .perfectE  =false ;
			Effectplanekk2 .SetActive (false  );
			Effectplanekk3 .SetActive (false  );
			//PlayerPixels ._instance .backcolor.a = 255;
		}
	}

}
