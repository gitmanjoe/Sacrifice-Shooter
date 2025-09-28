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
    // Update is called once per frame
    void Update()
    {
        
    }
}
