using UnityEngine;
using System.Collections;
using OpenNI;

public class JointTracker : MonoBehaviour {

    public NIPlayerManager m_playerManager;
    public SkeletonJoint singleJoint;
    Vector3 endpoint;
    Transform referenceTrans;
    public bool isOk = true;


    void Awake()
    {
       
    }
    
    void Start () {
        referenceTrans = GameObject.Find("A_ReferencePoint").transform;
        if (m_playerManager == null)
        {
            m_playerManager = FindObjectOfType(typeof(NIPlayerManager)) as NIPlayerManager;
            if (m_playerManager == null)
                throw new System.Exception("No player manager was found.");
        }
	}
	
	void Update () {
        NISelectedPlayer player = m_playerManager.GetPlayer(0);
        if (player == null)
            return;
        Vector3 originalPoint = new Vector3(0,0,0);
        SkeletonJointPosition curpos;
        if (player.GetSkeletonJointPosition(singleJoint, out curpos))
        {
            originalPoint = NIConvertCoordinates.ConvertPos(curpos.Position);
            endpoint = referenceTrans.position;
            Ray _ray = new Ray(originalPoint, (endpoint - originalPoint).normalized);
            RaycastHit hit;
            if (Physics.Raycast(_ray, out hit) && hit.collider.name == "PlaneYZ")
            {
                isOk = true;
                transform.position = hit.point;
            }
            //Debug.DrawLine(_ray.origin, endpoint, Color.yellow);
            else
                isOk = false;
           

        }
        
        

	}
}
