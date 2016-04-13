using UnityEngine;
using System.Collections;
using System;

public class CollisionDetection_Tony : MonoBehaviour {


    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag.Equals("collider"))
        {
            if (col.collider.name.Contains(gameObject.name))
            {
                if (gameObject.name == "LeftHand")
				{
                    GameObject.Find("Root").GetComponent<GradeHandle_Tony>().lhandi += col.collider.name.Substring(col.collider.name.Length - 1, 1);
                }
                if (gameObject.name == "RightHand")
                {
                    GameObject.Find("Root").GetComponent<GradeHandle_Tony>().rhandi += col.collider.name.Substring(col.collider.name.Length - 1, 1);
                }
                if (gameObject.name == "LeftFoot")
                {
                    GameObject.Find("Root").GetComponent<GradeHandle_Tony>().lfooti += col.collider.name.Substring(col.collider.name.Length - 1, 1);
                }
                if (gameObject.name == "RightFoot")
                {
                    GameObject.Find("Root").GetComponent<GradeHandle_Tony>().rfooti += col.collider.name.Substring(col.collider.name.Length - 1, 1);
                }
				if (gameObject.name == "RightElbow")
				{
					GameObject.Find("Root").GetComponent<GradeHandle_Tony>().relbowi += col.collider.name.Substring(col.collider.name.Length - 1, 1);
				}
				if (gameObject.name == "LeftElbow")
				{
					GameObject.Find("Root").GetComponent<GradeHandle_Tony>().lelbowi += col.collider.name.Substring(col.collider.name.Length - 1, 1);
				}
				if (gameObject.name == "RightKnee")
				{
					GameObject.Find("Root").GetComponent<GradeHandle_Tony>().rkneei += col.collider.name.Substring(col.collider.name.Length - 1, 1);
				}
				if (gameObject.name == "LeftKnee")
				{
					GameObject.Find("Root").GetComponent<GradeHandle_Tony>().lkneei += col.collider.name.Substring(col.collider.name.Length - 1, 1);
				}
				if (gameObject.name == "RightShoulder")
				{
					GameObject.Find("Root").GetComponent<GradeHandle_Tony>().rshoulderi += col.collider.name.Substring(col.collider.name.Length - 1, 1);
				}
				if (gameObject.name == "LeftShoulder")
				{
					GameObject.Find("Root").GetComponent<GradeHandle_Tony>().lshoulderi += col.collider.name.Substring(col.collider.name.Length - 1, 1);
				}
				if (gameObject.name == "Head")
				{
					GameObject.Find("Root").GetComponent<GradeHandle_Tony>().headi += col.collider.name.Substring(col.collider.name.Length - 1, 1);
				}
                Destroy(col.gameObject);
            }
        }       
    }
}
