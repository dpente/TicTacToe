using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;

    void Awake()
    {
        SetGameControllerRefOnButtons();
    }

    void SetGameControllerRefOnButtons()
    {
        for(int i =0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerRef(this);
        }
    }

    public string GetPlayerSide()
    {
        return "?";
    }

    public void EndTurn()
    {
        Debug.Log("End turn is not set up");
    }
}
