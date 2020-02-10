using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC_Voorbeeld3.Models;

namespace MVC_Voorbeeld3.Validation
{
    public class WeddeScoreAttribute : ValidationAttribute
    {
        public WeddeScoreAttribute()
        {
            ErrorMessage = "Personen met score onder de drie kunnen geen wedde boven 3000 hebben.";
        }
        public override bool IsValid(object value)
        {
            Persoon p = value as Persoon;
            return !((p.Score < 3) && (p.Wedde > 3000));
        }
    }
}