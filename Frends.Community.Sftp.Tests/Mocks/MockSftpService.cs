using System;
using System.Collections.Generic;
using Renci.SshNet;

namespace Frends.Community.Sftp.Tests.Mocks
{
    internal class MockSftpService : ISftpService
    {
        public ISftpService Connect(ConnectionInfo connectionInfo)
        {
            return this;
        }

        public void Disconnect()
        {
        }

        public void Dispose()
        {
        }

        public IEnumerable<IFileResult> ListDirectory(string path, Action<int> listCallback = null)
        {
            return new IFileResult[] {
                new MockFileResult { FullPath = "/documents/image01.jpg", IsDirectory = false, IsFile = true, Length = 12345, Name = "image01.jpg" },
                new MockFileResult { FullPath = "/documents/image02.jpg", IsDirectory = false, IsFile = true, Length = 24512, Name = "image02.jpg" },
                new MockFileResult { FullPath = "/documents/image03.jpg", IsDirectory = false, IsFile = true, Length = 54321, Name = "image03.jpg" },
                new MockFileResult { FullPath = "/documents/importantDoc.docx", IsDirectory = false, IsFile = true, Length = 12345, Name = "importantDoc.docx" },
                new MockFileResult { FullPath = "/documents/subdir", IsDirectory = true, IsFile = false, Length = 12345, Name = "subdir" }
            };
        }
    }
}
