using System.Collections;
using UnityEngine;

public class SpiderScore : MonoBehaviour
{
  public float speed = 3f; // Velocidad de movimiento
    
  private Rigidbody rb; // Rigidbody de la araña

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    StartCoroutine(FindClosestEgg());
  }

  // Coroutine para buscar el huevo más cercano
  private IEnumerator FindClosestEgg()
  {
    while (true) // Bucle infinito para buscar huevos continuamente
    {
      GameObject closestEgg = FindClosestEggInScene();
      if (closestEgg != null)
      {
        yield return MoveTowardsEgg(closestEgg);
        closestEgg.GetComponent<Egg>().Collect(); // Colectar el huevo
      }
      yield return new WaitForSeconds(2f); // Espera antes de buscar de nuevo
    }
  }

  // Método para buscar el huevo más cercano
  private GameObject FindClosestEggInScene()
  {
    GameObject[] eggs = GameObject.FindGameObjectsWithTag("Egg"); // Encuentra todos los huevos
    GameObject closestEgg = null;
    float closestDistance = Mathf.Infinity;

    foreach (GameObject egg in eggs)
    {
      float distance = Vector3.Distance(transform.position, egg.transform.position);
      if (distance < closestDistance)
      {
        closestDistance = distance;
        closestEgg = egg;
      }
    }
    return closestEgg;
  }

  // Coroutine para mover hacia el huevo
  private IEnumerator MoveTowardsEgg(GameObject egg)
  {
    Rigidbody eggRb = egg.GetComponent<Rigidbody>();
    while (Vector3.Distance(transform.position, egg.transform.position) > 0.5f)
    {
      Vector3 direction = (egg.transform.position - transform.position).normalized;
      rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
      yield return null; // Espera el siguiente frame
    }
  }
}
