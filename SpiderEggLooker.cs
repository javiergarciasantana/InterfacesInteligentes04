using System.Collections;
using UnityEngine;

// Class for Spider Egg Looker behavior
public class SpiderEggLooker : MonoBehaviour
{
    public GameObject eggTarget; // The target egg to look at
    public float speed = 5f; // Movement speed

    private Rigidbody rb; // Rigidbody of this spider

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Log an error if eggTarget is not assigned
        if (eggTarget == null)
        {
            Debug.LogError("Egg target not assigned in inspector for " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        // Subscribe to collision events
        CubeCollisionSpiderController.SpiderEggLooker += HandleSpiderEggLooker;
    }

    private void OnDisable()
    {
        // Unsubscribe from collision events
        CubeCollisionSpiderController.SpiderEggLooker -= HandleSpiderEggLooker;
    }

    // Handle collision with Type 1 spiders (look towards egg target)
    private void HandleSpiderEggLooker(GameObject spider)
    {
        StartCoroutine(LookTowardsTarget(eggTarget.transform));
    }

    // Coroutine to look towards a specific target
    private IEnumerator LookTowardsTarget(Transform targetTransform)
    {
        while (true) // Loop to continuously look at the target
        {
            // Calculate the direction to the target object
            Vector3 direction = (targetTransform.position - rb.position).normalized;

            // Calculate the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Rotate the object towards the target rotation at the specified speed
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, speed * Time.deltaTime));

            // Exit the loop if the spider is looking directly at the target
            if (Quaternion.Angle(rb.rotation, targetRotation) < 1f)
            {
                break; // Stop rotating if we're close enough to the target direction
            }

            yield return null; // Wait for the next frame
        }
    }
}
