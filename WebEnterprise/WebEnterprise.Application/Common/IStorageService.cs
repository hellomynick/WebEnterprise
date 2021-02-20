using System.IO;
using System.Threading.Tasks;

namespace WebEnterprise.Application.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string FileName);
        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);
        Task DeleteFileAsync(string fileName);
    }
}
