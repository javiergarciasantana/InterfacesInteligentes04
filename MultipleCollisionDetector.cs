using System;
using UnityEngine;

// Class to handle collision detection and events
public class MultipleCollisionDetector : MonoBehaviour
{
    // Events to notify when the cube collides with Type1 or Type2 spiders
    public delegate void CollisionEventHandler(GameObject spider);
    public static event CollisionEventHandler OnType1Collision;
    public static event CollisionEventHandler OnType2Collision;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a Type1 spider
        if (collision.gameObject.CompareTag("Type1Spider"))
        {
            // Trigger the event for Type1 collision, passing the colliding spider
            OnType1Collision?.Invoke(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Type2Spider"))
        {
            // Log the tag of the object that collided with this collider
            string collidedObjectTag = collision.gameObject.tag;
            Debug.Log("Collision detected with: " + collidedObjectTag);
            // Trigger the event for Type2 collision, passing the colliding spider
            OnType2Collision?.Invoke(collision.gameObject);
        }
    }
}
