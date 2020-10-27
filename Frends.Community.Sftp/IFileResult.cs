#pragma warning disable 1591

namespace Frends.Community.Sftp
{
    public interface IFileResult
    {
        /// <summary>
        /// Full path of directory or file
        /// </summary>
        string FullPath { get; }
        bool IsDirectory { get; }
        bool IsFile { get; }

        /// <summary>
        /// File size in bytes
        /// </summary>
        long Length { get; }
        string Name { get; }
    }
}
