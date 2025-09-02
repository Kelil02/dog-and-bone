using UnityEngine;

public class QuickResetVolume : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("MasterVolume");
        PlayerPrefs.Save();
        Destroy(this);
    }
}
