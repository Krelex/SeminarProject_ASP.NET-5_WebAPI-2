using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;

namespace SeminarMVC.Models.REST
{
    public class SeminarREST
    {
        readonly string uri = "http://localhost:59566/Api/";

        public async Task<IEnumerable<Seminar>> GetAllAsync()
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.DeserializeObject<IEnumerable<Seminar>>(await client.GetStringAsync(uri + "Seminar"));

                return rezult;
            }
        }

        public async Task<Seminar> GetByIdAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.DeserializeObject<Seminar>(await client.GetStringAsync(uri + "Seminar/" + id));
                
                return rezult;
            }
        }

        public async Task<Seminar> CreateAsync(Seminar seminar)
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.SerializeObject(await client.PostAsJsonAsync(uri + "Seminar" , seminar));

                return seminar;
            }
        }

        public async Task<Seminar> PutAsync(Seminar seminar)
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.SerializeObject(await client.PutAsJsonAsync(uri + "Seminar/" + seminar.IdSeminar, seminar));

                return seminar;
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(int Id)
        {
            using (var client = new HttpClient())
            {
                var rezult = await client.DeleteAsync(uri + "Seminar/" + Id);

                return rezult;
            }
        }
    }
}