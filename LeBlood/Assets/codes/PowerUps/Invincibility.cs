using System.Collections;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public float duration = 4f;

    public IEnumerator Pickup(movement stats)
{
    Debug.Log("Starting Invincibility Pickup");
    // Make the player invincible
    stats.isInvincible = true;

    yield return new WaitForSeconds(duration);

    // Reset the player's invincibility
    stats.isInvincible = false;
}

}
