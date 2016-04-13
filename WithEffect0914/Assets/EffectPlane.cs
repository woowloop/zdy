using UnityEngine;
using System.Collections;

public class EffectPlane : MonoBehaviour {
	public static EffectPlane _instance;
    //public MovieTexture[] movTextures;
	public GameObject lizilianji;
	private int numsocre;
    int i = 0,j=0,m=0,num=0,p=0,uu=0;
	int rannum=0,rannum1=0,rannum2=0;
	string stage="0";
	
	public GameObject[] efxs;
	public GameObject[] bomb;
	public GameObject[] Goodeffect;
	public GameObject[] Goodeffect1;
	public GameObject[] Goodeffect2;
	float changetime=0;

	void Start () {
//		//开始显示舞台1
//		renderer.material.mainTexture = movTextures[0];
		_instance = this;
		LoadResource2 ();
	}
	

	void Update () {
		LoadResource2 ();
        //设置当前对象的主纹理为电影纹理
        // renderer.material.mainTexture = movTextures[i];
        //设置电影纹理播放模式为循环
//        movTextures[i].loop = true;
//		if (i==0) {
//			LoadResource ();
//				}
//		if (i==2) {
//			LoadResource1 ();
//		}
//		if (i==1) {
//			LoadResource2 ();
//		}
//		if (i==1) {
//			LoadResource3 ();
//		}
//		changetime += Time.deltaTime;
//		if (changetime >= 15) {
//			//ChangeEfx();
//			ChangWutai();
//			changetime=0;
//				}

//		if (Scoring_Tony1 .lianji >0) {
//			LianjiEffect ();
//				}

//        //播放/继续播放视频
//        if (! movTextures[i].isPlaying)
//        {
//			//movTextures[i].anisoLevel
//            movTextures[i].Play();
//        }
		
	}
	public void  LianjiEffect()
	{
		lizilianji .SetActive (true);
		StartCoroutine(SetHide(5,lizilianji ));
		}
	void ChangWutai()
	{
		i = Random.Range (0, 3);
		}
	//随机切换舞台和特效的方法
	void ChangeEfx()
	{
		i = Random.Range (0, 4);
		if (i == 0) {
			//InvokeRepeating ("LoadResource", 1f, 0.1f);
			j = Random.Range (0, 4);
			if (j == 0)
			{
					efxs [0].SetActive (true);
				m=0;
			}
			else if (j==1)
			{
					efxs [9].SetActive (true);
				m=9;
			}
			else if(j==2)
			{
				efxs [1].SetActive (true);
				m=1;
			}
			else {
				efxs [8].SetActive (true);
				m=8;
			}
				} 
		else if (i == 1) {
			//InvokeRepeating ("LoadResource1", 1f, 0.1f);
			j = Random.Range (0, 4);
			if (j == 0)
			{
				efxs [7].SetActive (true);
				m=7;
			}
			else if (j == 1)
			{
				efxs [4].SetActive (true);
				m=4;
			}
			else if (j == 2)
			{
				efxs [8].SetActive (true);
				m=8;
			}
			else if (j == 3)
			{
				efxs [9].SetActive (true);
				m=9;
			}
				}
		else if (i == 2) {
			//InvokeRepeating ("LoadResource2", 1f, 0.1f);
			j = Random.Range (0, 4);
			if (j == 0)
			{
				efxs [0].SetActive (true);
				m=0;
			}
			else if (j == 1)
			{
				efxs [1].SetActive (true);
				m=1;
			}
			else if (j == 2)
			{
				efxs [7].SetActive (true);
				m=7;
			}
			else if (j == 3)
			{
				efxs [3].SetActive (true);
				m=3;
			}
		}
		else if (i == 3) {
			//InvokeRepeating ("LoadResource3", 1f, 0.1f);
			j = Random.Range (0, 3);
			if (j == 0)
			{
				efxs [6].SetActive (true);
				m=6;
			}
			else if (j == 1)
			{
				efxs [3].SetActive (true);
				m=3;
			}
			else if (j == 2)
			{
				efxs [4].SetActive (true);
				m=4;
			}
			else if (j == 3)
			{
				efxs [6].SetActive (true);
				m=6;
			}
		}
		HideEfx();
	}
	//遍历特效，使当前的显示，非当前的隐藏
	void HideEfx()
	{
		foreach (GameObject efx in efxs) {
			if (efx==efxs[m])
			{
				efx.SetActive(true);
				StartCoroutine(SetHide(7,efx));
			}
			else
				efx.SetActive(false);
				}
	}
	//隐藏特效
	IEnumerator SetHide(float time,GameObject go)
	{
		yield return new WaitForSeconds (time);
		go.SetActive (false);
	}
	public void RandomEffect()
	{
		p = Random .Range (0,5);
		efxs [p].SetActive (true);

		HideEfx1();

		}
	public void GoodEffect()
	{
		rannum = Random .Range (0,2);
		if (rannum ==0) {
			Goodeffect [0].SetActive (true );
			uu=0;
				}
		else if (rannum ==1) {
			Goodeffect [1].SetActive (true );
			uu=1;
				}
		HideEfx3();
		}
	public void GreatEffect()
	{
		rannum = Random .Range (0,2);
		if (rannum ==0) {
			Goodeffect1 [0].SetActive (true );
			uu=0;
		}
		else if (rannum ==1) {
			Goodeffect1 [1].SetActive (true );
			uu=1;
		}
		HideEfx4();
	}
	public void PerfectEffect()
	{
		rannum = Random .Range (0,2);
		if (rannum ==0) {
			Goodeffect2 [0].SetActive (true );
			uu=0;

		}
		else if (rannum ==1) {

			Goodeffect2 [1].SetActive (true );
			uu=1;

		}
		HideEfx5();
	}
	void HideEfx1()
	{
		foreach (GameObject efx in efxs) {
			if (efx==efxs[p])
			{
				efx.SetActive(true);
				StartCoroutine(SetHide(3,efx));
			}
			else
				efx.SetActive(false);
		}
	}
	void HideEfx2()
	{
		foreach (GameObject bo in bomb ) {
			if (bo ==bomb [uu ])
			{
				bo .SetActive(true);
				StartCoroutine(SetHide(2,bo ));
			}
			else
				bo .SetActive(false);
		}
	}
	void HideEfx3()
	{
		foreach (GameObject bo in Goodeffect  ) {
			if (bo ==Goodeffect [uu ])
			{
				bo .SetActive(true);
				StartCoroutine(SetHide(2,bo ));
			}
			else
				bo .SetActive(false);
		}
	}
	void HideEfx4()
	{
		foreach (GameObject bo in Goodeffect1  ) {
			if (bo ==Goodeffect1 [uu ])
			{
				bo .SetActive(true);
				StartCoroutine(SetHide(2,bo ));
			}
			else
				bo .SetActive(false);
		}
	}
	void HideEfx5()
	{
		foreach (GameObject bo in Goodeffect2  ) {
			if (bo ==Goodeffect2 [uu ])
			{
				bo .SetActive(true);
				StartCoroutine(SetHide(2,bo ));
			}
			else
				bo .SetActive(false);
		}
	}
	IEnumerator  HideEfx6(float time )
	{
		Goodeffect2 [1].SetActive (true);
		yield return new WaitForSeconds (time);
		Goodeffect2 [2].SetActive (true);

		yield return new WaitForSeconds (time);
		Goodeffect2 [3].SetActive (true);

		yield return new WaitForSeconds (time);
		Goodeffect2 [4].SetActive (true);

		yield return new WaitForSeconds (time);
		Goodeffect2 [5].SetActive (true);
		Goodeffect2 [1].SetActive (false );
		yield return new WaitForSeconds (time);
		Goodeffect2 [6].SetActive (true);
		Goodeffect2 [2].SetActive (false );
		yield return new WaitForSeconds (time);
		Goodeffect2 [3].SetActive (false );
		yield return new WaitForSeconds (time);
		Goodeffect2 [4].SetActive (false );
		yield return new WaitForSeconds (time);
		Goodeffect2 [5].SetActive (false );
		yield return new WaitForSeconds (time);
		Goodeffect2 [6].SetActive (false );
	}
//	void LoadResource()
//	{
//		num++;
//		if (num >=0&&num<=9) {
//			stage ="light3000"+num;
//				}
//		if (num >9&&num<=99) {
//			stage ="light300"+num;
//				}
//		if (num>99) {
//			stage ="light30"+num;
//				}
//		renderer .material .mainTexture = (Texture)Resources .Load ("Stage/bignew3/"+stage );
//		//Debug .Log (stage  );
//		if (num>195) {
//			num=0;
//				}
//	}
//	void LoadResource1()
//	{
//		num++;
//		if (num >=0&&num<=9) {
//			stage ="light2000"+num;
//		}
//		if (num >9&&num<=99) {
//			stage ="light200"+num;
//		}
//		if (num>99) {
//			stage ="light20"+num;
//		}
//		renderer .material .mainTexture = (Texture)Resources .Load ("Stage/bluepsnew2/"+stage );
//		//Debug .Log (stage  );
//		if (num>156) {
//			num=0;
//		}
//	}
	void LoadResource2()
	{
		num++;
		if (num >=0&&num<=9) {
			stage ="light4000"+num;
		}
		if (num >9&&num<=99) {
			stage ="light400"+num;
		}
		if (num>99) {
			stage ="light40"+num;
		}
		renderer .material .mainTexture = (Texture)Resources .Load ("Stage/lightnew4/"+stage );
		//Debug .Log (stage  );
		if (num>120) {
			num=0;
		}
	}

	public void HideALL()
	{
		foreach(var go in Goodeffect)
		{
			go.SetActive(false);
		}
		foreach(var go in Goodeffect1)
		{
			go.SetActive(false);
		}
		foreach(var go in Goodeffect2)
		{
			go.SetActive(false);
		}
	}
//	void LoadResource3()
//	{
//		num++;
//		if (num >=0&&num<=9) {
//			stage ="light1000"+num;
//		}
//		if (num >9&&num<=99) {
//			stage ="light100"+num;
//		}
//		if (num>99) {
//			stage ="light10"+num;
//		}
//		renderer .material .mainTexture = (Texture)Resources .Load ("Stage/turnlight1/"+stage );
//		//Debug .Log (stage  );
//		if (num>161) {
//			num=0;
//		}
//	}

}
