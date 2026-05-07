using UnityEngine;
using TMPro;

public class XPEconomyManager : MonoBehaviour
{
    public PlayerProfile playerProfile;
    public TextMeshProUGUI xpDisplay;
    public ProgressionUIController progressionUI;

    void Start()
    {
        RefreshUI();
    }

    public void AddXP(int amount)
    {
        int currentXP = PlayerPrefs.GetInt("PF_XP", 0);
        PlayerPrefs.SetInt("PF_XP", currentXP + amount);
        RefreshUI();
    }

    public void BuyUpgrade(string attributeName)
    {
        int currentXP = PlayerPrefs.GetInt("PF_XP", 0);
        int cost = 10;  

        if (currentXP >= cost)
        {
            PlayerPrefs.SetInt("PF_XP", currentXP - cost);

             
            int currentVal = PlayerPrefs.GetInt("PF_" + attributeName);
            PlayerPrefs.SetInt("PF_" + attributeName, currentVal + 1);

            Debug.Log($"Upgraded {attributeName} to {currentVal + 1}");
            progressionUI.RefreshDisplay();

            //RefreshUI();
        }
        else
        {
            Debug.Log("Not enough XP!");
        }
    }

    void RefreshUI()
    {
        xpDisplay.text = "XP: " + PlayerPrefs.GetInt("PF_XP", 0);
    }
}