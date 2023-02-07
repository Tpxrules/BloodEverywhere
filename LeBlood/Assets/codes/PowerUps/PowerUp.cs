using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject PickUpEffect;
    public float duration = 4f;
    public HealthManager healthManager;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other.GetComponent<movement>()));
        }
    }

    IEnumerator Pickup(movement stats)
    {
        Instantiate(PickUpEffect, transform.position, transform.rotation);

        healthManager.IncreaseHealth(stats);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        healthManager.DecreaseHealth(stats);
        Destroy(gameObject);
    }
}
