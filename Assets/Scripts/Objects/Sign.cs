using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField playerMessageInputField;

    public string playerMessage;
    public Transform signPosition;

    [SerializeField]
    private GameObject ui;

    private void Start()
    {
        ui.SetActive(false);
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Sign_Info");
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
    public void ReadStringInputMessage(string message)
    {
        playerMessage = message;
        playerMessage = Application.streamingAssetsPath + "/playerMessage.txt";

        if (!File.Exists(playerMessage))
        {
            File.WriteAllText(playerMessage, message);
        }
    }
}
