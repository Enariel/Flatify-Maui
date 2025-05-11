using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Flatify.MAUI.Interfaces;

namespace Flatify.MAUI.Controls;

public partial class FlatHyperlinkLabel : Label, ILink
{
    private CancellationToken _cancellationToken = CancellationToken.None;

    public static readonly BindableProperty LinkProperty =
        BindableProperty.Create(nameof(Link), typeof(string), typeof(FlatHyperlinkLabel), null);

    public static readonly BindableProperty LinkCommandProperty =
        BindableProperty.Create(nameof(LinkCommand), typeof(ICommand), typeof(FlatHyperlinkLabel), null);

    public static readonly BindableProperty LinkCommandParameterProperty =
        BindableProperty.Create(nameof(LinkCommandParameter), typeof(object), typeof(FlatHyperlinkLabel), null);

    public string Link
    {
        get { return (string)GetValue(LinkProperty); }
        set { SetValue(LinkProperty, value); }
    }

    public ICommand LinkCommand
    {
        get => (ICommand)GetValue(LinkCommandProperty);
        set => SetValue(LinkCommandProperty, value);
    }

    public object LinkCommandParameter
    {
        get => (object)GetValue(LinkCommandParameterProperty);
        set => SetValue(LinkCommandParameterProperty, value);
    }

    public FlatHyperlinkLabel()
    {
        InitializeComponent();
        GestureRecognizers.Add
        (
            new TapGestureRecognizer
            {
                Command = new Command(HandleLinkClickedAsync, () => true)
            }
        );
    }

    public async void HandleLinkClickedAsync()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(Link))
            {
                try
                {
                    await Launcher.Default
                        .OpenAsync(Link)
                        .WaitAsync(_cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    // Task was cancelled
                    Debug.WriteLine($"Opening URL was cancelled.");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to open URL: {ex.Message}");
                    throw;
                }
            }

            if (!_cancellationToken.IsCancellationRequested)
            {
                try
                {
                    LinkCommand?.Execute(LinkCommandParameter ?? null);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Command execution failed: {ex.Message}");
                    throw;
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Error in OnTapped: {e.Message}");
            throw;
        }
    }
}