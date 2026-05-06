using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;

    // 3 Simple Conditions
    private string[] possibleObjectives = { "Score 2 Goals", "Make 3 Blocks", "0 Turnovers" };
    private int currentObjectiveIndex;

    void OnEnable() // Runs every time the Season/Playoff panel opens
    {
        RandomizeObjective();
    }

    public void RandomizeObjective()
    {
        currentObjectiveIndex = Random.Range(0, possibleObjectives.Length);
        PlayerPrefs.SetInt("ActiveObjectiveID", currentObjectiveIndex);
        objectiveText.text = "Objective: " + possibleObjectives[currentObjectiveIndex];
    }
}