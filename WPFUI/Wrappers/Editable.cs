namespace WPFUI.Wrappers
{
    public interface IEditable<out T>
    {
        T Commit();
    }
}