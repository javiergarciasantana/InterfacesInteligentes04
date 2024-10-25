using System;
using UnityEngine;

// Class to handle collision detection and events
public class CubeCollisionSpiderController : MonoBehaviour
{
    // Events to notify when the cube collides with Type1 or Type2 spiders
    public delegate void CollisionEventHandler(GameObject spider);
    public static event CollisionEventHandler SpiderEggCollector;
    public static event CollisionEventHandler SpiderEggLooker;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a Type1 spider
        if (collision.gameObject.CompareTag("Pared"))
        {
            // Trigger the event for Type1 collision, passing the colliding spider
            SpiderEggCollector?.Invoke(collision.gameObject);
            SpiderEggLooker?.Invoke(collision.gameObject);
        }
    }
}
