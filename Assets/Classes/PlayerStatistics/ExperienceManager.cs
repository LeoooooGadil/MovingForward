using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentExperience = 0;
    public int experienceToNextLevel = 100;

    public void AddExperience(int experience)
    {
        currentExperience += experience;
        if (currentExperience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        currentExperience -= experienceToNextLevel;
        currentLevel++;
        experienceToNextLevel = Mathf.RoundToInt(experienceToNextLevel * 1.1f);
    }
}
