using UnityEngine;

public class MovingPlatformContainer : MonoBehaviour
{
    public float Speed;
    public Transform ObjectTransform;

	void Update ()
	{
	    transform.position = new Vector3(0, transform.position.y, transform.position.z + Speed);
	    if (transform.position.z >= 10f)
	        Speed = -Speed;
        else if (transform.position.z <= -10f)
	    {
	        Speed = -Speed;
	    }
	}
}
