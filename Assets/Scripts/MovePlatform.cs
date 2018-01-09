using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float speed;
	void Update ()
	{
	    transform.position = new Vector3(0, transform.position.y, transform.position.z + speed);
	    if (transform.position.z >= 10f)
	        speed = -speed;
        else if (transform.position.z <= -10f)
	    {
	        speed = -speed;
	    }
	}
}
