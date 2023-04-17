/*************************************************
   Copyright (c) 2021 Undersoft

   System.Instant.Tests.InstantSelectionTest.cs.Tests
   
   @project: Vegas.Sdk
   @stage: Development
   @author: Dariusz Hanc
   @date: (05.06.2021) 
   @licence MIT
 *************************************************/

namespace System.Instant.Tests
{
    using System;
    using System.Reflection;
    using System.Uniques;

    using Xunit;

    /// <summary>
    /// Defines the <see cref="SleevesTest" />.
    /// </summary>
    public class SleevesTest
    {
        #region Fields

        private IFigure ifigure;
        private IFigures isleeves;
        private Figures sleeves;

        #endregion

        #region Methods

        /// <summary>
        /// The Sleeve_SelectionFromFiguresMultiNesting_Test.
        /// </summary>
        [Fact]
        public void Sleeves_SelectionFromFiguresMultiNesting_Test()
        {
            sleeves = new Sleeves<FieldsAndPropertiesModel>("InstantSequence_Compilation_Test");
            isleeves = sleeves.Combine();

            ifigure = Sleeve_Compilation_Helper_Test(isleeves, new FieldsAndPropertiesModel());

            int idSeed = (int)ifigure["Id"];
            DateTime now = DateTime.Now;
            for (int i = 0; i < 250000; i++)
            {
                ISleeve _isleeve = isleeves.NewSleeve();
                _isleeve.Devisor = isleeves.NewSleeve();
                _isleeve.ValueArray = ifigure.ValueArray;
                _isleeve["Id"] = idSeed + i;
                _isleeve["Time"] = now;
                isleeves.Add(_isleeve);
            }

            ulong[] keyarray = new ulong[60 * 1000];
            for (int i = 0; i < 60000; i++)
            {
                keyarray[i] = Unique.New;
            }

            isleeves.Add(isleeves.NewSleeve());
            isleeves[0, 4] = ifigure[4];

            IFigures isel1 = new Sleeves(isleeves).Combine();
            IFigures isel2 = new Sleeves(isel1).Combine();

            foreach (var card in isleeves)
                isel2.Add(card);

            ifigure = Sleeve_Compilation_Helper_Test(isleeves, new FieldsAndPropertiesModel());

            isel2.Add(ifigure);
            isel2[0, 4] = ifigure[4];

            Assert.Equal(ifigure[4], isel2[0, 4]);
            Assert.Equal(isleeves.Count, isel1.Count);
            Assert.Equal(isel1.Count, isel2.Count);
        }

        /// <summary>
        /// The Sleeve_Compilation_Helper_Test.
        /// </summary>
        /// <param name="str">The str<see cref="IFigures"/>.</param>
        /// <param name="fom">The fom<see cref="FieldsAndPropertiesModel"/>.</param>
        /// <returns>The <see cref="IFigure"/>.</returns>
        private IFigure Sleeve_Compilation_Helper_Test(IFigures str, FieldsAndPropertiesModel fom)
        {
            ISleeve rts = str.NewSleeve();
            rts.Devisor = new FieldsAndPropertiesModel();

            for (int i = 1; i < str.Rubrics.Count; i++)
            {
                var r = str.Rubrics[i].RubricInfo;
                if (r.MemberType == MemberTypes.Field)
                {
                    var fi = fom.GetType().GetField(r.Name);
                    if (fi != null)
                        rts[r.Name] = fi.GetValue(fom);
                }
                if (r.MemberType == MemberTypes.Property)
                {
                    var pi = fom.GetType().GetProperty(r.Name);
                    if (pi != null)
                        rts[r.Name] = pi.GetValue(fom);
                }
            }
            return rts;
        }

        #endregion
    }
}
