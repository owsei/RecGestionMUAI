using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecGestion.Entidades
{
    public class ServiceCall
    {

        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public UsuarioExiste Items { get; private set; }

        public ServiceCall()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };


        }


        //public async Task<UsuarioExiste> RefreshDataAsync()
        //{
        //    Uri BaseAddress = new Uri(string.Format($"http://192.168.1.35/RecGestionBackEnd/public/doLogin?NO={this.nombre.Text}&PS={this.password.Text}"));

        //    Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
        //    try
        //    {
        //        HttpResponseMessage response = await _client.GetAsync(uri);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string content = await response.Content.ReadAsStringAsync();
        //            Items = JsonSerializer.Deserialize<List<TodoItem>>(content, _serializerOptions);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //    }

        //    return Items;
        //}



    }
}
