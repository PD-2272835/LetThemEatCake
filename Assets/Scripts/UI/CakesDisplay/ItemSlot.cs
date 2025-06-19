using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public CakeData _heldCake;
    
    [SerializeField] private Sprite selectedSlotSprite;
    [SerializeField] private Sprite deselectedSlotSprite;
    
    
    //references to objects/attributes that are changed depending on UI states
    [SerializeField] private TMP_Text costText;
    [SerializeField] private GameObject costIndicator;
    
    [SerializeField] private GameObject itemDisplay;
    [SerializeField] private GameObject lockOverlay;
    

    public void Initialize(CakeData cakeData)
    {
        _heldCake = cakeData;
        itemDisplay.GetComponent<Image>().sprite = _heldCake.sprite;
        costText.text = "";
    }

    void OnEnable() { EventManager.OnUpdateCake += TryThisSlotSelected; }
    void OnDisable() { EventManager.OnUpdateCake -= TryThisSlotSelected; }

    
    
    public void Unlock()
    {
        lockOverlay.SetActive(false); 
        costText.text = _heldCake.useCost.ToString();
        
    }
    
    public void NextToUnlock()
    {
        costIndicator.SetActive(true);
        costText.text = _heldCake.upgradeCost.ToString();
    }
    
    
    void TryThisSlotSelected(CakeData newCakeData)
    {
        //Update the slot background image only if it is not already selected and the newCake is the same as the one held in the slot
        if (_heldCake == newCakeData)
        {
            gameObject.GetComponent<Image>().sprite = selectedSlotSprite;
        }
        //Only if this slot was previously selected, update to the deselected sprite
        else
        {
            gameObject.GetComponent<Image>().sprite = deselectedSlotSprite;
        }
    }
}
