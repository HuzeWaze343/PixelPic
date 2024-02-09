using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelSelect : MonoBehaviour
{
    [SerializeField] float padding;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] GameObject container;
    void Start()
        {
        float btnHeight = 0;
        float totalOffset = 0;
        List<Level> levels = NonogramClass.levels;

        GameObject[] btns = new GameObject[levels.Count];

        //manually instantiate first level
        btns[0] = Instantiate(buttonPrefab);
        btns[0].transform.SetParent(container.transform, false);
        LevelSelectButton btn = btns[0].GetComponentInChildren<LevelSelectButton>();
        btn.id = levels[0].id;
        btn.puzzle = levels[0].levelCode;
        btn.GetComponentInChildren<Text>().text = "Level " + (levels[0].id + 1);
        if (levels[0].isComplete) btns[0].GetComponentInChildren<Button>().image.color = new Color(62f / 255f, 83f / 255f, 99f / 255f, 150f / 255f);
        
        RectTransform rt = btn.GetComponent<RectTransform>();
        btnHeight = rt.sizeDelta.y;
        totalOffset += btnHeight;
        
        for (int i = 1; i < levels.Count; i++)
            {
            totalOffset += padding;
            btns[i] = Instantiate(buttonPrefab);
            btns[i].transform.SetParent(container.transform, false);
            LevelSelectButton lsb = btns[i].GetComponentInChildren<LevelSelectButton>();
            lsb.id = levels[i].id;
            lsb.puzzle = levels[i].levelCode;
            lsb.GetComponentInChildren<Text>().text = "Level " + (levels[i].id + 1);
            if (levels[i].isComplete) btns[i].GetComponentInChildren<Button>().image.color = new Color(62f / 255f, 83f / 255f, 99f / 255f, 150f / 255f);
            btns[i].transform.position -= new Vector3(0.0f, totalOffset, 0.0f);
            totalOffset += btnHeight;
            }

        RectTransform rect = container.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, totalOffset);
        }
}
