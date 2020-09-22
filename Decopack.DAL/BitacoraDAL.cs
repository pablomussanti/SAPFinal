using Decopack.Servicios.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json.Linq;
using FireSharp.Config;

namespace Decopack.DAL
{
    public class BitacoraDAL
    {


    public void Create(Bitacora Bitacora)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Descripcion = Bitacora.descripcion,
                Fecha = DateTime.Now.ToString("dd/MM/yy"),
                Usuario = Bitacora.user,
                Tipo = Bitacora.tipo,

            });

            var request = WebRequest.CreateHttp("https://saptecnologiauai.firebaseio.com/");
            request.Method = "POST";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

        }

        public List<Bitacora> Read()
        {
            IFirebaseClient BitacoraI;

            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://saptecnologiauai.firebaseio.com/"
            };

            BitacoraI = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = BitacoraI.Get("Bitacora");
            dynamic data = JsonConvert.DeserializeObject<dynamic>((response.Body));
            List<Bitacora> Bitacoras = new List<Bitacora>();

            foreach (var item in data)
            {
                Bitacoras.Add(JsonConvert.DeserializeObject<Bitacora>(((JProperty)item).Value.ToString()));
            }
            return Bitacoras;
        }
    }
}
