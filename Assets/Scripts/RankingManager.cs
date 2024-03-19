using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public TextMeshProUGUI entriesText;
    public TextMeshProUGUI nombreEntrada;
    public int maxEntriesPerPage = 10;

    public List<string> allEntries = new List<string>();
    private int _currentPage = 1;

    public void Start()
    {
        UpdateEntriesText();
    }

    // Function to add entries to the ranking system
    public void AddEntry()
    {
        if (entriesText.text != null)
        {
            allEntries.Add(nombreEntrada.text);
            UpdateEntriesText();
        }
        
    }

    // Function to update the displayed entries text
    private void UpdateEntriesText()
    {
        entriesText.text = "";

        int startIndex = (_currentPage - 1) * maxEntriesPerPage;
        int endIndex = Mathf.Min(startIndex + maxEntriesPerPage, allEntries.Count);

        for (int i = startIndex; i < endIndex; i++)
        {
            entriesText.text += allEntries[i] + "\n";
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
