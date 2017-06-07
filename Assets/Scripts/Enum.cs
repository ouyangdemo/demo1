//if ((status & MotionStatusEnum.FacingRight) == MotionStatusEnum.FacingRight)
//status &= ~MotionStatusEnum.FacingRight;

public enum TagEnum {
    Player,
    Head,
    Body,
    Hand,
    Foot,
    Block,
    Pickup,
}


public enum StaticDelegateEnum {
    Input,
    Update,
    Motion,
    Action,   
    Animation,
    Audio,
}

public enum DelegateEnum {
    Input,
    Update,
    Motion,
    Action,
    Animation,
    Audio,
    Particle,
    Camera,
}

public enum CollisionEnum {
    
}


public enum UpdateEnum {
    JumpStatus,
}

public enum AnimationEnum {
    VelocityX, 
    FacingRight,
    VelocityY,
    Grounded,
    Bumped,
}

public enum AudioEnum {
    Coin,
    Death,
    GetKey,   
    HpDown,
    HpUp,
    Key,
    Jump,
    Pause,
    Pickup,
    Life,
    Bump,
    BlockBreak,
    BMG,
}

public enum ParticleEnum {
    Jump,
}

public enum CameraEnum {
    GroundedYAxis,
    Target,
    Anchoring,
    Following,
    Zooming,
}

public enum InputEnum {
    None,
    HorizontalMove,
    VerticalMove,
    Crouch,
    Jump,
    Action,
}

public enum MotionEnum {
    XAxis,
    YAxis,
    AddXAxis,
    AddYAxis,
    ReverseXAxis,
    ReverseYAxis,
}

public enum ItemPickupEnum {
    Hp,
    Coin,
    Life,
    Key,
}

public enum RendererEnum {
    Solid,
    Breakable,
    Bounce,
    Question,
}

public enum InstantiationEnum {
    Hp,
    Coin,
    Life,
    Key,    
    BlockSolid,
    BlockBreakable,
    BlockBounce,
    BlockQuestion,
    PlayerDog,
}

[System.Flags]
public enum CharacterState {
    Crouch = 1<<0,
}

public enum MoveStatus {
    Stay,
    Run,
}

public enum JumpStatus {
    Grounded,
    Jump,
}

public enum ColliderEnum {
    Head,
    Body,
    Foot,
    TrackingVision,
}

public enum InteractEnum {
    Enemy,
}
