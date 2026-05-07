using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    public SideDashboardController sideDash;
     
    private string[] possibleObjectives = { "Score 2 Goals", "Make 3 Blocks", "0 Turnovers" };
    private int currentObjectiveIndex;

    void OnEnable()  
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