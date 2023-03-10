using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
      public GameObject floatingMessagePrefab;
    public GameObject PickUpEffect;
    public float duration = 4f;
    public HealthManager healthManager;
    public bool speed = false;
    public SpeedUp speedUp;
     public bool invin = false;
    public Invincibility isInvincible;
     public bool maaag = false;
    public MangetCode magneeto;
    private movement stats;
        public string text;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            stats = other.GetComponent<movement>();
            StartCoroutine(gone());

            if(speed)
            StartCoroutine(speedUp.Pickup(stats));
            if(invin)
            StartCoroutine(isInvincible.Pickup(stats));
            if(maaag){
                StartCoroutine(gone());
                    StartCoroutine(magneeto.Pickup(stats));
            }
            GameObject floatingMessage = Instantiate(floatingMessagePrefab, transform.position, Quaternion.identity);
                        floatingMessage.GetComponent<FloatingMessage>().SetMessage(text);
        }
    }




    IEnumerator gone()
    {
        Instantiate(PickUpEffect, transform.position, transform.rotation);

      //  healthManager.IncreaseHealth(stats);
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

      //  healthManager.DecreaseHealth(stats);
        Destroy(gameObject);
    }
}
