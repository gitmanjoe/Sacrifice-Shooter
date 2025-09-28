using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject healthPrefab;
    public GameObject healthScript;
    public Transform bulletspawn;
    private bool isshooting = false;
    private bool iswaiting = false;
    public Transform player;  // Reference to the player's position
    private NavMeshAgent agent;  // Reference to the NavMeshAgent
    public float detectionRange = 1000f;  // Range within which the enemy will follow the player
    private Animator animator;
    public float health = 50f;

    private bool isAlive = true;
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
	animator.SetBool("Death", true);
	agent.isStopped = true;
	isAlive = false;
	int randomNumber = Random.Range(1, 2); 
	if(randomNumber == 1)
	{
		GameObject newHealthOrb = Instantiate(healthPrefab, bulletspawn.position, bulletspawn.rotation);
        	HealthTrigger HealthScript = newHealthOrb.GetComponent<HealthTrigger>();
        	HealthScript.health = healthScript;
	}
	Destroy(gameObject, 20f);
    }
    void Start()
    {
        // Get the NavMeshAgent component on the enemy
        agent = GetComponent<NavMeshAgent>();
	animator = GetComponent<Animator>();

        // Find the player object by tag
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
	if (!iswaiting && isshooting)
	{
		StartCoroutine(Shootevery3Seconds());
	}	
	 // Check if the player is within detection range
	float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= detectionRange && distance > 10f)
        {
	    // Move the enemy towards the player
            agent.SetDestination(player.position);
	    agent.isStopped = false;
        }
	else if(distance <= 10f)
	{
		agent.isStopped = true;
		FacePlayer();
	}
	
	if(distance <= 20f && distance >10f)
	{
		animator.SetBool("FiringWalk", true);
		animator.SetBool("Firing", false);
		isshooting = true;
	}
	else if(distance <= 10f)
	{
		animator.SetBool("Firing", true);
		animator.SetBool("FiringWalk", false);
		isshooting = true;
	}
	else
	{
		animator.SetBool("Firing", false);
		animator.SetBool("FiringWalk", false);
		isshooting = false;
	}
    }

    // Method to make the enemy face the player
    void FacePlayer()
    {
        // Calculate the direction from the enemy to the player
        Vector3 direction = player.position - transform.position;
        direction.y = 0;  // Keep the rotation on the Y axis 

        if (direction.sqrMagnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }
    IEnumerator Shootevery3Seconds()
    {
	if(isAlive)
	{
		iswaiting = true;
		GameObject newBullet = Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);
		bulletscript bullScript = newBullet.GetComponent<bulletscript>();
        	bullScript.HealthScript = healthScript;
		yield return new WaitForSeconds(3);
		iswaiting = false;
	}
    }
}
