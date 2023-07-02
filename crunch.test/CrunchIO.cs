using crunch.api.ui.Services.Abstration;
using crunch.api.ui.Services.Implemenation;
using Moq;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crunch.test
{

    [TestClass]
    public class CrunchIOTets
    {

        readonly Mock<IFileSystem> _mock;
        public CrunchIOTets() {

            _mock = new Mock<IFileSystem>();

            _mock.Setup(f => f.File.WriteAllText(It.IsAny<String>(), It.IsAny<String>())).Verifiable();

        }

        [TestMethod]
        public void WriteCrunchedStringOnFile_ReturnsTrueIfFileWritten() 
        {

            string expectedOutput = "test";

            ICrunchIO crunchIO = new CrunchIO(_mock.Object);
            var isFileWriten = crunchIO.WriteCrunchedStringOnFile(expectedOutput);

            Assert.IsTrue(isFileWriten);

        }


    }
}
