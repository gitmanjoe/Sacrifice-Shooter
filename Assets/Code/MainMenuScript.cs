using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuScript : MonoBehaviour
{
	public GameObject smp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		
    }

    public void PlayButtonClicked()
    {
	SceneManager.LoadScene("Scene", LoadSceneMode.Single); 
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
