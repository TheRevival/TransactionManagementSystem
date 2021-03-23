using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TransactionManagementSystem.Service.Extentions
{
    public static class IFormFileExtentions
    {
        public static StringBuilder ReadAsList(this IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            var result = new StringBuilder();
            while (reader.Peek() >= 0)
            {
                result.AppendLine(reader.ReadLine());
            }

            return result;
        }
        public static async Task<string> ReadAsStringAsync(this IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            var result = new StringBuilder();
            while (reader.Peek() >= 0)
            {
                result.AppendLine(await reader.ReadLineAsync());
            }

            return result.ToString();
        }
    }
}