using UnityEngine;

public class SettingsPanelScript : MonoBehaviour
{
    public GameObject mmp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
	
    public void BackButtonPressed()
    {
	mmp.SetActive(true);
	gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
