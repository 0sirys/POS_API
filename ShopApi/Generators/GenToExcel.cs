using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using ShopApi.DTOs.GeneratorDTO;
using ShopApi.Interface;
using ShopApi.Mappers;
using ShopApi.Models;

namespace ShopApi.Generators;

public class GenToExcel(ShopContext context) : IGenerator
{



    public async Task<(string Path, byte[] file)> MonthReport(IEnumerable<DateTime> dates, string Name)
    {

        FileInfo path = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\Reports\", Name, ".xlsx"));
        DeleteifExist(path);
        var data = await Invoices(context, dates);
        using var package = new ExcelPackage(path);
        var sheet = package.Workbook.Worksheets.Add("Sheet");
        var range = sheet.Cells["A4"].LoadFromCollection(data, true, TableStyle: TableStyles.Medium2);
        sheet.Cells[range.End.Row + 2, range.Start.Column].Value = "Total";
        for (int i = range.Start.Column; i <= range.End.Column; i++)
        {
            if (String.Compare(sheet.Cells[range.Start.Row, i].Value.ToString(), "Total") == 0)
            {
                sheet.Cells[range.End.Row + 2, i].Formula = $"SUM({sheet.Cells[range.Start.Row + 1, i]}:{sheet.Cells[range.End.Row, i]})";
                sheet.Calculate();
            }
            if (String.Compare(sheet.Cells[range.Start.Row, i].Value.ToString(), "Itbs") == 0)
            {
                sheet.Cells[range.End.Row + 2, i].Formula = $"SUM({sheet.Cells[range.Start.Row + 1, i]}:{sheet.Cells[range.End.Row, i]})";
                sheet.Calculate();
            }

        }

        await package.SaveAsAsync(path);


        (string Path, byte[] file) response = ($"{Name}.xlsx", File.ReadAllBytes(path.ToString()));
        return path.Exists ? response : (null!, null!);

    }
    public async Task<(string Path, byte[] file)> DailyReport()
    {
        FileInfo pathday = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Today.Date.ToString(), ".xlsx"));

        List<DateTime> dates =
        [
             DateTime.Today.Date,
             DateTime.Today.Date,
        ];
        DeleteifExist(pathday);
        var data = await Invoices(context, dates);
        using var package = new ExcelPackage(pathday);
        var sheet = package.Workbook.Worksheets.Add("Sheet");
        var range = sheet.Cells["A4"].LoadFromCollection(data, true, TableStyle: TableStyles.Medium2);
        sheet.Cells[range.End.Row + 2, range.Start.Column].Value = "Total";
        for (int i = range.Start.Column; i <= range.End.Column; i++)
        {
            if (String.Compare(sheet.Cells[range.Start.Row, i].Value.ToString(), "Total") == 0)
            {
                sheet.Cells[range.End.Row + 2, i].Formula = $"SUM({sheet.Cells[range.Start.Row + 1, i]}:{sheet.Cells[range.End.Row, i]})";
                sheet.Calculate();
            }
            if (String.Compare(sheet.Cells[range.Start.Row, i].Value.ToString(), "Itbs") == 0)
            {
                sheet.Cells[range.End.Row + 2, i].Formula = $"SUM({sheet.Cells[range.Start.Row + 1, i]}:{sheet.Cells[range.End.Row, i]})";
                sheet.Calculate();
            }


        }

        await package.SaveAsAsync(pathday);
        (string Path, byte[] file) response = ($"{DateTime.Today.Date.ToString()}.xlsx", File.ReadAllBytes(pathday.ToString()));
        return response;

    }
    public static async Task<IEnumerable<ExO>> Invoices(ShopContext ct, IEnumerable<DateTime> dates)
    {
        EntityToExODTO toEXO = new();
        return await ct.Invoices.Where(b => b.Date.Date >= dates.ElementAt(0) && b.Date.Date <= dates.ElementAt(1)).Select(b => toEXO.Mapp(b)).ToListAsync();

    }
    public static void DeleteifExist(FileInfo path)
    {
        if (path.Exists)
            path.Delete();

    }
}