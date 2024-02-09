using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] Button button;
    GameObject puzzleGameController;
    int buttonState = 0; // 3 states: -1 = blocked, 0 = not toggled, 1 = toggled
    void Start()
        {
        puzzleGameController = GameObject.Find("ControllerObject");
        button.onClick.AddListener(TaskOnClick);
        }
    private void TaskOnClick()
        {
        // figuring out which button was clicked as if they were indexed in a 2d array
        string[] strings = button.name.Split('-');
        int indexI = Convert.ToInt32(strings[1]);
        int indexX = Convert.ToInt32(strings[2]);

        // toggle button state on/off, or block button
        bool isBlocking = puzzleGameController.GetComponent<PuzzleGameController>().isBlocking;
        if (buttonState == -1)
            {
            if (isBlocking)
                {
                buttonState = 0;
                button.image.color = Color.white;
                }
            }
        else if (buttonState == 0)
            {
            if (isBlocking)
                {
                buttonState = -1;
                button.image.color = Color.red;
                }
            else
                {
                buttonState = 1;
                puzzleGameController.GetComponent<PuzzleGameController>().buttonstates[indexI, indexX] = true;
                puzzleGameController.GetComponent<PuzzleGameController>().tileCount++;
                button.image.color = Color.black;
                }
            }
        else if (buttonState == 1)
            {
            if (!isBlocking)
                {
                buttonState = 0;
                puzzleGameController.GetComponent<PuzzleGameController>().buttonstates[indexI, indexX] = false;
                puzzleGameController.GetComponent<PuzzleGameController>().tileCount--;
                button.image.color = Color.white;
                }
            }
        puzzleGameController.GetComponent<PuzzleGameController>().CheckForWin();
        }
}
