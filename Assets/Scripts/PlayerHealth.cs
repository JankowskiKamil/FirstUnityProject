using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{

    private bool _isDead = false;
    private float _belowLevelParameter = -2f;

    void Update()
    {
        Debug.Log(_isDead);
        if (transform.position.y < _belowLevelParameter && !_isDead)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            DisablePlayer();
            Die();
        }
    }

    void DisablePlayer()
    {
        GetComponent<MeshRenderer>().enabled = false; //player shouldnt be rendered
        GetComponent<Rigidbody>().isKinematic = true; //other objects cannot collide with player
        GetComponent<PlayerMovement>().enabled = false; // cannot move
    }

    void Die()
    {
        _isDead = true;

        Invoke(nameof(ReloadLevel), 1.3f); // Reload scene after 1.3 sec
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
