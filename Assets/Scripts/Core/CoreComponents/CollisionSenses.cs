using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    #region Check Transforms
    public Transform GroundCheck 
    { 
        get => GenericNotImplimentedError<Transform>.TryGet(groundCheck, core.transform.parent.name); 
        private set => groundCheck = value; 
    }
    public Transform WallCheck
    {
        get=> GenericNotImplimentedError<Transform>.TryGet(wallCheck, core.transform.parent.name);
        private set => wallCheck = value;
    }
    public Transform LedgeCheckVertical
    {
        get => GenericNotImplimentedError<Transform>.TryGet(ledgeCheckVertical, core.transform.parent.name);
        private set => ledgeCheckVertical = value;
    }

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheckVertical;


    [SerializeField] 
    private float groundCheckRadius = 0.3f;
    [SerializeField]
    private float wallCheckDistance = 0.1f;
    [SerializeField]
    private float ledgeCheckDistance = 0.3f;
    [SerializeField]
    private LayerMask whatIsGround = 3;
    #endregion

    #region Check Functions
    public bool isGroundedProperty //Returns true if the character is on the ground
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    public bool isHittingWallProperty //returns true when the character come in contact with a wall
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance);
    }
    public bool isOnLedgeProperty //Returns false if the character has found a ledge: Returns true if there is no ledge
    {
        get => Physics2D.Raycast(ledgeCheckVertical.position, Vector2.down, ledgeCheckDistance, whatIsGround);    
    }
    #endregion
}
