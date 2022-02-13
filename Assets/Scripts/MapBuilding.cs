using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilding : MapUnit
{
	readonly WaitForSeconds waiter = new WaitForSeconds(1f);

	[SerializeField] private List<Recipe> activeRecipes;

	private void Start()
	{
		StartCoroutine(ManageRecipes());
	}

	IEnumerator ManageRecipes()
	{
		for (; ; )
		{
			foreach (Recipe recipe in activeRecipes)
			{
			}

			yield return waiter;
		}
	}
}
