using UnityEngine;
using System.Collections;
using ZXing;
using ZXing.QrCode;

public class ZxingDraw : MonoBehaviour {

	public static ZxingDraw _instance;
	//private UITexture code;
    private UITexture codeShow;
    public Texture2D encoded;
    public bool isShow = false;
    private static string url = "http://shapejoy.duapp.com/user/authorize?devicereg=" + SystemInfo.deviceUniqueIdentifier;
	void Awake()
	{
        _instance = this;
        codeShow = GameObject.Find("CodeTexture").GetComponent<UITexture>();
        if (codeShow)
        {
            encoded = new Texture2D(256, 256);
        }
		//code = transform .Find ("CodeTexture").GetComponent <UITexture > ();
        
	}
    void Start()
    {
        StartCoroutine(StartDrawCode());
    }
    IEnumerator StartDrawCode()
    {
        yield return new WaitForSeconds(0.25f);
        DrawCode();
    }
    private Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

    private void QRCreate(string url, Texture2D encoded)
    {
        var color32 = Encode(url, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
    }

	public void DrawCode()
    {
        isShow = true;
        //QRlogin._instance.StartAuthorize();
        //QRlogin._instance.StartAuthorize();
        codeShow.mainTexture = encoded;
        QRCreate(url, encoded);
        //QRlogin._instance.OnLoginSucceed += DestroyCode;
	}
	/*public void CalCode()
	{
		QRlogin ._instance .StopAuthorize();
		code .mainTexture = null;
	}*/
    public void DestroyCode()
    {
        isShow = false;
       // QRlogin._instance.OnLoginSucceed -= DestroyCode;
        if (codeShow)
        {
            codeShow.mainTexture = null;
        }
    }
}
