using UnityEngine;

public class CreditsMenuScript : MonoBehaviour
{
    public GameObject mmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void BackButtonClick()
    {
	mmp.SetActive(true);
	gameObject.SetActive(false);	
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
