using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject BridgeRotatorGameObject;

    private bool _isStand;
    private void OnCollisionEnter(Collision collision)
    {
        if (!_isStand)
        {
            BridgeRotatorGameObject.transform.Rotate(new Vector3(1, 0, 0), -90);
            _isStand = !_isStand;
        }
        else
        {
            BridgeRotatorGameObject.transform.Rotate(new Vector3(1, 0, 0), 90);
            _isStand = !_isStand;
        }
    }
}
