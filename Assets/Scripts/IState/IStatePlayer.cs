using System.Collections.Generic;
using UnityEngine;

namespace IState
{
    public interface IStatePlayer
    {
        public void EnterState();
        public void UpdateState();
        public void ExitState();
        public void Trigger(Collider2D collider2D);
        public string GetStateName();
    }

    public class StateIdle : IStatePlayer
    {
        private Rigidbody2D Rigidbody2D;
        private Player _player;

        public StateIdle(Rigidbody2D rigidbody2D, Player player)
        {
            this.Rigidbody2D = rigidbody2D;
            _player = player;
        }

        public static string Name = "StateIdle";

        public void EnterState()
        {
        }

        public void UpdateState()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rigidbody2D.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                _player.ChangeState(StateJump.Name);
            }
        }

        public void ExitState()
        {
        }

        public void Trigger(Collider2D collider2D)
        {
        }


        public string GetStateName()
        {
            return Name;
        }
    }

    public class StateJump : IStatePlayer
    {
        public static string Name = "StateJump";

        private Player Player;

        public StateJump(Player player)
        {
            this.Player = player;
        }

        public void EnterState()
        {
        }

        public void UpdateState()
        {
        }

        public void ExitState()
        {
        }

        public void Trigger(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Ground"))
            {
                Player.ChangeState(StateIdle.Name);
            }
        }


        public string GetStateName()
        {
            return Name;
        }
    }

    public class StateMoving : IStatePlayer
    {
        public static string Name = "StateMoving";

        public void EnterState()
        {
        }

        public void UpdateState()
        {
        }

        public void ExitState()
        {
        }

        public void Trigger(Collider2D collider2D)
        {
        }


        public string GetStateName()
        {
            return Name;
        }
    }
}

namespace Command
{
    public interface CommandPattern
    {
        public void Excute();
    }

    public class JumpCommmand : CommandPattern
    {
        private GameObject Light;

        public JumpCommmand(GameObject Light)
        {
            this.Light = Light;
        }

        public void Excute()
        {
            Light.SetActive(true);
        }
    }

    public class DontAllowJumpCommand : CommandPattern
    {
        private GameObject Light;

        public DontAllowJumpCommand(GameObject Light)
        {
            this.Light = Light;
        }

        public void Excute()
        {
            Light.SetActive(false);
        }
    }

    public class CommandRemote
    {
        private CommandPattern _commandPattern;
        private List<CommandPattern> _commandPatterns;
        private int index;

        public CommandRemote(GameObject Light)
        {
            _commandPatterns = new List<CommandPattern>();
            _commandPatterns.Add(new JumpCommmand(Light));
            _commandPatterns.Add(new DontAllowJumpCommand(Light));
        }


        public void Remote()
        {
            _commandPattern = _commandPatterns[index++ % _commandPatterns.Count];

            _commandPattern.Excute();
        }
    }
}