using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Scores{
    O=10,
    X=-10,
    DRAW=0
}

public class Minimax : MonoBehaviour
{
    private GameController controller;
    private string ai = "O";
    private string player = "X";
    private int depth = 0;

    public static Minimax instance;
    public static Minimax Instance
    {
        get { return instance; }
    }

    private int move;

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

    public void BestMove()
    {
        controller = GameController.Instance;
        int bestScore = -0;
        int score;
        for(int i = 0; i < controller.buttonList.Length; i++)
        {
            if(controller.buttonList[i].text == "")
            {
                controller.buttonList[i].text = ai;
                score = MiniMax(controller.buttonList[i], 0, false);
                controller.buttonList[i].text = "";
                if (score > bestScore)
                {
                    bestScore = score;
                    move = i;
                }
            }
        }
        controller.buttonList[move].text = ai;
        controller.changeSides();
    }

    private int MiniMax(Text place, int depth, bool isMaximizing)
    {   
        string result = controller.winner;
        int score;
        if(result !=""){
            switch(result)
            {
                case "X":
                score = (int)Scores.X;
                break;

                case "O":
                score = (int)Scores.O;
                break;

                default:
                score = (int)Scores.DRAW;
                break;
            }
        return score;
        }

        if(isMaximizing)
        {
            int bestScore = -0;
            for(int i = 0; i < controller.buttonList.Length; i++)
            {
                if(controller.buttonList[i].text == "")
                {
                    controller.buttonList[i].text = ai;
                    score = MiniMax(controller.buttonList[i], depth +1, false);
                    controller.buttonList[i].text = "";
                    if (score > bestScore)
                    {
                        bestScore = score;
                    }
                }
            }
            return bestScore;
        }
        else{
            int bestScore = 0;
            for(int i = 0; i < controller.buttonList.Length; i++)
            {
                if(controller.buttonList[i].text == "")
                {
                    controller.buttonList[i].text = player;
                    score = MiniMax(controller.buttonList[i], depth +1, true);
                    controller.buttonList[i].text = "";
                    if (score > bestScore)
                    {
                        bestScore = score;
                    }
                }
            }
            return bestScore;
        }
    }
}
