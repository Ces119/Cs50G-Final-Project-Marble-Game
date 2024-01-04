using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{

    public AudioSource backGroundSound;
    public AudioSource clockSound;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float remainingTime;

    void Start()
    {
        backGroundSound.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
         if (remainingTime > 0)
         {
            remainingTime -= Time.deltaTime;
         }
         else if (remainingTime < 0)
         {
            remainingTime = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }  

         int minutes = Mathf.FloorToInt(remainingTime / 60);
         int seconds = Mathf.FloorToInt(remainingTime % 60);
         timeText.text = string.Format("{0:00}:{1:00}", minutes,seconds);

         if (remainingTime > 0.5 && remainingTime < 5)  
         {
            backGroundSound.enabled = false;
            clockSound.enabled = true;
         }
         else
         {            
            clockSound.enabled = false;
         }   
    }
}
