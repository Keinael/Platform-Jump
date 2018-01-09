﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject BridgeRotatorGameObject;
    
    private void OnCollisionEnter(Collision collision)
    {
        BridgeRotatorGameObject.transform.Rotate(new Vector3(1, 0, 0), -90);
    }
}
