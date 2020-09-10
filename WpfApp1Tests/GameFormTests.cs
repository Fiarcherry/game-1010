using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.Tests
{
    [TestClass()]
    public class GameFormTests
    {
        GameForm gameForm = new GameForm();
        int randomFigure = 13;
        SolidColorBrush solidColorBrush = new SolidColorBrush();
        
        [TestMethod()]
        public void ColorsToFiguresTest()
        {
            solidColorBrush = gameForm.ColorsToFigures(ref randomFigure);
            Assert.AreEqual("#FFDB6555", solidColorBrush.ToString());            
        }

        [TestMethod()]
        public void ColorsToFiguresTest1()
        {
            solidColorBrush = gameForm.ColorsToFigures(ref randomFigure);
            Assert.AreEqual("#FFE76A81", solidColorBrush.ToString());
        }

        [TestMethod()]
        public void ColorsToFiguresTest2()
        {
            solidColorBrush = gameForm.ColorsToFigures(ref randomFigure);
            Assert.AreEqual("#FFEF9647", solidColorBrush.ToString());
        }

        [TestMethod()]
        public void ColorsToFiguresTest3()
        {
            solidColorBrush = gameForm.ColorsToFigures(ref randomFigure);
            Assert.AreEqual("#FFFFC73C", solidColorBrush.ToString());
        }

        [TestMethod()]
        public void ColorsToFiguresTest4()
        {
            solidColorBrush = gameForm.ColorsToFigures(ref randomFigure);
            Assert.AreEqual("#FF788AC0", solidColorBrush.ToString());
        }

        [TestMethod()]
        public void ColorsToFiguresTest5()
        {
            solidColorBrush = gameForm.ColorsToFigures(ref randomFigure);
            Assert.AreEqual("#FF5DBFE1", solidColorBrush.ToString());
        }

        [TestMethod()]
        public void ColorsToFiguresTest6()
        {
            solidColorBrush = gameForm.ColorsToFigures(ref randomFigure);
            Assert.AreEqual("#FF4DD4AD", solidColorBrush.ToString());
        }

        [TestMethod()]
        public void ColorsToFiguresTest7()
        {
            solidColorBrush = gameForm.ColorsToFigures(ref randomFigure);
            Assert.AreEqual("#FF99DE55", solidColorBrush.ToString());
        }

        [TestMethod()]
        public void ColorsToFiguresTest8()
        {
            solidColorBrush = gameForm.ColorsToFigures(ref randomFigure);
            Assert.AreEqual("#FF57CB84", solidColorBrush.ToString());
        }
    }
}