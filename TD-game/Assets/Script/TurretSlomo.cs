using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class TurretSlomo : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private LayerMask enemyMask;

	[Header("Attribute")]
	[SerializeField] private float targetingRange = 3f;
	[SerializeField] private float aps = 4f;
	[SerializeField] private float freezeTime = 1f;

	private float timeUntilFire;

	private void Update()
	{
		timeUntilFire += Time.deltaTime;

		if (timeUntilFire >= 1f / aps)
		{
			FreezeEnemies();
			timeUntilFire = 0f;
		}


	}

	private void FreezeEnemies()
	{
		RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);


		if (hits.Length > 0)
		{
			for (int i = 0; i < hits.Length; i++)
			{
				RaycastHit2D hit = hits[i];

				EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
				em.UpdateSpeed(0.25f);

				StartCoroutine(ResetEnemySpeed(em));
			}
		}
	}

	private IEnumerator ResetEnemySpeed(EnemyMovement em)
	{
		yield return new WaitForSeconds(freezeTime);

		em.ResetSpeed();
	}

	private void OnDrawGizmosSelected()
	{
		Handles.color = Color.cyan;
		Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
	}
}
