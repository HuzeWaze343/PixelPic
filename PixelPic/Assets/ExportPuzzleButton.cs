using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExportPuzzleButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Text txtF;
    [SerializeField] Text txtB;
    Color colorB;
    Color colorF;
    void Start()
        {
        colorB = txtB.GetComponent<Text>().color;
        colorF = txtF.GetComponent<Text>().color;
        button.onClick.AddListener(ExportToClipboard);
        }
    private void ExportToClipboard()
        {
        bool[,] bStates = GameObject.Find("ControllerObject").GetComponent<PuzzleGameController>().buttonstates;
        int length = bStates.GetLength(0);
        string s = length.ToString() + "-";

        for (int y = 0; y < length; y++)
            {
            for (int x = 0; x < length; x++)
                {
                if (bStates[y, x]) s += "1";
                else s += "0";
                }
            }

        GUIUtility.systemCopyBuffer = s;

        colorB.a = 1f;
        colorF.a = 1f;
        txtB.GetComponent<Text>().color = colorB;
        txtF.GetComponent<Text>().color = colorF;
        Invoke("FadeOut", 3f);
        }
    private void FadeOut()
        {
        colorB.a = 0f;
        colorF.a = 0f;
        txtB.GetComponent<Text>().color = colorB;
        txtF.GetComponent<Text>().color = colorF;
        }
}
