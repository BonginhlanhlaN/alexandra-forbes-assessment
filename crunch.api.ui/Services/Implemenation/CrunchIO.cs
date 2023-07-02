using System.IO.Abstractions;
using crunch.api.ui.Services.Abstration;

namespace crunch.api.ui.Services.Implemenation
{
    public class CrunchIO : ICrunchIO
    {

        /**
         * Class Takes Care Of all things that has to Do with producing external Files related to the Crunched String.
         * Injected The IFileSystem to make the I/O processes testable.
         */

        private readonly IFileSystem _fileSystem;

        public CrunchIO(IFileSystem fileSystem)
        {

            _fileSystem = fileSystem;

        }

        public bool WriteCrunchedStringOnFile(string str)
        {

            /**
            * Writes Crunched String to filem and Saves File on C:\Temp\ 
            * Assumes that the machine on which this project will run on has a C Drive.
            */

            try
            {

                string folder = @"C:\Temp\";
                string fileName = "CrunchedString.txt";

                string fullPath = folder + fileName;

                _fileSystem.File.WriteAllText(fullPath, str);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }



        }

    }
}
