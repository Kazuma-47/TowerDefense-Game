using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTrap : MonoBehaviour
{

	public Transform target;
	public float range;
	public float trigger = 2f;

	public GameObject[] enemies;

	public string enemyTag = "Enemy";
	public bool gestunt = false;
	





	// Use this for initialization
	void Update()
	{

		enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        
			if (gestunt == false)
			{
				UpdateTarget();
			}
	}
	


		public void UpdateTarget()
		{
			GameObject LastEnemy = enemies[enemies.Length - 1];
			foreach (GameObject enemy in enemies)
			{
				float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
				if (distanceToEnemy <= trigger)
				{
					foreach (GameObject target in enemies)
					{
					
						//!!!laat checken want hij stun pas als de enemies in de trigger range zitten

						if (distanceToEnemy <= range)
						{
							target.GetComponent<Stuned>()._Stuned(3f);
							//target.GetComponent<Stuned>().stunTimer = 3;
							Destroy(gameObject);
							gestunt = true;
							// Check als je al op het eind van de array ben.
							
						}


					}
				}
			}
			
		}

	


	void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, range);
		}
}
