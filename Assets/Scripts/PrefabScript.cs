using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabScript : MonoBehaviour
{
    
	// Use this for initialization
    void Awake ()
    {
        var shootManager = GameObject.Find("Portal Gun").GetComponent<ShootManager>();


	    if (shootManager.RopeUnitsGameObjects.Count == 0)
	    {
	        GetComponent<ConfigurableJoint>().connectedBody = shootManager.Hit.rigidbody;
	        
	    }
	    else
	    {
	        GetComponent<ConfigurableJoint>().connectedBody = shootManager.RopeUnitsGameObjects[shootManager.RopeUnitsGameObjects.Count - 1].GetComponent<Rigidbody>();
	    }

//        gameObject.transform.rotation = shootManager.MainCamera.transform.rotation;

    }

}
