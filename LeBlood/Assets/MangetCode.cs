using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangetCode : MonoBehaviour
{
   
      public float duration = 4f;

    public IEnumerator Pickup(movement stats)
{
    Debug.Log("Starting Invincibility Pickup");
    // Make the player invincible
    stats.magnet = true;

    yield return new WaitForSeconds(duration);

    // Reset the player's invincibility
    stats.magnet = false;
}

}
