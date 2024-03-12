using NUnit.Framework;

namespace _2_3Tree.Tests
{
    [TestFixture]
    [TestOf(typeof(MainForm))]
    public class MainFormTest
    {
        [Test]
        public void EmptyInsert()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That("1", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void LeafInsert()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That("2(1|3)", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void AlreadyInTheTreeInsert()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(false, Is.EqualTo(tree.Insert("1")));
            Assert.That(false, Is.EqualTo(tree.Insert("2")));
            Assert.That(false, Is.EqualTo(tree.Insert("3")));
            Assert.That("2(1|3)", Is.EqualTo(tree.ToString));
        }


        [Test]
        public void LeafSplitInsert()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Insert("6")));
            Assert.That(true, Is.EqualTo(tree.Insert("7")));
            Assert.That("4(2(1|3)|6(5|7))", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void RootSearch()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Insert("6")));
            Assert.That(true, Is.EqualTo(tree.Insert("7")));
            Branch found = tree.Search("4");
            Assert.That("4", Is.EqualTo(found.LeftKey.ToString));
        }

        [Test]
        public void LeftSearch()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Insert("6")));
            Assert.That(true, Is.EqualTo(tree.Insert("7")));
            Branch found = tree.Search("1");
            Assert.That("1", Is.EqualTo(found.LeftKey.ToString));
        }

        [Test]
        public void RightSearch()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Insert("6")));
            Assert.That(true, Is.EqualTo(tree.Insert("7")));
            Branch found = tree.Search("7");
            Assert.That("7", Is.EqualTo(found.LeftKey.ToString));
        }

        [Test]
        public void CenterSearch()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Branch found = tree.Search("3");
            Assert.That("3", Is.EqualTo(found.LeftKey.ToString));
        }

        [Test]
        public void NullSearch()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Branch found = tree.Search("9");
            Assert.That(null, Is.EqualTo(found));
        }

        [Test]
        public void RootRemove()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Remove("1")));
            Assert.That("", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void Leaf2Remove()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Insert("6")));
            Assert.That(true, Is.EqualTo(tree.Insert("7")));
            Assert.That(true, Is.EqualTo(tree.Insert("8")));
            Assert.That(true, Is.EqualTo(tree.Remove("7")));
            Assert.That("4(2(1|3)|6(5|8))", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void Redistribute1LRemove()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Remove("1")));
            Assert.That("3(2|4)", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void Redistribute1RRemove()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Remove("4")));
            Assert.That("2(1|3)", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void Redistribute2LRemove()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Remove("1")));
            Assert.That("4((2:3)|5)", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void Redistribute2MRemove()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Remove("3")));
            Assert.That("4((1:2)|5)", Is.EqualTo(tree.ToString));
        }


        [Test]
        public void Redistribute2RRemove()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Remove("5")));
            Assert.That("2(1|(3:4))", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void MergeRemove1()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Remove("3")));
            Assert.That("(1:2)", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void MergeRemove2()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Remove("1")));
            Assert.That("4((2:3)|5)", Is.EqualTo(tree.ToString));
        }

        [Test]
        public void NotFoundRemove()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));

            Assert.That(false, Is.EqualTo(tree.Remove("6")));
        }

        [Test]
        public void AllRemove()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("10")));
            Assert.That(true, Is.EqualTo(tree.Insert("20")));
            Assert.That(true, Is.EqualTo(tree.Insert("30")));
            Assert.That(true, Is.EqualTo(tree.Insert("40")));
            Assert.That(true, Is.EqualTo(tree.Insert("50")));
            Assert.That(true, Is.EqualTo(tree.Insert("60")));
            Assert.That(true, Is.EqualTo(tree.Insert("70")));
            Assert.That(true, Is.EqualTo(tree.Insert("80")));
            Assert.That(true, Is.EqualTo(tree.Insert("90")));
            Assert.That(true, Is.EqualTo(tree.Insert("100")));
            Assert.That(true, Is.EqualTo(tree.Insert("110")));
            Assert.That(true, Is.EqualTo(tree.Insert("120")));
            Assert.That(true, Is.EqualTo(tree.Insert("130")));
            Assert.That(true, Is.EqualTo(tree.Insert("140")));
            Assert.That(true, Is.EqualTo(tree.Insert("150")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Insert("15")));
            Assert.That(true, Is.EqualTo(tree.Insert("25")));
            Assert.That(true, Is.EqualTo(tree.Insert("8")));
            Assert.That(true, Is.EqualTo(tree.Remove("5")));
            Assert.That("80(40(10:20(8|15|(25:30))|60(50|70))|120(100(90|110)|140(130|150)))",
                Is.EqualTo(tree.ToString));
            Assert.That(true, Is.EqualTo(tree.Remove("8")));
            Assert.That("80(40(20((10:15)|(25:30))|60(50|70))|120(100(90|110)|140(130|150)))",
                Is.EqualTo(tree.ToString));
            Assert.That(true, Is.EqualTo(tree.Remove("10")));
            Assert.That("80(40(20(15|(25:30))|60(50|70))|120(100(90|110)|140(130|150)))",
                Is.EqualTo(tree.ToString));
            Assert.That(true, Is.EqualTo(tree.Remove("30")));
            Assert.That("80(40(20(15|25)|60(50|70))|120(100(90|110)|140(130|150)))",
                Is.EqualTo(tree.ToString));
            Assert.That(true, Is.EqualTo(tree.Remove("15")));
            Assert.That("80:120(40:60((20:25)|50|70)|100(90|110)|140(130|150))",
                Is.EqualTo(tree.ToString));
        }


        [Test]
        public void CleatAll()
        {
            Tree tree = new Tree();
            Assert.That(true, Is.EqualTo(tree.Insert("1")));
            Assert.That(true, Is.EqualTo(tree.Insert("2")));
            Assert.That(true, Is.EqualTo(tree.Insert("3")));
            Assert.That(true, Is.EqualTo(tree.Insert("4")));
            Assert.That(true, Is.EqualTo(tree.Insert("5")));
            Assert.That(true, Is.EqualTo(tree.Insert("6")));
            Assert.That(true, Is.EqualTo(tree.Insert("7")));
            Assert.That(true, Is.EqualTo(tree.Insert("8")));
            Assert.That(true, Is.EqualTo(tree.Insert("9")));
            Assert.That(true, Is.EqualTo(tree.Insert("10")));

            tree.Clear();
            Assert.That("", Is.EqualTo(tree.ToString));
        }
    }
}