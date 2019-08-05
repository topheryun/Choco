using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInventoryDisplay : MonoBehaviour {

	public Transform targetTransform;
	public BaseIngredientDisplay ingredientDisplayPrefab;
	
	public IngredientInventory IInventory;
	
	void Start () {
		IngredientInventory.onChanged += HandleonChanged;
	}
	
	void OnDestroy() {
		IngredientInventory.onChanged -= HandleonChanged;
	}
	
	void HandleonChanged (IngredientInventory IInventory) {
		if (this.IInventory == IInventory)
			Prime (IInventory);
	}
	
	void Update () {
		
	}
	
	public void Prime(IngredientInventory IInventory) {
		for (int i = 0; i < targetTransform.childCount; i++) {
			Destroy(targetTransform.GetChild(i).gameObject);
		}
		
		this.IInventory = IInventory;
		List<BaseIngredient> ingredients = IInventory.ingredients;
		
		foreach (BaseIngredient ingredient in ingredients) {
			BaseIngredientDisplay display = (BaseIngredientDisplay)Instantiate(ingredientDisplayPrefab);
			display.transform.SetParent(targetTransform, false);
			display.Prime(ingredient);
		}
	}
}
