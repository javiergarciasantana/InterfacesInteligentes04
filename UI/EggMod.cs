using UnityEngine;

public class EggMod : MonoBehaviour
{
    public float respawnTime = 3f; // Time before the egg respawns

    // Method to deactivate and respawn the egg
    public void Collect()
    {
        gameObject.SetActive(false); // Deactivate the egg
        Invoke("Respawn", respawnTime); // Schedule respawn after specified time
    }

    private void Respawn()
    {
        // Choose a new random position for the egg
        transform.position = new Vector3(Random.Range(-3f, 3f), 0.5f, Random.Range(-3f, 3f));
        gameObject.SetActive(true); // Activate the egg again
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check for collisions with spiders and cube
        if (collision.gameObject.CompareTag("Type1Spider"))
        {
            ScoreManagerMod.AddScore(5, collision.gameObject.tag); // Update score for Type 1 Spider
            Collect(); // Call Collect() to deactivate the egg
        }
        else if (collision.gameObject.CompareTag("Type2Spider"))
        {
            ScoreManagerMod.AddScore(10, collision.gameObject.tag); // Update score for Type 2 Spider
            Collect(); // Call Collect() to deactivate the egg
        }
        else if (collision.gameObject.CompareTag("Cube"))
        {
            ScoreManagerMod.AddScore(20, collision.gameObject.tag); // Update score for Cube
            Collect(); // Call Collect() to deactivate the egg
        }
    }
}
