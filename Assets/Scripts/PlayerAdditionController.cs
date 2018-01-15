using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerAdditionController : MonoBehaviour
{
    public GameObject PortalOrangeGameObject;
    public GameObject PortalGreenGameObject;
    
    private bool _is2Portals;
    
	void Update ()
	{
	    
	    if (PortalOrangeGameObject.activeInHierarchy && PortalGreenGameObject.activeInHierarchy)
	        _is2Portals = true;

	    else
	        _is2Portals = false;
        
    
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PortalOrangeGameObject && _is2Portals)
        {
            gameObject.transform.position = PortalGreenGameObject.transform.position + PortalGreenGameObject.transform.forward * -2;
        }
        else if (other.gameObject == PortalGreenGameObject && _is2Portals)
        {
            gameObject.transform.position = PortalOrangeGameObject.transform.position + PortalOrangeGameObject.transform.forward * 2;
        }
        else if (other.gameObject.CompareTag("Rope") && Input.GetKey(KeyCode.C))
        {
            Debug.Log("sdfsdf");
            gameObject.AddComponent<FixedJoint>().connectedBody = other.GetComponent<Rigidbody>();
        }
    }  
}
