using UnityEngine;
using System.Collections;

public class Foreground : MonoBehaviour {

    UISprite fex;
    int n = 1;
    public bool canPlay = false;
    float time = 0;

    void Awake()
    {
        fex=GetComponent<UISprite>();
	}

    void Update()
    {
        fex.spriteName = "ef" + n;

        if (canPlay)
        {
            time += Time.deltaTime;
            if (time >= 1f)
            {
                n++;
                time = 0;
            }
            if (n ==6)
            {

                n = 1;
            }
        }

    }
}
