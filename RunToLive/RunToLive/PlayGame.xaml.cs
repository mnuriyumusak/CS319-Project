﻿/*
Contributors: Mehmet Nuri, Selin, Ege, Merve

*/
using benimKodlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace RunToLive
{

    public partial class PlayGame : Window
    {
        Game game;
        int clicked_country = -1;
        int count = 0;
        bool moveFurtherCheck = false;
        bool isMale;

        public PlayGame(int diff,bool isMale)
        {
            InitializeComponent();
            createMap(diff);
            showWorldStatistics();
            giveColorToCountries();
            infectedProb.Content = "%" + game.giveInfectedProbOfPlayer();
            setNewsText();
            this.isMale = isMale;
            putPlayerPicture(isMale);
        }
        public void createMap(int level)
        {
            
            game = new Game(level);
            int lev;
            if (level == 1) { lev = 8; }
            else if (level == 2) { lev = 6; }
            else { lev = 5; }

            int ButtonHeight = 470 / (lev);
            int ButtonWidth = 470 / (lev);
            int Distance = 0;
            int start_x = 10;
            int start_y = 10;

            for (int x = 0; x < lev; x++)
            {
                for (int y = 0; y < lev; y++)
                {
                    Button tmpButton = new Button();
                    tmpButton.Name = "C" + ((x * lev) + y);
                    tmpButton.Margin = new Thickness(start_y + (y * ButtonWidth + Distance), start_x + (x * ButtonHeight + Distance), 0, 0);
                    tmpButton.HorizontalAlignment = HorizontalAlignment.Left;
                    tmpButton.VerticalAlignment = VerticalAlignment.Top;
                    tmpButton.Width = ButtonWidth;
                    tmpButton.Height = ButtonHeight;
                    tmpButton.Content = count;
                    tmpButton.Background = Brushes.Black;
                    tmpButton.Foreground = Brushes.Blue;
                    tmpButton.Click += countryClick;
                    myGrid.Children.Add(tmpButton);
                    count++;
                }

            }

        }
        private void countryClick(object sender, EventArgs e)
        {
            clicked_country = Int32.Parse(((Button)sender).Content + "");
            int[] stats = game.giveStatisticsACountry(clicked_country);
            country_text.Text = "Number Of Died:\r\n" +
                            "Number Of Doctor:\r\n" +
                            "Number Of Infected:\r\n" +
                            "Number Of People:\r\n" +
                            "Number Of Sicked:\r\n" +
                            "Number Of SuperHuman:\r\n";
            country_number.Text = ""+stats[0] + "\r\n" +
                                    +stats[1] + "\r\n" +
                                    +stats[2] + "\r\n" +
                                    +stats[3] + "\r\n" +
                                    +stats[4] + "\r\n" +
                                    +stats[5];
            foreach (Button b in myGrid.Children)
            {
                b.BorderBrush = Brushes.Black;
            }
            ((Button)sender).BorderBrush = Brushes.Red;
        }


        private void showWorldStatistics()
        {
            int[] stats = game.giveStatisticsAllWorld();
            world_text.Text = "Total Healthy:\r\n" +
                                "Total Infected:\r\n" +
                                "Total Sicked:\r\n" +
                                "Total Died:\r\n" +
                                "Total SuperHuman:\r\n" +
                                "Day:\r\n" +
                                "Total Number Of Doctor:\r\n";
            world_number.Text = ""  +stats[0] + "\r\n" +
                                    +stats[1] + "\r\n" +
                                    +stats[2] + "\r\n" +
                                    +stats[3] + "\r\n" +
                                    +stats[4] + "\r\n" +
                                    +stats[5] + "\r\n" +
                                    +stats[6];
        }

        private void giveColorToCountries()
        {
            int[] color = new int[game.giveMeCountryNumber() * game.giveMeCountryNumber()];
            int count = 0;
            double sickedAvarage = 0;
            //find avarage sick people
            foreach (Country c in (game.world.getMap()).allCountries)
            {
                sickedAvarage += c.numberOfSicked;
            }
            sickedAvarage = sickedAvarage / game.giveMeTotalPeopleNumber();
            count = 0;
            foreach (Country c in (game.world.getMap()).allCountries)
            {
                if (c.numberOfSicked > sickedAvarage + (sickedAvarage * 30 / 100)) color[count] = 2; //if bigger than %30 more than avarage
                else if (c.numberOfSicked < sickedAvarage - (sickedAvarage * 30 / 100)) color[count] = 1; //if lesser than %30 less than avarage
                else color[count] = 0; // araound %30 of the avarage 
                count++;
            }

            //gives colors to buttons 
            count = 0;

            foreach (Button b in myGrid.Children)
            {
                if (color[count] == 2)
                    b.Background = Brushes.Red;
                else if (color[count] == 1)
                    b.Background = Brushes.Green;
                else
                    b.Background = Brushes.Yellow;
                count++;
            }
        }

        private void putPlayerPicture(bool isMale)
        {
            foreach (Button b in myGrid.Children)
            {
                if (Int32.Parse(b.Name.Substring(1)) == game.world.mapManager.gameMap.player.currentCountryId)
                {
                    string manPath = System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\icon\\man.png";
                    string womanPath = System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\icon\\woman.png";
                    if (isMale)
                        b.Background = new ImageBrush(new BitmapImage(new Uri(@manPath)));
                    else
                        b.Background = new ImageBrush(new BitmapImage(new Uri(@womanPath)));

                }
            }
        }
        private void turnButton(object sender, RoutedEventArgs e)
        {
            giveColorToCountries();
            
            if (moveFurtherCheck)
            {
                if (!game.passTurn(clicked_country, true))
                {
                    if(game.checkIsGameFinished())
                    {
                        button.IsEnabled = false;
                        moveFurtherCheck = false;
                    }
                }
               
            }
            else
                if(!game.passTurn(clicked_country, false))
                    if (game.checkIsGameFinished())
                    {
                        button.IsEnabled = false;
                    }

            putPlayerPicture(isMale);
            showWorldStatistics();
            infectedProb.Content = " % " + game.giveInfectedProbOfPlayer();
            setNewsText();
            //all of them turn black
            foreach (Button b in myGrid.Children)
            {
                b.BorderBrush = Brushes.Black;
            }

            int[] stats = game.giveStatisticsAllWorld();
            int totalPeople = game.giveMeTotalPeopleNumber();
            int superHuman = (int)(game.settings[0] * (game.settings[1] / 100.0));
            if (game.world.mapManager.gameMap.player.isDied)
            {
                GameResults gr = new GameResults(true, stats, totalPeople,game.world.vaccinateDay, superHuman);
                this.Close();
                gr.Show();
            }
            else if (game.checkIsGameFinished())
            {
                GameResults gr = new GameResults(false, stats, totalPeople, game.world.vaccinateDay, superHuman);
                this.Close();
                gr.Show();
            }

        }

 

        private void checkYourselfButton(object sender, RoutedEventArgs e)
        {
            if (game.world.mapManager.gameMap.player.useCheckHimselfPower())
                System.Windows.MessageBox.Show("You are infected");
            else
                System.Windows.MessageBox.Show("You are not infected");
            checkYourself.IsEnabled = false;
        }

        private void beHealthyButton(object sender, RoutedEventArgs e)
        {
            if (game.world.mapManager.gameMap.player.useBeHealthyPower())
                System.Windows.MessageBox.Show("You are healed");
            else
                System.Windows.MessageBox.Show("You were not infected so you wasted this power.");

            beHealthy.IsEnabled = false;
        }

        private void moveFurtherButton(object sender, RoutedEventArgs e)
        {
            moveFurtherCheck = true;
            moveFurther.IsEnabled = false;
        }

        private void setNewsText()
        {
            news_text.Content = game.giveNews();
        }


    }
}

