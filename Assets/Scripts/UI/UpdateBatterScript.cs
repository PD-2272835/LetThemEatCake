using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateBatterScript : MonoBehaviour
{
    [SerializeField]private GameStateManager _gameStateManager;
    [SerializeField]private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(_gameStateManager.GetBatter().ToString());
    }
}
