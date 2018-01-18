using UnityEngine;

public class PlayerAdditionController : MonoBehaviour
{
    [SerializeField] private GameObject PortalOrangeGameObject;
    [SerializeField] private GameObject PortalGreenGameObject;
    private bool _is2Portals;
    private bool _connectedToRope;
	void Update ()
	{
	    if (PortalOrangeGameObject.activeInHierarchy && PortalGreenGameObject.activeInHierarchy)
	    {
	        _is2Portals = true;
	    }

	    if (PortalOrangeGameObject.activeInHierarchy || PortalGreenGameObject.activeInHierarchy)
	    {
	        _is2Portals = false;
	    }
	    if (Input.GetKeyDown(KeyCode.E))
	    {
	        _connectedToRope = true;
	    }

	    if (Input.GetKeyUp(KeyCode.E))
	    {
	        _connectedToRope = false;
	        Destroy(gameObject.GetComponent<HingeJoint>());
	    }

	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("It's a collision");
        if (_connectedToRope == true && collision.gameObject.CompareTag("Rope") && !gameObject.GetComponent<HingeJoint>())
        {
            gameObject.AddComponent<HingeJoint>().connectedBody = collision.rigidbody;
            gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0, 1, 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PortalOrangeGameObject && _is2Portals)
        {
            gameObject.transform.position = PortalGreenGameObject.transform.position + PortalGreenGameObject.transform.forward * -2;
        }
        if (other.gameObject == PortalGreenGameObject && _is2Portals)
        {
            gameObject.transform.position = PortalOrangeGameObject.transform.position + PortalOrangeGameObject.transform.forward * 2;
        }
    }  
}
