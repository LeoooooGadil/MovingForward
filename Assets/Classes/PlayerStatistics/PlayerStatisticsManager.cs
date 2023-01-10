using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatisticsManager : MonoBehaviour
{
	public static PlayerStatisticsManager instance;
	[HideInInspector]
    public ExperienceManager xpManager;
	[HideInInspector]
	public WeeklyStatsManager weeklyStatsManager;

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
        xpManager = GetComponent<ExperienceManager>();
		weeklyStatsManager = GetComponent<WeeklyStatsManager>();
    }
}
