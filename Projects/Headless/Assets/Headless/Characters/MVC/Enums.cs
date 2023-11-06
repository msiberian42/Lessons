public enum Direction
{
    Left,
    Right
}

namespace PlayerMVC
{
    public enum State
    {
        Idle,
        Moving,
        Jumping,
        Falling,
        Attacking,
        Death
    }
}
namespace EnemyMVC
{
    public enum State
    {
        Idle,
        Patrolling,
        Chasing,
        Attacking,
        Death
    }
}
