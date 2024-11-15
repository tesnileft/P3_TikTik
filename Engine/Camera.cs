using System;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Camera
{
    public static Vector2 cameraOffset = Vector2.Zero;
    Vector2 centerOffset = Vector2.Zero;
    
    Vector2 destinationPosition = Vector2.Zero;
    Vector2 position = Vector2.Zero; 
    float followSpeed = 100f;
    
    float triggerDistance = 100f;
    
    //Camera bounds
    private Vector2 maxPos, minPos;
    
    public Camera(Rectangle bounds)
    {
        centerOffset = new Vector2(20 * 72 , 15 * 55) / 2;
        minPos = centerOffset;
        maxPos = new Vector2(bounds.Width, bounds.Height) - centerOffset*2;
    }
    //Update camera position
  
    public void Update(GameTime gameTime, Vector2 destinationPosition)
    {
        float dist = Vector2.Distance(position, destinationPosition);

        cameraOffset = -destinationPosition + centerOffset;

        //Constrain Camera
        cameraOffset.X = Math.Clamp(cameraOffset.X, -maxPos.X , 0);
        cameraOffset.Y = Math.Clamp(cameraOffset.Y, 0, maxPos.Y+200);



    }
    
    
}