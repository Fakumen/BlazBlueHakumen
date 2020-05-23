namespace BlazBlueFighter
{
    public enum AnimationSpeed
    {
        Average,
        Fast
    }
    public enum Arrows
    {
        DownLeft = 1,
        Down = 2,
        DownRight = 3,
        Left = 4,
        Neutral = 5,
        Right = 6,
        UpLeft = 7,
        Up = 8,
        UpRight = 9
    }

    public enum TouchType
    {
        None,
        Press,
        Release,
        Hold
    }

    public enum ActionButton
    {
        None,
        A,
        B,
        C,
        D
    }

    public enum InputFigure
    {
        /*
        41236 - forward piano
        41236 4 - forward pianoR
        623 - forward triangle
        236 - forward UpperAngle
        632 - forward DownAngle
        236236 - forward DoubleUpperAngle
        (123698741) - circle
        */
        Circle,
        ForwardPianoR,
        BackwardPianoR,
        ForwardDoubleUpperAngle,
        BackwardDoubleUpperAngle,
        ForwardTriangle,
        BackwardTriangle,
        ForwardDownAngle,
        BackwardDownAngle,
        ForwardUpperAngle,
        BackwardUpperAngle,
        ForwardStrafe,
        BackwardStrafe,
        Up,
        Down,
        Forward,
        Backward,
        None
    }

    public enum MoveType
    {
        GroundOnly,
        AirOnly,
        Universal
    }
}