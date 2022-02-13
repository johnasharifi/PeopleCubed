using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Recipe
{
	[SerializeField] private List<InventoryItemCost> costs;
	[SerializeField] private List<InventoryItemCost> benefits;
	
	[SerializeField] private List<AbstractEffect> effectOnManufactureTick;
	[SerializeField] private List<AbstractEffect> effectOnBeginManufacture;
	[SerializeField] private List<AbstractEffect> effectOnFinishManufacture;

	[SerializeField] private float manufactureTickCount;
}

[System.Serializable]
public struct InventoryItemCost {
	public InventoryItems item;
	public float cost;
}

public enum InventoryItems {
	GRAIN,
	VEGETABLES,

	BEER,
	WINE,

	WOOD,
	STONE,
	BRICK,

	CLAY,
	POTTERY,

	SPICE,

	COPPER,
	IRON,
	SILVER,
	GOLD,


}