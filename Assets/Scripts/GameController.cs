using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int whoTurn; //0 = X and 1 = o
    public int turnCount; // counts # of turns played
    public GameObject[] turnIcons; // Displays who's turn it is
    public GameObject[] playIcons; // 0 = x icon and 1 = y icon
    public Button[] ticTacToeSpaces; // playable spaces for our game
    public int[] markedSpaces; //Id's which space was marked by which player
    
    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        whoTurn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for(int i = 0; i < ticTacToeSpaces.Length; i++)
        {
           ticTacToeSpaces[i].interactable = true;
            ticTacToeSpaces[i].GetComponent<GameObject>();

        }

        for (int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TicTacToeButton(int whichNumber)
    {
       //ticTacToeSpaces[whichNumber].gameObject.GetComponent()= playIcons[whoTurn];
        ticTacToeSpaces[whichNumber].interactable = false;

        markedSpaces[whichNumber] = whoTurn+1;
        turnCount++;
        if (turnCount > 4)
        {
         WinnerCheck();    
        }
        
        if (whoTurn == 0)
        {
            whoTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            whoTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }

    void WinnerCheck()
    {
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[0] + markedSpaces[4] + markedSpaces[6];
        var solutions = new int[] {s1, s2, s3, s4, s5, s6, s7, s8};
        for (int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3 * (whoTurn + 1))
            {
                Debug.Log("player " + whoTurn + "  won!");
                return;
            }
        }
    }
}
