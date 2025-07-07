using Microsoft.Extensions.Logging;

namespace PilamungaSEvaluacion3P.Views;

public partial class LogsPage : ContentPage
{
    string logPath = Path.Combine(FileSystem.AppDataDirectory, "Logs_Pilamunga.txt");
    public LogsPage()
	{
		InitializeComponent();
        CargarLogs();
    }
    void CargarLogs()
    {
        if (File.Exists(logPath))
        {
            LogLabel.Text = File.ReadAllText(logPath);
        }
        else
        {
            LogLabel.Text = "No hay logs aún.";
        }
    }
}