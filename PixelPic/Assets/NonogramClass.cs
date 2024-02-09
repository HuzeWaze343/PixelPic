using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class NonogramClass
    {
    public static List<Level> levels;

    public static bool[,] nonogram;
    public static int id;
    public static string DecodePuzzle(string puzzle)
        {
        string[] puzzleParts = puzzle.Split('-');
        int length = Convert.ToInt32(puzzleParts[0]);
        puzzle = puzzleParts[1];

        nonogram = new bool[length, length];

        for (int y = 0; y < length; y++)
            {
            for (int x = 0; x < length; x++)
                {
                char c = puzzle[x + (y * length)]; // offset the current character by the length, to take into account the different rows of the puzzle 
                if (c == '1') nonogram[y, x] = true;
                else nonogram[y, x] = false;
                }
            }

        if (length == 15) return "FifteenByFifteenNonogram";
        else if (length == 10) return "TenByTenNonogram";
        else return "FiveByFiveNonogram";
        }
    public static void SaveProgress()
        {
        string saveString = "ID,LevelCode,IsComplete\n";
        foreach (Level l in levels)
            {
            string tempString = l.id + "," + l.levelCode + "," + l.isComplete.ToString().ToUpper() + "\n";
            saveString += tempString;
            }

        string path = Application.persistentDataPath;

        string filePath;
        int length = nonogram.GetLength(0);

        if (length == 15) filePath = "/Data/15x15Levels.csv";
        else if (length == 10) filePath = "/Data/10x10Levels.csv";
        else filePath = "/Data/5x5Levels.csv";
        
        StreamWriter writer = new StreamWriter(path + filePath, false);
        writer.Write(saveString);
        writer.Close();
        }
    }
