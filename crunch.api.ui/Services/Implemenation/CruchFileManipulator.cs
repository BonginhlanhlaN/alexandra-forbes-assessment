using crunch.api.ui.Models;
using crunch.api.ui.Services.Abstration;
using System.Text;

namespace crunch.api.ui.Services.Implemenation
{
    public class CruchFileManipulator : ICruchFileManipulator
    {

        /**
         *This Class Takes Care Of Extracting the contents of the file(String).
         **/

        public CruchFileManipulator() { }

        public StringBuilder GetFileStringFromStream(IFormFile formFile)
        {

            /**
             * Reads The Contents of the File and Converts them into String Builder. 
             */

            var result = new StringBuilder();
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            {

                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());

            }

            return result;

        }


    }
}
