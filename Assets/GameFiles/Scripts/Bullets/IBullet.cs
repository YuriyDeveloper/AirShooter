
public interface IBullet
{
    public BulletType Type { get; set; }
    public int Damage { get; set; }
    public bool CanFly { get; set; }
    public float XDirection { get; set; }
    public float XRotation { get; set; }
}
