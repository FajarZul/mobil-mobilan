using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    public float timeLeft = 60f;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI resultText;

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded)
            return;

        // countdown
        timeLeft -= Time.deltaTime;

        // update timer text
        timerText.text = "Time : " + Mathf.Ceil(timeLeft).ToString();

        // waktu habis
        if (timeLeft <= 0)
        {
            timeLeft = 0;

            GameOver();
        }
    }

    // MENANG
    public void WinGame()
    {
        gameEnded = true;

        resultText.text = "YOU WIN!";

        // pindah level setelah 3 detik
        Invoke("NextLevel", 3f);
    }

    // KALAH
    void GameOver()
    {
        gameEnded = true;

        resultText.text = "GAME OVER";

        // restart level setelah 3 detik
        Invoke("RestartLevel", 3f);
    }

    // NEXT LEVEL
    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        int nextScene = currentScene + 1;

        // cek apakah next scene ada
        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("SEMUA LEVEL SELESAI");
        }
    }

    // RESTART LEVEL
    public void RestartLevel()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}