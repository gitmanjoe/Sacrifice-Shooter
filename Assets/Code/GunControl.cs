using UnityEngine;

public class GunControl : MonoBehaviour
{
	Vector3 baseRevolver = new Vector3(1.42999995f, -1.10099995f, 1.67000055f);
	Vector3 baseShotgun  = new Vector3(1.5f, -0.939999998f, 1.49000001f);
	Vector3 baseAK       = new Vector3(1.39999998f, -1.32000005f, 1.67000055f);
	Vector3 baseSniper   = new Vector3(2.03999996f, -1.32000005f, 2.24000001f);

	[SerializeField]
	public int startingGun = 1;
	[SerializeField]
	public int currentGun;

	public GameObject revolver;
	public GameObject shotgun;
	public GameObject ak;
	public GameObject sniper;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       currentGun = startingGun;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
	{
		currentGun = 1;
		revolver.SetActive(true);
		shotgun.SetActive(false);
		ak.SetActive(false);
		sniper.SetActive(false);
	}
	if(Input.GetKeyDown(KeyCode.Alpha2))
	{
		currentGun = 2;
		revolver.SetActive(false);
		shotgun.SetActive(true);
		ak.SetActive(false);
		sniper.SetActive(false);
	}
	if(Input.GetKeyDown(KeyCode.Alpha3))
	{
		currentGun = 3;
		revolver.SetActive(false);
		shotgun.SetActive(false);
		ak.SetActive(true);
		sniper.SetActive(false);
	}
	if(Input.GetKeyDown(KeyCode.Alpha4))
	{
		currentGun = 4;
		revolver.SetActive(false);
		shotgun.SetActive(false);
		ak.SetActive(false);
		sniper.SetActive(true);
	}
    }
}
