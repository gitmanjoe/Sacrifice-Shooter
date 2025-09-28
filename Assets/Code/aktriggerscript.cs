using UnityEngine;

public class aktriggerscript : MonoBehaviour
{
    public GameObject gunControlScript;
    private void OnTriggerEnter(Collider other)
    {
	gunControlScript.GetComponent<GunControl>().assault_unlocked = true;
	Destroy(gameObject);
    }
}
