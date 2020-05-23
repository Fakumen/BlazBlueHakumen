using System;
using System.Collections.Generic;
using System.Text;

namespace BlazBlueFighter
{
    public class Animation
    {
        private readonly Sprite[] Frames;
        public readonly bool Looping = false;
        public readonly AnimationSpeed Speed;
        public readonly int FrameInterval = 100;
        private readonly int LoopStart = 0;
        private readonly int LoopEnd = int.MaxValue;
        public int CurrentFrameId { get; private set; }
        public int Length => Frames.Length;
        public static event Action AnimationEnded;

        //public Sprite this[int frameIndex] => Frames[frameIndex];
        public Sprite GetFrame() => Frames[CurrentFrameId];

        public void NextFrame()
        {
            if (++CurrentFrameId >= Length || CurrentFrameId > LoopEnd)
                if (Looping)
                    CurrentFrameId = LoopStart;
                else
                {
                    AnimationEnded?.Invoke();
                    CurrentFrameId = Length - 1;
                }
        }

        public void Play()
        {
            StageForm.FrameTimer.Stop();
            StageForm.FrameTimer.Interval = (int)Speed;
            StageForm.FrameTimer.Tick += (send, args) => NextFrame();
        }

        public void Reset()
        {
            CurrentFrameId = 0;
        }

        public void SetToLoopPhase()
        {
            CurrentFrameId = LoopStart;
        }
        public Animation(Sprite[] sprites, bool cycled, int loopStartFrame = 0, int loopEndFrame = int.MaxValue, AnimationSpeed speed = AnimationSpeed.Average)
        {
            Frames = sprites;
            Looping = cycled;
            Speed = speed;
            if (cycled)
            {
                LoopStart = loopStartFrame;
                LoopEnd = loopEndFrame;
            }
        }
    }
}
