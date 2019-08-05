using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseIngredientDisplay : MonoBehaviour {

	public Text textName;
	public Image sprite;
	
	public delegate void BaseIngredientDisplayDelegate(BaseIngredient ingredient);
	public static event BaseIngredientDisplayDelegate onClick;
	
	public BaseIngredient ingredient;
	
	void Start () {
		if (ingredient != null) Prime (ingredient);
	}
	
	void Update () {
		
	}
	
	public void Prime(BaseIngredient ingredient) {
		this.ingredient = ingredient;
		if (ingredient == null) {
			if (textName != null)
				textName.text = "";
			if (sprite != null)
				sprite.sprite = null;
			return;
		}
		
		if (textName != null)
			textName.text = ingredient.displayName;
		if (sprite != null)
			sprite.sprite = ingredient.sprite;
	}
	
	public void Click() {
		Debug.Log("Clicked " + ingredient.displayName);
		if (onClick != null) {
			onClick.Invoke(ingredient);
		}
		else {
			Debug.Log ("Nobody was listening to " + ingredient.displayName);
		}
	}
}
