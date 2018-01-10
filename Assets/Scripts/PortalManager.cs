using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject PortalOrangeGameObject;
    public GameObject PortalGreenGameObject;

    private RaycastHit _hit;

	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {
	        Ray ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward * 10);
	        if (Physics.Raycast(ray, out _hit) && _hit.transform.gameObject.tag == "Portal")
	        {
	            if (!PortalOrangeGameObject.activeInHierarchy)
	            {
	                PortalOrangeGameObject.SetActive(true);
	            }
	            PortalOrangeGameObject.transform.position = _hit.point + _hit.normal * 0.01f ;
	            PortalOrangeGameObject.transform.rotation = Quaternion.LookRotation(_hit.normal);
	            PortalOrangeGameObject.transform.parent = _hit.transform;
	            
	        }
	    }
	    if (Input.GetMouseButtonDown(1))
	    {
	        Ray ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward * 10);
	        if (Physics.Raycast(ray, out _hit) && _hit.transform.gameObject.tag == "Portal")
	        {
	            if (!PortalGreenGameObject.activeInHierarchy)
	            {
	                PortalGreenGameObject.SetActive(true);
	            }
	            PortalGreenGameObject.transform.position = _hit.point + _hit.normal * 0.01f;
	            PortalGreenGameObject.transform.rotation = Quaternion.LookRotation(-_hit.normal);
	            PortalGreenGameObject.transform.parent = _hit.transform;
	        }
	    }
	}
}
