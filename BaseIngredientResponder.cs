using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIngredientResponder : MonoBehaviour {

	
	
	void Start () {
		BaseIngredientDisplay.onClick += HandleonClick;
	}
	
	void OnDestroy () {
		Debug.Log ("Unsigned-up for onClick");
		BaseIngredientDisplay.onClick -= HandleonClick;
	}
	
	void HandleonClick (BaseIngredient ingredient) {
		Debug.Log ("BEHOLD I HAVE HEARD OF A LEGENDARY " + ingredient.displayName);
	}
	
	void Update () {
		
	}
}
