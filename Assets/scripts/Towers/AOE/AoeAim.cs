using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeAim : MonoBehaviour
{

	public Transform target;
	public float range = 5f;

	public string enemyTag = "Enemy";

	public float turnSpeed = 10f;
	public float firerate = 0.5f;
	public float damage = 1f;

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, firerate);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy <= range)
			{

				enemy.GetComponent<HealthManager>().Health-=damage;
			}
			else
			{
				//print(enemy);
			}
		}

		

	}

	// Update is called once per frame
	void Update()
	{
		if (target == null)
			return;

		//Target lock on
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);

	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}