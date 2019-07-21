using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateInventoryDisplay : MonoBehaviour {
	
	public Transform targetTransform;
	public BaseIngredientDisplay ingredientDisplayPrefab;
	
	public ChocolateInventory inventory;

	void Start () {
		ChocolateInventory.onChanged += HandleonChanged;
	}
	
	void OnDestroy() {
		ChocolateInventory.onChanged -= HandleonChanged;
	}
	
	void HandleonChanged (ChocolateInventory inventory) {
		if (this.inventory == inventory)
			Prime (inventory);
	}
	
	void Update () {
		
	}
	
	public void Prime(ChocolateInventory inventory) {
		this.inventory = inventory;
		List<BaseIngredient> ingredients = inventory.ingredients;
		
		foreach (BaseIngredient ingredient in ingredients) {
			BaseIngredientDisplay display = (BaseIngredientDisplay)Instantiate(ingredientDisplayPrefab);
			display.transform.SetParent(targetTransform, false);
			display.Prime(ingredient);
		}
	}
}
