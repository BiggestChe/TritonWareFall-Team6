using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SimonButton[] buttons; // Array of buttons
    private List<int> sequence = new List<int>(); // Sequence of button indices
    private List<int> playerInput = new List<int>(); // Player's input
    public float flashDuration = 0.5f; // Duration for each button flash
    public float timeBetweenFlashes = 0.5f; // Delay between flashes

    private bool playerTurn = false; //player turn
    private int currentStep = 0; // Current step in the sequence

    public GameObject hiddenFile; // Hidden file GameObject to activate

    public GameObject SimonSays;

    void Start()
    {
        StartCoroutine(StartNewRound());
    }

    public IEnumerator StartNewRound()
    {
        playerInput.Clear();
        sequence.Clear(); // Clear the previous sequence

        // Generate a sequence with a set number of steps (e.g., 6 steps)
        for (int i = 0; i < 6; i++)
        {
            AddToSequence();
        }

        // Start the sequence playback
        yield return StartCoroutine(PlaySequence());

        // Allow the player to start interacting after the sequence
        playerTurn = true;
        currentStep = 0;
    }

    private void AddToSequence()
    {
        int randomIndex = UnityEngine.Random.Range(0, buttons.Length); // Randomly select a button index
        sequence.Add(randomIndex);
    }

private IEnumerator PlaySequence()
{
    // Phase 1: Play the entire sequence (without waiting for player input yet)
    foreach (int index in sequence)
    {
        buttons[index].Flash(flashDuration); // Flash the button

        yield return new WaitForSeconds(flashDuration + timeBetweenFlashes); // Wait for the flash and delay before the next flash
    }

    playerTurn = true; // Now allow the player to start inputting
    currentStep = 0;
}

    private IEnumerator WaitForPlayerInput(int index)
    {
        while (playerTurn)
        {
            // Check if the player has pressed the correct button
            if (playerInput.Count > currentStep)
            {
                if (playerInput[currentStep] == index)
                {
                    currentStep++;
                    yield break; // Move to the next button
                }
                else
                {
                    // Wrong button pressed
                    StartCoroutine(HandleFailure());
                    yield break;
                }
            }
            yield return null; // Wait for the next frame
        }
    }

public void OnButtonPressed(int index)
{
    if (!playerTurn) return; // Only allow button press during the player's turn

    playerInput.Add(index); // Add the pressed button to player's input
    buttons[index].Flash(flashDuration); // Flash the button to provide feedback

    // Check if the player's input matches the sequence at the current step
    if (playerInput[currentStep] == sequence[currentStep])
    {
        currentStep++; // Player got the correct button, move to the next step

        // If the player has completed the sequence, end their turn
        if (currentStep == sequence.Count)
        {
            playerTurn = false;
            Debug.Log("Player completed the sequence!");
            Destroy(SimonSays);

            ShowHiddenFile(); // Show the hidden file or reward
        }
    }
    else
    {
        // Player pressed the wrong button, handle failure
        StartCoroutine(HandleFailure());
    }
}


    private void ShowHiddenFile()
    {
        hiddenFile.SetActive(true); // Activate the hidden file GameObject
    }

    private IEnumerator HandleFailure()
    {
        // Turn all buttons red
        foreach (SimonButton button in buttons)
        {
            button.SetButtonColor(Color.red);
        }

        // Wait for 1 second before resetting the game
        yield return new WaitForSeconds(1f);

        // Reset buttons to their original color
        foreach (SimonButton button in buttons)
        {
            button.SetButtonColor(button.buttonColor); // Restore to original color
        }

        // Restart the game
        playerTurn = false;
        StartCoroutine(StartNewRound());
    }
}
