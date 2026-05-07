using UnityEngine;
using TMPro;

public class ProgressionUIController : MonoBehaviour
{
    [Header("UI Fields")]
    public TextMeshProUGUI nameAndPosText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI staminaText;

    // Call this whenever the panel is opened
    public void OpenPanel()
    {
        gameObject.SetActive(true);
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        // Fetch from PlayerPrefs
        string pName = PlayerPrefs.GetString("PF_Name", "Rookie");
        int posID = PlayerPrefs.GetInt("PF_Pos", 0);
        string posName = (posID == 0) ? "Attack" : (posID == 1) ? "Mid" : "Def";

        nameAndPosText.text = $"{pName} | {posName}";
        xpText.text = "XP: " + PlayerPrefs.GetInt("PF_XP", 0);

        speedText.text = "Speed: " + PlayerPrefs.GetInt("PF_Speed", 10);
        powerText.text = "Power: " + PlayerPrefs.GetInt("PF_Power", 10);
        staminaText.text = "Stamina: " + PlayerPrefs.GetInt("PF_Stamina", 10);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}