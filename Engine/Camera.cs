using System;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Camera
{
    public static Vector2 cameraOffset = Vector2.Zero;
    Vector2 destinationPosition = Vector2.Zero;
    Vector2 position = Vector2.Zero; 
    float followSpeed = 100f;
    
    float triggerDistance = 100f;
    
    //Camera bounds
    private Vector2 maxPos, minPos;
    
    public Camera(Rectangle bounds)
    {
        minPos = new Vector2(1024, 586)/2;
        maxPos = new Vector2(bounds.Width, bounds.Height) - minPos;
    }
    //Update camera position
  
    public void Update(GameTime gameTime, Vector2 destinationPosition)
    {
        float dist = Vector2.Distance(position, destinationPosition);

        cameraOffset = -destinationPosition + minPos;

        //Constrain Camera
        cameraOffset.X = Math.Clamp(cameraOffset.X, minPos.X, maxPos.X);
        cameraOffset.Y = Math.Clamp(cameraOffset.Y, minPos.Y, maxPos.Y);



    }
    
    
}