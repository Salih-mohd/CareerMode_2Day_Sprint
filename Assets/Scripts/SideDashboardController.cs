using UnityEngine;
using TMPro;

public class SideDashboardController : MonoBehaviour
{
    [Header("Status Display")]
    public TextMeshProUGUI statusText;

    [Header("Objectives Scroll")]
    public TextMeshProUGUI objectiveListText; // Simplified for prototype scroll

    // Call this from CareerStateController whenever the state changes
    public void UpdateStatusDisplay(string stateName)
    {
        statusText.text = "Current Era: " + stateName;
    }

    // Call this from ObjectiveManager whenever a new objective is rolled
    public void UpdateObjectiveList(string objectiveDesc)
    {
        // For a prototype, we can just append or overwrite the scroll text
        objectiveListText.text = "• " + objectiveDesc;
    }
}