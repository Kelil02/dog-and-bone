using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel; 

    void Start()
    {
    
        Cursor.visible = true; 
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("MasterVolume");
PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        if (settingsPanel) settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel) settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        Debug.Log("Quit called (Editor only). Build to exit app.");
#else
        Application.Quit();
#endif
    }
}
