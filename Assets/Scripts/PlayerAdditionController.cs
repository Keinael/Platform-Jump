using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerAdditionController : MonoBehaviour
{
    public GameObject PortalOrangeGameObject;
    public GameObject PortalGreenGameObject;
    public bool is2Portals;
    
	void Update ()
	{
	    if (PortalOrangeGameObject.activeInHierarchy && PortalGreenGameObject.activeInHierarchy)
	        is2Portals = true;

	    else
	        is2Portals = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PortalOrangeGameObject && is2Portals)
        {
            gameObject.transform.position = PortalGreenGameObject.transform.position;
            RigidbodyFirstPersonController fpsController = new RigidbodyFirstPersonController();
            
//Реализовать правильный поворот

        }
    }


}
