using UnityEngine;
using UnityEngine.Audio;
public class SettingsPanelScript : MonoBehaviour
{
    public GameObject mmp;
    public AudioMixer mixer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
	
    public void BackButtonPressed()
    {
	mmp.SetActive(true);
	gameObject.SetActive(false);
    }
    public void SetVolume(float vol)
    {
	mixer.SetFloat("volume",vol);
    }
    public void SetSensitivity(float sens)
    {
	    PlayerPrefs.SetFloat("Sensitivity", sens);
    }
    public void SetQuality(int qualityIndex)
    {
	    QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
	    Screen.fullScreen = isFullscreen;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
