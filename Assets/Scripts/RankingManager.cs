using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[Serializable]
public class SaveData
{
    public string playerName;
    public int intentos;
    public int score;

    // Constructor
    public SaveData(string _playerName, int _intentos, int _score)
    {
        playerName = _playerName;
        intentos = _intentos;
        score = _score;
    }

}

public class RankingManager : MonoBehaviour
{

    public TextMeshProUGUI entriesText;
    public TextMeshProUGUI nombreEntrada;

    public int maxEntriesPerPage = 10;
    private int _currentPage = 1;

    [SerializeField] string filename;

    List<SaveData> players = new List<SaveData>();

    private void Start()
    {
        if (entriesText != null)
        {
            players = FileHandler.ReadListFromJSON<SaveData>(filename);
            UpdateEntriesText();
        }
        
    }

    public void AddNameToList()
    {
        players = FileHandler.ReadListFromJSON<SaveData>(filename);
        players.Add(new SaveData(nombreEntrada.text, OpcionesNivelesManager.instanciaOpcionesNivel.intentosFinales,OpcionesNivelesManager.instanciaOpcionesNivel.scoreFinal));
        nombreEntrada.text = "";
        FileHandler.SaveToJSON<SaveData>(players, filename);
    }

    // Function to update the displayed entries text
    private void UpdateEntriesText()
    {
        entriesText.text = "";

        int startIndex = (_currentPage - 1) * maxEntriesPerPage;
        int endIndex = Mathf.Min(startIndex + maxEntriesPerPage, players.Count);

        for (int i = startIndex; i < endIndex; i++)
        {
            entriesText.text += "nombre: "+players[i].playerName + " score: " + players[i].score + " intentos: " + players[i].intentos + "\n";
        }
    }

    // Function to navigate to the next page
    public void NextPage()
    {
        _currentPage++;
        UpdateEntriesText();
    }

    // Function to navigate to the previous page
    public void PreviousPage()
    {
        if (_currentPage > 1)
        {
            _currentPage--;
            UpdateEntriesText();
        }
    }

}
