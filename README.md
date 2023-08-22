# ExportToCSV

Export To CSV
The ability to export data into a CSV (Comma-Separated Values) format is an essential feature for many applications. Whether you're working with financial systems, academic datasets, or user management systems, having the ability to generate a downloadable CSV file can offer significant value to your users.

In this implementation, the CsvExport library from jitbit's GitHub repository is utilized to simplify the CSV generation process. Though the library is robust in its original form, a modification was made to better suit specific requirements. The library's AddRows function was extended to include an Ignore parameter. This parameter, an array of strings, is utilized to specify properties of the class that should not be included in the exported CSV. If a class property name matches any string in the Ignore array, it's skipped, preventing its values from being added to the CSV file.

The sample code below demonstrates how this can be utilized:

		public void AddRows(IEnumerable list, string[] Ignore)
		{
			if (list.Any())
			{
				var values = typeof(T).GetProperties();
				foreach (T obj in list)
				{
					AddRow();
					foreach (var value in values)
					{
						if (!Ignore.Contains(value.Name)){
                            this[value.Name] = value.GetValue(obj, null);
                        }
                    }
				}
			}
		}
This modification increases the versatility of the CsvExport library, making it more adaptable to scenarios where certain class properties should not be exported.

Country Model
For demonstration purposes, a Country model is used.

    public partial class Country
    {
        public int Id { get; set; }
        public int NumericId { get; set; }
        public int Code { get; set; }
        public string? Name { get; set; }
    }
    public partial class Country{

        public List GetAll() {
            List _Countrys = new List()
            {
                new Country(){ Id = 1, NumericId = 1, Code = 1, Name = "United States Of America"  },
                new Country(){ Id = 2, NumericId = 2, Code = 91, Name = "India"  },
                new Country(){ Id = 3, NumericId = 3, Code = 86, Name = "China"  },
            };            
            return _Countrys;
        }
    }


An API controller titled "Export" has been added. Within this controller, the Index method is set up to generate a CSV file titled "Countries.csv", comprising data about countries, but excluding specific fields like "Id" and "NumericId". The AddRows method is invoked with the Country model's data and an array specifying properties to ignore:

    public class ExportController : Controller
    {
        public IActionResult Index()
        {
            var myExport = new CsvExport();
            // usage 
            // myExport.AddRows<country>(List, Ignore Array )
            myExport.AddRows<country>(new Country().GetAll(), new string[] { "Id", "NumericId" });
            Byte[] file = myExport.ExportToBytes();
            return File(file, "application/octet-stream", "Countries.csv");
        }

    }
Upon invoking this method, a "Countries.csv" file is generated and presented for download, showcasing a streamlined process of generating CSV files with selective property inclusion in .NET Core 6.
