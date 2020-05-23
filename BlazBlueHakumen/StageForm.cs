using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazBlueFighter
{
    public partial class StageForm : Form
    {
        public static readonly Timer PhysicsTimer = new Timer{ Interval = 10 };
        public static readonly Timer InputBufferUpdateTimer = new Timer { Interval = 12 };
        public static readonly Timer FrameTimer = new Timer { Interval = 100 };
        //private readonly Dictionary<string, Keys> SettingsKeys = new Dictionary<string, Keys>();
        public static readonly int GroundLevel = 700;
        public static Player player1 = new Player(new PlayingCharacters.Hakumen(), new PointF(1100, 0));
        public static Player player2 = new Player(new PlayingCharacters.Hakumen(), new PointF(400, 0));
        public static List<Player> PlayersOnStage = new List<Player>
        {
            player1,
            //player2
        };

        public StageForm()
        {
            Text = "Waga na wa Hakumen";
            DoubleBuffered = true;
            Height = 820;
            Width = 1380;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            //
            BackgroundImage = Program.BackGroundImg;
            PhysicsTimer.Tick += UpdateScreen;
            PhysicsTimer.Start();
            FrameTimer.Tick += UpdateFrames;
            FrameTimer.Start();
            var fastFrameTimer = new Timer { Interval = 60 };
            fastFrameTimer.Tick += FastUpdateFrames;
            fastFrameTimer.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PlayersOnStage[0].SettingsKeys.Add("Left", Keys.A);
            PlayersOnStage[0].SettingsKeys.Add("Right", Keys.D);
            PlayersOnStage[0].SettingsKeys.Add("Up", Keys.W);
            PlayersOnStage[0].SettingsKeys.Add("Down", Keys.S);
            PlayersOnStage[0].SettingsKeys.Add("A", Keys.NumPad4);
            PlayersOnStage[0].SettingsKeys.Add("B", Keys.NumPad8);
            PlayersOnStage[0].SettingsKeys.Add("C", Keys.NumPad6);
            PlayersOnStage[0].SettingsKeys.Add("D", Keys.NumPad5);
            /*
            PlayersOnStage[1].SettingsKeys.Add("Left", Keys.Left);
            PlayersOnStage[1].SettingsKeys.Add("Right", Keys.Right);
            PlayersOnStage[1].SettingsKeys.Add("Up", Keys.Up);
            PlayersOnStage[1].SettingsKeys.Add("Down", Keys.Down);
            PlayersOnStage[1].SettingsKeys.Add("A", Keys.Delete);
            PlayersOnStage[1].SettingsKeys.Add("B", Keys.Home);
            PlayersOnStage[1].SettingsKeys.Add("C", Keys.PageDown);
            PlayersOnStage[1].SettingsKeys.Add("D", Keys.End);
            */
            foreach (var pl in PlayersOnStage)
            {
                PhysicsTimer.Tick += pl.Move;
                Animation.AnimationEnded += () =>
                {
                    pl.Busy = false;
                    pl.HandleKeys(Keys.None);
                    pl.CurrentMove.Animation.SetToLoopPhase();
                };
                InputBufferUpdateTimer.Tick += (sender, args) => 
                { 
                    pl.InputBuffer.AddLast(pl.GetArrow(pl.SettingsKeys, pl.PressedKeys));
                    pl.InputBuffer.RemoveFirst();
                    pl.HandleKeys(pl.CurrentPressedKey);
                    pl.CurrentPressedKey = Keys.None;
                };
            }
            InputBufferUpdateTimer.Start();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            var currentKey = e.KeyCode;
            foreach (var pl in PlayersOnStage)
            {
                if (pl.SettingsKeys.ContainsValue(currentKey))
                {
                    if (!pl.PressedKeys.Contains(currentKey))
                    {
                        pl.PressedKeys.Add(currentKey);
                        pl.CurrentPressedKey = currentKey;
                    }
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            var currentKey = e.KeyCode;
            foreach (var pl in PlayersOnStage)
            {
                if (pl.SettingsKeys.ContainsValue(currentKey))
                {
                    if (pl.PressedKeys.Contains(currentKey))
                    {
                        pl.PressedKeys.Remove(currentKey);
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Program.label.Text = player1.InputBuffer.Count > 0 ? player1.InputBuffer.Last.Value.ToString() : "kal";
            foreach (var pl in PlayersOnStage)
            {
                var curFrame = pl.CurrentMove.Animation.GetFrame();
                if (pl.FacingLeft)
                {
                    var ImgPos = new PointF(pl.Position.X - curFrame.Root.X, GroundLevel - pl.Position.Y - curFrame.Image.Height + curFrame.Root.Y);
                    e.Graphics.DrawImage(curFrame.Image, ImgPos);
                    //Debug
                    var drawPlPos = new PointF(pl.Position.X, -pl.Position.Y + GroundLevel);
                    e.Graphics.DrawRectangle(new Pen(Color.Blue), new Rectangle(ImgPos.ToIntPoint(), curFrame.Image.Size));
                    e.Graphics.DrawLine(new Pen(Color.Red), new Point((int)ImgPos.X - 2, (int)ImgPos.Y), new Point((int)ImgPos.X + 2, (int)ImgPos.Y));
                    e.Graphics.DrawLine(new Pen(Color.Lime), new Point((int)drawPlPos.X - 2, (int)drawPlPos.Y), new Point((int)drawPlPos.X + 2, (int)drawPlPos.Y));
                    e.Graphics.DrawLine(new Pen(Color.Lime), new Point((int)drawPlPos.X, (int)drawPlPos.Y + 10), new Point((int)drawPlPos.X, (int)drawPlPos.Y - 800));
                    //Program.label.Text = (ImgPos.X - drawPlPos.X).ToString();
                }
                else
                {
                    e.Graphics.ScaleTransform(-1, 1);
                    var ImgPos = new PointF(-pl.Position.X - curFrame.Root.X, GroundLevel - pl.Position.Y - curFrame.Image.Height + curFrame.Root.Y);
                    e.Graphics.DrawImage(curFrame.Image, ImgPos);
                    //Debug
                    var drawPlPos = new PointF(-pl.Position.X, -pl.Position.Y + GroundLevel);
                    e.Graphics.DrawRectangle(new Pen(Color.Blue), new Rectangle(ImgPos.ToIntPoint(), curFrame.Image.Size));
                    e.Graphics.DrawLine(new Pen(Color.Red), new Point((int)ImgPos.X - 2, (int)ImgPos.Y), new Point((int)ImgPos.X + 2, (int)ImgPos.Y));
                    e.Graphics.DrawLine(new Pen(Color.Lime), new Point((int)drawPlPos.X - 2, (int)drawPlPos.Y), new Point((int)drawPlPos.X + 2, (int)drawPlPos.Y));
                    e.Graphics.DrawLine(new Pen(Color.Lime), new Point((int)drawPlPos.X, (int)drawPlPos.Y + 10), new Point((int)drawPlPos.X, (int)drawPlPos.Y - 800));
                    e.Graphics.ScaleTransform(-1, 1);
                    //Program.label.Text = (ImgPos.X - drawPlPos.X).ToString();
                }
            }
        }

        private void UpdateScreen(object sender, EventArgs args)
        {
            foreach (var pl in PlayersOnStage)
            {
                if (pl.Position.X > 1200) pl.Teleport(new PointF(1200, pl.Position.Y));
                if (pl.Position.X < 200) pl.Teleport(new PointF(200, pl.Position.Y));
            }
            Invalidate();
        }

        private void UpdateFrames(object sender, EventArgs args)
        {
            foreach (var anim in PlayersOnStage
                .Select(p => p.CurrentMove.Animation)
                .Where(an => an.Speed == AnimationSpeed.Average))
                anim.NextFrame();
        }

        private void FastUpdateFrames(object sender, EventArgs args)
        {
            foreach (var anim in PlayersOnStage
                .Select(p => p.CurrentMove.Animation)
                .Where(an => an.Speed == AnimationSpeed.Fast))
                anim.NextFrame();
        }
    }
}
