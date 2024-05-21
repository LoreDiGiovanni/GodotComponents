using Godot;
using System;

public partial class VelocityComponent : Node
{
	[ExportGroup("Movements settings")]
	[Export]
	public float Speed = 250.0f;
	[Export]
	public float Acceleration = 50.0f;
	[Export]
	public float Friction = 100.0f;
	[Export]
	public CharacterBody2D user;

	public Vector2 VelocityOverride;

	public void MoveOnGroundByDirection(Vector2 direction){
		if (direction.X != 0.0f || direction.Y != 0.0f){
			VelocityOverride.X = ApplayAcceleration(VelocityOverride.X,direction.X);
			VelocityOverride.Y = ApplayAcceleration(VelocityOverride.Y,direction.Y);
		}else{
			VelocityOverride.X = ApplayFriction(VelocityOverride.X);
			VelocityOverride.Y = ApplayFriction(VelocityOverride.Y);
		}
	}
	
	public void Move(){
		user.Velocity = VelocityOverride;
		user.MoveAndSlide();
	}

	public float ApplayAcceleration(float vel,float direction){
		return Mathf.MoveToward(vel,Speed*direction,Acceleration);
	}

	public float ApplayFriction(float vel){
		 return Mathf.MoveToward(vel,0, Friction);
	}
}

