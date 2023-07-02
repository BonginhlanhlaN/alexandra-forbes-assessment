using crunch.api.ui.Services.Abstration;
using crunch.api.ui.Services.Implemenation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crunch.test
{


    [TestClass]
    public class CrunchFileManipulator
    {

        [TestMethod]
        public void GetFileStringFromStream_ReturnsSameStringAsOneInFile()
        {

            var fileName = "test.txt";

            var contentStringBuilder = new StringBuilder("Hello World from a Fake File"); ;

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            writer.Write(contentStringBuilder.ToString());
            writer.Flush();
            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            ICruchFileManipulator cruchFileManipulator = new CruchFileManipulator();

            var stringbuilder = cruchFileManipulator.GetFileStringFromStream(file);

            Assert.AreEqual(contentStringBuilder.ToString().Trim(), stringbuilder.ToString().Trim());

        }

    }
}
