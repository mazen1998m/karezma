using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
namespace App.Application.Notifications;
using FirebaseAdmin.Messaging;
internal class NotificationService : INotificationService
{
    private static FirebaseApp app = FirebaseApp.Create(new AppOptions { Credential = GoogleCredential.FromFile("firebase.json") });

    public async Task PushNotification(string body, string devicetoken, string title)
    {
        var message = new Message
        {
            Notification = new Notification()
            {
                Title = title,
                Body = body,
            },
            Apns = new ApnsConfig()
            {
                Aps = new Aps()
                {
                    Sound = "default",
                }
            },
            Android = new AndroidConfig()
            {
                Priority = Priority.High,
                Notification = new AndroidNotification()
                {
                    ChannelId = "default_channel",
                },
            },

            Token = devicetoken,
        };

        var firebaseMessagingInstance = FirebaseMessaging.GetMessaging(app);
        await firebaseMessagingInstance.SendAsync(message).ConfigureAwait(false);
    }

    public async Task PushNotificationTopic(string body, string topic, string title, string image)
    {
        var message = new Message
        {
            Notification = new Notification()
            {
                Title = title,
                Body = body,
                ImageUrl = image,
            },
            Apns = new ApnsConfig()
            {
                Aps = new Aps()
                {
                    Sound = "default",
                }
            },
            Android = new AndroidConfig()
            {
                Priority = Priority.High,
                Notification = new AndroidNotification()
                {
                    ChannelId = "default_channel",
                },
            },
            Topic = topic,
        };

        var firebaseMessagingInstance = FirebaseMessaging.GetMessaging(app);
        await firebaseMessagingInstance.SendAsync(message).ConfigureAwait(false);
    }
}


public interface INotificationService : IAutoInjection
{
    Task PushNotification(string body, string devicetoken, string title);
    Task PushNotificationTopic(string body, string topic, string title, string image);
}








