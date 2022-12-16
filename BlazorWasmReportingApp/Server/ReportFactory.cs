using BlazorWasmReportingApp.Server;
using DevExpress.XtraReports.UI;
public static class ReportFactory {
    public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>() {
        ["TestReport"] = () => new TestReport()
    };
}
