using UnityEngine;
using System.Collections;
using System;

public class Dec_IsClass : ADecorator
{
    public String className;

    public override bool Try(GameObject actor, GameObject target)
    {
        if (target.GetComponent(className) != null)
        {
            return true;
        }
        return false;
    }
}
