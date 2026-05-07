using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    public SideDashboardController sideDash;
    // 3 Simple Conditions
    private string[] possibleObjectives = { "Score 2 Goals", "Make 3 Blocks", "0 Turnovers" };
    private int currentObjectiveIndex;

    void OnEnable() // Runs every time the Season/Playoff panel opens
    {
        RandomizeObjective();
    }

    public void RandomizeObjective()
    {
        int index = Random.Range(0, possibleObjectives.Length);
        string selected = possibleObjectives[index];
        sideDash.UpdateObjectiveList(selected);
    }
}