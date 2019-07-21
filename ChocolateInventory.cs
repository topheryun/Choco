using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateInventory : MonoBehaviour {

	public List<BaseIngredient> ingredients = new List<BaseIngredient>();
	public ChocolateInventoryDisplay chocolateInventoryDisplayPrefab;
	public delegate void ChocolateInventoryDelegate(ChocolateInventory inventory);
	public static event ChocolateInventoryDelegate onChanged;


	void Start () {
		ChocolateInventoryDisplay display = (ChocolateInventoryDisplay)Instantiate(chocolateInventoryDisplayPrefab);
		display.Prime(this);
	}
	
	void Update () {
		
	}
	
	public void Display() {
		ChocolateInventoryDisplay display = (ChocolateInventoryDisplay)Instantiate (chocolateInventoryDisplayPrefab);
		display.Prime (this);
	}
}
