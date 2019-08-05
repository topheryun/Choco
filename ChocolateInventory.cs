using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateInventory : MonoBehaviour {

	public List<BaseIngredient> ingredients = new List<BaseIngredient>();
	public ChocolateInventoryDisplay chocolateInventoryDisplayPrefab;
	public delegate void ChocolateInventoryDelegate(ChocolateInventory CInventory);
	public static event ChocolateInventoryDelegate onChanged;


	void Start () {

	}
	
	void Update () {
		
	}
	
	public void Display() {
		ChocolateInventoryDisplay display = (ChocolateInventoryDisplay)Instantiate (chocolateInventoryDisplayPrefab);
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
