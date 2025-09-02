using UnityEngine;
using UnityEngine.Audio;

public class ResetVolumeOnce : MonoBehaviour
{
    public AudioMixer mixer;     

    void Start()
    {
        PlayerPrefs.DeleteKey("MasterVolume");
        PlayerPrefs.Save();

        // makes mixer back to 0 
        if (mixer) mixer.SetFloat("MasterVolume", 0f);
        AudioListener.volume = 1f;

        Debug.Log("MasterVolume reset to 0 dB. Remove ResetVolumeOnce after this run.");
    }
}
