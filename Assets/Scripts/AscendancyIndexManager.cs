using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using TMPro;
using TreeEditor;
using UnityEngine;

public class AscendancyIndexManager : MonoBehaviour
{
    public static AscendancyIndexManager Instance;
    public TextMeshProUGUI ascendancyIndexText; // UI text for displaying the score
    public float ascendancyIndex = 0;

    //mini-game 1 connections
    private SolarGameController solarGameController;
    private MiniGame1Manager miniGame1Manager;

    private void Start()
    {
        // Find the SolarGameController in the scene
        solarGameController = FindObjectOfType<SolarGameController>();
        if (solarGameController == null)
        {
            Debug.LogError("SolarGameController not found!");
        }

        miniGame1Manager = FindObjectOfType<MiniGame1Manager>();
        if (miniGame1Manager == null)
        {
            Debug.LogError("MiniGame1Manager not found!");
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private float CalculatingEngineerScore(int starRating)
    {
        int level = solarGameController.GetCurrentLevel(); // Get the current level from SolarGameController
        float score = 0;

        switch (level)
        {
            case 0:
                if (starRating == 3)
                    score = 5f;
                else if (starRating == 2)
                    score = 3.75f;
                else if (starRating == 1)
                    score = 2.5f;
                break;
            case 1: // Level 1
                if (starRating == 3)
                    score = 15f; // 3 stars = 15 points
                else if (starRating == 2)
                    score = 11.25f; // 2 stars = 11.25 points
                else if (starRating == 1)
                    score = 7.5f; // 1 star = 7.5 points
                else
                    score = 0f;
                break;
            case 2: // Level 2
                if (starRating == 3)
                    score = 20f; // 3 stars = 20 points
                else if (starRating == 2)
                    score = 15f; // 2 stars = 15 points
                else if (starRating == 1)
                    score = 10f; // 1 star = 10 points
                else
                    score = 0f; // 0 stars = 0 points
                break;
            case 3:
                if (starRating == 3)
                    score = 30f; // 3 stars = 30 points
                else if (starRating == 2)
                    score = 22.5f; // 2 stars = 22.5 points
                else if (starRating == 1)
                    score = 15f; // 1 star = 15 points
                else
                    score = 0f; // 0 stars = 0 points
                break;
            case 4: // Level 4 (Final Level)
                if (starRating == 3)
                    score = 50f; // 3 stars = 50 points
                else if (starRating == 2)
                    score = 37.5f; // 2 stars = 37.5 points
                else if (starRating == 1)
                    score = 25f; // 1 star = 25 points
                else
                    score = 0f; // 0 stars = 0 points
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        return score;
    }

    // Placeholder for Biologist's minigame score (MiniGame2)
    /*
    private float CalculateBiologistScore(int starRating)
    {
        int level = PipeGameController.Instance.GetCurrentLevel();  // Get the current level
        float score = 0;
    
        // Add similar logic to calculate score based on star ratings once the Biologist minigame is implemented

        switch (level)
        {
            case 0:
                if (starRating == 3)
                    score = 5f;
                else if (starRating == 2)
                    score = 3.75f;
                else if (starRating == 1)
                    score = 2.5f;
                break;
            case 1: // Level 1
                if (starRating == 3)
                    score = 15f; // 3 stars = 15 points
                else if (starRating == 2)
                    score = 11.25f; // 2 stars = 11.25 points
                else if (starRating == 1)
                    score = 7.5f; // 1 star = 7.5 points
                else
                    score = 0f;
                break;
            case 2: // Level 2
                if (starRating == 3)
                    score = 20f; // 3 stars = 20 points
                else if (starRating == 2)
                    score = 15f; // 2 stars = 15 points
                else if (starRating == 1)
                    score = 10f; // 1 star = 10 points
                else
                    score = 0f; // 0 stars = 0 points
                break;
            case 3:
                if (starRating == 3)
                    score = 30f; // 3 stars = 30 points
                else if (starRating == 2)
                    score = 22.5f; // 2 stars = 22.5 points
                else if (starRating == 1)
                    score = 15f; // 1 star = 15 points
                else
                    score = 0f; // 0 stars = 0 points
                break;
            case 4: // Level 4 (Final Level)
                if (starRating == 3)
                    score = 50f; // 3 stars = 50 points
                else if (starRating == 2)
                    score = 37.5f; // 2 stars = 37.5 points
                else if (starRating == 1)
                    score = 25f; // 1 star = 25 points
                else
                    score = 0f; // 0 stars = 0 points
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
       
        return score;
    }
    */

    private float ApplyRelationshipModifiers(float currentScore)
    {
        // Assuming the relationships are based on characters' flags from MasterEventSystem
        if (MasterEventSystem.Instance.checkFlag(Flags.HawthornLikePlus))
        {
            currentScore *= 1.10f; // +10% boost
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.HawthornLike))
        {
            currentScore *= 1.05f; // +5% boost
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.HawthornDislike))
        {
            currentScore *= 0.95f; // -5% drain
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.HawthornDislikePlus))
        {
            currentScore *= 0.90f; // -10% drain
        }

        // Dr. Aspen Bonnie Relationship
        if (MasterEventSystem.Instance.checkFlag(Flags.BonnieLikePlus))
        {
            currentScore *= 1.10f; // +10% boost
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.BonnieLike))
        {
            currentScore *= 1.05f; // +5% boost
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.BonnieDislike))
        {
            currentScore *= 0.95f; // -5% drain
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.BonnieDislikePlus))
        {
            currentScore *= 0.90f; // -10% drain
        }

        // Gary Pine Relationship
        if (MasterEventSystem.Instance.checkFlag(Flags.PineLikePlus))
        {
            currentScore *= 1.10f; // +10% boost
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.PineLike))
        {
            currentScore *= 1.05f; // +5% boost
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.PineDislike))
        {
            currentScore *= 0.95f; // -5% drain
        }
        else if (MasterEventSystem.Instance.checkFlag(Flags.PineDislikePlus))
        {
            currentScore *= 0.90f; // -10% drain
        }

        return currentScore;
    }

    // Update the UI element to show the current Ascendancy Index
    private void UpdateAscendancyScoreUI(float totalScore)
    {
        ascendancyIndexText.text = totalScore.ToString("F1");
    }

    // Calculate the final Ascendancy Index score based on star ratings and relationships
    public void CalculateFinalScore()
    {
        float totalScore = 0;

        //check player role and calculate the score accordingly
        if (MasterEventSystem.Instance.getRole() == Roles.Engineer)
        {

            //get star rating for the engineer minigame (minigame1)
            int starRating = miniGame1Manager.GetStarRating();
            totalScore = CalculatingEngineerScore(starRating);
        }
        else if (MasterEventSystem.Instance.getRole() == Roles.Biologist)
        {
            // Placeholder for Biologist's score (MiniGame2)
            /*
            int starRating = PipeGameController.Instance.GetStarRating();
            totalScore = CalculateBiologistScore(starRating);
            */
        }
        totalScore = ApplyRelationshipModifiers(totalScore);
        ascendancyIndex = totalScore;
        UpdateAscendancyScoreUI(ascendancyIndex);
    }

    public float GetAIScore() //for ranking system
    {
        return ascendancyIndex;  // Returns the score the player has
    }

    public float GetAscendancyIndex()
    {
        return ascendancyIndex;
    }
}
