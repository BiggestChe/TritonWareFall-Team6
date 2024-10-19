using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SimonButton[] buttons; // Array of buttons
    private List<int> sequence = new List<int>(); // Sequence of button indices
    private List<int> playerInput = new List<int>(); // Player's input
    public float flashDuration = 0.5f;
    public float timeBetweenFlashes = 0.5f;

    private bool playerTurn = false;
    private int currentStep = 0;

    void Start()
    {
        StartCoroutine(StartNewRound());
    }

    private IEnumerator StartNewRound()
    {
        playerInput.Clear();
        AddToSequence();
        yield return StartCoroutine(PlaySequence());
        playerTurn = true;
        currentStep = 0;
    }

    private void AddToSequence()
    {
        int randomIndex = Random.Range(0, buttons.Length);
        sequence.Add(randomIndex);
        Debug.Log(sequence); // For debugging purposes
    }

    private IEnumerator PlaySequence()
    {
        foreach (int index in sequence)
        {
            buttons[index].Flash(flashDuration);
            yield return new WaitForSeconds(flashDuration + timeBetweenFlashes);
        }
    }

    public void ButtonPressed(int index)
    {
        if (!playerTurn) return; // Only allow button press during player's turn

        playerInput.Add(index); // Add the button pressed to player's input
        buttons[index].Flash(flashDuration); // Flash the button when pressed

        // Check if the player's input matches the sequence
        if (playerInput[currentStep] == sequence[currentStep])
        {
            currentStep++;

            // If player successfully finishes the current sequence, start a new round
            if (currentStep == sequence.Count)
            {
                playerTurn = false;
                StartCoroutine(StartNewRound());
                Debug.Log("You Win");
            }
        }
        else
        {
            // Handle failure: turn all buttons red
            StartCoroutine(HandleFailure());
        }
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
