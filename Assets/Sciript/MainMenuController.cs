using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Tooltip("Nama scene game yang akan dimuat, harus sama persis dengan nama file scene")]
    [SerializeField] private string gameSceneName = "Game";

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        // Quit tidak akan terlihat efeknya di Editor, hanya jalan di build
    }
}