
using RecGestion.Entidades;
using System.Net.Http.Headers;
using System.Net.Http.Json;



namespace RecGestion;
public partial class LoginRecGestion : ContentPage
{

    static HttpClient client = new HttpClient();
    Uri baseAdress = new Uri("http://192.168.1.35/RecGestionBackEnd/public");

    public LoginRecGestion()
	{
		InitializeComponent();
        client.BaseAddress = baseAdress;
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }


    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        
        
        this.URLDestino.Text= client.BaseAddress.ToString();
        string URL2 = $"http://192.168.1.35/RecGestionBackEnd/public/doLogin?NO="+this.nombre.Text+"&PS="+this.password.Text;
        Uri URL = new Uri(URL2);

        UsuarioExiste usuario= new UsuarioExiste();
        //var url = await CreateProductAsync(usuario);
        
        string respuesta = "";
        try
        {
            UsuarioExiste usuarioExiste = new UsuarioExiste();
            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                respuesta = await response.Content.ReadAsStringAsync();
                this.respuestaLlamada.Text = respuesta;
            }
        }
        catch (Exception ex)
        {
            this.respuestaLlamada.Text = ex.Message;
        }
    }

    private async Task<Uri> CreateProductAsync(UsuarioExiste usuario)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync(
            "api/products", usuario);
        response.EnsureSuccessStatusCode();

        // return URI of the created resource.
        return response.Headers.Location;
    }


    //private async Task DoLoginUsuarios()
    //{
    //    using var client = new HttpClient();
    //    string serviceURL = $"localhost/RecGestionBackEnd/public/doLogin?NO={this.nombre.Text}&PS={this.password.Text}";
    //    this.respuestaLlamada.Text = "iniciando llamada:" + serviceURL;
    //    var result = await client.GetFromJsonAsync<bool>(serviceURL);
    //    //if (result.Content.ToString() != null)
    //    Console.WriteLine(result.ToString());
    //}
}