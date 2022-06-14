using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public int[] Grid
    {
        get; set;
    }

    public GameBoard()
    {
        //Initialize the board
        //Set all squares to empty
        for (int i = 0; i < 9; i++)
        {
            Grid[i] = 0;
        }
    }
}
