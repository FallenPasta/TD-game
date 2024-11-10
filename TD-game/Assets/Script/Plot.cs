using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private SpriteRenderer sr;
	[SerializeField] private Color hoverColer;


	private GameObject tower;
	private Color startColor;

	private void Start()
	{
		startColor = sr.color;
	}

	private void OnMouseEnter()
	{
		sr.color = Color.green;
	}
	private void OnMouseExit()
	{
		sr.color = startColor;
	}
	private void OnMouseDown()
	{
		if (tower != null) return;

		Tower towerToBuild = BuildManager.main.GetSelectedTower();

		if (towerToBuild.cost > LevelManager.main.money)
		{
			Debug.Log("Not enough money");
				return;
		}

		LevelManager.main.SpendMoney(towerToBuild.cost);

		tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);


	}
}
