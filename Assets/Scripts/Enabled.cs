using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabled : MonoBehaviour
{
    public float time;
    private  MeshRenderer step;

    private BoxCollider boxCollider;

    bool transparent = false;


    // Start is called before the first frame update
    void Start()
    {
       step = GetComponent<MeshRenderer>();
       boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transparent == false)
        {
            StartCoroutine(EnabledTime());
        }
        else 
        {
            StartCoroutine(UnEnabledTime());
        }
    }    

    IEnumerator EnabledTime()
    {
        boxCollider.enabled = true;
        step.enabled = true;
        yield return new WaitForSeconds(time);
        transparent = true;
        
    }
    IEnumerator UnEnabledTime()
    {
        boxCollider.enabled = false;
        step.enabled = false;
        yield return new WaitForSeconds(time);
        transparent = false;

    }
}
