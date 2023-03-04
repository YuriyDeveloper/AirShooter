

using System;

public interface IBullet
{
    BulletIs bulletIs { get; set; }
    int Damage { get; set; }
    public void SetXDirection(int direction);
}
