using UnityEngine;
using System.Collections;

public class TotalControl : MonoBehaviour {

    bool showNewUi = false;
    public GameObject newMainInterface, oldMainInterface, newInterface, oldInterface;

	void Start () {
	
	}
	

	void Update () {

        if (showNewUi)
        {
            newMainInterface.SetActive(true);
            newInterface.SetActive(true);
            oldMainInterface.SetActive(false);
            oldInterface.SetActive(false);
        }
        else
        {
            newMainInterface.SetActive(false);
            newInterface.SetActive(false);
            oldMainInterface.SetActive(true);
            oldInterface.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (showNewUi)
                showNewUi = false;
            else
                showNewUi = true;

        }
	}
}
