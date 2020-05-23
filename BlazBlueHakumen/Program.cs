using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BlazBlueFighter
{
    static class Program
    {
        public static Label label = new Label();
        public static Label label2 = new Label();
        public static Image BackGroundImg = new Bitmap(@"..\..\..\Resources\bg_1.png");
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            
            var form = new StageForm();
            label.Location = new Point(200, 200);
            label2.Location = new Point(320, 200);
            label2.Text = "0";
            form.Controls.Add(label);
            form.Controls.Add(label2);
            //form.KeyDown += StageForm.RequestRemove;
            form.MouseClick += (sender, args) => 
            
            {
                /*
                if (args.Button == MouseButtons.Left)
                    StageForm.player1.SetCurrentMove(StageForm.player1.PlayingCharacter.MoveList["BG6325632"]);//Teleport(StageForm.player1.Position.SetY(300));
                if (args.Button == MouseButtons.Right)
                    StageForm.player1.Fall();
                    */
                StageForm.player1.SetCurrentMove(StageForm.player1.PlayingCharacter.MoveList["IdleTaunt"]);
                StageForm.player1.FacingLeft = !StageForm.player1.FacingLeft;
                label.Text = args.X.ToString() + " " + args.Y.ToString(); 
            };
            Application.Run(form);
        }
    }
}
