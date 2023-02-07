using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAttack : MonoBehaviour
{
    public int damage = 2;
    public float attackInterval = 1.0f;
    public float attackRange = 3.0f;
    private float timeSinceLastAttack;
    private movement a;
    private Transform playerTransform;

    void Start()
    {
        a = GameObject.FindWithTag("Player").GetComponent<movement>();
        playerTransform = a.transform;
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
        a.TakeDamage(damage);
    }
}
