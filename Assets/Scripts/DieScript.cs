using UnityEngine.SceneManagement;
using UnityEngine;

public class DieScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
