using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour, IClickable
{
    public GameObject startScreenPanel; // Assign the Start Screen Panel in the Inspector
    public WallSwitcher walls;  // Reference to the WallSwitcher script
    public Timerscript timer;
    public Image fadeImage;  // The image to handle the fade effect

    public AudioSource audioSource;  // Reference to the AudioSource component
    public AudioClip audioCueClip;  // Assign the audio cue clip in the Inspector
    public AudioClip backgroundMusicClip;  // Assign the background music clip in the Inspector

    public void Click()
    {
        StartGame();
    }

    public void StartGame()
    {
        startScreenPanel.SetActive(false);  // Hide the start screen
        walls.MovementActive(); // Enable wall switching
        timer.TurnTimerOn(); // Activate timer

        // Fade to black
        fadeImage.color = Color.black;
        fadeImage.gameObject.SetActive(true);

        // Play audio cue after 1 second
        Invoke("PlayAudioCue", 1f);
    }

    private void PlayAudioCue()
    {
        // Play the audio cue using the AudioSource and the AudioClip
        audioSource.clip = audioCueClip;
        audioSource.Play();

        // Invoke the background music after the audio cue ends
        Invoke("PlayBackgroundMusic", audioSource.clip.length);  // Wait for the cue to finish
    }

    private void PlayBackgroundMusic()
    {
        // Play the background music after the audio cue finishes
        audioSource.clip = backgroundMusicClip;
        audioSource.loop = true;  // Loop the background music
        audioSource.Play();

        // Disable the fade image once the background music starts
        fadeImage.gameObject.SetActive(false);
    }
}
