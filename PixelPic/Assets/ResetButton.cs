using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    [SerializeField] Button button;
    void Start()
    {
        button.onClick.AddListener(ResetProgress);
    }
    void ResetProgress()
        {
        //resetting 5x5 levels
        LoadLevels.LoadFromFile("/Data/5x5Levels.csv");
        NonogramClass.nonogram = new bool[5, 5];
        foreach (Level l in NonogramClass.levels)
            {
            l.isComplete = false;
            }
        NonogramClass.SaveProgress();
        //resetting 10x10 levels
        LoadLevels.LoadFromFile("/Data/10x10Levels.csv");
        NonogramClass.nonogram = new bool[10, 10];
        foreach (Level l in NonogramClass.levels)
            {
            l.isComplete = false;
            }
        NonogramClass.SaveProgress();
        //resetting 15x15 levels
        LoadLevels.LoadFromFile("/Data/15x15Levels.csv");
        NonogramClass.nonogram = new bool[15, 15];
        foreach (Level l in NonogramClass.levels)
            {
            l.isComplete = false;
            }
        NonogramClass.SaveProgress();

        Debug.LogWarning("Progress has been reset");
        }
}
