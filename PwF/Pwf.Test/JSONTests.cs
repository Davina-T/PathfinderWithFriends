using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwf.Test {
    [TestFixture]
    public class JSONTests {

        [Test]
        public void GetFileNotFoundTest() {
            string test = PwF.Statics.JsonStuff.GetFile("doesn't exist");
            
            if(test == "") {
                Assert.Pass();
            } else {
                Assert.Fail("content: " + test);
            }
        }

        [Test]
        public void GetFileCharactersNotAssignedTest() {
            string test = PwF.Statics.JsonStuff.GetFile("Characters.json");

            if (test == "") {
                Assert.Pass();
            } else {
                Assert.Fail();
            }
        }
        
    }
}
