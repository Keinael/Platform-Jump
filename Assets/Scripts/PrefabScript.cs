using UnityEngine;

public class PrefabScript : MonoBehaviour
{
    void Awake ()
    {
        var shootManager = GameObject.Find("Portal Gun").GetComponent<ShootManager>();
        gameObject.GetComponent<ConfigurableJoint>().anchor = new Vector3(0, 1, 0);

	    if (shootManager.RopeUnitsGameObjects.Count == 0)
        {
            GetComponent<ConfigurableJoint>().connectedBody = shootManager.Hit.rigidbody;
        }            
	    else
        {
            GetComponent<ConfigurableJoint>().connectedBody = shootManager.RopeUnitsGameObjects[shootManager.RopeUnitsGameObjects.Count - 1].GetComponent<Rigidbody>();
        }
    }   
}
