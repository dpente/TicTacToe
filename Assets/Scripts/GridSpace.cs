using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public static GridSpace instance;
    public static GridSpace Instance
    {
        get { return instance; }
    }
    private GameController gameController;
    public Button button;
    public Text buttonText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }                
        else if (instance != this)
        {
            Destroy(this); 
        }  
    }
    
    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();;
        button.interactable=false;
        gameController.EndTurn();
    }

    public void SetGameControllerRef(GameController controller)
    {
        gameController = controller;
    }
}
