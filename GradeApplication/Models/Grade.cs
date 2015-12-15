using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeApplication.Models
{
    public class Grade
    {
        public double Value { get; set; }

        public Grade(double Value)
        {
            this.Value = Value;
        } 
    }
}
