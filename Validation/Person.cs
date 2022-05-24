using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    internal class Person : IDataErrorInfo
    {
        
        public int Alter { get; set; }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Alter):
                        if (Alter < 0) return "Du kannst nicht jünger sein als 0 Jahre";
                        if (Alter > 150) return "Du sollst nicht lügen";
                        break;
                    default:
                        break;
                }

                return String.Empty;
            }
        }
        public string Error => null;
    }
}
