using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoadNextLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;

    [SerializeField]
    private GameObject xboxUI;

    [SerializeField]
    private GameObject keyboardUI;

    [SerializeField]
    private PlayerInputHandler playerInputHandler;

    private void Start()
    {
        UI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
             UI.SetActive(true);
            if (playerInputHandler.playerInput.currentControlScheme == "Controller")
            {
                xboxUI.SetActive(true);
                keyboardUI.SetActive(false);
            }
            else if (playerInputHandler.playerInput.currentControlScheme == "PC")
            {
                xboxUI.SetActive(false);
                keyboardUI.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI.SetActive(false);
        }
    }
}
