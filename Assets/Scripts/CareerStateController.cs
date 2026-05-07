using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CareerStateController : MonoBehaviour
{
    public enum CareerState { Creation, Season, Playoffs, Offers }
    public CareerState currentState = CareerState.Creation;

    [Header("References")]
    public Button create;
    public Button hS;
    public Button hs_Playoff;
    public Button offer;
    public SideDashboardController sideDash;




    void Start()
    {
         
        currentState = (CareerState)PlayerPrefs.GetInt("CurrentCareerState", 0);
        RefreshUI();
    }

    public void SetState(int stateIndex)
    {
        currentState = (CareerState)stateIndex;
        PlayerPrefs.SetInt("CurrentCareerState", (int)currentState);
        PlayerPrefs.Save();
        Debug.Log($"now in state{currentState}");
        sideDash.UpdateStatusDisplay(currentState.ToString());
        RefreshUI();
    }

    void RefreshUI()
    {
        int currentLevel = (int)currentState;

         
        create.interactable = (currentLevel >= 0);
        hS.interactable = (currentLevel >= 1);
        hs_Playoff.interactable = (currentLevel >= 2);
        offer.interactable = (currentLevel >= 3);
    }

    public void ResetAllCareerData()
    {
         
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        currentState = CareerState.Creation;
        RefreshUI();


    }


}