using UnityEngine;

public class shotguntriggerscript : MonoBehaviour
{
    public GameObject gunControlScript;
    private void OnTriggerEnter(Collider other)
    {
	gunControlScript.GetComponent<GunControl>().shotgun_unlocked = true;
	Destroy(gameObject);
    }
}
