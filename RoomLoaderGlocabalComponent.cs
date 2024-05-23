using Godot;
using System.Collections.Generic;

public partial class RoomLoaderGlocabalComponent: Node
{


	private List<string> caves_rooms = new List<string>();
	private List<string> woods_rooms = new List<string>();


	public override void _Ready(){

		
	}

	public string getRandomRoom(string type){
		switch(type){
			case "caves":
				return "nil";
			case "woods":
				return "nil";
			default:
				return "nil";
		}
	}
}
