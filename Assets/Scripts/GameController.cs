//This script runs the game, checks for wins and calls the ai to play.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;

    private static GameController instance;    
    public static GameController Instance
    {
        get { return instance; }
    }

    private Minimax ai;

    public string winner;
    public string playerSide;
    private int moveCount;

    public int aiMove;

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
        restartButton.SetActive(false);
        gameOverPanel.SetActive(false);
        SetGameControllerRefOnButtons();
        playerSide = "O";
        moveCount = 0;
        winner = "";
    }

    private void Update()
    {
        ai = Minimax.Instance;
        if(playerSide == "O")
        {
            aiTurn();
        }
    }

    private void aiTurn()
    {
        aiMove = ai.BestMove();
        buttonList[aiMove].text = playerSide;
        buttonList[aiMove].GetComponentInParent<GridSpace>().button.interactable=false;
        EndTurn();
    }
    private void SetGameControllerRefOnButtons()
    {
        for(int i =0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerRef(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        if((buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) ||
           (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) ||
           (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) ||
           (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) ||
           (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) ||
           (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) ||
           (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) ||
           (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide))
        {
            winner = playerSide;
            gameOver(winner);
        }

        if(moveCount >= 9)
        {
            winner = "draw";
            gameOver(winner);
        }
        changeSides();
    }

    public void changeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    private void gameOver(string winner)
    {
        setBoardInteractable(false); 

        if(winner == "draw")
        {
            setGameOverText("Draw!");
        }
        else{
            setGameOverText(playerSide + " Wins!");
        }
          
        restartButton.SetActive(true);
    }

    private void setGameOverText(string condition)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = condition;
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        setBoardInteractable(true);
        restartButton.SetActive(false);

        for(int i =0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
    }

    private void setBoardInteractable(bool toggle)
    {
        for(int i =0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}
