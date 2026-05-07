using UnityEngine;
using TMPro;

public class PlayerProfile : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField nameInput;
    public CareerStateController stateController;

    [Header("Persistent Data")]
    public string playerName;
    public int playerPosition;  

    [Header("Section 8: Attribute System")]
    public int speed;
    public int power;
    public int stamina;

    

    public void ConfirmCreation(int positionIndex)
    {
        playerName = nameInput.text;
        if (string.IsNullOrEmpty(playerName)) playerName = "Rookie";

        playerPosition = positionIndex;

         
        if (playerPosition == 0) { speed = 15; power = 10; stamina = 12; }
        else if (playerPosition == 1) { speed = 12; power = 12; stamina = 15; }
        else { speed = 10; power = 15; stamina = 12; }

        SaveData();

         
        stateController.SetState(1);
        Debug.Log($"Profile Created: {playerName}. Attributes - S:{speed} P:{power} ST:{stamina}");
    }

    void SaveData()
    {
        PlayerPrefs.SetString("PF_Name", playerName);
        PlayerPrefs.SetInt("PF_Pos", playerPosition);
        PlayerPrefs.SetInt("PF_Speed", speed);
        PlayerPrefs.SetInt("PF_Power", power);
        PlayerPrefs.SetInt("PF_Stamina", stamina);
        PlayerPrefs.SetInt("PF_XP", 0);
        PlayerPrefs.SetFloat("PF_Recruitment", 0);
        PlayerPrefs.Save();
    }

}