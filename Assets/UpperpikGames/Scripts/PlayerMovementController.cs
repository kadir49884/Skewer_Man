using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Upperpik;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Camera ortho;

    [SerializeField] private PlayerMovementSettings movementSettings;

    [SerializeField] private GameObject spear;

    private Vector3 diff;
    private Vector3 firstPos;
    private Vector3 mousePos;

    private Rigidbody body;

    private GameManager gameManager;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        gameManager = GameManager.Instance;
        anim = GetComponent<Animator>();
        gameManager.GameStart += GameStartThis;
    }

    private void GameStartThis()
    {
        anim.SetBool("Run", true);
    }

    void Update()
    {
        if (!gameManager.ExecuteGame)
            return;

        firstPos = Vector3.Lerp(firstPos, mousePos, .1f);

        if (Input.GetMouseButtonDown(0))
            MouseDown(Input.mousePosition);

        else if (Input.GetMouseButtonUp(0))
            MouseUp();

        else if (Input.GetMouseButton(0))
            MouseHold(Input.mousePosition);
    }


    private void FixedUpdate()
    {
        if (!gameManager.ExecuteGame)
        {
            body.velocity = new Vector3(0, body.velocity.y, 0);
            return;
        }

        body.velocity = Vector3.Lerp(body.velocity, new Vector3(diff.x, body.velocity.y, movementSettings.ForwardSpeed), .1f);

        //SPEAR ROTATE
        //body.velocity = Vector3.Lerp(body.velocity, new Vector3(0, body.velocity.y, movementSettings.ForwardSpeed), .1f);
        //Vector3 rotVector = spear.transform.eulerAngles;
        //rotVector.y += diff.x;

        //rotVector.y.ClampWithin180Angle(-15, 15);

        //Quaternion quaternion = Quaternion.Euler(rotVector);

        //spear.transform.rotation = Quaternion.Slerp(spear.transform.rotation, quaternion, 0.1f);
    }

    private void MouseDown(Vector3 inputPos)
    {
        mousePos = ortho.ScreenToWorldPoint(inputPos);
        firstPos = mousePos;
    }

    private void MouseHold(Vector3 inputPos)
    {
        mousePos = ortho.ScreenToWorldPoint(inputPos);
        diff = mousePos - firstPos;
        diff *= movementSettings.Sensitivity;
    }

    private void MouseUp()
    {
        diff = Vector3.zero;
    }
}
