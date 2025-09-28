using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public GameObject HealthScript;
    float total_distance = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	//total_distance += transform.forward * 5f * Time.deltaTime;
	transform.position +=  transform.forward * 5f * Time.deltaTime;
//	if (total_distance > 100f)
//	{
//		Destroy(gameObject);
//	}
    }
    
    private void OnTriggerEnter(Collider Other)
    {
	HealthScript.GetComponent<PlayerMovement>().health -= 2;		    
    }
}
