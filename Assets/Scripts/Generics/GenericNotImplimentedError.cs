using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericNotImplimentedError<T>
{
    public static T TryGet(T value, string name)
    {
        if (value != null)
        {
            return value;
        }

        Debug.LogError(typeof(T) + " not implimented on " +  name);
        return default;
    }
}
