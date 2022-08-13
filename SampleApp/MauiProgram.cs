using Microsoft.Maui.LifecycleEvents;
using CommunityToolkit.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Xaml;
using SampleApp.Services;
#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif
namespace SampleApp;
public static class MauiProgram
{

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        }).UseMauiCommunityToolkit();
        builder.AddServices();
#if WINDOWS
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                   
                    WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                    
                    AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);    
                   
                    if(winuiAppWindow.Presenter is OverlappedPresenter p)
                       { p.Maximize();
                       p.IsAlwaysOnTop=true;
                       p.IsResizable=false;
                       p.IsMaximizable = false;
                       p.IsMinimizable=false;
                       }                     
                    else
                    {
                        const int width = 1920;
                        const int height = 1080;
                        winuiAppWindow.MoveAndResize(new RectInt32(1920 / 2 - width / 2, 1080 / 2 - height / 2, width, height));                      
                        }                        
                });
            });
        });
#endif     
        return builder.Build();
    }
}