using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHMI_Coursework_Forms;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dialog inner = new Dialog()
            {
                FormalModel = @"GameTheory",
                Steps = new DialogStep[]
                {
                    new DialogStep() { Question = "What?", Num = 1, Responses = new DialogResponse[] { new DialogResponse() {  Response = "OK", Next = 2} } },
            new DialogStep() { Question = "Finish", Num = 2, Responses = new DialogResponse[] { new DialogResponse() { Next = 3, Response = "OK" } } }
                }
            };
            Dialog dialog = new Dialog()
            {
                Steps = new DialogStep[]
                {
                    new DialogStep() { Question = "What", Num = 1, Responses = new DialogResponse[] { new DialogResponse() { Response = "OK", InnerDialog = inner } } }
                }
            };
            dialog.SaveToFile("testScen.xml");
        }
    }
}
