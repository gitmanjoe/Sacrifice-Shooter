using UnityEngine;

public class HealthTrigger : MonoBehaviour
{
    public GameObject health; 
    private void OnTriggerEnter(Collider Other)
    {
	health.GetComponent<PlayerMovement>().health += 15;
	Debug.Log(health.GetComponent<PlayerMovement>().health);
    }
}
