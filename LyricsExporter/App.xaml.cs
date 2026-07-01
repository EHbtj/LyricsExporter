using System;
using System.Windows;
using System.Diagnostics;
using System.IO;

namespace LyricsExporter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            if (e.Args.Length > 0)
            {
                try
                {
                    // MP3ファイルの読み込み
                    var tfile = TagLib.File.Create(e.Args[0]);
                    File.WriteAllText(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "get_lyrics.txt", tfile.Tag.Lyrics);
                }
                catch
                {
                    Debug.WriteLine("Error: can't read file");
                }
                Application.Current.Shutdown();
            }

            else
            {
                File.WriteAllText(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "get_lyrics.txt", "");
                Application.Current.Shutdown();
                // ウィンドウを表示
                MainWindow mainWindow = new MainWindow();
            }

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                // 例外情報をログに記録
                Debug.WriteLine($"非UIスレッド例外が発生しました: {ex.Message}");
                Debug.WriteLine($"スタックトレース: {ex.StackTrace}");
            }
            else
            {
                Debug.WriteLine("非UIスレッドで不明な例外が発生しました。");
            }
        }
    }
}