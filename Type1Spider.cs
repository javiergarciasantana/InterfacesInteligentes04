using System.Collections;
using UnityEngine;

// Class for Type 1 spider behavior
public class Type1Spider : MonoBehaviour
{
  public GameObject target; // The target to move towards when triggered
  public float speed = 5f; // Movement speed
  public Color collisionColor = Color.red; // Color to change to on collision
  public GameObject eggTarget; // The target eggs to move towards when the cube collides

  private Rigidbody rb; // Rigidbody of this spider
  private Renderer renderer; // Renderer for color change

  private void Start()
  {
    rb = GetComponent<Rigidbody>();

    // Log warnings if the targets are not set in the inspector
    if (target == null)
    {
      Debug.LogError("Target not assigned in inspector for " + gameObject.name);
    }

    if (eggTarget == null)
    {
      Debug.LogError("Egg target not assigned in inspector for " + gameObject.name);
    }
  }

  private void OnEnable()
  {
    // Subscribe to collision events
    MultipleCollisionDetector.OnType1Collision += HandleType1Collision;
    MultipleCollisionDetector.OnType2Collision += HandleType2Collision;
  }

  private void OnDisable()
  {
    // Unsubscribe from collision events
    MultipleCollisionDetector.OnType1Collision -= HandleType1Collision;
    MultipleCollisionDetector.OnType2Collision -= HandleType2Collision;
  }

  // Handle collision with Type 1 spiders (move towards egg targets)
  private void HandleType1Collision(GameObject spider)
  {
    StartCoroutine(MoveTowardsTarget(rb, eggTarget.GetComponent<Rigidbody>()));
  }

  // Handle collision with Type 2 spiders (move towards the specified target)
  private void HandleType2Collision(GameObject spider)
  {
    StartCoroutine(MoveTowardsTarget(rb, target.GetComponent<Rigidbody>()));
  }

  // Coroutine to move towards a specific target using Rigidbody
  private IEnumerator MoveTowardsTarget(Rigidbody spiderRb, Rigidbody targetRb)
  {
    while (Vector3.Distance(spiderRb.position, targetRb.position) > 0.1f)
    {
      // Calculate the new position using Rigidbody's MovePosition
      Vector3 newPosition = Vector3.MoveTowards(spiderRb.position, targetRb.position, speed * Time.deltaTime);
      spiderRb.MovePosition(newPosition);
      yield return null; // Wait for the next frame
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("GreyEgg") || collision.gameObject.CompareTag("WeirdEgg"))
    {
      // Find all game objects with the "Red" tag
      GameObject[] redObjects = GameObject.FindGameObjectsWithTag("Red");
      
      // Loop through each object and change their color
      foreach (GameObject redObject in redObjects)
      {
        Renderer redRenderer = redObject.GetComponent<Renderer>();
        if (redRenderer != null) // Check if the renderer exists
        {
          redRenderer.material.color = collisionColor;
        }
        else
        {
          Debug.LogWarning($"No Renderer component found on {redObject.name}.");
        }
      }
    }
  }
}
