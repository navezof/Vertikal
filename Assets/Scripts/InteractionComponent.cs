using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InteractionComponent : AComponent {

    List<GameObject> interactables = new List<GameObject>();
    AAction[] actions;

    protected override void Start()
    {
        actions = GetComponentsInChildren<AAction>();
    }

    public void AddInteractable(GameObject interactable)
    {
        if (!interactables.Contains(interactable))
            interactables.Add(interactable);
    }

    public void RemoveInteractable(GameObject interactable)
    {
        interactables.Clear();
    }

    public void CloseInteraction()
    {
        if (interactables.Count <= 0)
            return;
        foreach (AAction action in actions)
        {
            if (action.Try(gameObject, interactables[0]))
            {
                action.Act(gameObject, interactables[0]);
            }
        }
    }
}
