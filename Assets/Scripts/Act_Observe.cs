using UnityEngine;
using System.Collections;
using System;

public class Act_Observe : AAction
{
    public override void Act(GameObject actor, GameObject target)
    {
        Observation observation = target.GetComponent<Observation>();
        print(observation.observation);
    }
}
