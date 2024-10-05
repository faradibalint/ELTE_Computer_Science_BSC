using Beadando;
namespace Test
{
    [TestClass]
    public class BeadandoTest
    {
        [TestMethod]
        public void AttackTest()
        {   
            Elf elf = new Vakmero("elf");
            Ork ork = new Verengzo("ork",5);
            Assert.AreEqual(0, elf.acquireTreasure());
            Assert.AreEqual(5, ork.acquireTreasure());
            elf.Attack(ork);
            Assert.AreEqual(75, ork.getHealth());
            ork.Attack(elf);
            Assert.AreEqual(80, elf.getHealth());
            elf.Attack(ork);
            elf.Attack(ork);
            elf.Attack(ork);
            Assert.IsFalse(ork.Alive());
            //Testing acquireTreasure()
            Assert.AreEqual(5, elf.acquireTreasure());
            //Defend() is tested indirectly
        }
        [TestMethod]
        public void HealingTest()
        {
            Elf vakmero = new Vakmero("vakmero");
            Elf ugyes = new Ugyes("ugyes");
            Elf bolcs = new Bolcs("bolcs");
            Assert.AreEqual(0, vakmero.acquireTreasure());
            Assert.AreEqual(0, vakmero.getElixir());
            Assert.AreEqual(0, ugyes.acquireTreasure());
            Assert.AreEqual(0, ugyes.getElixir());
            Assert.AreEqual(0, bolcs.acquireTreasure());
            Assert.AreEqual(0, bolcs.getElixir());

            Ork verengzo = new Verengzo("verengzo", 5);

            vakmero.Attack(verengzo);
            verengzo.Attack(vakmero);
            vakmero.Attack(verengzo);
            vakmero.Attack(verengzo);
            vakmero.Attack(verengzo);
            //Testing acquireTreasure()
            Assert.AreEqual(80,vakmero.getHealth());
            vakmero.Healing();
            Assert.AreEqual(80, vakmero.getHealth());

            Ork verengzo1 = new Verengzo("verengzo", 24);
            for (int i = 0; i < 4; i++)
            {
                verengzo.Attack(ugyes);
            }
            Assert.AreEqual(0, ugyes.acquireTreasure());
            Assert.AreEqual(0, ugyes.getElixir());
            for (int i = 0; i < 7; i++)
            {
                ugyes.Attack(verengzo1);
            }
            ugyes.Healing();
            Assert.AreEqual(50, ugyes.getHealth());

            Ork verengzo2 = new Verengzo("verengzo", 9);
            verengzo2.Attack(bolcs);
            for(int i = 0; i < 20; i++)
            {
                bolcs.Attack(verengzo2);
            }
            bolcs.Healing();
            Assert.AreEqual(49, bolcs.getHealth());


        }
        [TestMethod]
        public void BattleTest()
        {
            List<Elf> elfek = new List<Elf>();
            elfek.Add(new Ugyes("Sudár"));
            elfek.Add(new Vakmero("Nyúlánk"));
            List<Ork> orkok = new List<Ork>();
            orkok.Add(new Verengzo("Falánk", 7));
            orkok.Add(new Verengzo("köpcös", 4));
            Battle battle = new Battle(elfek, orkok);
            battle.Start();
            elfek = battle.getElves();
            Assert.AreEqual(23, elfek[0].getHealth());
            Assert.AreEqual(0, elfek[0].getElixir());
            Assert.AreEqual(4, elfek[0].acquireTreasure());

            Assert.AreEqual(40, elfek[1].getHealth());
            Assert.AreEqual(0, elfek[1].getElixir());
            Assert.AreEqual(4, elfek[1].acquireTreasure());

        }

    }
}