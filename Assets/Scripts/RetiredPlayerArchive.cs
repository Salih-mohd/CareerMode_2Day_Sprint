using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RetiredPlayerArchive : MonoBehaviour
{
    [Header("Archive UI")]
    public GameObject historyPanel;
    public TextMeshProUGUI archiveDisplayText;
    public Button historyButton;

    void Start()
    {
        UpdateHistoryButtonVisibility();
    }

    
    public void UpdateHistoryButtonVisibility()
    {
        
        bool hasHistory = PlayerPrefs.HasKey("Archive_Name");
        historyButton.interactable = hasHistory;
    }

    // called when commitring from offferss
    public void ArchiveCurrentPlayer(string collegeName)
    {
         
        string pName = PlayerPrefs.GetString("PF_Name");
        int posID = PlayerPrefs.GetInt("PF_Pos");
        string posName = (posID == 0) ? "Attack" : (posID == 1) ? "Mid" : "Def";
        int s = PlayerPrefs.GetInt("PF_Speed");
        int p = PlayerPrefs.GetInt("PF_Power");
        int st = PlayerPrefs.GetInt("PF_Stamina");

         
        PlayerPrefs.SetString("Archive_Name", pName);
        PlayerPrefs.SetString("Archive_Pos", posName);
        PlayerPrefs.SetString("Archive_College", collegeName);
        PlayerPrefs.SetString("Archive_Stats", $"SPD: {s} | PWR: {p} | STM: {st}");
        PlayerPrefs.Save();

        UpdateHistoryButtonVisibility();
        Debug.Log("Player successfully archived to Hall of Fame!");
    }

    public void ShowHistoryPanel()
    {
        historyPanel.SetActive(true);

        string archName = PlayerPrefs.GetString("Archive_Name", "No Legend Found");
        string archPos = PlayerPrefs.GetString("Archive_Pos", "");
        string archColl = PlayerPrefs.GetString("Archive_College", "");
        string archStats = PlayerPrefs.GetString("Archive_Stats", "");

        archiveDisplayText.text = $"<b>LEGEND FOUND:</b>\n\n" +
                                  $"Name: {archName}\n" +
                                  $"Position: {archPos}\n" +
                                  $"Committed to: {archColl}\n" +
                                  $"Final Stats: {archStats}";
    }

    public void CloseHistory() => historyPanel.SetActive(false);
}