﻿/*
 This program is free software; you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation; either version 2 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program; if not, write to the Free Software
 Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/

using NUnit.Framework;
using ThalesSim.Core.Commands;
using ThalesSim.Core.Commands.Host;
using ThalesSim.Core.Commands.Host.Implementations;
using ThalesSim.Core.Cryptography.LMK;
using ThalesSim.Core.Message;
using ThalesSim.Core.Resources;
using ThalesSim.Core.Utility;

namespace ThalesSim.Tests.Unit.Commands
{
    [TestFixture]
    public class HostCommandTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            CommandExplorer.Discover();
            LmkStorage.LmkStorageFile = "nofile.txt";
            LmkStorage.GenerateTestLmks(false);
            ConfigHelpers.SetAuthorizedState(true);
        }

        [Test]
        public void SetHsmDelayTest()
        {
            Assert.AreEqual("00", TestMessage("000", new SetHsmDelay_LG()));
        }

        [Test]
        public void CancelAuthStateTest()
        {
            ConfigHelpers.SetAuthorizedState(true);
            Assert.AreEqual("00", TestMessage("", new CancelAuthState_RA()));
            Assert.IsFalse(ConfigHelpers.IsInAuthorizedState());
            ConfigHelpers.SetSingleLengthZmk();
        }

        [Test]
        public void EchoTest()
        {
            Assert.AreEqual("80", TestMessage("000A0123456", new EchoTest_B2()));
            Assert.AreEqual("15", TestMessage("000A0123456789ABCDEF", new EchoTest_B2()));
            Assert.AreEqual("000123456789", TestMessage("000A0123456789", new EchoTest_B2()));
        }

        [Test]
        public void ImportKeyTest()
        {
            ConfigHelpers.SetSingleLengthZmk();
            Assert.AreEqual("000406FBB23A5214DF0035BB", TestMessage("0024ED06495741C280C35ED0C0EA7F7D0FAZ", new ImportKey_A6()));
            Assert.AreEqual("000406FBB23A5214DF0035BB", TestMessage("0024ED06495741C280CB9219C90F03A9627Z5", new ImportKey_A6()));
            ConfigHelpers.SetDoubleLengthZmk();
            // Contributed by wpak, fixes issue described at https://codeplexarchive.org/codeplex/projecttab/discussions/thalessim/217215.
            Assert.AreEqual("00U0E07CDC0161A0DE3B5AA44DF227EC9DEABDEBC", TestMessage("001U71979DEB8587E2734F1E99D5DCAEF9ACU482C4E722BB0CF1845E1E5BD16310119U", new ImportKey_A6()));
            Assert.AreEqual("00U1EF828AA8F6B80EB83E19FBC373F3A856F1E3F", TestMessage("001U71979DEB8587E2734F1E99D5DCAEF9ACXC8E3118AFA853807EB7E92294663A5BAU", new ImportKey_A6()));
            Assert.AreEqual("00U1EF828AA8F6B80EB83E19FBC373F3A856F1E3F", TestMessage("001U71979DEB8587E2734F1E99D5DCAEF9ACX8E80C547F2A1324B84763B0EE32B73ADU1", new ImportKey_A6()));
            Assert.AreEqual("00BAB32D775A38E4AB73936E", TestMessage("001U1457FF6ADF6250C66C368416B4C9D3832B930A07119F93A8Z", new ImportKey_A6()));
        }

        [Test]
        public void ExportKeyTest()
        {
            ConfigHelpers.SetAuthorizedState(true);
            Assert.AreEqual("0035ED0C0EA7F7D0FA0035BB", TestMessage("0024ED06495741C280C0406FBB23A5214DFZ", new ExportKey_A8()));
            ConfigHelpers.SetDoubleLengthZmk();
            Assert.AreEqual("0016224FDAA779AFB31FFD3C", TestMessage("002U1457FF6ADF6250C66C368416B4C9D3837BB126F2BE631486Z", new ExportKey_A8()));
            Assert.AreEqual("00U2C62A23D001B97412950CD8BE66C7639070753", TestMessage("002U1457FF6ADF6250C66C368416B4C9D383U8463435FC4B4DAA0C49025272C29B12CU", new ExportKey_A8()));
        }

        [Test]
        public void FormKeyFromEncryptedComponentsTest()
        {
            ConfigHelpers.SetAuthorizedState(true);
            Assert.AreEqual("00FE018240022A76DCA192FE",
                            TestMessage("3002Z3B723AF4CF00A7A6954111D254A90D17EAAF49979FA95742",
                                        new FormKeyFromEncryptedComponents_A4()));
            Assert.AreEqual("00XC0BC1DFFC449A402DAB71250CA5869CC8CE396",
                            TestMessage("3000XX2EC8A0412B5D0E86E3C1E5ABFA19B3F5XFF43378ED5D85B1BC465BF000335FBF1XA235EDF4C58A2CB0C84641D07319CF21",
                                        new FormKeyFromEncryptedComponents_A4()));
            ConfigHelpers.SetAuthorizedState(false);
            Assert.IsTrue(CommandExplorer.GetCommand(CommandType.Host, "A4").RequiresAuthorizedState);
        }

        [Test]
        public void DecryptEncryptedPinTest()
        {
            ConfigHelpers.SetAuthorizedState(true);
            Assert.AreEqual("001234F", TestMessage("12345678901201234", new DecryptEncryptedPIN_NG()));
            ConfigHelpers.SetAuthorizedState(false);
            Assert.IsTrue(CommandExplorer.GetCommand(CommandType.Host, "NG").RequiresAuthorizedState);
        }

        [Test]
        public void DerivePinUsingTheIbmMethodTest()
        {
            const string cryptPvk = "UA8B1520E201412938388191885FFA50A";
            const string cryptZpk = "U402F396F7ABEDC14976EB65959AA99B2";
            const string acct = "832937216759";
            const string decTable = "FFFFFFFFFFFFFFFF";
            const string pinValData = "4458329372N3";
            const string offset = "0000FFFFFFFF";
            var result = TestMessage(cryptPvk + offset + "04" + acct + decTable + pinValData, new DerivePinUsingTheIBMMethod_EE());

            Assert.AreEqual("0004584", result);

            result = TestMessage(cryptZpk + "01" + acct + result.Substring(2), new TranslatePinFromLMKToZPK_JG());

            Assert.AreEqual("0028992058275C1FED", result);

            Assert.AreEqual("00",
                            TestMessage(
                                cryptZpk + cryptPvk + "12" + result.Substring(2) + "01" + "04" + acct + decTable +
                                pinValData + offset, new VerifyInterchangePinWithIBMAlgorithm_EA()).Substring(0, 2));
        }

        [Test]
        public void TranslatePinFromLmkToZpkTest()
        {
            Assert.AreEqual("0098A841D13467F185",
                            TestMessage("TA5E7D4FE829B0D83C5E7352636C16C7827E197349E34A5CD0112345678901201234",
                                        new TranslatePinFromLMKToZPK_JG()));
            Assert.AreEqual("00E98FFDA17099AF55",
                            TestMessage("BAB32D775A38E4AB0155000002532101234", new TranslatePinFromLMKToZPK_JG()));
            Assert.AreEqual("00F7808F2CBEC63168",
                            TestMessage("BAB32D775A38E4AB0355000002532101234", new TranslatePinFromLMKToZPK_JG()));
        }

        [Test]
        public void GenerateKeyTest()
        {
            Extensions.RndMachine = new NotSoRandom();
            Assert.AreEqual("00U37C214786596A294ED92DBA27208C13B18EC38", TestMessage("0001U", new GenerateKey_A0()));
            Assert.AreEqual("00U37C214786596A294ED92DBA27208C13BX6A4BF2BD845FCBD66A4BF2BD845FCBD618EC38",
                            TestMessage("1001UU4C94ED3CBF0597C848000A85A55C2E54X", new GenerateKey_A0()));
            Extensions.RndMachine = new RandomMachine();
        }

        [Test]
        public void EncryptClearPinTest()
        {
            ConfigHelpers.SetAuthorizedState(true);
            Assert.AreEqual("0001234", TestMessage("1234F" + "012345678901", new EncryptClearPIN_BA()));
            Assert.AreEqual("0001234", TestMessage("01234" + "012345678901", new EncryptClearPIN_BA()));

            ConfigHelpers.SetAuthorizedState(false);
            Assert.IsTrue(CommandExplorer.GetCommand(CommandType.Host, "BA").RequiresAuthorizedState);
        }

        [Test]
        public void FormZmkFromThreeComponentsTest()
        {
            ConfigHelpers.SetAuthorizedState(true);
            Assert.AreEqual("00XC0BC1DFFC449A402DAB71250CA5869CC8CE39643DA9A9B99",
                            TestMessage(
                                "A235EDF4C58A2CB0C84641D07319CF21FF43378ED5D85B1BC465BF000335FBF12EC8A0412B5D0E86E3C1E5ABFA19B3F5",
                                new FormZMKFromThreeComponents_GG()));

            ConfigHelpers.SetAuthorizedState(false);
            Assert.IsTrue(CommandExplorer.GetCommand(CommandType.Host, "GG").RequiresAuthorizedState);
        }

        [Test]
        public void FormZmkFromTwoToNineComponentsTest()
        {
            ConfigHelpers.SetAuthorizedState(true);
            ConfigHelpers.SetLegacyMode(false);

            Assert.AreEqual("00C0BC1DFFC449A402DAB71250CA5869CC8CE39643DA9A9B99",
                            TestMessage(
                                "32EC8A0412B5D0E86E3C1E5ABFA19B3F5FF43378ED5D85B1BC465BF000335FBF1A235EDF4C58A2CB0C84641D07319CF21",
                                new FormZMKFromTwoToNineComponents_GY()));
            Assert.AreEqual("00U369835189A058604EB7F84EAE10C7D048CE396",
                            TestMessage(
                                "32EC8A0412B5D0E86E3C1E5ABFA19B3F5FF43378ED5D85B1BC465BF000335FBF1A235EDF4C58A2CB0C84641D07319CF21;0U1",
                                new FormZMKFromTwoToNineComponents_GY()));
            Assert.AreEqual("00XC0BC1DFFC449A402DAB71250CA5869CC8CE39643DA9A9B99",
                            TestMessage(
                                "32EC8A0412B5D0E86E3C1E5ABFA19B3F5FF43378ED5D85B1BC465BF000335FBF1A235EDF4C58A2CB0C84641D07319CF21;0X0",
                                new FormZMKFromTwoToNineComponents_GY()));

            Assert.AreEqual("15",
                            TestMessage(
                                "3U2EC8A0412B5D0E86E3C1E5ABFA19B3F5FF43378ED5D85B1BC465BF000335FBF1A235EDF4C58A2CB0C84641D07319CF21;0X0",
                                new FormZMKFromTwoToNineComponents_GY()));
            ConfigHelpers.SetAuthorizedState(false);
            Assert.IsTrue(CommandExplorer.GetCommand(CommandType.Host, "GY").RequiresAuthorizedState);
        }

        [Test]
        public void GenerateMacMabUsingAnsiX919Test()
        {
            const string cryptZak = "U4F24FC3AADA72104B6BE1D1E296CA774";
            var result = TestMessage("1111" + cryptZak + "001030303030303030303131313131313131",
                                     new GenerateMACMABUsingAnsiX919ForLargeMessage_MS());
            Assert.AreEqual("00A9D4D96683B51333", result);

            result = TestMessage("2111" + cryptZak + result.Substring(2) + "001030303030303030303131313131313131",
                         new GenerateMACMABUsingAnsiX919ForLargeMessage_MS());
            Assert.AreEqual("00DA46CEC9E61AF065", result);

            result = TestMessage("2111" + cryptZak + result.Substring(2) + "001030303030303030303131313131313131",
                         new GenerateMACMABUsingAnsiX919ForLargeMessage_MS());
            Assert.AreEqual("0056A27E35442BD07D", result);

            result = TestMessage("2111" + cryptZak + result.Substring(2) + "001030303030303030303131313131313131",
                         new GenerateMACMABUsingAnsiX919ForLargeMessage_MS());
            Assert.AreEqual("00B12874BED7137303", result);

            result = TestMessage("3111" + cryptZak + result.Substring(2) + "001030303030303030303131313131313131",
                         new GenerateMACMABUsingAnsiX919ForLargeMessage_MS());
            Assert.AreEqual("000D99127F7734AA58", result);
        }

        [Test]
        public void GenerateAndPrintComponentTest()
        {
            ConfigHelpers.SetAuthorizedState(true);
            Extensions.RndMachine = new NotSoRandom();
            string rsp;
            string rspAfterIo;

            TestMessageWithIo("001U", new GenerateAndPrintComponent_A2(), out rsp, out rspAfterIo);
            Assert.AreEqual("00U37C214786596A294ED92DBA27208C13B", rsp);
            Assert.IsNotNullOrEmpty(rspAfterIo);

            TestMessageWithIo("001T", new GenerateAndPrintComponent_A2(), out rsp, out rspAfterIo);
            Assert.AreEqual("00T07481EB9B807DF6E4AAF814F18038290CE01C666B4B2F652", rsp);
            Assert.IsNotNullOrEmpty(rspAfterIo);

            TestMessageWithIo("002X", new GenerateAndPrintComponent_A2(), out rsp, out rspAfterIo);
            Assert.AreEqual("00X3A6F3B5520B820EC3A6F3B5520B820EC", rsp);
            Assert.IsNotNullOrEmpty(rspAfterIo);

            TestMessageWithIo("002Y", new GenerateAndPrintComponent_A2(), out rsp, out rspAfterIo);
            Assert.AreEqual("00Y3A6F3B5520B820EC3A6F3B5520B820EC3A6F3B5520B820EC", rsp);
            Assert.IsNotNullOrEmpty(rspAfterIo);

            Extensions.RndMachine = new RandomMachine();

            ConfigHelpers.SetAuthorizedState(false);
            Assert.IsTrue(CommandExplorer.GetCommand(CommandType.Host, "A2").RequiresAuthorizedState);
        }

        private string TestMessage (string message, AHostCommand command)
        {
            var msg = new StreamMessage(message);
            command.AcceptMessage(msg);
            if (command.XmlParseResult != ErrorCodes.ER_00_NO_ERROR)
            {
                return command.XmlParseResult;
            }

            var rsp = command.ConstructResponse();

            return rsp.GetBytes().GetString();
        }

        private void TestMessageWithIo(string message, AHostCommand command, out string rsp, out string rspAfterIo)
        {
            var msg = new StreamMessage(message);
            command.AcceptMessage(msg);
            if (command.XmlParseResult != ErrorCodes.ER_00_NO_ERROR)
            {
                rsp = command.XmlParseResult;
                rspAfterIo = string.Empty;
                return;
            }

            rsp = command.ConstructResponse().Message;

            rspAfterIo = command.ConstructResponseAfterIo().Message;
        }
    }
}
