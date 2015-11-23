using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryBox : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler {

	protected Image ImgSource;
	
	public Sprite iconBox;
	public Sprite iconBoxActive;

	// Use this for initialization
	void Start () {
		ImgSource = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData e){
		Debug.Log ("Entered");
		ActivateBox();
	}
	
	void IPointerClickHandler.OnPointerClick(PointerEventData e){
		Debug.Log ("Exited");
		DeactivateBox();
	}
	
	
	public void ActivateBox(){
		Debug.Log ("Entered");
		ImgSource.overrideSprite = iconBoxActive;
	}
	
	public void DeactivateBox(){
		Debug.Log ("Exited");
		ImgSource.overrideSprite = iconBox;
	}
}
