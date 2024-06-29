namespace Microservices.DotNet8MiniBankingManagementSystem.Models.Features;

public class ReportModel<T>
{
    public string DataSetName { get { return ReportFileName + "DataSet"; } }
    public string ReportFileName { get; set; }
    public string ExportFileName { get; set; }
    public EnumFileType ReportType { get; set; }
    public Dictionary<string, string> Parameters { get; set; }
    public List<T> DataLst { get; set; }
}