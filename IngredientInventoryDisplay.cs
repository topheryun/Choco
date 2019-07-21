using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInventoryDisplay : MonoBehaviour {

	public Transform targetTransform;
	public BaseIngredientDisplay ingredientDisplayPrefab;
	
	public IngredientInventory inventory;

	void Start () {
		IngredientInventory.onChanged += HandleonChanged;
	}
	
	void OnDestroy() {
		IngredientInventory.onChanged -= HandleonChanged;
	}
	
	void HandleonChanged (IngredientInventory inventory) {
		if (this.inventory == inventory)
			Prime (inventory);
	}
	
	void Update () {
		
	}
	
	public void Prime(IngredientInventory inventory) {
		this.inventory = inventory;
		List<BaseIngredient> ingredients = inventory.ingredients;
		
		foreach (BaseIngredient ingredient in ingredients) {
			BaseIngredientDisplay display = (BaseIngredientDisplay)Instantiate(ingredientDisplayPrefab);
			display.transform.SetParent(targetTransform, false);
			display.Prime(ingredient);
		}
	}
}
