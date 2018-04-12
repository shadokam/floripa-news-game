using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interacted {

    public string[] dialogue;
    public string name;

    public override void Interact()
    {
        base.Interact();

        DialogueGO();
    }
    public void DialogueGO()
    {
        Dialogue.instance2.AddNewDialogue(dialogue, name);
    }
}
