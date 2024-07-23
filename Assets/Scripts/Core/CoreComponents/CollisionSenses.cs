using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    #region Check Transforms
    public Transform GroundCheck { get => groundCheck; private set => groundCheck = value; }
    [SerializeField]
    private Transform groundCheck;

    [SerializeField] 
    private float groundCheckRadius = 0.5f;
    [SerializeField]
    private LayerMask whatIsGround;
    #endregion

    #region Check Functions
    public bool Grounded
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    #endregion
}
