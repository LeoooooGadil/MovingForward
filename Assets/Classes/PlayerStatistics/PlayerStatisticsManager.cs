using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatisticsManager : MonoBehaviour
{
	public static PlayerStatisticsManager instance;
    ExperienceManager experienceManager;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

    void Start() {
        experienceManager = GetComponent<ExperienceManager>();
    }
}
