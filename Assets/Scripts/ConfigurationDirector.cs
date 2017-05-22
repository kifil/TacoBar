using System.Collections.Generic;
using UnityEngine;

public class ConfigurationDirector : MonoBehaviour
{
	#region Preference Cache

	static Dictionary<string,float> cachedFloatProps = new Dictionary<string, float>();
	static Dictionary<string,string> cachedStringProps = new Dictionary<string, string>();
	static Dictionary<string,int> cachedIntProps = new Dictionary<string, int>();

	public static float GetFloat(string prefName, float defaultValue)
	{
		if (!cachedFloatProps.ContainsKey(prefName))
		{
			cachedFloatProps.Add(prefName, PlayerPrefs.GetFloat(prefName, defaultValue));
			PlayerPrefs.SetFloat(prefName, PlayerPrefs.GetFloat(prefName, defaultValue));
		}
		return cachedFloatProps[prefName];
	}

	public static void SetFloat(string prefName, float newValue)
	{
		PlayerPrefs.SetFloat(prefName, newValue);
		if (!cachedFloatProps.ContainsKey(prefName))
		{
			cachedFloatProps.Add(prefName, newValue);
		}
		else
		{
			cachedFloatProps[prefName] = newValue;
		}
	}

	public static string GetString(string prefName, string defaultValue)
	{
		if (!cachedStringProps.ContainsKey(prefName))
		{
			cachedStringProps.Add(prefName, PlayerPrefs.GetString(prefName, defaultValue));
			PlayerPrefs.SetString(prefName, PlayerPrefs.GetString(prefName, defaultValue));
		}
		return cachedStringProps[prefName];
	}

	public static void SetString(string prefName, string newValue)
	{
		PlayerPrefs.SetString(prefName, newValue);
		if (!cachedStringProps.ContainsKey(prefName))
		{
			cachedStringProps.Add(prefName, newValue);
		}
		else
		{
			cachedStringProps[prefName] = newValue;
		}
	}

	public static int GetInt(string prefName, int defaultValue)
	{
		if (!cachedIntProps.ContainsKey(prefName))
		{
			cachedIntProps.Add(prefName, PlayerPrefs.GetInt(prefName, defaultValue));
			PlayerPrefs.SetInt(prefName, PlayerPrefs.GetInt(prefName, defaultValue));
		}
		return cachedIntProps[prefName];
	}

	public static void SetInt(string prefName, int newValue)
	{
		PlayerPrefs.SetInt(prefName, newValue);
		if (!cachedIntProps.ContainsKey(prefName))
		{
			cachedIntProps.Add(prefName, newValue);
		}
		else
		{
			cachedIntProps[prefName] = newValue;
		}
	}

	public static bool GetBool(string prefName, bool defaultValue)
	{
		return (GetInt(prefName, (defaultValue ? 1 : 0)) != 0);
	}

	public static void SetBool(string prefName, bool newValue)
	{
		SetInt(prefName, newValue ? 1 : 0);
	}
	#endregion

	#region Audio configuration settings

	/// <summary> Gets the default master volume. </summary>
	public static int DefaultMasterVolume { get { return 100; } }

	/// <summary> Gets the default music volume. </summary>
	public static int DefaultMusicVolume { get { return 100; } }

	/// <summary> Gets the default SFX volume. </summary>
	public static int DefaultSFXVolume { get { return 100; } }

	/// <summary> Gets or sets the master volume. </summary>
	public static int MasterVolume
	{
		get
		{
			return GetInt("Audio.MasterVolume", DefaultMusicVolume);
		}
		set
		{
			SetInt("Audio.MasterVolume", value);
		}
	}

	/// <summary> Gets or sets the music volume. </summary>
	public static int MusicVolume
	{
		get
		{
			return GetInt("Audio.MusicVolume", DefaultMusicVolume);
		}
		set
		{
			SetInt("Audio.MusicVolume", value);
		}
	}

	/// <summary> Gets or sets the SFX volume. </summary>
	public static int SFXVolume
	{
		get
		{
			return GetInt("Audio.SFXVolume", DefaultSFXVolume);
		}
		set
		{
			SetInt("Audio.SFXVolume", value);
		}
	}

	/// <summary> Restore the default settings. </summary>
	public static void RestoreDefaults()
	{
		MasterVolume = DefaultMasterVolume;
		MusicVolume = DefaultMusicVolume;
		SFXVolume = DefaultSFXVolume;
	}
    #endregion

}
