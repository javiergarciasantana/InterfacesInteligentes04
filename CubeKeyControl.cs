using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeKeyControl : MonoBehaviour
{
  // Public field for speed, visible in the Inspector
  public float speed = 5;
  private KeyCode keyCode;
  //public Transform targetObject;
  private Rigidbody rb;

  void Start()
  {
    // Get the Rigidbody component attached to the GameObject
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    Vector3 moveDirection = Vector3.zero;
    if (Input.anyKey)
    {
      switch (true)
      { // Use 'true' for switching based on conditions
        case bool _ when Input.GetKey(KeyCode.UpArrow):
          moveDirection += Vector3.forward; // Move Up
          break;

        case bool _ when Input.GetKey(KeyCode.DownArrow):
          moveDirection += Vector3.back; // Move Down
          break;

        case bool _ when Input.GetKey(KeyCode.LeftArrow):
          moveDirection += Vector3.left; // Move left
          break;

        case bool _ when Input.GetKey(KeyCode.RightArrow):
          moveDirection += Vector3.right; // Move right
          break;
      }

      // Use MovePosition to move the Rigidbody
      Vector3 newPosition = rb.position + moveDirection.normalized * speed * Time.deltaTime;
      rb.MovePosition(newPosition);

      // // Calculate the direction to the target object
      // Vector3 direction = (targetObject.position - transform.position).normalized;

      // // Calculate the target rotation
      // Quaternion targetRotation = Quaternion.LookRotation(direction);

      // // Rotate the object towards the target rotation at the specified speed
      // transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
  }
}
