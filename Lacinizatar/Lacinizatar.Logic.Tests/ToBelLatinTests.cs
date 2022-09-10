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
    }
}