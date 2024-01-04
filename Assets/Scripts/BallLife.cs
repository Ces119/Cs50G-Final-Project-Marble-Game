using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallLife : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource loseSound;

    public AudioSource backgroundSound;

    void Start()
    {
        backgroundSound.enabled = true;
        loseSound.enabled = false;
    }

    private void FixedUpdate()
    {   
        // if the ball down the platform, game over

        if (rb.position.y < - 4f)
        {
            Die();
        }
               
    }
    // Collision the enemy 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Die();
        }
        // Collision bullet, destroy ball.
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            
            Die();
        }
    }

    void Die()
    {
        backgroundSound.enabled = false;
        loseSound.enabled = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Movement>().enabled = false; 
        StartCoroutine(WaitTime()); 
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
