using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Camera MainCamera;
//    public GameObject[] _portalGameObjects;
    public GameObject PortalOrangeGameObject;
    public GameObject PortalGreenGameObject;

    private RaycastHit _hit;

	void Start ()
	{
//        _portalGameObjects = new GameObject[2];
//	    _portalGameObjects[0] = PortalOrangeGameObject;
//	    _portalGameObjects[1] = PortalGreenGameObject;
	}   

	void Update () {
//		Debug.DrawRay(MainCamera.transform.position, MainCamera.transform.forward * 10);
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
//                PortalOrangeGameObject.transform.SetParent(_hit.transform, false);
//	            PortalOrangeGameObject.transform.parent = _hit.transform;
	            
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
	        }
	    }
	}
}
