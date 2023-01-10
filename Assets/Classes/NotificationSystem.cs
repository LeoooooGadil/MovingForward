using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;


public class NotificationSystem : MonoBehaviour
{
	public static NotificationSystem instance;

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

	void Start()
	{
		var channel = new AndroidNotificationChannel()
		{
			Id = "channel_id",
			Name = "Default Channel",
			Description = "Generic notifications",
			Importance = Importance.Default,
		};

		AndroidNotificationCenter.RegisterNotificationChannel(channel);
	}

	public void SendNotification(string title, string text, int delay)
	{
		var notification = new AndroidNotification();
		notification.Title = title;
		notification.Text = text;
		notification.FireTime = System.DateTime.Now.AddSeconds(delay);

		AndroidNotificationCenter.SendNotification(notification, "channel_id");

		Debug.Log("Notification sent");
	}

	public void SendNotification(string title, string text)
	{
		var notification = new AndroidNotification();
		notification.Title = title;
		notification.Text = text;
		notification.FireTime = System.DateTime.Now.AddSeconds(5);

		AndroidNotificationCenter.SendNotification(notification, "channel_id");

		Debug.Log("Notification sent");
	}
}