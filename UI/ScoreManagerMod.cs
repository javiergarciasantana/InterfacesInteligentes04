using UnityEngine;
using UnityEngine.Events;

public class ScoreManagerMod : MonoBehaviour
{
  // Singleton instance
  public static ScoreManagerMod Instance { get; private set; }

  public static int score = 0;

  // Event to notify listeners about score changes
  public UnityEvent<int> onScoreChanged = new UnityEvent<int>();

  private void Awake()
  {
    // Ensure only one instance of ScoreManager exists
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject); // Destroy duplicate instances
    }
    else
    {
      Instance = this; // Set the singleton instance
      DontDestroyOnLoad(gameObject); // Keep the ScoreManager between scenes
    }
  }

  // Method to increase the score
  public static void AddScore(int points, string name)
  {
    if (Instance == null) return; // Safety check to ensure Instance is not null

    score += points; // Increase the score
    Debug.Log($"{name} ha recogido un huevo | Puntuación actual: {score}"); // Display score in console

    // Notify listeners about the score change
    Instance.onScoreChanged.Invoke(score);
  }

  // Method to get the current score
  public static int GetScore()
  {
    return score;
  }

  // Method to reset the score
  public static void ResetScore()
  {
    if (Instance == null) return; // Safety check

    score = 0; // Reset the score
    Debug.Log("La puntuación ha sido reiniciada."); // Notify in console
    Instance.onScoreChanged.Invoke(score); // Notify listeners about the score reset
  }
}
