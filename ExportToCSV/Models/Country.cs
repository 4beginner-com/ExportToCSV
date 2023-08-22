using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExportToCSV
{
    public partial class Country
    {
        public int Id { get; set; }
        public int NumericId { get; set; }
        public int Code { get; set; }
        public string? Name { get; set; }
    }
    public partial class Country
    {

        public List<Country> GetAll() {
            List<Country> _Countrys = new List<Country>()
            {
                new Country(){ Id = 1, NumericId = 1, Code = 1, Name = "United States Of America"  },
                new Country(){ Id = 2, NumericId = 2, Code = 91, Name = "India"  },
                new Country(){ Id = 3, NumericId = 3, Code = 86, Name = "China"  },
            };            
            return _Countrys;
        }
    }

    }
