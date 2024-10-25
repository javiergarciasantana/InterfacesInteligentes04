using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
  public Text scoreText; // Referencia al componente Text

  private void Start()
  {
    // Inicializar el texto con la puntuación inicial
    UpdateScoreText(ScoreManagerMod.GetScore());

    // Suscribirse al evento de cambio de puntuación
    ScoreManagerMod.Instance.onScoreChanged.AddListener(UpdateScoreText);
  }

  private void OnDestroy()
  {
    // Asegurarse de desuscribirse para evitar fugas de memoria
    ScoreManagerMod.Instance.onScoreChanged.RemoveListener(UpdateScoreText);
  }

  private void UpdateScoreText(int newScore)
  {
    scoreText.text = "Score: " + newScore.ToString(); // Actualizar el texto con la nueva puntuación
  }
}
