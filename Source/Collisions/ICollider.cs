namespace GameBase;

public interface ICollider
{
	public void OnCollisionEnter(Collider other);

	public Collider Collider { get; protected set; }
}
