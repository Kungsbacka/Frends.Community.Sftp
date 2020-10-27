namespace Frends.Community.Sftp.Tests.Mocks
{
    internal class MockFileResult : IFileResult
    {
        public string FullPath { get; set; }
        public bool IsDirectory { get; set; }
        public bool IsFile { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
    }
}
