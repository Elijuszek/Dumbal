using Dumbal;
using Godot;
using Godot.NativeInterop;
using System;

public partial class Client : HttpRequest
{
    [Export] private Table table;

    private bool isRequestPending = false;
    private const string host = "https://dumbal-8107e-default-rtdb.europe-west1.firebasedatabase.app/";

    public override void _Ready()
    {
        RequestCompleted += OnRequestCompleted;
    }
    private void OnRequestCompleted(long result, long responseCode, string[] responseHeaders, byte[] responseBody)
    {
        if (result != (long)Result.Success)
        {
            GD.Print("Error Client HttpRequest: " + result);
            return;
        }
        isRequestPending = false;
    }

    public void SendCardPosition(DragableCard card)
    {
        Dictionary<string, Variant> data = new Dictionary<string, Variant>
        {
            { "posX", card.GlobalPosition.X },
            { "posY", card.GlobalPosition.Y }
        };

        var json = Json.Stringify(data);
        string url = host + string.Format("/cards/{0}.json", card.GetInstanceId());
        GD.Print(url);
        isRequestPending = true;
        Request(url, null, HttpClient.Method.Put, json);
    }
}
