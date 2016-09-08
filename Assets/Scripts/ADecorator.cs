using UnityEngine;
using System.Collections;

public abstract class ADecorator : MonoBehaviour {

    public abstract bool Try(GameObject actor, GameObject target);
}
