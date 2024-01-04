using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public AudioSource LevelUpSound;
    public AudioSource BackgroundSound;

    void Start()
    {
        LevelUpSound.enabled = false;
    }
    // Collision and level up 
    private void OnTriggerEnter(Collider other)
    {
        BackgroundSound.enabled = false;
        LevelUpSound.enabled = true;
        StartCoroutine(WaitTime());             
    }    
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
