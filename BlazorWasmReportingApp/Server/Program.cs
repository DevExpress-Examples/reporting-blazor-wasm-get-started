using BlazorWasmReportingApp.Server;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.XtraReports.Web.Extensions;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDevExpressControls();
// Register the name resolution service for the Document Viewer.
//builder.Services.AddScoped<DevExpress.XtraReports.Services.IReportProvider, ReportProvider>();
// Register the service that works for the Document Viewer (name resolution)
// and Report Designer (loads and saves reports).
builder.Services.AddScoped<ReportStorageWebExtension, ReportStorage>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseReporting(builder => {
    builder.UserDesignerOptions.DataBindingMode =
        DevExpress.XtraReports.UI.DataBindingMode.ExpressionsAdvanced;
});
app.UseDevExpressControls();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

string contentPath = app.Environment.ContentRootPath;
AppDomain.CurrentDomain.SetData("DXResourceDirectory", contentPath);

app.Run();
