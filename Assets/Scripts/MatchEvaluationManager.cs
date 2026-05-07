using UnityEngine;
using TMPro;

public class MatchEvaluationManager : MonoBehaviour
{
    [Header("Dependencies")]
    public CareerStateController stateController;
    public SideDashboardController sideDash;

    [Header("Match Stats")]
    private float matchPoints = 0;
    public TextMeshProUGUI liveGradeText;

    [Header("Result Panel UI")]
    public GameObject resultPanel;
    public TextMeshProUGUI gradeResultText;
    public TextMeshProUGUI xpResultText;
    public TextMeshProUGUI recruitResultText;

    public void StartMatch()
    {
        matchPoints = 0;
        gameObject.SetActive(true);
        //sideDash.gameObject.SetActive(false); 
        resultPanel.SetActive(false);
        UpdateUI();
    }

    // SIMULATED ACTIONS
    public void Action_ScoreGoal() { matchPoints += 50; UpdateUI(); }
    public void Action_MakeBlock() { matchPoints += 30; UpdateUI(); }
    public void Action_Turnover() { matchPoints -= 20; UpdateUI(); }

    void UpdateUI()
    {
        liveGradeText.text = "Grade: " + CalculateGrade() + " (" + matchPoints + ")";
    }

    public void EndMatch(int state)
    {
        string finalGrade = CalculateGrade();
        int xpReward = 0;
        float recruitBoost = 0;

        
        switch (finalGrade)
        {
            case "A": xpReward = 50; recruitBoost = 20f; break;
            case "B": xpReward = 30; recruitBoost = 10f; break;
            case "C": xpReward = 10; recruitBoost = 5f; break;
            default: xpReward = 5; recruitBoost = 0f; break;
        }

        
        int totalXP = PlayerPrefs.GetInt("PF_XP", 0);
        float totalRecruit = PlayerPrefs.GetFloat("PF_Recruitment", 0);

        PlayerPrefs.SetInt("PF_XP", totalXP + xpReward);
        PlayerPrefs.SetFloat("PF_Recruitment", totalRecruit + recruitBoost);
        PlayerPrefs.Save();

        // DISPLAY RESULTS
        gradeResultText.text = "Final Grade: " + finalGrade;
        xpResultText.text = "XP Gained: +" + xpReward;
        recruitResultText.text = "Recruit Score: +" + recruitBoost;

        //resultPanel.SetActive(true);

        
        
        stateController.SetState(state);
    }

    public void CloseMatchPanel()
    {
        sideDash.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    string CalculateGrade()
    {
        if (matchPoints >= 100) return "A";
        if (matchPoints >= 50) return "B";
        if (matchPoints >= 20) return "C";
        return "F";
    }
}