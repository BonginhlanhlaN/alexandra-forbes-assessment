using System.Text;

namespace crunch.api.ui.Services.Abstration
{
    public interface ICruchFileManipulator
    {

        public StringBuilder GetFileStringFromStream(IFormFile formFile);

    }
}
