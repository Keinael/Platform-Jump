using System;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public RaycastHit Hit;
    public List<GameObject> RopeUnitsGameObjects;

    [SerializeField] private Camera MainCamera;
    [SerializeField] private GameObject PortalOrangeGameObject;
    [SerializeField] private GameObject PortalGreenGameObject;
    [SerializeField] private GameObject RopePrefabGameObject;
    
    void Start()
    {
        RopeUnitsGameObjects = new List<GameObject>();
    }

	void Update ()
	{
	    var ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward * 50);
	    Physics.Raycast(ray, out Hit);
        
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

        if (Input.GetKeyDown(KeyCode.R) && Hit.collider.gameObject.tag == "Portal")
        {
            var prefabScaleY = RopePrefabGameObject.GetComponent<Transform>().lossyScale.y;
            var CountUnits = Convert.ToInt16((Hit.distance / prefabScaleY)/2.2);

            for (int i = 0; i < RopeUnitsGameObjects.Count; i++)
            {
                Destroy(RopeUnitsGameObjects[i]);
            }
            RopeUnitsGameObjects.RemoveRange(0, RopeUnitsGameObjects.Count);
            
	        for (int i = CountUnits; i >= 2; i--)
	        {
	            RopeUnitsGameObjects.Add(Instantiate(RopePrefabGameObject, ray.GetPoint(i * prefabScaleY * 2f), MainCamera.transform.rotation * Quaternion.AngleAxis(90, Vector3.right)));
	        }
	    }
	}
}
