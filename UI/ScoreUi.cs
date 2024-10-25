using UnityEngine;
using TMPro; // Ensure you include this

public class ScoreUi : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro component

    private void Start()
    {
        // Ensure the ScoreManager instance is initialized
        if (ScoreManagerMod.Instance == null)
        {
            Debug.LogError("ScoreManagerMod instance is null. Please ensure it is initialized.");
            return;
        }

        // Set initial score display
        UpdateScoreDisplay(ScoreManagerMod.GetScore());

        // Subscribe to score change events
        ScoreManagerMod.Instance.onScoreChanged.AddListener(UpdateScoreDisplay);
    }

    private void OnDestroy()
    {
        // Unsubscribe from score change events to prevent memory leaks
        if (ScoreManagerMod.Instance != null)
        {
            ScoreManagerMod.Instance.onScoreChanged.RemoveListener(UpdateScoreDisplay);
        }
    }

    // Method to update the UI with the current score
    private void UpdateScoreDisplay(int currentScore)
    { 
      if (currentScore == 100) {
        scoreText.text = "¡Muy bien!"; // Update the text with the current score 
        return;
      }
      //yield WaitForSeconds (2);
      scoreText.text = "Puntuación: " + currentScore; // Update the text with the current score
    }
}
