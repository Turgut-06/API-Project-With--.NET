using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Exceptions
{
    public class ExceptionModel : ErrorStatusCode //hata mesajlarımın döneceği model
    {
        public IEnumerable<string > Errors { get; set; }

        public override string ToString()
        {
            //Errors yerine this de yazabiliriz
            return JsonConvert.SerializeObject(Errors); //middleware de responseların content type ını Json yaptığım için jsona çeviriyorum
        }

    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set;} 

    }
}
