using System.Collections;
using System.Collections.Generic;
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
    private float wallCheckDistance = 0.4f;
    [SerializeField]
    private float ledgeCheckDistance = 0.7f;
    [SerializeField]
    private LayerMask whatIsGround;
    #endregion

    #region Check Functions
    public bool Grounded
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    public bool Wall
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, whatIsGround);
    }
    public bool LedgeVertical
    {
        get => Physics2D.Raycast(ledgeCheckVertical.position, Vector2.down, ledgeCheckDistance, whatIsGround);    
    }
    #endregion
}
