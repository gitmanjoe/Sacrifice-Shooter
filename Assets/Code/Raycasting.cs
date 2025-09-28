using UnityEngine;
using System.Collections;
public class Raycasting : MonoBehaviour
{
	public float baseDamage = 10f;
	public float range = 100f;
	public Animator revolveranimator;
	public Animator shotgunanimator;
	public Animator sniperanimator;
	public Animator assaultanimator;
	public GameObject gunControlScript;
	public GameObject healthScript;
	public Camera fpsCam;
	public GameObject impactEffect;
	public float fireRate = 0.1f;   // Time in seconds between shots
        private float nextFireTime = 0f;
	private bool iswaiting = false;
	private AudioSource audioSource;
	//public void TakeDamage(float amount)
    	//{
        //	 healthScript.GetComponent<PlayerMovement>().health -= (int)amount;
    	//}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
        	// Check if the fire button is held down and enough time has passed since the last shot
        	if (Input.GetButton("Fire1") && Time.time >= nextFireTime && gunControlScript.GetComponent<GunControl>().currentGun == 3)
        	{
        	    Shoot(); // Call the firing function
        	    nextFireTime = Time.time + fireRate; // Set the next allowed firing time
        	}
		else if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
    	}

	void Shoot()
	{
		float gundmg = 0f;
		int gunnum = gunControlScript.GetComponent<GunControl>().currentGun;
		switch (gunnum)
		{
			case 1:
				revolveranimator.SetTrigger("Shoot");
				gundmg = baseDamage;
				break;
			case 2:
				shotgunanimator.SetTrigger("Shoot");
				gundmg = 2*baseDamage;
				break;
			case 3:
				assaultanimator.SetTrigger("Shoot");
				gundmg = 3*baseDamage;
				break;
			case 4:
				sniperanimator.SetTrigger("Shoot");
				gundmg= 5*baseDamage;
				break;
		}
		audioSource.Play();
		healthScript.GetComponent<PlayerMovement>().health -= 1;
		RaycastHit hit;
		if(Physics.Raycast(fpsCam.transform.position + fpsCam.transform.forward, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);

			Enemy enemy = hit.transform.GetComponent<Enemy>();
			if(enemy != null)
			{
				enemy.TakeDamage(gundmg);
			}

			GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, 0.2f);
		}
	}
	 
	IEnumerator Shootevery0_1Seconds()
	{
		iswaiting = true;
		yield return new WaitForSeconds(0.1f);
		Shoot();
		iswaiting = false;
    	}
}
