using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    private const string VOLUME_KEY = "MasterVolume";

    private void Start()
    {
        // Load volume tersimpan, default 0.75 (75%)
        float savedVolume = PlayerPrefs.GetFloat(VOLUME_KEY, 0.75f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);

        // Daftarkan listener lewat kode, otomatis dipanggil tiap slider digeser
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SetVolume(float value)
    {
        // Slider 0.0001 - 1, dikonversi ke desibel (logaritmik)
        float dB = Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f;
        audioMixer.SetFloat("MasterVolume", dB);
        PlayerPrefs.SetFloat(VOLUME_KEY, value);
    }
}