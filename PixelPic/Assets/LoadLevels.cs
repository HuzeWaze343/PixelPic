using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevels : MonoBehaviour
    {
    [SerializeField] string filePath;
    [SerializeField] Button button;
    void Start()
        {
        button.onClick.AddListener(TaskOnClick);
        }
    private void TaskOnClick()
        {
        LoadFromFile(filePath);
        }
    public static void LoadFromFile(string fPath)// fpath is the filepath from the root persistentdatapath directory
        {
        List<Level> levels = new List<Level>();
        string path = Application.persistentDataPath;
        StreamReader reader = new StreamReader(path + fPath);
        string levelData = reader.ReadToEnd();
        reader.Close();

        string[] data = levelData.Split('\n');

        for (int i = 1; i < data.Length - 1; i++)
            {
            string[] row = data[i].Split(',');
            Level l = new Level();
            l.id = Convert.ToInt32(row[0]);
            l.levelCode = row[1];
            l.isComplete = Convert.ToBoolean(row[2]);

            levels.Add(l);
            }

        NonogramClass.levels = levels;
        }
    }
