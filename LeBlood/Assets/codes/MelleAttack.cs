using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAttack : MonoBehaviour
{
      public int damage = 10;
    public float attackInterval = 1.0f;
    public float attackRange = 3.0f;
    private float timeSinceLastAttack;
    private PlayerHealth playerHealth;
    private Transform playerTransform;

    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerTransform = playerHealth.transform;
        timeSinceLastAttack = attackInterval;
    }

    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (timeSinceLastAttack >= attackInterval && InAttackRange())
        {
            Attack();
        }
    }

    bool InAttackRange()
    {
        return Vector2.Distance(transform.position, playerTransform.position) <= attackRange;
    }

    void Attack()
    {
        timeSinceLastAttack = 0.0f;
        playerHealth.TakeDamage(damage);
    }
}
