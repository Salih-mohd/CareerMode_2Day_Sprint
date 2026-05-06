using UnityEngine;
using UnityEngine.UI;


public class CareerStateController : MonoBehaviour
{
    public enum CareerState { Creation, Season, Playoffs, Offers }
    public CareerState currentState = CareerState.Creation;

    [Header("Panel References")]
    public Button create;
    public Button hS;
    public Button hs_Playoff;
    public Button offer;




    void Start()
    {
        // Check if we have a saved state, otherwise start at Creation
        currentState = (CareerState)PlayerPrefs.GetInt("CurrentCareerState", 0);
        RefreshUI();
    }

    public void SetState(int stateIndex)
    {
        currentState = (CareerState)stateIndex;
        PlayerPrefs.SetInt("CurrentCareerState", (int)currentState);
        PlayerPrefs.Save();
        Debug.Log($"now in state{currentState}");
        //RefreshUI();
    }

    void RefreshUI()
    {
        // Deactivate all first
        

        // Activate based on state
        switch (currentState)
        {
            case CareerState.Creation: create.interactable=true; break;
            case CareerState.Season: hS.interactable=true; break;
            case CareerState.Playoffs: hs_Playoff.interactable=true; break;
            case CareerState.Offers: offer.interactable=true; break;   
        }
    }
}