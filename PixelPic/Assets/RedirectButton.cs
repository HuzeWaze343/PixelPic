using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RedirectButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] string sceneToNavigateTo;

    // Start is called before the first frame update
    void Start()
        {
        button.onClick.AddListener(NavigateToPage);
        }

    private void NavigateToPage()
        {
        SceneManager.LoadScene(sceneToNavigateTo);
        }
}
