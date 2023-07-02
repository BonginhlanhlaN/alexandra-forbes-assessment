using crunch.api.ui.Services.Abstration;
using crunch.api.ui.Services.Implemenation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crunch.test
{

    [TestClass]
    public  class CrunchValidatorTests
    {

        [TestMethod]
        public void ValidatesCapitalLetters_ReturnsFalseIfStringContainsLowerCase()
        {

            ICrunchValidator crunchValidator = new CrunchValidator();

            var isAllCapitalLetters = crunchValidator.IsAllCapitalLetters("ALL Not UPPER CASE");

            Assert.IsFalse(isAllCapitalLetters);


        }

        [TestMethod]
        public void ValidatePunctuations_ReturnsFalseIfStringContainsInValidPuctuations()
        {

            ICrunchValidator crunchValidator = new CrunchValidator();

            var isAllValidPunctuations = crunchValidator.IsAllValidPunctuations("HAS UNALLOWED # PUNCTUATION");

            Assert.IsFalse(isAllValidPunctuations);

        }

        [TestMethod]
        public void ValidatesStringLength_ReturnsFalseIfStringNotBetween2and70Characters()
        {

            ICrunchValidator crunchValidator = new CrunchValidator();

            var isAllValidPunctuations = crunchValidator.IsBetween2and70Characters("H");

            Assert.IsFalse(isAllValidPunctuations);

        }

    }
}
