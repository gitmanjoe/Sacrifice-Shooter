using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;  // Reference to the player's position
    private NavMeshAgent agent;  // Reference to the NavMeshAgent
    public float detectionRange = 10f;  // Range within which the enemy will follow the player

    private Coroutine firingCoroutine;

    public bool isFiring;
    public float range = 100f;

    public Camera fpsCam;
    public GameObject impactEffect;

    private Animator animator;
    
    public float health = 50f;
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
	Destroy(gameObject, 20f);
    }
    void Start()
    {
        // Get the NavMeshAgent component on the enemy
        agent = GetComponent<NavMeshAgent>();
	animator = GetComponent<Animator>();

        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
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
		isFiring = true;
		StartFiringCoroutine();
		animator.SetBool("FiringWalk", true);
		animator.SetBool("Firing", false);
	}
	else if(distance <= 10f)
	{
		isFiring = true;
		StartFiringCoroutine();
		animator.SetBool("Firing", true);
		animator.SetBool("FiringWalk", false);
	}
	else
	{
		isFiring = false;
		animator.SetBool("Firing", false);
		animator.SetBool("FiringWalk", false);
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

    // Start the firing pulse coroutine if enemy is firing
    void StartFiringCoroutine()
    {
        if (firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FiringPulse());
        }
    }

    // Stop the firing pulse coroutine not firing
    void StopFiringCoroutine()
    {
        if (firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    // Coroutine that sends a pulse every 0.5 seconds while firing
    IEnumerator FiringPulse()
    {
        while (true)
        {
            FireWeapon();

            yield return new WaitForSeconds(0.5f);
        }
    }

    void FireWeapon()
    {
	    RaycastHit hit;
		if(Physics.Raycast(transform.position + transform.forward, transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);

			Raycasting player = hit.transform.GetComponent<Raycasting>();
			if(player != null)
			{
				player.TakeDamage(20f);
			}

			GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, 0.2f);
		}

    }
}
