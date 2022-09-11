using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
public class DataManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private string gameTitle;
    [Header("Debug Only")]
    [SerializeField] private TMP_Text gameTitleTMP;
    [SerializeField] private SerializedSaveData playerData;
    [SerializeField] private TMP_Text playerNameTMP;
    [SerializeField] private TMP_Text playerCurHPTMP;
    [SerializeField] private TMP_Text playerMaxHPTMP;
    private string GetFilePath(string fileName)
    {
        //Application.persistentDataPath is the directory where our project exists.
        return Application.persistentDataPath + "/" + fileName;
    }
    public void GameSave()
    {
        FileStream fileStream = new FileStream(GetFilePath("nonBinary.save"), FileMode.OpenOrCreate);
        Debug.Log($"file path: {GetFilePath("nonBinary.save")}");
        BinaryWriter binaryWriter = new BinaryWriter(fileStream);
        binaryWriter.Write(gameTitle);
        //Debug.Log(gameManager.GetCollectibles());
        binaryWriter.Write(gameManager.GetCollectibles().ToString());
        fileStream.Close();
        binaryWriter.Close();
    }
    public void GameLoad()
    {
        FileStream fileStream = new FileStream(GetFilePath("nonBinary.save"), FileMode.Open);
        BinaryReader binaryReader = new BinaryReader(fileStream);
        Debug.Log($"Game Title: {binaryReader.ReadString()}");
        Debug.Log($"Collectibles: {binaryReader.ReadString()}");
        //gameTitleTMP.text = binaryReader.ReadString();
        fileStream.Close();
        binaryReader.Close();
    }
    public void SerializedDataSave()
    {
        //prepare the data to save
        SerializedSaveData newSaveData = new SerializedSaveData(playerData.charName, playerData.curHP, playerData.maxHP);
        FileStream fileStream = new FileStream(GetFilePath("serializedData.save"), FileMode.OpenOrCreate);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, newSaveData);
        fileStream.Close();
    }
    public void SerializedDataLoad()
    {
        FileStream fileStream = new FileStream(GetFilePath("serializedData.save"), FileMode.Open);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        //read the data we want to load and cast it as the type class we created
        SerializedSaveData loadedData = binaryFormatter.Deserialize(fileStream) as SerializedSaveData;
        Debug.Log($"Player Name: {loadedData.charName}");
        Debug.Log($"Current HP: {loadedData.curHP}");
        Debug.Log($"Maximum HP: {loadedData.maxHP}");
        fileStream.Close();
    }
    [System.Serializable]
    private class SerializedSaveData
    {
        public string charName;
        public int curHP;
        public int maxHP;
        public SerializedSaveData(string sName, int iCurHP, int iMaxHP)
        {
            charName = sName;
            curHP = iCurHP;
            maxHP = iMaxHP;
        }
    }
}