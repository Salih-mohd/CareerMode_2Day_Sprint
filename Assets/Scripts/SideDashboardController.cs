using UnityEngine;
using TMPro;

public class SideDashboardController : MonoBehaviour
{
    [Header("Status Display")]
    public TextMeshProUGUI statusText;

    [Header("Objectives Scroll")]
    public TextMeshProUGUI objectiveListText; // Simplified for prototype scroll

    // Ccall from career statee
    public void UpdateStatusDisplay(string stateName)
    {
        statusText.text = "Current Era: " + stateName;
    }

    // call from objectivee
    public void UpdateObjectiveList(string objectiveDesc)
    {
        
        objectiveListText.text = "• " + objectiveDesc;
    }
}