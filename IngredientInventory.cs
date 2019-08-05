using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInventory : MonoBehaviour {

	public List<BaseIngredient> ingredients = new List<BaseIngredient>();
	public IngredientInventoryDisplay ingredientInventoryDisplayPrefab;
	public delegate void IngredientInventoryDelegate(IngredientInventory IInventory);
	public static event IngredientInventoryDelegate onChanged;
	
	void Start () {

	}
	
	void Update () {
		
	}
	
	public void Display() {
		IngredientInventoryDisplay display = (IngredientInventoryDisplay)Instantiate (ingredientInventoryDisplayPrefab);
		display.Prime (this);
	}
	
	public void Add (BaseIngredient ingredient) {
		if (ingredient == null) return;
		ingredients.Add(ingredient);
		if (onChanged != null)
			onChanged.Invoke(this);
	}
	
	public void Remove (BaseIngredient ingredient) {
		if (ingredient == null) return;
		if (! ingredients.Contains (ingredient)) return;
		ingredients.Remove(ingredient);
		if (onChanged != null)
			onChanged.Invoke (this);
	}
}
