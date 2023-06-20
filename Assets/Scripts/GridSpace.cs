using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    private GameController gameController;
    public Button button;
    public Text buttonText;

    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();;
        button.interactable=false;
        gameController.EndTurn();
        Debug.Log(gameController.playerSide);
    }

    public void SetGameControllerRef(GameController controller)
    {
        gameController = controller;
    }
}
