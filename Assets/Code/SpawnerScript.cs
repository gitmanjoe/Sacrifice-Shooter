using UnityEngine;
using System.Collections;
public class SpawnerScript : MonoBehaviour
{
	private bool iswaiting = false;
	public GameObject enemyPrefab;
	public Transform player; 
	public GameObject HealthScript;

    // Update is called once per frame
    void Update()
    {
	    if (!iswaiting)
	    {
	    	StartCoroutine(SleepFor30Seconds());
	    }
    }
    IEnumerator SleepFor30Seconds()
    {
	iswaiting = true;
	yield return new WaitForSeconds(15);
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        enemyScript.player = player;
	enemyScript.healthScript = HealthScript;
	iswaiting = false;
    }
}
