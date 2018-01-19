using System;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public RaycastHit Hit;
    public List<GameObject> RopeUnitsGameObjects;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject _portalOrangeGameObject;
    [SerializeField] private GameObject _portalGreenGameObject;
    [SerializeField] private GameObject _ropePrefabGameObject;
    
    void Start()
    {
        RopeUnitsGameObjects = new List<GameObject>();
    }

	void Update ()
	{
	    var ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward * 50);
	    Physics.Raycast(ray, out Hit);

	    if (Input.GetMouseButtonDown(0) && Hit.transform.gameObject.tag == "Portal")
	    {
	        if (!_portalOrangeGameObject.activeInHierarchy)
	        {
	            _portalOrangeGameObject.SetActive(true);
	        }
	        _portalOrangeGameObject.GetComponent<AudioSource>().Play();
	        _portalOrangeGameObject.transform.position = Hit.point + Hit.normal * 0.01f;
	        _portalOrangeGameObject.transform.rotation = Quaternion.LookRotation(Hit.normal);
	        _portalOrangeGameObject.transform.parent = Hit.transform;
	    }

	    if (Input.GetMouseButtonDown(1))
	    {
	        if (Hit.transform.gameObject.tag == "Portal")
	        {
	            if (!_portalGreenGameObject.activeInHierarchy)
	            {
	                _portalGreenGameObject.SetActive(true);
	            }
	            _portalGreenGameObject.GetComponent<AudioSource>().Play();
	            _portalGreenGameObject.transform.position = Hit.point + Hit.normal * 0.01f;
	            _portalGreenGameObject.transform.rotation = Quaternion.LookRotation(-Hit.normal);
	            _portalGreenGameObject.transform.parent = Hit.transform;
	        }
	    }

        if (Input.GetKeyDown(KeyCode.R) && Hit.collider.gameObject.tag == "Portal")
        {
            var prefabScaleY = _ropePrefabGameObject.GetComponent<Transform>().lossyScale.y;
            var CountUnits = Convert.ToInt16((Hit.distance / prefabScaleY)/2.2);

            for (int i = 0; i < RopeUnitsGameObjects.Count; i++)
            {
                Destroy(RopeUnitsGameObjects[i]);
            }
            RopeUnitsGameObjects.RemoveRange(0, RopeUnitsGameObjects.Count);
            
	        for (int i = CountUnits; i >= 2; i--)
	        {
	            RopeUnitsGameObjects.Add(Instantiate(_ropePrefabGameObject, ray.GetPoint(i * prefabScaleY * 2f), _mainCamera.transform.rotation * Quaternion.AngleAxis(90, Vector3.right)));
	        }
	    }
	}
}
