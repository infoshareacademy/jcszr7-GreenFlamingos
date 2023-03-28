using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingos.Model.APIResponses
{
    public class ApiIngredient
    {
        public string IdIngredient { get; set; }
        public string StrIngredient { get; set; }
        [DisplayName("Description")]
        public string StrDescription { get; set; }
        public string StrType { get; set; }
        public string StrAlcohol { get; set; }
        [DisplayName("Alcohol content")]
        public string StrABV { get; set; }
    }
}
