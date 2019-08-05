using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateInventoryDisplay : MonoBehaviour {
	
	public Transform targetTransform;
	public BaseIngredientDisplay ingredientDisplayPrefab;
	
	public ChocolateInventory CInventory;

	void Start () {
		ChocolateInventory.onChanged += HandleonChanged;
	}
	
	void OnDestroy() {
		ChocolateInventory.onChanged -= HandleonChanged;
	}
	
	void HandleonChanged (ChocolateInventory CInventory) {
		if (this.CInventory == CInventory)
			Prime (CInventory);
	}
	
	void Update () {
		
	}
	
	public void Prime(ChocolateInventory CInventory) {
		for (int i = 0; i < targetTransform.childCount; i++) {
			Destroy(targetTransform.GetChild(i).gameObject);
		}
		
		this.CInventory = CInventory;
		List<BaseIngredient> ingredients = CInventory.ingredients;
		
		foreach (BaseIngredient ingredient in ingredients) {
			BaseIngredientDisplay display = (BaseIngredientDisplay)Instantiate(ingredientDisplayPrefab);
			display.transform.SetParent(targetTransform, false);
			display.Prime(ingredient);
		}
	}
}
