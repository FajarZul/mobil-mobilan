using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Sudah ada MusicPlayer lain (misal balik ke MainMenu), hancurkan yang baru
            Destroy(gameObject);
        }
    }
}