using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
  public static MusicManager Instance;

  public AudioSource musicSource;

  [System.Serializable]
  public class SceneMusic
  {
    public string sceneName;
    public AudioClip musicClip;
  }

  public SceneMusic[] sceneMusicList;

  private string currentScene = "";
  private bool isMuted = false;

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
      SceneManager.sceneLoaded += OnSceneLoaded;
    }
    else
    {
      Destroy(gameObject);
    }
  }

  void OnDestroy()
  {
    SceneManager.sceneLoaded -= OnSceneLoaded;
  }

  void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
    PlayMusicForScene(scene.name);
  }

  void PlayMusicForScene(string sceneName)
  {
    if (sceneName == currentScene) return;

    currentScene = sceneName;

    foreach (var entry in sceneMusicList)
    {
      if (entry.sceneName == sceneName)
      {
        if (entry.musicClip != null && musicSource.clip != entry.musicClip)
        {
          musicSource.clip = entry.musicClip;
          musicSource.loop = true;
          musicSource.mute = isMuted;
          musicSource.Play();
        }
        return;
      }
    }

    // No music found for this scene
    musicSource.Stop();
  }

  public void MuteMusic(bool mute)
  {
    isMuted = mute;
    if (musicSource != null)
      musicSource.mute = mute;
  }

  public bool IsMusicMuted()
  {
    return isMuted;
  }
}