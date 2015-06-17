using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.B2W.SDK.Models
{
    public class Error
    {
        public List<ValidationError> validationErrors { get; set; }
        
        public int httpStatusCode { get; set; }
        
        public int errorCode { get; set; }
        
        public string message { get; set; }

        public class ValidationError
        {
            public string fieldName { get; set; }

            public string restrictionType { get; set; }

            public string message { get; set; }
        }

        public bool HasValidationErrors()
        {
            return httpStatusCode == 422;
        }
    }
}
