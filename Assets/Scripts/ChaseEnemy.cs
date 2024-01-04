using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChaseEnemy : MonoBehaviour
{
    public float speed;
    private Transform player;

    public float movingDestination = 3f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // FixedUpdate Chase Player 
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.position) < movingDestination)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        
    }
}
