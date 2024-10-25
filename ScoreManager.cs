using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  public static int score = 0;

  // Método para aumentar la puntuación
  public static void AddScore(int points, string name)
  {
    score += points; // Aumenta la puntuación
    Debug.Log(name + " Ha recogido un huevo" + " | Puntuación actual: " + score); // Muestra la puntuación en la consola
  }

  public static int GetScore()
  {
    return score;
  }
}
