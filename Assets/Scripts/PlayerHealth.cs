using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();

        }
    }

    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false; //player shouldnt be rendered
        GetComponent<Rigidbody>().isKinematic = true; //other objects cannot collide with player
        GetComponent<PlayerMovement>().enabled = false; // cannot move
        Invoke(nameof(ReloadLevel), 1.3f); // Reload scene after 1.3 sec
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
