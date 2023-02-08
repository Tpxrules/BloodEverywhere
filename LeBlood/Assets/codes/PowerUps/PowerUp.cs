using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject PickUpEffect;
    public float duration = 4f;
    public HealthManager healthManager;
    public SpeedUp speedUp;
    public Invincibility isInvincible;

    private movement stats;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            stats = other.GetComponent<movement>();
            StartCoroutine(Pickup());
            StartCoroutine(speedUp.Pickup(stats));
            StartCoroutine(isInvincible.Pickup(stats));
        }
    }

    IEnumerator Pickup()
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
