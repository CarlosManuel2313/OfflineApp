using Microsoft.Maui.Controls;
using Microsoft.Maui.Networking;

namespace OfflineApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        VerificarConexion(); // Verifica al iniciar
        Connectivity.ConnectivityChanged += ConectividadCambio; // Detecta cambios
    }

    private async void VerificarConexion()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            EstadoConexionLabel.Text = "❌ Sin conexión a Internet";
            EstadoConexionLabel.TextColor = Colors.Red;
            await DisplayAlert("Sin conexión", "No tienes acceso a Internet.", "OK");
        }
        else
        {
            EstadoConexionLabel.Text = "✅ Conectado a Internet";
            EstadoConexionLabel.TextColor = Colors.Green;
        }
    }

    private void ConectividadCambio(object? sender, ConnectivityChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            VerificarConexion();
        });
    }
}
