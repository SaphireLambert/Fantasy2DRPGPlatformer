using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Core : MonoBehaviour
{
    private readonly List<CoreComponent> CoreComponents = new List<CoreComponent>();

    #region Components
   

    #endregion

    #region Functions
    private void Awake()
    {
       
    }

    public void LogicUpdate()
    {
        foreach (CoreComponent component in CoreComponents) component.LogicUpdate();
    }

    public void AddCoreComponent(CoreComponent component)
    {
        if (!CoreComponents.Contains(component))
        {
            CoreComponents.Add(component);
        }
    }

    public T GetCoreComponent<T>() where T : CoreComponent
    {
       var comp = CoreComponents.OfType<T>().FirstOrDefault();
        if(comp) return comp;

        comp = GetComponentInChildren<T>();

        if(comp) return comp;

        Debug.LogWarning($"{typeof(T)} not found on {transform.parent.name}.");
        return null;
    }
    #endregion
}
