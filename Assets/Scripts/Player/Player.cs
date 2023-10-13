using System;
using System.Collections.Generic;
using Command;
using Extension.Singleton;
using IState;
using UnityEngine;

public class Player : Singleton<Player>
{
    private IStatePlayer state;
    [TextArea] public string State;

    [SerializeField] private GameObject Light;
    private Rigidbody2D Rigidbody2D;

    private Dictionary<string, IStatePlayer> listState;

    public Action<float> OnScaleChangeScaleX;
    private float scaleX;

    #region Test State Pattern

    // private void Awake()
    // {
    //     Rigidbody2D = GetComponent<Rigidbody2D>();
    // }
    //
    // private void Start()
    // {
    //     listState = new Dictionary<string, IStatePlayer>();
    //     listState.Add(StateJump.Name, new StateJump(this));
    //     listState.Add(StateIdle.Name, new StateIdle(Rigidbody2D, this));
    //     listState.Add(StateMoving.Name, new StateMoving());
    //     ChangeState(StateIdle.Name);
    // }
    //
    // private void Update()
    // {
    //     state.UpdateState();
    // }
    //
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     state.Trigger(other);
    // }
    //
    //

    #endregion

    private CommandRemote _commandRemote;

    private void Start()
    {
        _commandRemote = new CommandRemote(Light);
    }

    private void Update()
    {
        if (scaleX != transform.localScale.x)
        {
            scaleX = transform.localScale.x;
            OnScaleChangeScaleX?.Invoke(scaleX);

        }
    }

    public void ChangeState(string nameState)
    {
        if (state != listState[nameState])
        {
            if (state != null)
            {
                state.ExitState();
            }

            state = listState[nameState];

            this.State = state.GetStateName();

            state.EnterState();
        }
    }
}