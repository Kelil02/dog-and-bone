using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private AudioSource goalSfx; 
    [SerializeField] private AudioSource music;    

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy() => SceneManager.sceneLoaded -= OnSceneLoaded;

    void Start()
    {
        EnsureMusic();
        if (IsGameScene() && music && !music.isPlaying) music.Play();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EnsureMusic();
        if (IsGameScene() && music && !music.isPlaying) music.Play();
    }

    void EnsureMusic()
    {
        if (music == null)
        {
            var go = GameObject.FindGameObjectWithTag("Music");
            if (go) music = go.GetComponent<AudioSource>();
        }
    }

    bool IsGameScene() => SceneManager.GetActiveScene().name == "Game";

    public void Win()
    {
        if (music) music.Stop();
        if (goalSfx) goalSfx.Play();
        if (winPanel) winPanel.SetActive(true);
        Cursor.visible = true;
    }

    public void GameOver()
    {
        if (music) music.Stop();
        if (losePanel) losePanel.SetActive(true);
        Cursor.visible = true;
    }

    public void ReloadLevel()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}
