using System.Windows.Input;

namespace Flatify.MAUI.Interfaces;

public interface ILink
{
    public ICommand LinkCommand { get; set; }

    public object LinkCommandParameter { get; set; }

    public string Link { get; set; }

    public void HandleLinkClickedAsync();
}