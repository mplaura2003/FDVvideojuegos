using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("✅ StartGame() ejecutado"); // mensaje visible en consola
        SceneManager.LoadScene("GameScene");
    }
}
