using UnityEngine;

public class PlayerAdditionController : MonoBehaviour
{
    [SerializeField] private GameObject _portalOrangeGameObject;
    [SerializeField] private GameObject _portalGreenGameObject;
    [SerializeField] private AudioSource _audioSource;
    private bool _is2Portals;
    private bool _connectedToRope;

	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.E))
	    {
	        _connectedToRope = true;
	    }
	    else if (Input.GetKeyUp(KeyCode.E))
	    {
	        _connectedToRope = false;

            //Change Destroy() function with disabling game object
	        Destroy(gameObject.GetComponent<HingeJoint>());
	        _audioSource.Play();
	    }
	    else if (_portalOrangeGameObject.activeInHierarchy && _portalGreenGameObject.activeInHierarchy)
	    {
	        _is2Portals = true;
	    }
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("It's a collision");
        if (_connectedToRope == true && collision.gameObject.CompareTag("Rope") && !gameObject.GetComponent<HingeJoint>())
        {
            _audioSource.Play();
            gameObject.AddComponent<HingeJoint>().connectedBody = collision.rigidbody;
            GetComponent<HingeJoint>().anchor = new Vector3(0, 1, 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _portalOrangeGameObject && _is2Portals)
        {
            transform.position = _portalGreenGameObject.transform.position + _portalGreenGameObject.transform.forward * -2;
        }
        if (other.gameObject == _portalGreenGameObject && _is2Portals)
        {
            gameObject.transform.position = _portalOrangeGameObject.transform.position + _portalOrangeGameObject.transform.forward * 2;
        }
    }  
}
