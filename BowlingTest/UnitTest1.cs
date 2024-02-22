using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BowlingTest
{
    public class ProgramTests
    {
        [Fact]
        public void Run_PrintsHelloWorld()
        {
            // Arrange
            var program = new Program();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                program.Run();

                // Assert
                var expected = $"Hello, World!{Environment.NewLine}";
                Assert.Equal(expected, sw.ToString());
            }
        }

        [Fact]
        public void Run_CalculScoreSimple()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (5, 3)
                };


            var result = program.CalculScore(resultatJeu);

            Assert.Equal(8, result);
        }


        [Fact]
        public void Run_IsSpareValid()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = (5, 5);

            var result = program.IsSpare(resultatJeu);

            Assert.True(result);
        }
        
        [Fact]
        public void Run_IsSpareValid2()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = (0, 10);

            var result = program.IsSpare(resultatJeu);

            Assert.True(result);
        }

        [Fact]
        public void Run_IsSpareInvalid()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = (5, 3);

            var result = program.IsSpare(resultatJeu);

            Assert.False(result);
        }

        [Fact]
        public void Run_IsSpareInvalidStrike()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = (10, 0);

            var result = program.IsSpare(resultatJeu);

            Assert.False(result);
        }
        
        [Fact]
        public void Run_IsSpareInvalidStrike2()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = (10, (int?)null);

            var result = program.IsSpare(resultatJeu);

            Assert.False(result);
        }

        [Fact]
        public void Run_IsStrikeValid()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = (10, (int?)null);

            var result = program.IsStrike(resultatJeu);

            Assert.True(result);
        }

        [Fact]
        public void Run_IsStrikeInvalid()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = (6, 4);

            var result = program.IsStrike(resultatJeu);

            Assert.False(result);
        }

        [Fact]
        public void Run_IsStrikeInvalid2()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = (0, 10);

            var result = program.IsStrike(resultatJeu);

            Assert.False(result);
        }

        [Fact]
        public void Run_CalculScoreSpareSimple()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (5, 5),
                    (8,0)
                };

            var result = program.CalculScore(resultatJeu);

            Assert.Equal(26, result);
        }

        [Fact]
        public void Run_CalculScoreSpareMoyen()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (5, 5),
                    (9, 1),
                    (8,0)
                };

            var result = program.CalculScore(resultatJeu);

            Assert.Equal(45, result);
        }

        [Fact]
        public void Run_CalculScoreStrikeSimple()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (5,2)
                };

            var result = program.CalculScore(resultatJeu);

            Assert.Equal(24, result);
        }
        
        [Fact]
        public void Run_CalculScoreStrikeMulti()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (4,1),
                };

            var result = program.CalculScore(resultatJeu);

            Assert.Equal(104, result);
        }

        [Fact]
        public void Run_CalculScoreStrikeSpareMulti()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (10,null),
                    (10,null),
                    (6,4),
                    (10,null),
                    (2,3),
                };

            var result = program.CalculScore(resultatJeu);

            Assert.Equal(116, result);
        }

        [Fact]
        public void Run_CalculScoreSpareFinal()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (10,null),
                    (10,null),
                    (6,4),
                    (10,null),
                    (2,3),
                    (2,3),
                    (2,3),
                    (2,3),
                    (7,3),
                    (5,null),
                };

            var result = program.CalculScore(resultatJeu);

            Assert.Equal(146, result);
        }

        [Fact]
        public void Run_CalculScoreStrikeMaxScore()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                };

            var result = program.CalculScore(resultatJeu);

            Assert.Equal(300, result);
        }

        [Fact]
        public void Run_CanPlayValid()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (10,null),
                    (10,null),
                    (6,4),
                    (10,null),
                    (2,3),
                };

            var result = program.CanPlay(resultatJeu);

            Assert.True(result);
        }
                
        [Fact]
        public void Run_CanPlayInvalid()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (10,null),
                    (10,null),
                    (6,4),
                    (10,null),
                    (2,3),
                    (2,3),
                    (2,3),
                    (2,3),
                    (2,3),
                };

            var result = program.CanPlay(resultatJeu);

            Assert.False(result);
        }

        [Fact]
        public void Run_CanPlaySpare()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (10,null),
                    (10,null),
                    (6,4),
                    (10,null),
                    (2,3),
                    (2,3),
                    (2,3),
                    (2,3),
                    (7,3),
                };

            var result = program.CanPlay(resultatJeu);

            Assert.True(result);
        }

        [Fact]
        public void Run_CanPlaySpareInvalid()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (10,null),
                    (10,null),
                    (6,4),
                    (10,null),
                    (2,3),
                    (2,3),
                    (2,3),
                    (2,3),
                    (7,3),
                    (4,null),
                };

            var result = program.CanPlay(resultatJeu);

            Assert.False(result);
        }

        [Fact]
        public void Run_CanPlayStrike()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (10,null),
                    (10,null),
                    (6,4),
                    (10,null),
                    (2,3),
                    (2,3),
                    (2,3),
                    (2,3),
                    (10,null),
                };

            var result = program.CanPlay(resultatJeu);

            Assert.True(result);
        }

        [Fact]
        public void Run_CanPlayStrikeInvalid()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (10,null),
                    (10,null),
                    (6,4),
                    (10,null),
                    (2,3),
                    (2,3),
                    (2,3),
                    (2,3),
                    (10,null),
                    (4,2)
                };

            var result = program.CanPlay(resultatJeu);

            Assert.False(result);
        }

        [Fact]
        public void Run_CanPlayStrikeDouble()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10, null),
                    (10,null),
                    (10,null),
                    (6,4),
                    (10,null),
                    (2,3),
                    (2,3),
                    (2,3),
                    (2,3),
                    (10,null),
                    (10,null),
                };

            var result = program.CanPlay(resultatJeu);

            Assert.True(result);
        }

        public void Run_CanPlayScoreMax()
        {
            // Arrange
            var program = new Program();

            var resultatJeu = new List<(int, int?)>
                {
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                    (10,null),
                };

            var result = program.CanPlay(resultatJeu);

            Assert.False(result);
        }

        [Fact]
        public void Run_SaisieValide()
        {
            Program program = new Program();

            bool result = program.EstSaisieValide(8,10);

            Assert.True(result);
        }

        [Fact]
        public void Run_SaisieInvalide()
        {
            Program program = new Program();

            bool result = program.EstSaisieValide(8, 6);

            Assert.False(result);
        }

    }
}