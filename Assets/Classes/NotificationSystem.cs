using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public static class NotificationSystem
{
    public static void SendNotification(string title, string message, int delay)
    {
        if (!Permission.HasUserAuthorizedPermission(Permission))
        {
            Permission.RequestUserPermission(Permission.Notification);
        }

        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = message;
        notification.FireTime = System.DateTime.Now.AddSeconds(delay);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
}
