using crunch.api.ui.Models;
using crunch.api.ui.Services.Abstration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace crunch.api.ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrunchController : ControllerBase
    {

        private readonly ICruchFileManipulator _cruchFileManipulator;
        private readonly IStringCruncher _stringCruncher;
        private readonly ICrunchIO _crunchIO;
        private readonly ICrunchValidator _crunchValidator;

        public CrunchController(
            ICruchFileManipulator cruchFileManipulator, 
            IStringCruncher stringCruncher, 
            ICrunchIO crunchIO,
            ICrunchValidator crunchValidator
        ) {

            _cruchFileManipulator = cruchFileManipulator;
            _stringCruncher = stringCruncher;
            _crunchIO = crunchIO;
            _crunchValidator = crunchValidator;

        }


        [Route("CrunchWord")]
        [HttpPost]
        public Response CrunchWord([FromForm] CrunchDocument crunchDocument)
        {

            var response = new Response();

            var stringFromFile = _cruchFileManipulator.GetFileStringFromStream(crunchDocument.DocumentFile);

            var removedNewLineOperators = stringFromFile.ToString().Replace("\r\n", string.Empty);//Removes \r\n at the end of line produced by StreamReader

            var isAllUpperCases = _crunchValidator.IsAllCapitalLetters(removedNewLineOperators);
            var isAllValidPunctuation = _crunchValidator.IsAllValidPunctuations(removedNewLineOperators);
            var isBetween2and70Characters = _crunchValidator.IsBetween2and70Characters(removedNewLineOperators);

            if (!isAllUpperCases)
            {

                //Does not even Crunch if String has a lower case.
                response.Data = new { };
                response.IsSuccess = false;
                response.Message = "All Characters in your file should be capital letters.";

                return response;

            }

            if (!isAllValidPunctuation)
            {

                //Does not even Crunch if String Has invalid Punctuation.
                response.Data = new { };
                response.IsSuccess = false;
                response.Message = "One or more of your characters has a disallowed punctuation or character.";

                return response;
            }

            if (!isBetween2and70Characters)
            {

                //Does not even Crunch if String is between 2 and 70 Characters.
                response.Data = new { };
                response.IsSuccess = false;
                response.Message = "Length of your string should be between 2 and 70 character long.";

                return response;
            }

            var crunchedStringVowls = _stringCruncher.CrunchVowls(removedNewLineOperators);
            var crunchedRepeatedCharacterd = _stringCruncher.CrunchRepeatedCharachers(crunchedStringVowls);
            var crunchBeginningAndEndBlanks = _stringCruncher.CrunchBeginningAndEndBlanks(crunchedRepeatedCharacterd);
            var crunchedConsecutiveBlanks = _stringCruncher.CrunchConsecutiveBlanks(crunchBeginningAndEndBlanks);
            var crunchedBlanksBeforePunctuations = _stringCruncher.CrunchBlanksBeforePunctuations(crunchedConsecutiveBlanks);

            _crunchIO.WriteCrunchedStringOnFile(crunchedBlanksBeforePunctuations);

            
            response.Data = crunchedBlanksBeforePunctuations;
            response.IsSuccess = true;
            response.Message = "Successful";

            return response;

        }

    }
}
