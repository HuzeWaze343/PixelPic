using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevelEditor : MonoBehaviour
{
    [SerializeField] int puzzleSize;
    GameObject puzzleGameController;
    void Start()
    {
        NonogramClass.nonogram = new bool[puzzleSize, puzzleSize];
        puzzleGameController = GameObject.Find("ControllerObject");
        puzzleGameController.GetComponent<PuzzleGameController>().buttonstates = new bool[puzzleSize, puzzleSize];
        }
}
