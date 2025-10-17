using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    [Header("Buttons")]
    public Button restartButton;
    
    void Awake()
    {
        if (restartButton)
            restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        Debug.Log("Reiniciando partida...");
        SceneManager.LoadScene("MainMenu"); // nombre de tu escena de juego
    }


}
