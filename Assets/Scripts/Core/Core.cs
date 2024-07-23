using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement {  get; private set; }
    public CollisionSenses CollisionSenses { get; private set; }
    public Combat Combat { get; private set; }

    private Movement movement;
    private CollisionSenses collisionSenses;
    private Combat combat;

    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();

        if (!Movement)
        {
            Debug.LogError("Missing Core Component");
        }
    }
    public void LogicUpdate()
    {
        Movement.LogicUpdate();
    }
}
