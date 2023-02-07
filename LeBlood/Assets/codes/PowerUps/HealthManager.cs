using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float multiplier = 2f;

    public void IncreaseHealth(movement stats)
    {
        stats.maxHealth = (int)(stats.maxHealth * multiplier);
    }

    public void DecreaseHealth(movement stats)
    {
        stats.maxHealth = (int)(stats.maxHealth / multiplier);
    }
}
