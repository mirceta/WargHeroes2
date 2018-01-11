using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public int scoreAmount = 0;
    public float timeAmount = 0.0f;

    public GameObject explosionPrefab;


    public int maxRange = 100;
    public int minRange = 1;
    public int minDistanceToShoot = 2;
    public int speedChase = 2;
    private Vector3 targetTran;
    public Transform target;
    private Transform playerPosition;

    private bool chasingPlayer = false;

    void Start()
    {
        if(target == null)
        {
            if(GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>(); 
        float distanceFromPlayer = Vector3.Distance(transform.position, playerPosition.position);

        if(distanceFromPlayer < maxRange)
        {
            chasingPlayer = true;
            target = playerPosition;
        }
        else
        {
            chasingPlayer = false;
            target = GameObject.FindWithTag("Tower").GetComponent<Transform>();
        }

        transform.LookAt(target);


        if ((Vector3.Distance(transform.position, target.position) < maxRange)
           && (Vector3.Distance(transform.position, target.position) > minRange) && chasingPlayer)
        {
            transform.position += transform.forward * speedChase * Time.deltaTime;
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < minDistanceToShoot)
            {

            }
            Debug.Log("I SEE YOU");
        }
        /*
        else
        {
            // approach the base
            target = GameObject.FindWithTag("Tower").GetComponent<Transform>();

        }
        */
       


    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            
            if (explosionPrefab)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
           
            Destroy(collision.gameObject); 
            Destroy(gameObject);
        }
       
    }
	
}
