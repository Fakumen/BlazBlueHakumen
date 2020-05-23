using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace BlazBlueFighter
{
    public static class PlayingCharacters
    {
        public class Hakumen : Character
        {
            public Hakumen() : base("Hakumen", 12000, new Dictionary<string, GameMove>())
            {
                var anim_Idle = new Animation(new[]
                {
                    //new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_01.png"), new Point(124, 0)),
                    //new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_00.png"), new Point(128, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_00.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_01.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_02.png"), new Point(152, 1)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_03.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_04.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_05.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_06.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_07.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_08.png"), new Point(153, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_09.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_10.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha000_11.png"), new Point(152, 0))
                }, true);
                var anim_ForwardWalk = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha030_00.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha030_01.png"), new Point(142, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha030_02.png"), new Point(131, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha030_03.png"), new Point(115, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha030_04.png"), new Point(100, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha030_05.png"), new Point(103, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha030_06.png"), new Point(103, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha030_07.png"), new Point(108, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha030_08.png"), new Point(150, 0))
                }, true, 1);
                var anim_BackwardWalk = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha031_00.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha031_01.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha031_02.png"), new Point(140, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha031_03.png"), new Point(147, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha031_04.png"), new Point(155, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha031_05.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha031_06.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha031_07.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha031_08.png"), new Point(134, 0))
                }, true, 1);
                var anim_Crouch = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_00.png"), new Point(128, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_01.png"), new Point(124, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_02.png"), new Point(132, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_03.png"), new Point(132, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_04.png"), new Point(133, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_05.png"), new Point(132, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_06.png"), new Point(132, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_07.png"), new Point(132, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_08.png"), new Point(132, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_09.png"), new Point(132, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_10.png"), new Point(132, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_11.png"), new Point(133, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_12.png"), new Point(133, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha010_13.png"), new Point(133, 0))
                }, true, 2);
                var anim_Jump = new Animation(new[]
                {
                    //new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha020_00.png"), new Point(128, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha020_01.png"), new Point(128, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha020_01.png"), new Point(128, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha020_02.png"), new Point(128, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha020_02.png"), new Point(128, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha020_03.png"), new Point(128, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha020_03.png"), new Point(128, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha020_04.png"), new Point(128, 0)),
                    //new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha020_05.png"), new Point(128, 0))
                }, true, 4, 4);
                var anim_IdleTaunt = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha001_00.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha001_01.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha001_02.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha001_03.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha001_04.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha001_05.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha001_06.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha001_07.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha001_08.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha001_09.png"), new Point(152, 0))
                }, false);
                var anim_5A_Ground = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha200_00.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha200_01.png"), new Point(152, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha200_02.png"), new Point(232, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha200_03.png"), new Point(217, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha200_04.png"), new Point(151, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha200_05.png"), new Point(151, 0))
                }, false, speed:AnimationSpeed.Fast);
                var anim_2A_Ground = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha230_00.png"), new Point(130, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha230_01.png"), new Point(149, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha230_02.png"), new Point(322, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha230_03.png"), new Point(305, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha230_04.png"), new Point(201, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha230_05.png"), new Point(130, 0))
                }, false, speed:AnimationSpeed.Fast);
                var anim_4A_Ground = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_00.png"), new Point(150, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_01.png"), new Point(150, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_02.png"), new Point(150, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_03.png"), new Point(150, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_04.png"), new Point(245, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_05.png"), new Point(198, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_06.png"), new Point(172, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_07.png"), new Point(179, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_08.png"), new Point(195, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_09.png"), new Point(150, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha210_10.png"), new Point(150, 0))
                }, false, speed: AnimationSpeed.Fast);
                var anim_5A_Air = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha250_00.png"), new Point(134, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha250_01.png"), new Point(134, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha250_02.png"), new Point(256, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha250_03.png"), new Point(245, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha250_04.png"), new Point(184, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha250_05.png"), new Point(154, 170))
                }, false, speed: AnimationSpeed.Fast);
                var anim_2A_Air = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_00.png"), new Point(195, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_01.png"), new Point(148, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_02.png"), new Point(143, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_03.png"), new Point(145, 2)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_04.png"), new Point(149, 30)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_05.png"), new Point(314, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_06.png"), new Point(314, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_07.png"), new Point(314, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_08.png"), new Point(214, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_09.png"), new Point(194, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha260_10.png"), new Point(134, 0)),
                }, false, speed: AnimationSpeed.Fast);
                var anim_5B_Ground = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_00.png"), new Point(98, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_01.png"), new Point(48, -16)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_02.png"), new Point(21, -13)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_03.png"), new Point(248, -16)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_04.png"), new Point(232, -16)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_05.png"), new Point(206, -16)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_06.png"), new Point(132, -15)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_07.png"), new Point(102, -15)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_08.png"), new Point(105, -14)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_09.png"), new Point(110, -11)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha201_10.png"), new Point(150, 0))
                }, false, speed: AnimationSpeed.Fast);
                var anim_2B_Ground = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha231_00.png"), new Point(120, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha231_01.png"), new Point(108, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha231_02.png"), new Point(91, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha231_03.png"), new Point(126, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha231_04.png"), new Point(291, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha231_05.png"), new Point(283, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha231_06.png"), new Point(256, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha231_07.png"), new Point(203, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha231_08.png"), new Point(149, 0)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha231_09.png"), new Point(118, 0))
                }, false, speed: AnimationSpeed.Fast);
                var anim_4B_Ground = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_00.png"), new Point(54, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_01.png"), new Point(70, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_02.png"), new Point(125, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_03add3.png"), new Point(120, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_03add4.png"), new Point(152, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_03.png"), new Point(228, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_04.png"), new Point(242, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_05.png"), new Point(240, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_06.png"), new Point(240, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_07.png"), new Point(236, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_08.png"), new Point(230, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_09.png"), new Point(230, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_10.png"), new Point(233, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_11.png"), new Point(156, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha211_12.png"), new Point(158, -2))

                }, false, speed: AnimationSpeed.Fast);
                var anim_Super_Mugen_Ground = new Animation(new[]
                {
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_00.png"), new Point(150, -4)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_01.png"), new Point(140, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_02.png"), new Point(103, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_03.png"), new Point(109, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_04.png"), new Point(110, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_05.png"), new Point(113, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_06.png"), new Point(113, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_07.png"), new Point(113, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_08.png"), new Point(113, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_09.png"), new Point(113, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_10.png"), new Point(131, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_11.png"), new Point(159, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_12.png"), new Point(156, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_13.png"), new Point(139, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_14.png"), new Point(129, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_15.png"), new Point(113, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_16.png"), new Point(113, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_17.png"), new Point(113, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_18.png"), new Point(113, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_19.png"), new Point(133, -12)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_20.png"), new Point(154, -7)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_21.png"), new Point(140, -4)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_22.png"), new Point(149, -2)),
                    new Sprite(new Bitmap(@"..\..\..\Resources\Images\Characters\Hakumen\ha450_23.png"), new Point(151, 0)),

                }, false, speed: AnimationSpeed.Average);
                //
                var moves = new List<GameMove>
                {
                    //(A/B/C/D) + (A/G/B) + [Input] + ...
                    new GameMove("Idle", anim_Idle, action:(player) => { player.Stop(); player.Busy = false; }),
                    new GameMove("ForwardWalk", anim_ForwardWalk, action:(player) => { player.MoveForward(); }),
                    new GameMove("BackwardWalk", anim_BackwardWalk, action:(player) => { player.MoveBackward(); }),
                    new GameMove("Crouch", anim_Crouch, MoveType.GroundOnly),
                    new GameMove("ForwardJump", anim_Jump, MoveType.Universal, action:(player) => { player.Jump(); player.MoveForward(); }),
                    new GameMove("BackwardJump", anim_Jump, MoveType.Universal, action:(player) => { player.Jump(); player.MoveBackward(); }),
                    new GameMove("UpJump", anim_Jump, MoveType.Universal, action:(player) => { player.Jump(); }),
                    new GameMove("IdleTaunt", anim_IdleTaunt, condMove:"Idle", action:(player) => player.Busy = true),
                    new GameMove("AG", anim_5A_Ground, damage: 200, action:(player) => player.Busy = true),
                    new GameMove("AG2", anim_2A_Ground, condMove:"Crouch", damage: 200, action:(player) => player.Busy = true),
                    new GameMove("AG4", anim_4A_Ground, damage: 600, action:(player) => { player.Busy = true; }),
                    new GameMove("AA", anim_5A_Air, damage: 200, action:(player) => player.Busy = true),
                    new GameMove("AA2", anim_2A_Air, damage: 300, action:(player) => player.Busy = true),
                    new GameMove("BG", anim_5B_Ground, damage: 400, action:(player) => { player.Busy = true; }),
                    new GameMove("BG2", anim_2B_Ground, condMove:"Crouch", damage: 400, action:(player) => { player.Busy = true; }),
                    new GameMove("BG4", anim_4B_Ground, damage: 600, action:(player) => { player.Busy = true; }),
                    new GameMove("BG6325632", anim_Super_Mugen_Ground, damage: 0, action:(player) => { player.Busy = true; }),
                };
                foreach (var m in moves)
                    MoveList.Add(m.Name, m);
            }
        }

        public class Azrael : Character
        {
            public Azrael() : base("Azrael", 12000, new Dictionary<string, GameMove>())
            {

            }
        }
    }
}
