using UnityEngine;

public class snipertriggerscript : MonoBehaviour
{
    public GameObject gunControlScript;
    private void OnTriggerEnter(Collider other)
    {
	gunControlScript.GetComponent<GunControl>().sniper_unlocked = true;
	Destroy(gameObject);
    }
}
