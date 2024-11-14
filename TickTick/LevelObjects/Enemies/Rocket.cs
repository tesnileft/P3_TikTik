﻿using System;
using Engine;
using Microsoft.Xna.Framework;

/// <summary>
/// Represents a rocket enemy that flies horizontally through the screen.
/// </summary>
class Rocket : AnimatedGameObject
{
    Level level;
    Vector2 startPosition;
    const float speed = 500;
    private bool dead = false;

    public Rocket(Level level, Vector2 startPosition, bool facingLeft) 
        : base(TickTick.Depth_LevelObjects)
    {
        this.level = level;

        LoadAnimation("Sprites/LevelObjects/Rocket/spr_rocket@3", "rocket", true, 0.1f);
        PlayAnimation("rocket");
        SetOriginToCenter();

        sprite.Mirror = facingLeft;
        if (sprite.Mirror)
        {
            velocity.X = -speed;
            this.startPosition = startPosition + new Vector2(2*speed, 0);
        }
        else
        {
            velocity.X = speed;
            this.startPosition = startPosition - new Vector2(2 * speed, 0);
        }
        Reset();
    }

    public override void Reset()
    {
        // go back to the starting position
        dead = false;
        velocity.Y = 0;
        LocalPosition = startPosition;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        // if the rocket has left the screen, reset it
        if (sprite.Mirror && BoundingBox.Right < level.BoundingBox.Left)
            Reset();
        else if (!sprite.Mirror && BoundingBox.Left > level.BoundingBox.Right)
            Reset();

        if (dead)
        {
            velocity.Y += 15;
            if (BoundingBox.Top > level.BoundingBox.Bottom)
            {
                Reset();
            }
            return;
        }

        // if the rocket touches the player, the player dies
        if (level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player))
            //Check if player is on top of the rocket
            if (level.Player.BoundingBox.Bottom < BoundingBox.Bottom)
            {
                Die();
                level.Player.SetYImpulse(- 600);
            }
            else
            {
                Console.WriteLine(level.Player.BoundingBox.Bottom.ToString() +" > " + BoundingBox.Bottom.ToString());
                level.Player.Die();  
            }
            
    }

    public void Die()
    {
        dead = true;
    }
}
