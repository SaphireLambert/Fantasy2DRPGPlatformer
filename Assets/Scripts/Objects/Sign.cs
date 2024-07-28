using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public string playerMessage;

    public Transform signPosition;

    [SerializeField]
    private GameObject ui;

    private void Start()
    {
        ui.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ui.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ui.SetActive(false);
        }
    }
    public void ReadStringInput(string s)
    {
        playerMessage = s;
    }
}
