using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _bridgeRotatorGameObject;
    private bool _isStand;

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isStand)
        {
            _bridgeRotatorGameObject.transform.Rotate(new Vector3(1, 0, 0), -90);
            _isStand = !_isStand;
        }
        else
        {
            _bridgeRotatorGameObject.transform.Rotate(new Vector3(1, 0, 0), 90);
            _isStand = !_isStand;
        }
    }
}
