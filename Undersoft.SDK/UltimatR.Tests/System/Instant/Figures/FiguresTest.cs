/*************************************************
   Copyright (c) 2021 Undersoft

   System.Instant.Tests.InstantFiguresTest.cs.Tests
   
   @project: Vegas.Sdk
   @stage: Development
   @author: Dariusz Hanc
   @date: (05.06.2021) 
   @licence MIT
 *************************************************/

namespace System.Instant.Tests
{
    using System.Collections.Generic;
    using System.Reflection;

    using Xunit;

    /// <summary>
    /// Defines the <see cref="FiguresTest" />.
    /// </summary>
    public class FiguresTest
    {
        #region Fields

        private IFigure ifigure;
        private IFigures ifigures;
        private Figures figures;
        private Figure figure;

        #endregion

        #region Methods

        /// <summary>
        /// The Figures_Compile_Test.
        /// </summary>
        [Fact]
        public void Figures_Compile_Test()
        {
            var figure2 = new Sleeve<FieldsAndPropertiesModel>();

            FieldsAndPropertiesModel fom = new FieldsAndPropertiesModel();
            
            var ifigure2 = Sleeve_Compilation_Helper_Test(figure2, fom);

            var isleeve = new FieldsAndPropertiesModel().ToSleeve();

            var figures2 = new Sleeves<FieldsAndPropertiesModel>();

            var rttab = figures2.Combine();

            for (int i = 0; i < 10000; i++)
            {
                rttab.Add((long)int.MaxValue + i, rttab.NewFigure());
            }

            for (int i = 9999; i > -1; i--)
            {
                rttab[i] = rttab.Get(i + (long)int.MaxValue);
            }
        }

        /// <summary>
        /// The Figures_MutatorAndAccessorById_Test.
        /// </summary>
        [Fact]
        public void Figures_MutatorAndAccessorById_Test()
        {
            figure = new Figure(typeof(FieldsAndPropertiesModel));
            FieldsAndPropertiesModel fom = new FieldsAndPropertiesModel();
            ifigure = Figure_Compilation_Helper_Test(figure, fom);

            figures = new Figures(figure, "InstantSequence_Compilation_Test");

            ifigures = figures.Combine();

            ifigures.Add(ifigures.NewFigure());
            ifigures[0, 4] = ifigure[4];

            Assert.Equal(ifigure[4], ifigures[0, 4]);
        }

        /// <summary>
        /// The Figures_MutatorAndAccessorByName_Test.
        /// </summary>
        [Fact]
        public void Figures_MutatorAndAccessorByName_Test()
        {
            figure = new Figure(typeof(FieldsAndPropertiesModel));
            FieldsAndPropertiesModel fom = new FieldsAndPropertiesModel();
            ifigure = Figure_Compilation_Helper_Test(figure, fom);

            figures = new Figures(figure, "InstantSequence_Compilation_Test");

            ifigures = figures.Combine();

            ifigures.Add(ifigures.NewFigure());
            ifigures[0, nameof(fom.Name)] = ifigure[nameof(fom.Name)];

            Assert.Equal(ifigure[nameof(fom.Name)], ifigures[0, nameof(fom.Name)]);
        }

        /// <summary>
        /// The Figures_NewFigure_Test.
        /// </summary>
        [Fact]
        public void Figures_NewFigure_Test()
        {
            figure = new Figure(typeof(FieldsAndPropertiesModel));
            FieldsAndPropertiesModel fom = new FieldsAndPropertiesModel();
            ifigure = Figure_Compilation_Helper_Test(figure, fom);

            figures = new Figures(figure, "InstantSequence_Compilation_Test");

            ifigures = figures.Combine();

            IFigure rcst = ifigures.NewFigure();

            Assert.NotNull(rcst);
        }

        /// <summary>
        /// The Figures_SetRubrics_Test.
        /// </summary>
        [Fact]
        public void Figures_SetRubrics_Test()
        {
            figure = new Figure(typeof(FieldsAndPropertiesModel));
            FieldsAndPropertiesModel fom = new FieldsAndPropertiesModel();
            ifigure = Figure_Compilation_Helper_Test(figure, fom);

            figures = new Figures(figure, "InstantSequence_Compilation_Test");

            var rttab = figures.Combine();

            Assert.Equal(rttab.Rubrics, figures.Rubrics);
        }

        /// <summary>
        /// The Figure_Compilation_Helper_Test.
        /// </summary>
        /// <param name="figure">The figure<see cref="Figure"/>.</param>
        /// <param name="fom">The fom<see cref="FieldsAndPropertiesModel"/>.</param>
        /// <returns>The <see cref="IFigure"/>.</returns>
        private IFigure Figure_Compilation_Helper_Test(Figure figure, FieldsAndPropertiesModel fom)
        {
            IFigure rts = figure.Combine();

            for (int i = 1; i < figure.Rubrics.Count; i++)
            {
                var r = figure.Rubrics[i].RubricInfo;
                if (r.MemberType == MemberTypes.Field)
                {
                    var fi = fom.GetType().GetField(((FieldInfo)r).Name);
                    if (fi != null)
                        rts[r.Name] = fi.GetValue(fom);
                }
                if (r.MemberType == MemberTypes.Property)
                {
                    var pi = fom.GetType().GetProperty(((PropertyInfo)r).Name);
                    if (pi != null)
                        rts[r.Name] = pi.GetValue(fom);
                }
            }
            return rts;
        }

        private IFigure Sleeve_Compilation_Helper_Test(Sleeve figure2, FieldsAndPropertiesModel fom)
        {
            ISleeve rts = null;
            List<ISleeve> list = new List<ISleeve>();
            for(int y = 0; y < 300000; y++)
            {
                var rts0 = figure2.Combine();

                for(int i = 1; i < figure2.Rubrics.Count; i++)
                {
                    var r = figure2.Rubrics[i].RubricInfo;
                    if(r.MemberType == MemberTypes.Field)
                    {
                        var fi = fom.GetType().GetField(((FieldInfo)r).Name);
                        if(fi != null)
                            rts0[r.Name] = fi.GetValue(fom);
                    }
                    if(r.MemberType == MemberTypes.Property)
                    {
                        var pi = fom.GetType().GetProperty(((PropertyInfo)r).Name);
                        if(pi != null)
                            rts0[r.Name] = pi.GetValue(fom);
                    }
                }

                list.Add(rts0);
            }
            return list[0];
        }

        #endregion
    }
}
