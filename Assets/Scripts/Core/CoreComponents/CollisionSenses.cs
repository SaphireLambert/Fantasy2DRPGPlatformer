using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This class is for the detection of any other objects in the scene. 
/// The transforms are objects attacked to the characater defining a 
/// start position where the bool casts a ray or circle to return true or not. 
/// </summary>
 
public class CollisionSenses : CoreComponent
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    #region Check Transforms
    public Transform GroundCheck //Reference to the ground check trasnform 
    { 
        get => GenericNotImplimentedError<Transform>.TryGet(groundCheck, core.transform.parent.name); 
        private set => groundCheck = value; 
    }

    public Transform WallCheck //reference to the wall check transform
    {
        get=> GenericNotImplimentedError<Transform>.TryGet(wallCheck, core.transform.parent.name);
        private set => wallCheck = value;
    }

    public Transform LedgeCheckVertical //Reference to the lefge check transform
    {
        get => GenericNotImplimentedError<Transform>.TryGet(ledgeCheckVertical, core.transform.parent.name);
        private set => ledgeCheckVertical = value;
    }

    /// <summary>
    /// These access the trasnform in the scene so i can attach them in the project. 
    /// </summary>
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheckVertical;

    /// <summary>
    /// These are the distances for the checks to see how big the check range is
    /// </summary>
    [SerializeField] 
    private float groundCheckRadius = 0.15f;
    [SerializeField]
    private float wallCheckDistance = 0.1f;
    [SerializeField]
    private float ledgeCheckDistance = 0.3f;

    /// <summary>
    /// This is the layer that the detcetion is on.
    /// </summary>
    [SerializeField]
    private LayerMask groundLayerMask = 3; //In series he calls this whatIsGround
    #endregion

    #region Check Functions
    public bool isGroundedBool //Returns true if the character is on the ground
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);
    }
    public bool isHittingWallBool //returns true when the character come in contact with a wall
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, groundLayerMask);
    }
    public bool isHittingWallBehindBool //returns true when the character come in contact with a wall
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right * -Movement.FacingDirection, wallCheckDistance, groundLayerMask);
    }
    public bool isOnLedgeBool //Returns false if the character has found a ledge: Returns true if there is no ledge
    {
        get => Physics2D.Raycast(ledgeCheckVertical.position, Vector2.down, ledgeCheckDistance, groundLayerMask);
    }
    #endregion

    #region Debugging Gizmos
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * core.Movement.FacingDirection * wallCheckDistance));
    //    Gizmos.DrawLine(ledgeCheckVertical.position, ledgeCheckVertical.position + (Vector3)(Vector2.down * ledgeCheckDistance));
    //}
    #endregion
}
