using UnityEngine;

public class snipertriggerscript : MonoBehaviour
{
    public GameObject gunControlScript;
    //public void Init(GameObject GunThingy)
    //{
    //    gunControlScript = newTarget;
    //}

    private void OnTriggerEnter(Collider other)
    {
	gunControlScript.GetComponent<GunControl>().sniper_unlocked = true;
	Destroy(gameObject);
    }
}
