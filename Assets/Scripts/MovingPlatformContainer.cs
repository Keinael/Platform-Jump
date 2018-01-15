using UnityEngine;

public class MovingPlatformContainer : MonoBehaviour
{
    public float Speed;
    public Transform ObjectTransform;

	void Update ()
	{
        
	    transform.Translate(new Vector3(0, 0, Speed * Time.deltaTime));
	    if (transform.position.z >= 10f)
	    {
	        Speed = -Speed;
	    }
	    else if (transform.position.z <= -10f)
	    {
	        Speed = -Speed;
	    }
	}
}
