using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject PortalOrangeGameObject;
    public GameObject PortalGreenGameObject;
    public List<GameObject> RopeUnitsGameObjects;
    public GameObject RopePrefabGameObject;
    public RaycastHit Hit;
    public Ray Ray;


    void Start()
    {
        RopeUnitsGameObjects = new List<GameObject>();
    }

	void Update () 
	{
	    Ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward * 50);
	    Physics.Raycast(Ray, out Hit);
        
	    if (Input.GetMouseButtonDown(0))
	    {
	        if (Hit.transform.gameObject.tag == "Portal")
	        {
	            if (!PortalOrangeGameObject.activeInHierarchy)
	            {
	                PortalOrangeGameObject.SetActive(true);
	            }
	            PortalOrangeGameObject.transform.position = Hit.point + Hit.normal * 0.01f ;
	            PortalOrangeGameObject.transform.rotation = Quaternion.LookRotation(Hit.normal);
	            PortalOrangeGameObject.transform.parent = Hit.transform;
	        }
	    }
	    if (Input.GetMouseButtonDown(1))
	    {
	        
	        if (Hit.transform.gameObject.tag == "Portal")
	        {
	            if (!PortalGreenGameObject.activeInHierarchy)
	            {
	                PortalGreenGameObject.SetActive(true);
	            }
	            PortalGreenGameObject.transform.position = Hit.point + Hit.normal * 0.01f;
	            PortalGreenGameObject.transform.rotation = Quaternion.LookRotation(-Hit.normal);
	            PortalGreenGameObject.transform.parent = Hit.transform;
	        }
	    }
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            for (int i = 0; i < RopeUnitsGameObjects.Count - 1; i++)
            {
                Destroy(RopeUnitsGameObjects[i]);
            }
            
            RopeUnitsGameObjects.RemoveRange(0, RopeUnitsGameObjects.Count);

	        var CountUnits = Convert.ToInt16((Hit.distance / RopePrefabGameObject.GetComponent<Transform>().lossyScale.y)/2.2);
	        Debug.Log("Дистанция: " + Hit.distance);
	        Debug.Log("Элементов: " + CountUnits);
            
	        for (int i = CountUnits; i >= 2; i--)
	        {
	            RopeUnitsGameObjects.Add(Instantiate(RopePrefabGameObject, Ray.GetPoint(i * RopePrefabGameObject.GetComponent<Transform>().lossyScale.y * 2f), Quaternion.identity) as GameObject);
	            
	        }
	    }
        Debug.DrawRay(MainCamera.transform.position, MainCamera.transform.forward * 50, Color.red);
	    
	}
}
