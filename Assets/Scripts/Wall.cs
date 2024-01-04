using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public AudioSource wallStrikeSound;
    private bool wallStrike = false;

    void Start()
    {
        wallStrikeSound.enabled = false;
    }

    void Update()
    {
        // For Wall Strike Sound 
        if (wallStrike == true)
        {            
            StartCoroutine(WallStrikeSound());
            
        }
    }
    // For Wall Strike Sound 
    IEnumerator WallStrikeSound()
    {
        wallStrikeSound.enabled = true;
        yield return new WaitForSeconds(0.1f);
        wallStrike = false;
        wallStrikeSound.enabled = false;
                
    }
    //if  Bullet collision at the wall, it destroys. 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            wallStrike = true;
        }
        
    }

}
