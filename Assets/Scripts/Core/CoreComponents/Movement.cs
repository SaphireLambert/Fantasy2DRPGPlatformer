using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    public Rigidbody2D RB {  get; private set; }
    public int FacingDirection {  get; private set; }
    public Vector2 CurrentVelocity {  get; private set; }

    public bool CanSetVelocity { get; set; }

    private Vector2 workSpace;

    protected override void Awake()
    {
        base.Awake();

        RB = GetComponentInParent<Rigidbody2D>();

        FacingDirection = 1;

        CanSetVelocity = true;
    }


    public void LogicUpdate()
    {
        CurrentVelocity = RB.velocity;
    }

    #region Set Functions
    public void SetKnockbackVelocity(float velocity, Vector2 angle, int direction) //In tutorial Series this is called SetVelocity():
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetFinalVelocity();
    }
    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelocity.y);
        SetFinalVelocity();
    }
    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, velocity);
        SetFinalVelocity();
    }

    private void SetFinalVelocity()
    {
        if(CanSetVelocity)
        {
            RB.velocity = workSpace;
            CurrentVelocity = workSpace;
        }  
    }

    public void Flip()
    {
        FacingDirection *= -1;
        RB.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    #endregion
}
