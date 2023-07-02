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
    public class StringCruncherTest
    {

        [TestMethod]
        public void RemovesVowls_ReturnsStrignWithoutVowls()
        {

            var beforeVowlCrunch = "AEIOUS";

            IStringCruncher stringCruncher = new StringCruncher();

            var afterVowelCrunch = stringCruncher.CrunchVowls(beforeVowlCrunch);

            Assert.AreEqual(afterVowelCrunch, "S");

        }

        [TestMethod]
        public void RemovesRepeatedLetters_ReturnsStringWithLettersOccuringOnlyOnce()
        {

            var beforeCharacterRepeatCrunch = "AABB";

            IStringCruncher stringCruncher = new StringCruncher();

            var afterCharacterRepeatCrunch = stringCruncher.CrunchRepeatedCharachers(beforeCharacterRepeatCrunch);

            Assert.AreEqual(afterCharacterRepeatCrunch, "AB");

        }

        [TestMethod]
        public void RemovesBlanksOnEdges_ReturnsTrimmedString()
        {

            var beforeCrunchBeginningAndEndBlanks = "  AABB ";

            IStringCruncher stringCruncher = new StringCruncher();

            var afterCrunchBeginningAndEndBlanks = stringCruncher.CrunchBeginningAndEndBlanks(beforeCrunchBeginningAndEndBlanks);

            Assert.AreEqual(afterCrunchBeginningAndEndBlanks, "AABB");

        }

        [TestMethod]
        public void RemovesConsecutiveBlanks_ReturnsStringWithNoConsecutiveBlanks()
        {

            var beforeCrunchConsecutiveBlanks = "AAB  B";

            IStringCruncher stringCruncher = new StringCruncher();

            var afterCrunchConsecutiveBlanks = stringCruncher.CrunchConsecutiveBlanks(beforeCrunchConsecutiveBlanks);


            Assert.AreEqual(afterCrunchConsecutiveBlanks, "AAB B");

        }

        [TestMethod]
        public void RemovesBlanksBeforePunctuations_ReturnsStringWithNoBlanksBeforePunctuations()
        {

            var beforeCrunchBlanksBeforePunctuations = "AAB , B";

            IStringCruncher stringCruncher = new StringCruncher();

            var afterCrunchBlanksBeforePunctuations = stringCruncher.CrunchBlanksBeforePunctuations(beforeCrunchBlanksBeforePunctuations);

            Assert.AreEqual(afterCrunchBlanksBeforePunctuations, "AAB, B");

        }

    }
}
