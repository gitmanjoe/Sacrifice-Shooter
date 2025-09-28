using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
	public GameObject PauseMenuUI;
	public static bool GamePaused = false;
	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.Escape)){
			if(GamePaused){
				Resume();
			}
			else{
				Pause();
			}
		}
	}
	public void ResumeButtonClicked()
	{
		Resume();
	}
	public void QuitButtonClicked()
	{
		SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);  
	}
	void Resume() 
	{
		Cursor.lockState = CursorLockMode.Locked;
		Debug.Log("Running");
		PauseMenuUI.SetActive(false);
		GamePaused = false;
		Time.timeScale = 1f;
	}
	void Pause()
	{
		Cursor.lockState = CursorLockMode.None; 
		PauseMenuUI.SetActive(true);
		GamePaused = true;
		Time.timeScale = 0f;
	}
}
