using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.IO;

namespace OnceMore
{
    public partial class Form1 : Form
    {
        string typeOne, typeTwo;
        int CurrentLvl, nextLevel, PkmnSlainLevel, PkmnSlainAmount, SubtotalEXP, TotalEXP, SelectedPokemon;

        public Form1()
        {
            InitializeComponent();
            pokemonBindingSource.Sort = "pokemonID ASC";
            pokemonBindingSource1.Sort = "pokemonID ASC";
            pokemonBindingSource2.Sort = "pokemonID ASC";
            pokemonBindingSource3.Sort = "pokemonID ASC";
            pokemonBindingSource4.Sort = "pokemonID ASC";
            pokemonBindingSource5.Sort = "pokemonID ASC";
            movelistBindingSource2.Sort = "typename ASC";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pokemonDBDataSet.movelist' table. You can move, or remove it, as needed.
            this.movelistTableAdapter.Fill(this.pokemonDBDataSet.movelist);
            // TODO: This line of code loads data into the 'pokemonDBDataSet.pokemontype' table. You can move, or remove it, as needed.
            this.pokemontypeTableAdapter.Fill(this.pokemonDBDataSet.pokemontype);
            // TODO: This line of code loads data into the 'pokemonDBDataSet.typelist' table. You can move, or remove it, as needed.
            this.typelistTableAdapter.Fill(this.pokemonDBDataSet.typelist);
            // TODO: This line of code loads data into the 'pokemonDBDataSet.typeswithpokemon' table. You can move, or remove it, as needed.
            this.typeswithpokemonTableAdapter.Fill(this.pokemonDBDataSet.typeswithpokemon);
            // TODO: This line of code loads data into the 'pokemonDBDataSet.pokemonstats' table. You can move, or remove it, as needed.
            this.pokemonstatsTableAdapter.Fill(this.pokemonDBDataSet.pokemonstats);
            // TODO: This line of code loads data into the 'pokemonDBDataSet.pokemon' table. You can move, or remove it, as needed.
            this.pokemonTableAdapter.Fill(this.pokemonDBDataSet.pokemon);

        }

        private void SpecialType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeTwo = SpecialType3.SelectedText;
        }

