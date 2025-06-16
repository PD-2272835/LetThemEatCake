using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    
    
    
    
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
