using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//PLEASE READ - Pete
//This needs to be refactored. Keeping for now as we need to know how the upgrade system should behave

public class upgradeButtonScript : MonoBehaviour
{
    public Button yourButton;
    public cakeManagerScript cakemanagerscript;
    public int price = 50;
    public TMP_Text btnText;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        //btnText.SetText("Upgrade - " + cakemanagerscript.modifier.ToString() + "x (" + price.ToString() + ")"); //sets the button text to the current modifier and the price
    }

    void TaskOnClick()
    {
        /*if (cakemanagerscript.cakeBatter > price)
        {
            //price = price + 50*cakemanagerscript.modifier; //price scales after purchase
            //cakemanagerscript.modifier++; //modifier increases
        }*/
    }
}
