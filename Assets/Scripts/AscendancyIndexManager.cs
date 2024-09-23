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

    public float ascendancyIndex = 0;

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

    //Method to adjust Ascendancy Index based on relationship status
    public void UpdateAscendancyBasedOnRelationships(int captainRelationship, int bonnieRelationship, int garyRelationship)
    {
        float newIndex = ascendancyIndex;

        //Captain's relationship effect
        newIndex = AdjustIndexBasedOnRelationship(newIndex, captainRelationship, 10, -10, 5, -5);

        //Dr. Bonnie's relationship effect
        newIndex = AdjustIndexBasedOnRelationship(newIndex, bonnieRelationship, 10, -10, 5, -5);

        //Gary's relationship effect
        newIndex = AdjustIndexBasedOnRelationship(newIndex, garyRelationship, 10, -10, 5, -5);

        //Update the final Ascendancy Index (clamped between 0 and 100)
        ascendancyIndex = Mathf.Clamp(newIndex, 0, 100);
        Debug.Log("Ascendancy Index updated: " + ascendancyIndex);

    }

    //helper function to apply relationship effects by percentage
    private float AdjustIndexBasedOnRelationship(float index, int relationship, float extraPositiveBoost, float extraNegativeDrain, float positiveBoost, float negativeDrain )
    {
        if (relationship >= 7) //extra positive
        {
            index += index * (extraPositiveBoost / 100); // 10% boost

        }
        else if (relationship <= -7) //extra negative 
        {
            index -= index * (extraNegativeDrain / 100); //10% boost
        }
        else if (relationship > 0) //positive
        {
            index += index * (positiveBoost / 100); //5% boost
        }
        else if (relationship < 0) //negative
        {
            index -= index * (negativeDrain / 100);
        }
        return index;
    }

    public void UpdateAscendancyWithMinigameScore(int score)
    {
        ascendancyIndex += score;
        ascendancyIndex = Mathf.Clamp(ascendancyIndex, 0, 100);
    }

    public float GetAscendancyIndex()
    {
        return ascendancyIndex;
    }
}
