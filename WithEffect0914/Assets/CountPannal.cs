using UnityEngine;
using System.Collections;
using System .Collections .Generic ;
using System.Linq;
public class CountPannal : MonoBehaviour {

	public static CountPannal _instance;
	private UILabel leftHandnum;
	private UILabel rightHandnum;
	private UILabel leftElbownum;
	private UILabel rightElbownum;
	private UILabel leftFootnum;
	private UILabel rightFootnum;
	private UILabel hold;
	private UIButton retune;
	private TweenPosition countpannal;
	private Scoring_Tony1 st1;
	private List <int> misscor=new List<int > ();
	void  Awake(){
		_instance = this;
		hold =transform .Find ("Hope").GetComponent <UILabel >();
		leftHandnum =transform .Find ("parent/LeftHandnum").GetComponent<UILabel >(); 
		rightHandnum =transform .Find ("parent/RightHandnum").GetComponent<UILabel >(); 
		leftElbownum =transform .Find ("parent/LeftElbownum").GetComponent<UILabel >(); 
		rightElbownum =transform .Find ("parent/RightElbownum").GetComponent<UILabel >(); 
		leftFootnum =transform .Find ("parent/LeftFootnum").GetComponent<UILabel >(); 
		rightFootnum =transform .Find ("parent/RightFootnum").GetComponent<UILabel >(); 
		retune =transform .Find ("Close").GetComponent <UIButton >();
		countpannal =this.GetComponent <TweenPosition >();
		st1=GameObject .Find ("Cube1").GetComponent <Scoring_Tony1 >();
		EventDelegate ed = new EventDelegate (this ,"ClosePannal");
		retune .onClick .Add (ed);

	}
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePannal();
        }
    }
	void Start()
    {

		//Init ();
	}
	void ClosePannal()
	{
		countpannal .PlayReverse ();
		misscor .Clear ();
//		if (RankingListPannel ._instance .qrpintkey == 1) {
//			SavePicture ._instance .qrpaint = true;
//		} else {
//			SavePicture ._instance .qrpaint1 = true;
//		}
	}
	public void Init()
	{
		countpannal .PlayForward ();
		misscor .Add (st1.num1);
		misscor .Add (st1.num2);
		misscor .Add (st1.num3);
		misscor .Add (st1.num4);
		misscor .Add (st1.num5);
		misscor .Add (st1.num6);

		leftHandnum.text =st1.num1 .ToString () ;
		rightHandnum.text =st1. num2 .ToString ();
		leftElbownum.text =st1. num3 .ToString ();
		rightElbownum.text =st1. num4 .ToString ();
		leftFootnum.text =st1. num5 .ToString ();
		rightFootnum.text =st1. num6 .ToString ();
		ShoeMassage ();

//		int num = Random .Range (1,20);
//		leftHandnum.text =num .ToString () ;
//		rightHandnum.text =num .ToString ();
//		leftElbownum.text =num.ToString ();
//		rightElbownum.text =num .ToString ();
//		leftFootnum.text =num.ToString ();
//		rightFootnum.text =num .ToString ();
	}
	public void ShoeMassage()
	{
		int maxnum = misscor.Max ();
			if (st1.num1==maxnum ) {
			hold .text ="你的左手动作还需要加强哦！";
				}
		if (st1.num2==maxnum ) {
			hold .text ="你的右手动作还需要加强哦！";
		}
		if (st1.num3==maxnum ) {
			hold .text ="你的左肘动作还需要加强哦！";
		}
		if (st1.num4==maxnum ) {
			hold .text ="你的右肘动作还需要加强哦！";
		}
		if (st1.num5==maxnum ) {
			hold .text ="你的左脚动作还需要加强哦！";
		}
		if (st1.num6==maxnum ) {
			hold .text ="你的右脚动作还需要加强哦！";
		}

	}
}
