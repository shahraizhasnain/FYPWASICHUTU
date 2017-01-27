using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace SaudaMaster.SharedModel
{
    public class ResponseObject
    {
        public string Message { get; set; }
        public object Data { get; set; }

        public ResponseObject result(string message, object data)
        {
            return new ResponseObject
            {
                Message = message,
                Data = data
            };
        }
    }
}
