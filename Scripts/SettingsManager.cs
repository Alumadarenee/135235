using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Slider volumeSlider;

    private Resolution[] resolutions;

    void Start()
    {
        // Populate resolution dropdown with available screen resolutions
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        foreach (var resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        // Load saved settings
        LoadSettings();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, fullscreenToggle.isOn);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        int resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", resolutions.Length - 1);
        resolutionDropdown.value = resolutionIndex;
        SetResolution(resolutionIndex);

        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        float volume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = volume;
        SetVolume(volume);
    }
}
