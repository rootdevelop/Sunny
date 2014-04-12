using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Microsoft.ServiceBus.Notifications;

namespace Sunny.Services.Services
{
    public class PushService
    {
        /// <summary>
        /// Sends a push notification to all registered devices
        /// </summary>
        /// <param name="message">Push message (max 107 characters)</param>
        /// <returns></returns>
        public static async Task SendNotification(string message)
        {
            if (message.Length > 107)
                throw new Exception("Message lenght exceeds 107 characters");

            // Setup connection
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(WebConfigurationManager.AppSettings["PushEndpoint"], "spacechallenge");
            
            // Send iOS Push Notifications
            var alert = "{\"aps\":{\"alert\":\"" + message + "\"}}";
            await hub.SendAppleNativeNotificationAsync(alert);

            // Send Windows Store Push Notifications
            var toastTemplate = @"<toast><visual><binding template=""ToastText01""><text id=""1"">{0}</text></binding></visual></toast>";
            var toast = string.Format(toastTemplate, message);
            await hub.SendWindowsNativeNotificationAsync(toast);
        }
    }
}