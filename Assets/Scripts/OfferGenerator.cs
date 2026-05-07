using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OfferGenerator : MonoBehaviour
{
    public RetiredPlayerArchive archive;

    [Header("UI Offer Cards")]
    public GameObject[] offerCards;  
    public TextMeshProUGUI[] schoolNames;
    public TextMeshProUGUI[] requirementTexts;
    public Button[] commitButtons;

    [Header("Recruitment Logic")]
    public float currentScore;

    void OnEnable()
    {
        GenerateOffers();
    }

    public void GenerateOffers()
    {
        currentScore = PlayerPrefs.GetFloat("PF_Recruitment", 0);

        
        SetCard(0, "State Tech", 0);

        
        if (currentScore >= 25) SetCard(1, "Northlake Uni", 25);
        else offerCards[1].SetActive(false);

        
        if (currentScore >= 50) SetCard(2, "Elite Vanguard", 50);
        else offerCards[2].SetActive(false);
    }

    void SetCard(int index, string schoolName, float req)
    {
        offerCards[index].SetActive(true);
        schoolNames[index].text = schoolName;
        requirementTexts[index].text = $"Requirement: {req} Score";
    }

    public void CommitToSchool(string schoolName)
    {
        PlayerPrefs.SetString("PF_CommittedSchool", schoolName);
        PlayerPrefs.Save();
        archive.ArchiveCurrentPlayer(schoolName);
        Debug.Log("Committed to: " + schoolName);

        
    }
}