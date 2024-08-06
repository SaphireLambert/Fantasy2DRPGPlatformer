using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignOnboarding : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;

    private void Start()
    {
        UI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI.gameObject.SetActive(false);
        }
    }
}
