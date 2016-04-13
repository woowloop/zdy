using UnityEngine;
using System.Collections;
using ZXing;
using ZXing.QrCode;
using System;

using ZXing.Common;
using ZXing.Rendering;
using System.Collections.Generic;





 
public class BarcodeCam: MonoBehaviour
{
    public Texture2D encoded;



void Start () 
    {

        encoded = new Texture2D(512, 512);

    BitMatrix BIT = new BitMatrix(512, 512);
  

		string name="http://www.baidu.cn/";
     Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();

     //Unicode Big Unmarked UTF8 Big5 GB18030 EUC_KR
     hints.Add(EncodeHintType.CHARACTER_SET, "EUC-KR");

     BIT = new MultiFormatWriter().encode(name, BarcodeFormat.QR_CODE, 512, 512, hints);
     int width = BIT.Width;
     int height = BIT.Width;

     for (int x = 0; x < height; x++)
     {
         for (int y = 0; y < width; y++)
         {
             if (BIT[x, y])
             {
                 encoded.SetPixel(y, x, Color.black);
             }
             else
             {
                 encoded.SetPixel(y,x, Color.white);
             }
           
         }
     }
     encoded.Apply();
   
}
//使用屏蔽代码请先屏蔽Start里的

    //private static Color32[] Encode(string textForEncoding, int width, int height)
    //{
        

        
    //    //var writer = new BarcodeWriter
    //    //{
    //    //    Format = BarcodeFormat.QR_CODE,

            
    //    //    Options = new QrCodeEncodingOptions
    //    //    {
    //    //        Height = height,
    //    //        Width = width
    //    //    }
         
    //    //   //Hashtable hints = new Hashtable();
    //    //   // hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");

    //    //};
    //    //return writer.Write(textForEncoding);
    //}


void Update ()
{
    //var textForEncoding = Lastresult;
    //if (textForEncoding != null)
    //{
    //    var color32 = Encode(textForEncoding, encoded.width, encoded.height);
    //    encoded.SetPixels32(color32);
    //    encoded.Apply();
    //} 

      
}


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(100, 100,256,256), encoded);
    }


  
    
}

