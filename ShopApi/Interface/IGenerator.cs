using ShopApi.Models;

namespace ShopApi.Interface;


public interface IGenerator
{
    Task<(string Path, byte[] file)> MonthReport(IEnumerable<DateTime> dates, string Name);
    Task<(string Path, byte[] file)> DailyReport();
}