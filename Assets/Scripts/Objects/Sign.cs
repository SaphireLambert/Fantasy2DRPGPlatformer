using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityGoogleDrive;
using UnityEngine;
using System.Runtime.CompilerServices;
using System.Text;

public class Sign : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;

    public TMP_InputField inputFieldMessage;

    public SignStats stats = new SignStats();

    private string folderPath = Application.streamingAssetsPath;
    private string signFileName = "signInfo.json";
    private string fullFilePath = string.Empty;

    public string fileID;
    public string jsonData;

    public byte[] downLoadedContent;

    public float[] signPositionArray = new float[] { 0, 0};

    private void Start()
    {
        //Create the folder
        fullFilePath = Path.Combine(folderPath, signFileName);

        StartCoroutine("DownloadJsonFiles");


        UI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI.SetActive(false);
        }
    }

    public void SaveJSONFile() //This creates the json file with all the info from the sign; 
    {
        if (inputFieldMessage.text == "")
        {
            return;
        }

        stats.playerInput = inputFieldMessage.text;
        stats.SetSignPosition(transform.position);

        jsonData = JsonUtility.ToJson(stats);

        if(!File.Exists(fullFilePath))
        {
            File.WriteAllText(fullFilePath, jsonData);
        }

        File.AppendAllText(fullFilePath, jsonData + "\n\n");

        StartCoroutine("CreateJsonFiles");
    }

    public void LoadJSONFile()
    {
        if (File.Exists(fullFilePath))
        {
            jsonData = File.ReadAllText(fullFilePath);

            stats = JsonUtility.FromJson<SignStats>(jsonData);

            if(stats != null)
            {

            }
            else
            {
                Debug.Log("JSON found but cant convert to class");
            }

        }
        else
        {
            Debug.LogError("No sign Data found");
        }
    }


    public IEnumerator CreateJsonFiles()  //Creates and stores the json file in my google drive
    {
        var content = Encoding.ASCII.GetBytes(jsonData);
        var file = new UnityGoogleDrive.Data.File() { Name = signFileName, Content = content };
        var request = GoogleDriveFiles.Create(file);
        request.Fields = new List<string> { "id" };
        yield return request.Send();
        print(request.IsError);
        print(request.RequestData.Content);
        print(request.ResponseData.Id);
    }

    public IEnumerator DownloadJsonFiles()  //Saves the specific document that the id is from to the project
    {
        var request = GoogleDriveFiles.Download("1lA2KWEVGMUaPqHKA8QWBXjEs6OnvqnpD"); //reference to the document ID
        yield return request.Send();
        print(request.IsError);
        print (request.ResponseData.Content);
        downLoadedContent = request.ResponseData.Content;

        string json = Encoding.ASCII.GetString(downLoadedContent);

        string jsonSaver = Application.dataPath + "/" + signFileName;

        if(File.Exists(jsonSaver))
        {
            File.Delete(jsonSaver);
        }

        File.AppendAllText(jsonSaver, json + "\n");
    }
}
