using UnityEngine;
using System.Collections;
public class bulletscript : MonoBehaviour
{
    public GameObject HealthScript;
    void Start()
    {
	StartCoroutine(SleepFor30Seconds());
    }
    IEnumerator SleepFor30Seconds()
    {
	yield return new WaitForSeconds(30);
	Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
	transform.position +=  transform.forward * 5f * Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider Other)
    {
	HealthScript.GetComponent<PlayerMovement>().health -= 2;		    
    }
}
