using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phantom : MonoBehaviour
{
        public GameObject BulletPrefab;
    	float distanceToClosestEnemy = Mathf.Infinity;
		Enemy closestEnemy = null;
    // Start is called before the first frame update

    public void shoot(){
         FindClosestEnemy();
    }
	void FindClosestEnemy()
	{
            distanceToClosestEnemy = Mathf.Infinity;
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

		foreach (Enemy currentEnemy in allEnemies) {
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy && currentEnemy.transform.position != transform.position) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}

            closestEnemy.TakeDamamge(1, 0);
        
		
	}

 
}
