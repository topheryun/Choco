using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParty : MonoBehaviour {

	public static GlobalParty party;
	public static IngredientInventory ingredientInventory;
	public static ChocolateInventory chocolateInventory;
	
	void Awake () {
		DontDestroyOnLoad (gameObject);
		party = this;
		ingredientInventory = gameObject.GetComponent<IngredientInventory> ();
		chocolateInventory = gameObject.GetComponent<ChocolateInventory> ();
	}
	
	void Update () {
		
	}
}
