using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class abilities : MonoBehaviour
{

    public Image slides;
    float time;
      Transform pls;
     public float bulletForce  = 2;

     public float full = 20;
    public GameObject BulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
         pls = GameObject.FindGameObjectWithTag("Hand").GetComponent<Transform>();
    }
    void Shoot()
    {
      

     
        GameObject bullet = Instantiate(BulletPrefab, pls.position, pls.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(pls.up * bulletForce );
        Bullet c = bullet.GetComponent<Bullet>();
     

      
    }
    // Update is called once per frame
    void Update()
    {
        if( full > time)
        time += Time.deltaTime;
        else 
        time = full;
          float noom = time/full;
             slides.fillAmount = noom;
        
         if (Input.GetButtonDown("ability") && time == full){
                Shoot();
                time = 0;
         }

    }
}
