using UnityEngine;
using UnityEngine.Audio;

public class VolumeInitializer : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    const string PrefKey = "MasterVolume";

    void Awake()
    {
        float v = PlayerPrefs.GetFloat(PrefKey, 1f);
        float dB = (v <= 0.0001f) ? -80f : Mathf.Log10(Mathf.Clamp(v, 0.0001f, 1f)) * 20f;
        masterMixer.SetFloat("MasterVolume", dB);
    }
}
