namespace Lacinizatar.Logic.Tests
{
    public class ToBelLatinTests
    {
        [TestCase("аловак", "ałovak")]
        [TestCase("бегчы", "biehčy")]
        [TestCase("вавёрка", "vaviorka")]
        [TestCase("гусь", "huś")]
        [TestCase("дрэва", "dreva")]
        [TestCase("ежа", "ježa")]
        [TestCase("жук", "žuk")]
        [TestCase("зашнуроўваць", "zašnuroŭvać")]
        [TestCase("ісьці", "iści")]
        [TestCase("йеменскі", "jemienski")]
        [TestCase("калючы", "kalučy")]
        [TestCase("ласкавы", "łaskavy")]
        [TestCase("лямпа", "lampa")]
        [TestCase("маці", "maci")]
        [TestCase("несьці", "nieści")]
        [TestCase("одэр", "oder")]
        [TestCase("паляваньне", "palavańnie")]
        [TestCase("рыж", "ryž")]
        [TestCase("самастойны", "samastojny")]
        [TestCase("сьвет", "śviet")]
        [TestCase("таўталогія", "taŭtałohija")]
        [TestCase("упэўнены", "upeŭnieny")]
        [TestCase("ўпэўнены", "ŭpeŭnieny")]
        [TestCase("фыркаць", "fyrkać")]
        [TestCase("хацець", "chacieć")]
        [TestCase("чалавек", "čałaviek")]
        [TestCase("шышка", "šyška")]
        [TestCase("эмблема", "emblema")]
        [TestCase("юнацтва", "junactva")]
        [TestCase("ямшчык", "jamščyk")]
        public void OneLowcaseWord(string cyrillic, string expected)
        {
            var result = new ToBelLatin(cyrillic).Translate();
            Assert.AreEqual(expected, result);
        }

        [TestCase("у мяне ёсьць аловак", "u mianie jość ałovak")]
        [TestCase("у мяне ёсьць аловак.", "u mianie jość ałovak.")]
        [TestCase("у мяне ёсьць аловак!", "u mianie jość ałovak!")]
        [TestCase("у мяне ёсьць аловак?", "u mianie jość ałovak?")]
        [TestCase("паслухай, у мяне ёсьць аловак", "pasłuchaj, u mianie jość ałovak")]
        [TestCase("паслухай, у мяне ёсьць: аловак, папера і кніга", "pasłuchaj, u mianie jość: ałovak, papiera i kniha")]
        [TestCase("паслухай, у мяне ёсьць: аловак, папера і кніга; усё гэта мне патрэбна", "pasłuchaj, u mianie jość: ałovak, papiera i kniha; usio heta mnie patrebna")]
        [TestCase("я - беларус", "ja - biełarus")]

        public void LowcaseSentence(string cyrillic, string expected)
        {
            var result = new ToBelLatin(cyrillic).Translate();
            Assert.AreEqual(expected, result);
        }

        [TestCase(" 2+2=5  у мяне ёсьць аловак", " 2+2=5  u mianie jość ałovak")]
        [TestCase("у мяне ёсьць аловак  123", "u mianie jość ałovak  123")]
        [TestCase("у мяне*(&   ёсьць аловак     ", "u mianie*(&   jość ałovak     ")]

        public void LowcaseSentenceWithExtraneousSymbols(string cyrillic, string expected)
        {
            var result = new ToBelLatin(cyrillic).Translate();
            Assert.AreEqual(expected, result);
        }

        [TestCase("qу мяне ёсьць аловак", "qu mianie jość ałovak")]
        [TestCase("у мяне qwer ёсьць аловак", "u mianie qwer jość ałovak")]
        [TestCase("у мянещ ёсьць аловак", "u mianieщ jość ałovak")]

        public void LowcaseSentenceWithNonBelarussianLetters(string cyrillic, string expected)
        {
            var result = new ToBelLatin(cyrillic).Translate();
            Assert.AreEqual(expected, result);
        }

        [TestCase("Зашнуроўваць", "Zašnuroŭvać")]
        [TestCase("заШнуроўваць", "ZaŠnuroŭvać")]
        [TestCase("Хлусіць", "Chłusić")]
        public void UppercaseSentenceWithNonBelarussianLetters(string cyrillic, string expected)
        {
            var result = new ToBelLatin(cyrillic).Translate();
            Assert.AreEqual(expected, result);
        }
    }
}