using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockingButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Animator animator;
    GameObject puzzleGameController;
    void Start()
        {
        puzzleGameController = GameObject.Find("ControllerObject");
        button.onClick.AddListener(ToggleBlocking);
        }
    private void ToggleBlocking()
        {
        if (puzzleGameController.GetComponent<PuzzleGameController>().isBlocking == false)
            {
            puzzleGameController.GetComponent<PuzzleGameController>().isBlocking = true;
            animator.SetTrigger("Block");
            }
        else
            {
            puzzleGameController.GetComponent<PuzzleGameController>().isBlocking = false;
            animator.SetTrigger("Unblock");
            }
        }
}
