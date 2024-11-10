using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
	public static LevelManager main;

	public Transform start;
	public Transform[] path;

	public int money;

	private void Awake()
	{
		main = this;
	}

	private void Start()
	{
		money = 400;
	}

	public void IncreaseMoney (int amount)
	{
		money += amount;
	}

	public bool SpendMoney(int amount)
	{
		if (amount <= money)
		{
			money -= amount;
			return true;
		}
		else
		{
			Debug.Log("not enough money");
			return false;
		}
	}
}
