using System.Collections;
using UnityEngine;

// Class for Type 2 spheres
public class Type2Sphere : MonoBehaviour
{
  public float speed = 5f; // Movement speed

  private Rigidbody rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void OnEnable()
  {
    // Subscribe to the cylinder collision event
    CollisionDetector.OnCylinderCollision += HandleCylinderCollision;
  }

  private void OnDisable()
  {
    // Unsubscribe from the event to avoid errors when the object is deactivated
    CollisionDetector.OnCylinderCollision -= HandleCylinderCollision;
  }

  // Callback to handle the cylinder collision event
  private void HandleCylinderCollision(Rigidbody cylinderRb)
  {
    // Start the coroutine to move towards the cylinder
    StartCoroutine(MoveTowardsTarget(cylinderRb));
  }

  // Coroutine to move the sphere towards a target using Rigidbody
  private IEnumerator MoveTowardsTarget(Rigidbody targetObj)
  {
    while (Vector3.Distance(rb.position, targetObj.position) > 0.1f)
    {
      // Calculate the new position using MovePosition
      Vector3 newPosition = Vector3.MoveTowards(rb.position, targetObj.position, speed * Time.deltaTime);
      rb.MovePosition(newPosition);
      yield return null; // Wait for the next frame
    }
  }
}
