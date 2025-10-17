using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool IsPaused { get; private set; }

    [Header("Panels")]
    public GameObject backgroundPanel; 
    public GameObject pausePanel;      
    public GameObject restartPanel;   

    [Header("Buttons")]
    public Button pauseButton;         // Botón Pausar
    public Button resumeButton;        // Botón Continuar
    public Button restartButton;       // Botón Reiniciar

    [Header("Input")]
    public KeyCode toggleKey = KeyCode.Escape;

    void Awake()
    {
        // Estado inicial del juego
        Time.timeScale = 1f;
        AudioListener.pause = false;
        IsPaused = false;

        // Ocultar paneles al inicio
        if (pausePanel) pausePanel.SetActive(false);
        if (restartPanel) restartPanel.SetActive(false);

        // Asignar listeners a botones si existen
        if (pauseButton) pauseButton.onClick.AddListener(Pause);
        if (resumeButton) resumeButton.onClick.AddListener(Resume);
        if (restartButton) restartButton.onClick.AddListener(Restart);
    }

    void Update()
    {
        // Alternar pausa con tecla Esc
        if (Input.GetKeyDown(toggleKey))
        {
            if (IsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        if (IsPaused) return;
        IsPaused = true;

        Time.timeScale = 0f;           
        AudioListener.pause = true;    

        if (pausePanel) pausePanel.SetActive(true);
        if (pauseButton) pauseButton.gameObject.SetActive(false);
    }

    public void Resume()
    {
        if (!IsPaused) return;
        IsPaused = false;

        Time.timeScale = 1f;
        AudioListener.pause = false;

        if (pausePanel) pausePanel.SetActive(false);
        if (pauseButton) pauseButton.gameObject.SetActive(true);
        if (restartPanel) restartPanel.SetActive(false);
    }

    public void Restart()
    {
    	Debug.Log("Cargando escena MainMenu...");

    	// Antes de cambiar de escena, restablecemos el tiempo y audio
    	IsPaused = false;
    	Time.timeScale = 1f;
    	AudioListener.pause = false;

    	// Cargar la escena del menú principal
    	SceneManager.LoadScene("MainMenu");
    }

}