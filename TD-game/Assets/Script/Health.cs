using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[Header("Attributes")]
	[SerializeField] private int hitPoints = 2;
	[SerializeField] private int MoneyWorth = 50;

	private bool isDestroyed = false;

	public void TakeDamage(int dmg)
	{
		hitPoints -= dmg;

		if (hitPoints <= 0 && !isDestroyed)
		{
			EnemySpawner.onEnemyDestroy.Invoke();
			LevelManager.main.IncreaseMoney(MoneyWorth);
			isDestroyed = true;
			Destroy(gameObject);
		}
	}
}