using System.Collections;
using UnityEngine;

// Class to handle the cylinder collision event
public class CollisionDetector : MonoBehaviour
{
  // Delegate and event to notify the collision
  public delegate void CollisionEventHandler(Rigidbody cylinderRb);
  public static event CollisionEventHandler OnCylinderCollision;

  private Rigidbody cylinderRb;

  private void Start()
  {
    // Get the Rigidbody component attached to the GameObject
    cylinderRb = GetComponent<Rigidbody>();
  }

  private void OnCollisionEnter(Collision collision)
  {
    // Check if the collision is with the correct object (e.g., a cube)
    if (collision.gameObject.CompareTag("Cube"))
    {
      // Trigger the collision event and notify subscribers
      OnCylinderCollision?.Invoke(cylinderRb);
    }
  }
}
