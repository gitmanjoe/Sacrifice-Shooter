using UnityEngine;

public class Raycasting : MonoBehaviour
{
	public float akDamage = 10f;
	public float range = 100f;

	public Camera fpsCam;
	public GameObject impactEffect;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		RaycastHit hit;
		if(Physics.Raycast(fpsCam.transform.position + fpsCam.transform.forward, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);

			Enemy enemy = hit.transform.GetComponent<Enemy>();
			if(enemy != null)
			{
				enemy.TakeDamage(akDamage);
			}

			GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, 0.2f);
		}
	}
}
