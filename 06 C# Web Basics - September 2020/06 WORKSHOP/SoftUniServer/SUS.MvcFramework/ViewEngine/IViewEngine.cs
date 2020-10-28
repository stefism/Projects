namespace SUS.MvcFramework
{
    public interface IViewEngine
    {
        string GetHtml(string templateCode, object viewModel);
    }
}
