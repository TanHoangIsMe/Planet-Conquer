using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;

    private void OnCollisionEnter(Collision collision)
    {
        particleSystem.Play();
        gameObject.GetComponent<PlayerMoveControl>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;    
        Invoke("ReloadScene", 1);
    }

    private void ReloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}
