using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlazBlueFighter
{
    public class Player
    {
        public PointF Position { get; private set; }
        public readonly Character PlayingCharacter;
        #region private Fields
        private float health;
        private float heatGauge;
        private float overDriveMeter;
        private int ticksInAir;
        #endregion private Fields
        public float Health 
        { 
            get { return health; } 
            private set { health = value < 0 ? 0 : value; } 
        }
        public float HeatGauge //(0-100%)"Super Move meter"
        {
            get { return heatGauge; }
            private set { heatGauge = value < 0 ? 0 : value > 100 ? 100 : value; }
        }
        public float OverDriveMeter 
        {
            get { return overDriveMeter; }
            private set { overDriveMeter = value < 0 ? 0 : value > 100 ? 100 : value; }
        }
        public bool IsDead => Health == 0;
        public bool OnGround => Position.Y <= 0;
        public bool CanMoveInAir { get; private set; } = true;
        public bool Busy { get; set; } = false;
        public bool FacingLeft { get; set; } = true;
        public PointF MoveVector;
        public GameMove CurrentMove { get; private set; }
        public readonly LinkedList<Arrows> InputBuffer = new LinkedList<Arrows>();
        public readonly HashSet<Keys> PressedKeys = new HashSet<Keys>();
        public readonly Dictionary<string, Keys> SettingsKeys = new Dictionary<string, Keys>();
        public Keys CurrentPressedKey = Keys.None;

        public Player(
            Character character, 
            PointF position, 
            float health, 
            float heatGauge, 
            float overDriveMeter)
        {
            PlayingCharacter = character;
            Position = position;
            Health = health;
            HeatGauge = heatGauge;
            OverDriveMeter = overDriveMeter;
            CurrentMove = PlayingCharacter.MoveList["Idle"];
            for (var i = 0; i < 20; i++)
                InputBuffer.AddLast(Arrows.Neutral);
        }

        public Player(Character character, PointF position) : this(character, position, character.InitialHealth, 100, 100) { }

        public Player(Character character) : this(character, new Point(0, 0)) { }

        public List<Arrows> FilteredBuffer()
        {
            var result = new List<Arrows>();
            result.Add(InputBuffer.First.Value);
            foreach (var arrow in InputBuffer.Skip(1))
                if (arrow != result[result.Count - 1])
                    result.Add(arrow);
            return result;
        }

        public void HandleKeys(Keys currentKey)
        {
            if (Busy)
                return;
            var actButton = ActionButton.None;
            if (currentKey == SettingsKeys["A"])
                actButton = ActionButton.A;
            if (currentKey == SettingsKeys["B"])
                actButton = ActionButton.B;
            if (currentKey == SettingsKeys["C"])
                actButton = ActionButton.C;
            if (currentKey == SettingsKeys["D"])
                actButton = ActionButton.D;

            var moveToSet = GetRightInputMove(actButton);
            if (currentKey == SettingsKeys["Up"]) SetCurrentMove(moveToSet, true);
            else SetCurrentMove(moveToSet);
        }

        public void SetCurrentMove(GameMove move, bool ignoreRepeat = false)
        {
            if (!Busy && (CurrentMove != move || ignoreRepeat))
            {
                if (OnGround)
                    Stop();
                CurrentMove = move;
                CurrentMove.Perform(this);
            }
        }

        public void ForceSetCurrentMove(GameMove move)
        {
            //StageForm.PhysicsTimer.Tick -= MoveForward;
            //StageForm.PhysicsTimer.Tick -= MoveBackward;
            //StageForm.PhysicsTimer.Tick -= JumpOffset;
            CurrentMove = move;
            CurrentMove.Perform(this);
        }

        public void GetDamage(float damage)
        {
            Health -= damage > 0 ? damage : 0;
        }

        public void Teleport(PointF point)
        {
            Position = point;
        }

        public void Stop()
        {
            CanMoveInAir = true;
            ticksInAir = 0;
            MoveVector = PointF.Empty;
            StageForm.PhysicsTimer.Tick -= JumpOffset;
        }

        public void Move(object sender, EventArgs args)
        {
            Position = Position.Add(MoveVector);
            if (Position.Y < 0)
                Position = Position.SetY(0);
        }

        public void MoveForward()
        {
            var moveX = 10;
            if (FacingLeft) moveX *= -1;
            MoveVector = MoveVector.SetX(moveX);
        }

        public void MoveBackward()
        {
            var moveX = -8;
            if (FacingLeft) moveX *= -1;
            MoveVector = MoveVector.SetX(moveX);
        }

        public void Jump()
        {
            if (!CanMoveInAir)
                return;
            Stop();
            if (!OnGround)
                CanMoveInAir = false;
            StageForm.PhysicsTimer.Tick += JumpOffset;
        }

        public void Fall()
        {
            ticksInAir = 12;
            StageForm.PhysicsTimer.Tick -= JumpOffset;
            StageForm.PhysicsTimer.Tick += JumpOffset;
        }

        private void JumpOffset(object sender, EventArgs args)
        {
            ++ticksInAir;
            MoveVector = MoveVector.SetY(60 - 5 * ticksInAir);
            if (Position.Y <= 0 && ticksInAir > 1)
            {
                Stop();
                CurrentMove = PlayingCharacter.MoveList["Idle"];
                CurrentMove.Perform(this);
            }
        }

        public GameMove GetRightInputMove(ActionButton button)
        {
            var possibleMoveNames = GetPossibleInputs(button);
            var moveToSet = CurrentMove;//   <-- SOME SERIOUS SHIT HERE!!! FIX IT!
            foreach (var name in possibleMoveNames)
                if (PlayingCharacter.MoveList.ContainsKey(name)
                    && (PlayingCharacter.MoveList[name].ConditionalMove == null
                    || PlayingCharacter.MoveList[name].ConditionalMove == CurrentMove.Name))
                    moveToSet = PlayingCharacter.MoveList[name];
            return moveToSet;
        }

        public Arrows GetArrow(Dictionary<string, Keys> settings, HashSet<Keys> inputedKeys)
        {
            sbyte x = 0;
            sbyte y = 0;
            if (inputedKeys.Contains(settings["Left"]))
                x--;
            if (inputedKeys.Contains(settings["Right"]))
                x++;
            if (inputedKeys.Contains(settings["Down"]))
                y--;
            if (inputedKeys.Contains(settings["Up"]))
                y++;
            return x switch
            {
                1 => y == 0 ? Arrows.Right : y < 0 ? Arrows.DownRight : Arrows.UpRight,
                -1 => y == 0 ? Arrows.Left : y < 0 ? Arrows.DownLeft : Arrows.UpLeft,
                0 => y == 0 ? Arrows.Neutral : y < 0 ? Arrows.Down : Arrows.Up,
                _ => Arrows.Neutral,
            };
        }

        public IEnumerable<string> GetPossibleInputs(ActionButton actionButton)
        {
            var filterInputs = FilteredBuffer();
            var lastDirection = filterInputs[filterInputs.Count - 1].Turn(FacingLeft);
            if (actionButton == ActionButton.None)
            {
                if (OnGround)
                {
                    if (lastDirection == Arrows.Neutral)
                        yield return "Idle";
                    if (lastDirection == Arrows.Down || lastDirection == Arrows.DownLeft || lastDirection == Arrows.DownRight)
                        yield return "Crouch";
                    if (lastDirection == Arrows.Left)
                        yield return "ForwardWalk";
                    if (lastDirection == Arrows.Right)
                        yield return "BackwardWalk";
                }
                var prevDirect = filterInputs.Count > 1 ? filterInputs[filterInputs.Count - 2] : Arrows.Neutral;
                if (prevDirect != Arrows.UpLeft && prevDirect != Arrows.Up && prevDirect != Arrows.UpRight)
                {
                    if (lastDirection == Arrows.Up)
                        yield return "UpJump";
                    if (lastDirection == Arrows.UpLeft)
                        yield return "ForwardJump";
                    if (lastDirection == Arrows.UpRight)
                        yield return "BackwardJump";
                }
                yield break;
            }
            //
            var possibleName = new StringBuilder();
            possibleName.Append(actionButton);
            possibleName.Append(OnGround ? "G" : "A");
            yield return possibleName.ToString();
            /*
            if (lastDirection == Arrows.DownLeft || lastDirection == Arrows.DownRight)
            {
                possibleName.Append(2);
                yield return possibleName.ToString();
                possibleName.Remove(possibleName.Length - 1, 1);
            }
            */
            filterInputs.Reverse();
            foreach (var dir in filterInputs.Select(ar => ar.Turn(FacingLeft)))
            {
                possibleName.Append((int)dir);
                yield return possibleName.ToString();
                if (possibleName.Length > 18)
                    yield break;
            }
            //possibleName.Remove(possibleName.Length - 1, 1);
            //possibleName.Append("B");
            //yield return possibleName.ToString();
            Program.label2.Text = possibleName.ToString();
        }
    }
}
