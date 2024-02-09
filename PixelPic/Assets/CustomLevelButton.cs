using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomLevelButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] InputField inputField;
    void Start()
        {
        button.onClick.AddListener(SelectLevel);
        }
    void SelectLevel()
        {
        NonogramClass.id = -1;
        string puzzle = inputField.text.ToString();
        Debug.Log(puzzle);
        string s = NonogramClass.DecodePuzzle(puzzle);
        SceneManager.LoadScene(s);
        }
}
