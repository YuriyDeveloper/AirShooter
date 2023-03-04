

using System;

public interface IBullet
{
    int Damage { get; set; }
    void SetXDirection(int direction);
}
