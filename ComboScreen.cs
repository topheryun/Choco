using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScreen : MonoBehaviour {

	public BaseIngredientDisplay leftSlot, rightSlot;
	public Combo combo;

	void Start () {
		if (combo != null)
			Prime (combo);
		
		GlobalParty.ingredientInventory.Display();
		GlobalParty.chocolateInventory.Display();
		
		BaseIngredientDisplay.onClick += HandleonClick;
		Combo.onImageChanged += HandleonImageChanged;
	}
	
	void OnDestroy() {
		BaseIngredientDisplay.onClick -= HandleonClick;
		Combo.onImageChanged -= HandleonImageChanged;
	}
	
	void HandleonClick (BaseIngredient ingredient) {
		if (combo.IsShown(ingredient)) {
			combo.UnShow(ingredient);
			GlobalParty.ingredientInventory.Add(ingredient);
			GlobalParty.chocolateInventory.Add(ingredient);
			return;
		}
		if (combo.ShowImage(ingredient)) {
			GlobalParty.ingredientInventory.Remove(ingredient);
			GlobalParty.chocolateInventory.Remove(ingredient);
		}
	}
	
	void HandleonImageChanged (Combo combo) {
		if (combo == this.combo) {
			Debug.Log("Image changed, image screen updating...");
			Prime(combo);
		}
	}
	
	void Update () {
		
	}
	
	public void Prime (Combo combo) {
		this.combo = combo;
		
		if (leftSlot != null)
			leftSlot.Prime (combo.leftSlot);
		if (rightSlot != null)
			rightSlot.Prime (combo.rightSlot);
	}
}
