using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static Frends.Community.Sftp.Tests.Helpers;

namespace Frends.Community.Sftp.Tests
{
    [TestFixture]
    class SftpTests
    {
        private Parameters _dummyParams = new Parameters { Server = "foo.bar.com", Port = 1234, UserName = "demo", Password = "demo", Directory = "/" };

        [TestCase(null, IncludeType.Both, new[] { "image01.jpg", "image02.jpg", "image03.jpg", "importantDoc.docx", "subdir" })]
        [TestCase("", IncludeType.Both, new[] { "image01.jpg", "image02.jpg", "image03.jpg", "importantDoc.docx", "subdir" })]
        [TestCase("subdir", IncludeType.Both, new[] { "subdir" })]
        [TestCase("*.jpg", IncludeType.Both, new[] { "image01.jpg", "image02.jpg", "image03.jpg" })]
        [TestCase(null, IncludeType.File, new[] { "image01.jpg", "image02.jpg", "image03.jpg", "importantDoc.docx" })]
        [TestCase("", IncludeType.File, new[] { "image01.jpg", "image02.jpg", "image03.jpg", "importantDoc.docx" })]
        [TestCase("subdir", IncludeType.File, new string[] { })]
        [TestCase("*.jpg", IncludeType.File, new[] { "image01.jpg", "image02.jpg", "image03.jpg" })]
        [TestCase(null, IncludeType.Directory, new[] { "subdir" })]
        [TestCase("", IncludeType.Directory, new[] { "subdir" })]
        [TestCase("subdir", IncludeType.Directory, new[] { "subdir" })]
        [TestCase("*.jpg", IncludeType.Directory, new string[] { })]
        public void GetDirectoryList(string fileMask, IncludeType includeType, IEnumerable<string> expectedFileNames)
        {
            var options = new Options { FileMask = fileMask, IncludeType = includeType };
            var result = CreateSftpTaskInstance().ListDirectoryInternal(_dummyParams, options, new System.Threading.CancellationToken());

            Assert.That(result.Select(f => f.Name), Is.EquivalentTo(expectedFileNames));
        }

        [Test]
        [Ignore("This is used to test with an actual SFTP server.")]
        public void GetActualDirectoryList()
        {
            var input = new Parameters
            {
                Server = "test",
                Port = 22,
                UserName = "test",
                Password = "test",
                Directory = "."
            };

            var options = new Options
            {
                FileMask = "*.jpg"
            };

            var result = Sftp.ListDirectory(input, options, new System.Threading.CancellationToken());

            Assert.That(result, Is.Not.Empty);
        }
    }
}
