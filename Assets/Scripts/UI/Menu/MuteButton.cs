using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
  public Toggle muteToggle; // Assign this in the inspector

  void Start()
  {
    if (MusicManager.Instance != null)
    {
      // Sync the toggle with the current mute state
      muteToggle.isOn = MusicManager.Instance.IsMusicMuted();

      // Add a listener to respond to user interaction
      muteToggle.onValueChanged.AddListener(OnMuteToggleChanged);
    }
    else
    {
      Debug.LogWarning("AudioManager not found in scene. Make sure it was loaded in a previous scene.");
    }
  }

  void OnMuteToggleChanged(bool isMuted)
  {
    if (MusicManager.Instance != null)
    {
      MusicManager.Instance.MuteMusic(isMuted);
    }
  }
}