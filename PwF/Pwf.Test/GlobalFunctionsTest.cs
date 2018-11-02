using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pwf.Test {
    [TestFixture]
    public class GlobalFunctionsTest {
        [Test]
        public void ReturnModifier0Test() {
            // TODO: Add your test code here
            int number = PwF.Statics.GlobalFunctions.ReturnModifier(10);

            Assert.AreEqual(number, 0);
        }

        [Test]
        public void ReturnModifierEven2Test() {
            // TODO: Add your test code here
            int number = PwF.Statics.GlobalFunctions.ReturnModifier(14);

            Assert.AreEqual(number, 2);
        }

        [Test]
        public void ReturnModifierOdd2Test() {
            // TODO: Add your test code here
            int number = PwF.Statics.GlobalFunctions.ReturnModifier(15);

            Assert.AreEqual(number, 2);
        }

        [Test]
        public void ReturnModifierEven3Test() {
            // TODO: Add your test code here
            int number = PwF.Statics.GlobalFunctions.ReturnModifier(16);

            Assert.AreEqual(number, 3);
        }

        [Test]
        public void ReturnModifierOdd3Test() {
            // TODO: Add your test code here
            int number = PwF.Statics.GlobalFunctions.ReturnModifier(17);

            Assert.AreEqual(number, 3);
        }

        [Test]
        public void ReturnModifierNegativeTest() {
            // TODO: Add your test code here
            int number = PwF.Statics.GlobalFunctions.ReturnModifier(8);

            Assert.AreEqual(number, 0);
        }

        [Test]
        public void ReturnModifierNegativeUsingNegativeTest() {
            // TODO: Add your test code here
            int number = PwF.Statics.GlobalFunctions.ReturnModifier(-8);

            Assert.AreEqual(number, 0);
        }

        [Test]
        public void getPopupFillErrorTest() {
            // TODO: Add your test code here
            try {
                AbsoluteLayout number = PwF.Statics.GlobalFunctions.getPopUpFill();
            } catch (Exception err) {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void getFontSizeSameTest() {
            // TODO: Add your test code here
            int testNumber = (int)PwF.Statics.GlobalFunctions.getFontSize(24, 411.5);
            if(testNumber == 24) {
                Assert.Pass();
            } else {
                Assert.Fail();
            }
        }

        [Test]
        public void getFontSizeHalfTest() {
            // TODO: Add your test code here
            int testNumber = (int)PwF.Statics.GlobalFunctions.getFontSize(24, 411.5/2);
            if (testNumber == 24/2) {
                Assert.Pass();
            } else {
                Assert.Fail();
            }
        }

        [Test]
        public void getFontSizeFourthTest() {
            // TODO: Add your test code here
            int testNumber = (int)PwF.Statics.GlobalFunctions.getFontSize(24, 411.5 / 4);
            if (testNumber == 24 / 4) {
                Assert.Pass();
            } else {
                Assert.Fail();
            }
        }

        [Test]
        public void getFontSizeDoubleTest() {
            // TODO: Add your test code here
            int testNumber = (int)PwF.Statics.GlobalFunctions.getFontSize(24, 411.5 * 2);
            if (testNumber == 24 * 2) {
                Assert.Pass();
            } else {
                Assert.Fail();
            }
        }
    }


}
