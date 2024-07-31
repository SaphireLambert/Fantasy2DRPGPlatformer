using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SignStats
{ 
    public string playerInput;
    public float[] signPositionArray = new float[] { 0, 0 };

    public void SetSignPosition(Vector2 signPosition)
    {
        signPositionArray[0] = signPosition.x;
        signPositionArray[1] = signPosition.y;
    }

    public Vector2 ReturnSignPosition()
    {
        if (signPositionArray.Length < 2)
        {
            Debug.LogError("Not enough elements in the sign position array");
            return new Vector2(0, 0);
        }

        return new Vector2(signPositionArray[0], signPositionArray[1]);
    }
}
