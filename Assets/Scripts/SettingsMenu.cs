using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer; // assign GameMixer
    [SerializeField] private Slider volumeSlider;    // assign VolumeSlider
    const string PrefKey = "MasterVolume";

    void Start()
    {
        if (volumeSlider)
        {
            volumeSlider.wholeNumbers = false;
            volumeSlider.minValue = 0.01f;
            volumeSlider.maxValue = 1f;
        }
        float v = PlayerPrefs.GetFloat(PrefKey, 1f);
        if (volumeSlider) volumeSlider.value = v;
        Apply(v);
    }

    public void OnSliderChanged(float v)
    {
        Apply(v);
        PlayerPrefs.SetFloat(PrefKey, v);
        PlayerPrefs.Save();
    }

    private void Apply(float linear)
    {
        AudioListener.volume = Mathf.Clamp01(linear);

        float clamped = Mathf.Clamp(linear, 0.01f, 1f);
        float dB = Mathf.Log10(clamped) * 20f;
        masterMixer.SetFloat("MasterVolume", dB);
    }
}
