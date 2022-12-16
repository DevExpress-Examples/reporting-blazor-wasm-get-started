using DevExpress.XtraReports.Services;
using DevExpress.XtraReports.UI;

namespace BlazorWasmReportingApp.Server {
    public class ReportProvider : IReportProvider {
        XtraReport IReportProvider.GetReport(string id, ReportProviderContext context) {
            if (ReportFactory.Reports.ContainsKey(id)) {
                return ReportFactory.Reports[id]();
            }
            else
                throw new DevExpress.XtraReports.Web.ClientControls.FaultException
                    (string.Format("Could not find report '{0}'.", id));
        }
    }
}
