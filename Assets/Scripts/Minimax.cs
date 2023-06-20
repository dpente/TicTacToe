using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Scores{
    O= 10,
    X= -10,
    DRAW= 0
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

    public int BestMove()
    {
        controller = GameController.Instance;
        int bestScore = int.MinValue;
        int move = 0;
        for(int i = 0; i < controller.buttonList.Length; i++)
        {
            if(controller.buttonList[i].text == "")
            {
                controller.buttonList[i].text = ai;
                int score = MiniMax(controller.buttonList, 0, false);
                Debug.Log(score);
                controller.buttonList[i].text = "";
                if (score > bestScore)
                {
                    bestScore = score;
                    move = i;
                }
            }
        }
        return move;
    }

    private int MiniMax(Text[] place, int depth, bool isMaximizing)
    {   
        string result = controller.winner;
        int score = depth;

        if(result !=""){
            switch(result)
            {
                case "X":
                score = (int)Scores.X;
                break;

                case "O":
                score = (int)Scores.O;
                break;

                case "draw":
                score = (int)Scores.DRAW;
                break;
            }
        return score;
        }

        if(isMaximizing)
        {
            int bestScore = int.MinValue;
            for(int i = 0; i < controller.buttonList.Length; i++)
            {
                if(place[i].text == "")
                {
                    controller.buttonList[i].text = ai;
                    score = MiniMax(place, depth +1, false);
                    controller.buttonList[i].text = "";
                    bestScore = Mathf.Max(score, bestScore);
                }
            }
            return bestScore;
        }
        else{
            int bestScore = int.MaxValue;
            for(int i = 0; i < controller.buttonList.Length; i++)
            {
                if(place[i].text == "")
                {
                    controller.buttonList[i].text = player;
                    score = MiniMax(place, depth +1, true);
                    controller.buttonList[i].text = "";
                    bestScore = Mathf.Min(score, bestScore);
                }
            }
            return bestScore;
        }
    }
}
