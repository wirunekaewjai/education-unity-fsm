
namespace Devdayo
{
	public interface IUpdate
	{
		void OnUpdate();
	}
	public interface IFixedUpdate
	{
		void OnFixedUpdate();
	}
	public interface ILateUpdate
	{
		void OnLateUpdate();
	}
}