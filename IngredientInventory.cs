using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInventory : MonoBehaviour {

	public List<BaseIngredient> ingredients = new List<BaseIngredient>();
	public IngredientInventoryDisplay ingredientInventoryDisplayPrefab;
	public delegate void IngredientInventoryDelegate(IngredientInventory inventory);
	public static event IngredientInventoryDelegate onChanged;


	void Start () {
		IngredientInventoryDisplay display = (IngredientInventoryDisplay)Instantiate(ingredientInventoryDisplayPrefab);
		//display.Prime(this);
	}
	
	void Update () {
		
	}
	
	public void Display() {
		IngredientInventoryDisplay display = (IngredientInventoryDisplay)Instantiate (ingredientInventoryDisplayPrefab);
		//display.Prime (this);
	}
}
