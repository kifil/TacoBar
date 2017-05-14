using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingSliders : MonoBehaviour
{
	public Slider masterSlider;
	public Slider musicSlider;
	public Slider sfxSlider;
	public Text masterText;
	public Text musicText;
	public Text sfxText;

	private bool isDirty;

	public void Start()
	{
		SetSlidersFromSavedSettings();
		SetTextFromSliders();
		isDirty = false;
	}

	public void SetTextFromSliders()
	{
		masterText.text = masterSlider.value.ToString();
		musicText.text = musicSlider.value.ToString();
		sfxText.text = sfxSlider.value.ToString();
		isDirty = true;
	}

	public void SetSlidersFromSavedSettings()
	{
		masterSlider.value = ConfigurationDirector.MasterVolume;
		musicSlider.value = ConfigurationDirector.MusicVolume;
		sfxSlider.value = ConfigurationDirector.SFXVolume;
	}

	public void Save()
	{
		ConfigurationDirector.MasterVolume = (int)masterSlider.value;
		ConfigurationDirector.MusicVolume = (int)musicSlider.value;
		ConfigurationDirector.SFXVolume = (int)sfxSlider.value;
		isDirty = false;
	}

	public void RestoreDefaults()
	{
		ConfigurationDirector.RestoreDefaults();
		SetSlidersFromSavedSettings();
		SetTextFromSliders();
		isDirty = false;
	}

	public void Back()
	{
		// Prompt user if settings aren't saved
		if (isDirty)
		{
			Debug.Log("Settings are not saved! Are you sure you want to go back?");
		}

		SceneManager.LoadScene(0);
	}
}
