using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float timeShots;
    public float startTimeShots;
    public float Speed;

    public float shootingDistance = 10f;
    public GameObject bullet;
    private Transform player;

    

    // Start is called before the first frame update
    void Start()
    {
        timeShots = startTimeShots;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance         
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);    

        if (distanceToPlayer <= shootingDistance)
        {
            if (timeShots <= 0)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                timeShots = startTimeShots;
            }
            else
            {
                timeShots -= Time.deltaTime;   
            }
        }    
    }
    void FixedUpdate()
    {
        // Get the current position of the enemy
        Vector3 currentPosition = transform.position;
        
        // Calculate the target position only considering the player's X
        Vector3 targetPosition = new Vector3(player.position.x - 0.7f, currentPosition.y, currentPosition.z);

        // Move the enemy towards the target position
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, Speed * Time.deltaTime);
    }

}
