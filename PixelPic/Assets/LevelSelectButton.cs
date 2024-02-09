using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
    {
    [SerializeField] Button button;
    [SerializeField] public int id;
    [SerializeField] public string puzzle;
    void Start()
        {
        button.onClick.AddListener(SelectLevel);
        }
    private void SelectLevel()
        {
        NonogramClass.id = id;
        string s = NonogramClass.DecodePuzzle(puzzle);
        SceneManager.LoadScene(s);
        }
    }
