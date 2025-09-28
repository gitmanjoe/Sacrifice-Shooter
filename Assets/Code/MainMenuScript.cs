using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuScript : MonoBehaviour
{
    public GameObject smp;
    public GameObject cmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		
    }

    public void PlayButtonClicked()
    {
	SceneManager.LoadScene("City-Level", LoadSceneMode.Single); 
    }

    public void CreditsButtonClicked()
    {
	cmp.SetActive(true);
	gameObject.SetActive(false);	
    }

    public void SettingsButtonClicked()
    {
	smp.SetActive(true);
	gameObject.SetActive(false);	
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
