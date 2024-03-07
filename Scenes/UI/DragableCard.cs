namespace Dumbal;
public partial class DragableCard : Card
{
    [Export] private TouchScreenButton touchButton;
    private Vector2 origin = new Vector2();
    Random rand = new Random();
    public override void _Ready()
    {
        base._Ready();
        SetPhysicsProcess(false);
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (touchButton.IsPressed())
        {
            GlobalPosition = GetGlobalMousePosition();
        }
    }
    private void TouchButtonPressed()
    {
        SetProcess(true);
    }
    private void TouchButtonReleased()
    {
        SetProcess(false);
    }
}
