using Csv;
using Microsoft.AspNetCore.Mvc;

namespace ExportToCSV.Controllers
{
    public class ExportController : Controller
    {
        public IActionResult Index()
        {
            var myExport = new CsvExport();
            // usage 
            // myExport.AddRows<Country>(List, Ignore Array )
            myExport.AddRows<Country>(new Country().GetAll(), new string[] { "Id", "NumericId" });
            Byte[] file = myExport.ExportToBytes();
            return File(file, "application/octet-stream", "Countries.csv");
        }

    }
}
