using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameController : MonoBehaviour
    {
    public bool[,] buttonstates;
    private string masterString;
    private string s;
    private bool[,] correctLayout;
    private int correctTileCount = 0;
    public int tileCount = 0;
    public bool isBlocking = false;

    // initializing gameobjects so I dont have to use find methods over and over
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject txtCountF;
    [SerializeField] GameObject txtCountB;

    public void Start()
        {
        correctLayout = NonogramClass.nonogram;
        buttonstates = new bool[NonogramClass.nonogram.GetLength(0), NonogramClass.nonogram.GetLength(0)];
        SetNums();
        }
    private void SetNums() // Sets the numbers on the side of each row/column, as well as the x/y display at the top
        {
        int num = 0;
        string numString = "";
        correctTileCount = 0;

        // sets the numbers for each column
        // yes i know theres a bunch of gameobject.find methods here but we run this once per puzzle on load so its aight
        for (int x = 0; x < correctLayout.GetLength(0); x++)
            {
            for (int y = 0; y < correctLayout.GetLength(1); y++)
                {
                if (correctLayout[y,x]) // if the tile is filled num++
                    {
                    num++;
                    correctTileCount++; // stores the amount of tiles that have to be filled for the solution to be correct
                    }
                else // if the tile is not filled..
                    {
                    if (num > 0) // ..and tiles have been counted, add the numbers to the string..
                        {
                        numString += ("\n" + num);
                        }
                    num = 0; // ..and reset the counter to 0
                    }
                }
            if (num > 0)
                {
                numString += ("\n" + num);
                }
            num = 0;
            GameObject.Find("Column" + x).transform.Find("Text").GetComponent<Text>().text = numString;
            numString = "";
            }

        // sets the numbers for each row
        for (int y = 0; y < correctLayout.GetLength(1); y++)
            {
            for (int x = 0; x < correctLayout.GetLength(1); x++)
                {
                if (correctLayout[y, x]) // if the tile is filled num++
                    {
                    num++;
                    }
                else // if the tile is not filled..
                    {
                    if (num > 0) // ..and tiles have been counted, add the numbers to the string..
                        {
                        numString += (" " + num);
                        }
                    num = 0; // ..and reset the counter to 0
                    }
                }
            if (num > 0)
                {
                numString += (" " + num);
                }
            num = 0;
            GameObject.Find("Row" + y).transform.Find("Text").GetComponent<Text>().text = numString;
            numString = "";
            }

        txtCountB.GetComponent<Text>().text = tileCount + "/" + correctTileCount;
        txtCountF.GetComponent<Text>().text = tileCount + "/" + correctTileCount;
        }
    public void CheckForWin() // updates the display and checks if the player won or not, called from each button
        {
        // updating display
        txtCountB.GetComponent<Text>().text = tileCount + "/" + correctTileCount;
        txtCountF.GetComponent<Text>().text = tileCount + "/" + correctTileCount;

        if (tileCount == correctTileCount) // only check if its a winning layout if the amount of tiles checked is the same as the correct amount
            {
            bool mismatchDetected = false;
            for (int i = 0; i < buttonstates.GetLength(0); i++)
                {
                for (int x = 0; x < buttonstates.GetLength(1); x++)
                    {
                    if (buttonstates[i, x] != correctLayout[i, x]) mismatchDetected = true;
                    }
                }
            if (!mismatchDetected)
                {
                if(NonogramClass.id != -1) //the only time id is -1 is if a puzzle is custom, which we dont want to save progress of
                    {
                    NonogramClass.levels[NonogramClass.id].isComplete = true;
                    NonogramClass.SaveProgress();
                    }
                winPanel.SetActive(true);
                }
            }
        }
    }