        private void SpecialTypeOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeOne = SpecialTypeOne.SelectedText;
        }

        private void CurrentPartySelectOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            PartyOneTypeOne.Text = "";
            PartyOneTypeTwo.Text = "";
            int picNum = CurrentPartySelectOne.SelectedIndex + 1;
            try
            {
                string absolutePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"128\" + picNum + ".png");
                PictureOne.Image = Image.FromFile(absolutePath);

                var pokeQueryOne =
                    from queryMon in pokemonDBDataSet.pokemonstats
                    where queryMon.pokemon_id == picNum
                    select new
                    {
                        queryMon.base_hp,
                        queryMon.base_attack,
                        queryMon.base_defense,
                        queryMon.base_special_attack,
                        queryMon.base_special_defense,
                        queryMon.base_speed
                    };

                foreach (var queryMon in pokeQueryOne)
                {
                    pkHP1.Text = queryMon.base_hp.ToString();
                    pkATK1.Text = queryMon.base_attack.ToString();
                    pkDEF1.Text = queryMon.base_defense.ToString();
                    pkSA1.Text = queryMon.base_special_attack.ToString();
                    pkSD1.Text = queryMon.base_special_defense.ToString();
                    pkSPD1.Text = queryMon.base_speed.ToString();
                }

                var pokeQueryTwo =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 1
                    select queryNew.typename;

                foreach (var queryNew in pokeQueryTwo)
                {
                    PartyOneTypeOne.Text = queryNew.ToUpper();
                }

                var pokeQueryThree =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 2
                    select queryNew.typename;

                foreach (var queryNew in pokeQueryThree)
                {
                    PartyOneTypeTwo.Text = queryNew.ToUpper();
                }

            }
            catch (Exception ex) { PartyOneTypeOne.Text = ex.ToString(); }
        }

        private void CurrentPartySelectTwo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PartyTwoTypeOne.Text = "";
            PartyTwoTypeTwo.Text = "";
            int picNum = CurrentPartySelectTwo.SelectedIndex + 1;
            try
            {
                string absolutePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"128\" + picNum + ".png");
                PictureTwo.Image = Image.FromFile(absolutePath);

                var pokeQueryOne =
                    from queryMon in pokemonDBDataSet.pokemonstats
                    where queryMon.pokemon_id == picNum
                    select new
                    {
                        queryMon.base_hp,
                        queryMon.base_attack,
                        queryMon.base_defense,
                        queryMon.base_special_attack,
                        queryMon.base_special_defense,
                        queryMon.base_speed
                    };

                foreach (var queryMon in pokeQueryOne)
                {
                    pkHP2.Text = queryMon.base_hp.ToString();
                    pkATK2.Text = queryMon.base_attack.ToString();
                    pkDEF2.Text = queryMon.base_defense.ToString();
                    pkSA2.Text = queryMon.base_special_attack.ToString();
                    pkSD2.Text = queryMon.base_special_defense.ToString();
                    pkSPD2.Text = queryMon.base_speed.ToString();
                }

                var pokeQueryTwo =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 1
                    select queryNew.typename;

                foreach (var queryNew in pokeQueryTwo)
                {
                    PartyTwoTypeOne.Text = queryNew.ToUpper();
                }

                var pokeQueryThree =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 2
                    select queryNew.typename;

                foreach (var queryNew in pokeQueryThree)
                {
                    PartyTwoTypeTwo.Text = queryNew.ToUpper();
                }

            }
            catch (Exception ex) { PartyTwoTypeOne.Text = ex.ToString(); }
        }

        private void CalculateEXP_Click(object sender, EventArgs e)
        {
            try
            {
                PkmnSlainAmount = Convert.ToInt32(NumberofSlainPokemon.Text);
                PkmnSlainLevel = Convert.ToInt32(LevelofSlainPokemon.Text);
                bool ExpHalved = false;
                if ((SpecialType3.Text == typeOne || SpecialType3.Text == typeTwo) && (SpecialTypeOne.Text == typeOne || SpecialType3.Text == typeTwo))
                {
                    SubtotalEXP = PkmnSlainLevel * 3;
                }
                else if ((SpecialType3.Text == typeOne || SpecialType3.Text == typeTwo) || (SpecialTypeOne.Text == typeOne || SpecialType3.Text == typeTwo))
                {
                    SubtotalEXP = PkmnSlainLevel * 2;
                }
                else
                {
                    SubtotalEXP = PkmnSlainLevel;
                }
                TotalEXP = SubtotalEXP * PkmnSlainAmount;
                nextLevel = CurrentLvl + 1;
                while (TotalEXP >= nextLevel)
                {
                    TotalEXP -= nextLevel;
                    CurrentLvl++;
                    if (CurrentLvl > PkmnSlainLevel && ExpHalved == false)
                    {
                        TotalEXP /= 2;
                        ExpHalved = true;
                    }
                }
                switch (SelectedPokemon)
                {
                    case 1:
                        pkLVL1.Text = CurrentLvl.ToString();
                        pkXPLabel.Text = TotalEXP.ToString();
                        break;
                    case 2:
                        pkLVL2.Text = CurrentLvl.ToString();
                        pkXPLabel2.Text = TotalEXP.ToString();
                        break;
                    case 3:
                        pkLVL3.Text = CurrentLvl.ToString();
                        pkXPLabel3.Text = TotalEXP.ToString();
                        break;
                    case 4:
                        pkLVL4.Text = CurrentLvl.ToString();
                        pkXPLabel4.Text = TotalEXP.ToString();
                        break;
                    case 5:
                        pkLVL5.Text = CurrentLvl.ToString();
                        pkXPLabel5.Text = TotalEXP.ToString();
                        break;
                    case 6:
                        pkLVL6.Text = CurrentLvl.ToString();
                        pkXPLabel6.Text = TotalEXP.ToString();
                        break;

                }

                PkmnSlainAmount = 0;
                NumberofSlainPokemon.Text = "";
                PkmnSlainLevel = 0;
                LevelofSlainPokemon.Text = "";
            }
            catch (Exception ex)
            {
            }
        }

        private void CurrentPartySelectThree_SelectedIndexChanged(object sender, EventArgs e)
        {
            PartyThreeTypeOne.Text = "";
            PartyThreeTypeTwo.Text = "";
            int picNum = CurrentPartySelectThree.SelectedIndex + 1;
            try
            {
                string absolutePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"128\" + picNum + ".png");
                PictureThree.Image = Image.FromFile(absolutePath);

                var pokeQuerySix =
                    from queryMon in pokemonDBDataSet.pokemonstats
                    where queryMon.pokemon_id == picNum
                    select new
                    {
                        queryMon.base_hp,
                        queryMon.base_attack,
                        queryMon.base_defense,
                        queryMon.base_special_attack,
                        queryMon.base_special_defense,
                        queryMon.base_speed
                    };

                foreach (var queryMon in pokeQuerySix)
                {
                    pkHP3.Text = queryMon.base_hp.ToString();
                    pkATK3.Text = queryMon.base_attack.ToString();
                    pkDEF3.Text = queryMon.base_defense.ToString();
                    pkSA3.Text = queryMon.base_special_attack.ToString();
                    pkSD3.Text = queryMon.base_special_defense.ToString();
                    pkSPD3.Text = queryMon.base_speed.ToString();
                }

                var pokeQuerySeven =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 1
                    select queryNew.typename;

                foreach (var queryNew in pokeQuerySeven)
                {
                    PartyThreeTypeOne.Text = queryNew.ToUpper();
                }

                var pokeQueryEight =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 2
                    select queryNew.typename;

                foreach (var queryNew in pokeQueryEight)
                {
                    PartyThreeTypeTwo.Text = queryNew.ToUpper();
                }

            }
            catch (Exception ex) { PartyThreeTypeOne.Text = ex.ToString(); }
        }

        private void CurrentPartySelectFour_SelectedIndexChanged(object sender, EventArgs e)
        {
            PartyFourTypeOne.Text = "";
            PartyFourTypeTwo.Text = "";
            int picNum = CurrentPartySelectFour.SelectedIndex + 1;
            try
            {
                string absolutePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"128\" + picNum + ".png");
                PictureFour.Image = Image.FromFile(absolutePath);

                var pokeQueryNine =
                    from queryMon in pokemonDBDataSet.pokemonstats
                    where queryMon.pokemon_id == picNum
                    select new
                    {
                        queryMon.base_hp,
                        queryMon.base_attack,
                        queryMon.base_defense,
                        queryMon.base_special_attack,
                        queryMon.base_special_defense,
                        queryMon.base_speed
                    };

                foreach (var queryMon in pokeQueryNine)
                {
                    pkHP4.Text = queryMon.base_hp.ToString();
                    pkATK4.Text = queryMon.base_attack.ToString();
                    pkDEF4.Text = queryMon.base_defense.ToString();
                    pkSA4.Text = queryMon.base_special_attack.ToString();
                    pkSD4.Text = queryMon.base_special_defense.ToString();
                    pkSPD4.Text = queryMon.base_speed.ToString();
                }

                var pokeQueryTen =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 1
                    select queryNew.typename;

                foreach (var queryNew in pokeQueryTen)
                {
                    PartyFourTypeOne.Text = queryNew.ToUpper();
                }

                var pokeQueryEleven =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 2
                    select queryNew.typename;

                foreach (var queryNew in pokeQueryEleven)
                {
                    PartyFourTypeTwo.Text = queryNew.ToUpper();
                }

            }
            catch (Exception ex) { PartyThreeTypeOne.Text = ex.ToString(); }
        }

        private void CurrentPartySelectFive_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PartyFiveTypeOne.Text = "";
            PartyFiveTypeTwo.Text = "";
            int picNum = CurrentPartySelectFive.SelectedIndex + 1;
            try
            {
                string absolutePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"128\" + picNum + ".png");
                PictureFive.Image = Image.FromFile(absolutePath);

                var pokeQueryTwelve =
                    from queryMon in pokemonDBDataSet.pokemonstats
                    where queryMon.pokemon_id == picNum
                    select new
                    {
                        queryMon.base_hp,
                        queryMon.base_attack,
                        queryMon.base_defense,
                        queryMon.base_special_attack,
                        queryMon.base_special_defense,
                        queryMon.base_speed
                    };

                foreach (var queryMon in pokeQueryTwelve)
                {
                    pkHP5.Text = queryMon.base_hp.ToString();
                    pkATK5.Text = queryMon.base_attack.ToString();
                    pkDEF5.Text = queryMon.base_defense.ToString();
                    pkSA5.Text = queryMon.base_special_attack.ToString();
                    pkSD5.Text = queryMon.base_special_defense.ToString();
                    pkSPD5.Text = queryMon.base_speed.ToString();
                }

                var pokeQueryThirteen =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 1
                    select queryNew.typename;

                foreach (var queryNew in pokeQueryThirteen)
                {
                    PartyFiveTypeOne.Text = queryNew.ToUpper();
                }

                var pokeQueryFourteen =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 2
                    select queryNew.typename;

                foreach (var queryNew in pokeQueryFourteen)
                {
                    PartyFiveTypeTwo.Text = queryNew.ToUpper();
                }

            }
            catch (Exception ex) { PartyFiveTypeOne.Text = ex.ToString(); }
        }

        private void CurrentPartySelectSix_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PartySixTypeOne.Text = "";
            PartySixTypeTwo.Text = "";
            int picNum = CurrentPartySelectSix.SelectedIndex + 1;
            try
            {
                string absolutePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"128\" + picNum + ".png");
                PictureSix.Image = Image.FromFile(absolutePath);

                var pokeQueryFift =
                    from queryMon in pokemonDBDataSet.pokemonstats
                    where queryMon.pokemon_id == picNum
                    select new
                    {
                        queryMon.base_hp,
                        queryMon.base_attack,
                        queryMon.base_defense,
                        queryMon.base_special_attack,
                        queryMon.base_special_defense,
                        queryMon.base_speed
                    };

                foreach (var queryMon in pokeQueryFift)
                {
                    pkHP6.Text = queryMon.base_hp.ToString();
                    pkATK6.Text = queryMon.base_attack.ToString();
                    pkDEF6.Text = queryMon.base_defense.ToString();
                    pkSA6.Text = queryMon.base_special_attack.ToString();
                    pkSD6.Text = queryMon.base_special_defense.ToString();
                    pkSPD6.Text = queryMon.base_speed.ToString();
                }

                var pokeQuerySixt =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 1
                    select queryNew.typename;

                foreach (var queryNew in pokeQuerySixt)
                {
                    PartySixTypeOne.Text = queryNew.ToUpper();
                }

                var pokeQuerySevent =
                    from queryNew in pokemonDBDataSet.typeswithpokemon
                    where queryNew.pokemon_id == picNum
                    where queryNew.slot == 2
                    select queryNew.typename;

                foreach (var queryNew in pokeQuerySevent)
                {
                    PartySixTypeTwo.Text = queryNew.ToUpper();
                }

            }
            catch (Exception ex) { PartySixTypeOne.Text = ex.ToString(); }
        }

        private void PictureOne_Click(object sender, EventArgs e)
        {
            CurrentLvl = Convert.ToInt32(pkLVL1.Text);
            SelectedPokemon = 1;
            PictureOne.BorderStyle = BorderStyle.FixedSingle;
            PictureTwo.BorderStyle = BorderStyle.None;
            PictureThree.BorderStyle = BorderStyle.None;
            PictureFour.BorderStyle = BorderStyle.None;
            PictureFive.BorderStyle = BorderStyle.None;
            PictureSix.BorderStyle = BorderStyle.None;
        }

        private void PictureTwo_Click(object sender, EventArgs e)
        {
            CurrentLvl = Convert.ToInt32(pkLVL2.Text);
            SelectedPokemon = 2;
            PictureOne.BorderStyle = BorderStyle.None;
            PictureTwo.BorderStyle = BorderStyle.FixedSingle;
            PictureThree.BorderStyle = BorderStyle.None;
            PictureFour.BorderStyle = BorderStyle.None;
            PictureFive.BorderStyle = BorderStyle.None;
            PictureSix.BorderStyle = BorderStyle.None;
        }

        private void PictureThree_Click(object sender, EventArgs e)
        {
            CurrentLvl = Convert.ToInt32(pkLVL3.Text);
            SelectedPokemon = 3;
            PictureOne.BorderStyle = BorderStyle.None;
            PictureTwo.BorderStyle = BorderStyle.None;
            PictureThree.BorderStyle = BorderStyle.FixedSingle;
            PictureFour.BorderStyle = BorderStyle.None;
            PictureFive.BorderStyle = BorderStyle.None;
            PictureSix.BorderStyle = BorderStyle.None;
        }

        private void PictureFour_Click(object sender, EventArgs e)
        {
            CurrentLvl = Convert.ToInt32(pkLVL4.Text);
            SelectedPokemon = 4;
            PictureOne.BorderStyle = BorderStyle.None;
            PictureTwo.BorderStyle = BorderStyle.None;
            PictureThree.BorderStyle = BorderStyle.None;
            PictureFour.BorderStyle = BorderStyle.FixedSingle;
            PictureFive.BorderStyle = BorderStyle.None;
            PictureSix.BorderStyle = BorderStyle.None;
        }

        private void PictureFive_Click(object sender, EventArgs e)
        {
            CurrentLvl = Convert.ToInt32(pkLVL5.Text);
            SelectedPokemon = 5;
            PictureOne.BorderStyle = BorderStyle.None;
            PictureTwo.BorderStyle = BorderStyle.None;
            PictureThree.BorderStyle = BorderStyle.None;
            PictureFour.BorderStyle = BorderStyle.None;
            PictureFive.BorderStyle = BorderStyle.FixedSingle;
            PictureSix.BorderStyle = BorderStyle.None;
        }

        private void PictureSix_Click(object sender, EventArgs e)
        {
            CurrentLvl = Convert.ToInt32(pkLVL6.Text);
            SelectedPokemon = 6;
            PictureOne.BorderStyle = BorderStyle.None;
            PictureTwo.BorderStyle = BorderStyle.None;
            PictureThree.BorderStyle = BorderStyle.None;
            PictureFour.BorderStyle = BorderStyle.None;
            PictureFive.BorderStyle = BorderStyle.None;
            PictureSix.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
