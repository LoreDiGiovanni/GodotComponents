using Godot;

public partial class RoomSelectorComponent : Node{
    
    
	[ExportGroup("Navigation settings")]

    [Export]
    public string room_foulder = "res://Rooms/";
   
    private Sprite2D door_up;
    private Sprite2D door_down;
    private Sprite2D door_left;
    private Sprite2D door_right;
    private Node2D room_up;
    private Node2D room_down;
    private Node2D room_left;
    private Node2D room_right;
    private Node2D CurrentRoom;
    private RoomLoaderGlocabalComponent room_loader;

    public override void _Ready(){
        room_loader = GetNode<RoomLoaderGlocabalComponent>("/root/RoomLoaderGlocabalComponent");
        if(room_loader == null){
            GD.Print("No room loader provided");
        }else{
            GD.Print("[v] Room loader provided");
        }
    }

    
}
