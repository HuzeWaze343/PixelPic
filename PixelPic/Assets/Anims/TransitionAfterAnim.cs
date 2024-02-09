using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionAfterAnim : MonoBehaviour
{
    public void NavigateAfterAnim(string scene)
        {
        SceneManager.LoadScene(scene);
        }
}
