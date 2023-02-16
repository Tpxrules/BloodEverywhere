using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closestenemy : MonoBehaviour
{
	// Update is called once per frame
	Enemy closestEnemy = null;
	
	private float timesinceattack = 0;
	public float attacktime  = 2;
	public int damage  = 1;
	public bool ElectricWave  = false;
	float distanceToClosestEnemy = Mathf.Infinity;
	void FindClosestEnemy()
	{
		 distanceToClosestEnemy = Mathf.Infinity;
		 closestEnemy = null;
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

		foreach (Enemy currentEnemy in allEnemies) {
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy ) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}

		Debug.DrawLine (this.transform.position, closestEnemy.transform.position);
	}
	void Update () {
		FindClosestEnemy ();

		   float d = Time.time - timesinceattack;
         if(d > attacktime && ElectricWave){
            timesinceattack = Time.time;
			if(distanceToClosestEnemy < 10){
			closestEnemy.electric();
			closestEnemy.TakeDamamge(damage);
			}
			
         }

/*
		// Finds the rotation of said enemy...


        Vector3 difference = closestEnemy.transform.position - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

*/
	}

}
