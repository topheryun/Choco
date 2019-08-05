using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour {

	public BaseIngredient leftSlot, rightSlot;
	public delegate void ComboDelegate(Combo combo);
	public static event ComboDelegate onImageChanged;
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	public bool IsShown (BaseIngredient ingredient) {
		if (leftSlot == ingredient) return true;
		if (rightSlot == ingredient) return true;
		return false;
	}
	
	public void UnShow(BaseIngredient ingredient) {
		if (leftSlot == ingredient) leftSlot = null;
		if (rightSlot == ingredient) rightSlot = null;
		
				if (onImageChanged != null) {
			Debug.Log (name + " image unshown, listen up.");
			onImageChanged.Invoke(this);
		}
		else Debug.Log (name + " image unshown, nobody cared.");
	}
	
	public bool ShowImage(BaseIngredient ingredient) {
		if (ingredient == null) return false;
		switch (ingredient.slot) {
		default: 
			Debug.Log ("Doesn't know how to use slot " + ingredient.slot);
			return false;
		case ImageSlot.LeftSlot:
			GlobalParty.chocolateInventory.Add(leftSlot);			// UI Lists #9 at 7:00
			leftSlot = ingredient;
			break;
		case ImageSlot.RightSlot:
			GlobalParty.ingredientInventory.Add(rightSlot);
			rightSlot = ingredient;
			break;
//		case ImageSlot.ComboSlot:
//			comboSlot = ingredient;
//			break;
		}
		
		if (onImageChanged != null) {
			Debug.Log (name + " image change, listen up.");
			onImageChanged.Invoke(this);
		}
		else Debug.Log (name + " image change, nobody cared.");
		
		return true;
	}
}
