using System.Collections;
using UnityEngine;

// Class for Type 1 spider behavior
public class SpiderEggCollector : MonoBehaviour
{
  public GameObject eggTarget;

  private Rigidbody rb; // Rigidbody of this spider
  private Renderer renderer; // Renderer for color change

  private void Start()
  {
    rb = GetComponent<Rigidbody>();

  }

  private void OnEnable()
  {
    // Subscribe to collision events
    CubeCollisionSpiderController.SpiderEggCollector += HandleSpiderEggCollector;
  }

  private void OnDisable()
  {
    // Unsubscribe from collision events
    CubeCollisionSpiderController.SpiderEggCollector -= HandleSpiderEggCollector;
  }

  // Handle collision with Type 1 spiders (move towards egg targets)
  private void HandleSpiderEggCollector(GameObject spider)
  {
    StartCoroutine(TeleportTowardsTarget(rb, eggTarget.GetComponent<Rigidbody>()));
  }

  // Coroutine to move towards a specific target using Rigidbody
  private IEnumerator TeleportTowardsTarget(Rigidbody spiderRb, Rigidbody targetRb)
  {
    while (Vector3.Distance(spiderRb.position, targetRb.position) > 0.1f)
    {
      // Calculate the new position using Rigidbody's MovePosition
      Vector3 newPosition = targetRb.position;
      spiderRb.MovePosition(newPosition);
      yield return null; // Wait for the next frame
    }
  }


}
