using UnityEngine;

public class MovingPlatformContainer : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float startPosition = -10f;
    private float endPosition = 10f;
	void Update ()
	{
	    transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
	    if (transform.position.z >= endPosition)
	    {
	        _speed = -_speed;
	    }
	    else if (transform.position.z <= startPosition)
	    {
	        _speed = -_speed;
	    }
	}
}
