using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SeminarMVC.Models.REST
{
    public class PredbiljezbaREST
    {
        readonly string uri = "http://localhost:59566/Api/";

        public async Task<IEnumerable<Predbiljezba>> GetAllAsync()
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.DeserializeObject<IEnumerable<Predbiljezba>>(await client.GetStringAsync(uri + "Predbiljezbas"));

                return rezult;
            }
        }

        public async Task<Predbiljezba> GetByIdAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.DeserializeObject<Predbiljezba>(await client.GetStringAsync(uri + "Predbiljezbas/" + id));
                
                return rezult;
            }
        }

        public async Task<Predbiljezba> CreateAsync(Predbiljezba predbiljezba)
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.SerializeObject( await client.PostAsJsonAsync(uri + "Predbiljezbas", predbiljezba));

               
                return predbiljezba;
            }
        }

        public async Task<HttpResponseMessage> PutAsync(Predbiljezba predbiljezba)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage respone;
                var rezult = JsonConvert.SerializeObject( respone =await client.PutAsJsonAsync(uri + "Predbiljezbas/" + predbiljezba.IdPredbiljezba , predbiljezba));

                return respone;
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(int Id)
        {
            using (var client = new HttpClient())
            {
                var rezult = await client.DeleteAsync(uri + "Predbiljezbas/" + Id);

                return rezult;
            }
        }

        public async Task<string> BrojPolaznikaAsync(int Id)
        {
            using (var client = new HttpClient())
            {
                var rezult =  client.GetStringAsync(uri + "Predbiljezbas/" + Id + "/PolaznikaCount").Result;

                return rezult;
            }
        }
    }
}