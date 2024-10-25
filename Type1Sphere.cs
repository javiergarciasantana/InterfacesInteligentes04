using System.Collections;
using UnityEngine;

// Class for Type 1 spheres
public class Type1Sphere : MonoBehaviour
{
  public GameObject targetType2; // Type 2 sphere towards which Type 1 spheres will move
  public float speed = 5f; // Movement speed

  private Rigidbody rb;
  private Rigidbody rb_2;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb_2 = targetType2.GetComponent<Rigidbody>();
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
    // Start the coroutine to move towards targetType2
    StartCoroutine(MoveTowardsTarget(rb_2));
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
