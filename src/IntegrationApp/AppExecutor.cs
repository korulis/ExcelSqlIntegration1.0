using System;
using System.Configuration;
using System.Data.SqlClient;
using ExcelData;
using SqlData;

namespace IntegrationApp
{
    internal class AppExecutor
    {
        private readonly ExcelFileParser _excelRepo;
        private readonly GerveSqlRepository _sqlRepo;
        private DataProcesser<ExcelDto,SqlDto> _dataProcesser;

        public AppExecutor()
        {
            _excelRepo = new ExcelFileParser(@"C:\Users\k.blazevicius\Desktop\test.xlsx");

            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["GerveSqlDbConnection"].ToString());
            var sqlContext = new GerveContext(sqlConnection);
            _sqlRepo = new GerveSqlRepository(sqlContext);

            _dataProcesser = new DataProcesser<ExcelDto,SqlDto>();
        }

        public void Execute()
        {
            _excelRepo.GetDataFromSheet<ExcelDto>("SpecialSheetName");
            
        }
    }

    internal class DataProcesser<T, T1>
    {
    }

    public class SqlDto
    {
        
    }

    public struct ExcelDto
    {
        public string Id;
        public string Comment;
        public decimal Amount;
        public DateTime Timestamp;
    }

}
