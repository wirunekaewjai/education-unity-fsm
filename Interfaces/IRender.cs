
namespace Devdayo
{
	public interface IWillRenderObject
	{
		void OnWillRenderObject();
	}
	public interface IPreCull
	{
		void OnPreCull();
	}
	public interface IBecameVisible
	{
		void OnBecameVisible();
	}
	public interface IBecameInvisible
	{
		void OnBecameInvisible();
	}
	public interface IPreRender
	{
		void OnPreRender();
	}
	public interface IRenderObject
	{
		void OnRenderObject();
	}
	public interface IRenderImage
	{
		void OnRenderImage();
	}
	public interface IPostRender
	{
		void OnPostRender();
	}
}