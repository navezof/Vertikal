using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AAction : MonoBehaviour {

    ADecorator[] decorators;

    public abstract void Act(GameObject actor, GameObject target);

    void Start()
    {
        decorators = GetComponentsInChildren<ADecorator>();
    }

    public bool Try(GameObject actor, GameObject target)
    {
        foreach (ADecorator decorator in decorators)
        {
            if (decorator.Try(actor, target) == false)
                return false;
        }
        return true;
    }

}
