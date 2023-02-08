using System.Collections;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float duration = 4f;
    public float speedMultiplier = 2f;
    private movement stats;
    private float originalSpeed;

    private void Start()
    {
        stats = GetComponent<movement>();
        originalSpeed = stats.runSpeed;
    }

    public IEnumerator Pickup(movement playerStats)
    {
        // Store the original speed
        originalSpeed = playerStats.runSpeed;

        // Increase the player speed
        playerStats.runSpeed *= speedMultiplier;

        yield return new WaitForSeconds(duration);

        // Reset the player speed to the original value
        playerStats.runSpeed = originalSpeed;
    }
}

