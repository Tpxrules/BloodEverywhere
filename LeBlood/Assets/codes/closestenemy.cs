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
		  if(allEnemies.Length > 0){
		foreach (Enemy currentEnemy in allEnemies) {
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy ) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}
		  }
		Debug.DrawLine (this.transform.position, closestEnemy.transform.position);
	}
	public void hurtclose(float x){
			FindClosestEnemy ();
			closestEnemy.electric();
			closestEnemy.TakeDamamge(x , 0);
	}
	void Update () {
	

		   float d = Time.time - timesinceattack;
         if(d > attacktime && ElectricWave){
				FindClosestEnemy ();
            timesinceattack = Time.time;
			if(distanceToClosestEnemy < 10){
			closestEnemy.electric();
			closestEnemy.TakeDamamge(damage , 0);
			}
			
         }
	}

}
