using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class MoveOnClick : MonoBehaviour
{

    public Interacted focus;

    public LayerMask movementMask;
    UnityEngine.AI.NavMeshAgent agente;
    PlayerMotor motor;
    Camera cam;

    // Use this for initialization
    void Start()
    {
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
               Interacted interactable = hit.collider.GetComponent<Interacted>();
                    if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus (Interacted newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OffFocus();
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocus(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
            focus = null;
        motor.StopFollow();
    }
}
