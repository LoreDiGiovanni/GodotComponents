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

	[ExportGroup("Dash settings")]
    [Export]
    public float dash_time = 0.1f;
    [Export]
    public float dash_speed= 800f;
    [Export]
	public float dash_acceleration = 700.0f;
	[Export]
	public float dash_friction = 300.0f;
    [Export]
    public Timer dash_timer;
    public Vector2 dash_direction = Vector2.Zero; 
    public bool onDash = false;

    [ExportGroup("Kcnockback settings")]
    [Export]
    public float kcnockback_time = 0.1f;
    [Export]
	public float kcnockback_acceleration = 700.0f;
	[Export]
	public float kcnockback_friction = 300.0f;
    [Export]
    public Timer knockback_timer;
    public Vector2 knockback_direction = Vector2.Zero; 
    public bool onKnockback= false;

	public Vector2 VelocityOverride;
    public float current_speed = 0.0f;
    public float current_acceleration = 0.0f;
    public float current_friction = 0.0f;

    public override void _Ready(){
        current_speed = Speed;
        current_acceleration = Acceleration;
        current_friction = Friction;
        //Dash
        dash_timer.WaitTime = dash_time;
        dash_timer.OneShot = true;
        dash_timer.Timeout += OnDashTimerTimeout;
        //Knockback
        knockback_timer.WaitTime = kcnockback_time;
        knockback_timer.OneShot = true;
        knockback_timer.Timeout += OnKnockbackTimerTimeout;


    }

	public void MoveOnGroundByDirection(Vector2 direction){
        if (onDash){
            direction = dash_direction;
        }else if(onKnockback){
            direction = knockback_direction;
        }
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
		return Mathf.MoveToward(vel,current_speed*direction,current_acceleration);
	}

	public float ApplayFriction(float vel){
		 return Mathf.MoveToward(vel,0, current_friction);
	}

    public void Dash(Vector2 dir){
        dash_timer.Start();
        onDash = true;
        dash_direction = dir;
        current_speed = dash_speed;
        current_acceleration = dash_acceleration;
        current_friction = dash_friction;
    }

    public void OnDashTimerTimeout(){
        onDash = false;
        current_speed = Speed;
        current_acceleration = Acceleration;
        current_friction = Friction;
        dash_timer.Stop();
    }
    public void Knockback(Vector2 dir,float force){
        GD.Print("Knockback start");
        onKnockback = true;
        onDash = false;
        knockback_timer.Start();
        knockback_direction = dir;
        current_speed = force;
        current_acceleration = kcnockback_acceleration;
        current_friction = kcnockback_friction;
    }
    public void OnKnockbackTimerTimeout(){
        onKnockback = false;
        current_speed = Speed;
        current_acceleration = Acceleration;
        current_friction = Friction;
        GD.Print("Knockback end");
    }
}

