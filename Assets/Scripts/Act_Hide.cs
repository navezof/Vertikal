using UnityEngine;
using System.Collections;
using System;

public class Act_Hide : AAction
{
    public override void Act(GameObject actor, GameObject target)
    {
        print("Hiding in " + target.name);
    }
}
