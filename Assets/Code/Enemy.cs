using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;  // Reference to the player's position
    private NavMeshAgent agent;  // Reference to the NavMeshAgent
    public float detectionRange = 10f;  // Range within which the enemy will follow the player
    public bool isDetected = false;

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
	    ExitIdle();
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
	}
	else if(distance <= 10f)
	{
		animator.SetBool("Firing", true);
		animator.SetBool("FiringWalk", false);
	}
	else
	{
		animator.SetBool("Firing", false);
		animator.SetBool("FiringWalk", false);
	}
    }

    // Method to make the enemy face the player using Quaternion
    void FacePlayer()
    {
        // Calculate the direction from the enemy to the player
        Vector3 direction = player.position - transform.position;
        direction.y = 0;  // Keep the rotation on the Y axis (don't rotate up/down)

        // If the direction is not zero (to avoid errors), rotate towards the player
        if (direction.sqrMagnitude > 0.1f)
        {
            // Use Quaternion.LookRotation to calculate the rotation towards the player
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // Apply the rotation to the enemy's transform
            transform.rotation = targetRotation;
        }
    }

    void ExitIdle()
    {
	    if(!isDetected)
	    {
		    animator.SetTrigger("NoIdle");
	    }
	    isDetected = true;
	    
    }
}
