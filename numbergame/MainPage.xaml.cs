using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Core;
using Windows.Storage;
using Windows.Storage.FileProperties;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace numbergame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int[] board = new int[26];
        int inc_num=1;
        string loadedHighScore="0";
        int score = 0, high_score = 0, MAX_SCORE = 25000, IN_SCORE = 10, random_num_grn = 5;
        public StorageFolder storageFolder = null;
        public StorageFile storageFile = null;
        public  MainPage()
        {
            this.InitializeComponent();
            sound_b.IsOn = true;
            CoreWindow.GetForCurrentThread().KeyDown += KeyDownFn;
            blank_board();
            update_board();
            start_game();
            blank_board();
            update_board();
            //this.fle = await sf.CreateFileAsync(MainPage.filename, CreationCollisionOption.OpenIfExists);
        }
        private async void highscore(int ow)
        {
            string filename = "HighScore.hs", HS =high_score.ToString();      
            if (ow == 0)
            {
                StorageFile sampleFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
                if (sampleFile != null)
                {
                    loadedHighScore = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                    try{
                        if((high_score = int.Parse(loadedHighScore)) == null)
                        loadedHighScore = "0";

                    }catch{
                        loadedHighScore="0";
                    }
                }
                else
                {
                    loadedHighScore = "0";
                }
            }
            else
            {
                StorageFile sampleFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(sampleFile, HS);

            }
        }
        private void blank_board()
        {
            int i;
            for (i = 1; i <= 25; i++)
                board[i] = 0;
        }
        public void KeyDownFn(CoreWindow sender,KeyEventArgs args)
        {
            if (args.VirtualKey.ToString().CompareTo("Up") == 0)
            {
                play_game(2);
                inc_num++;
            }
            else if (args.VirtualKey.ToString().CompareTo("Down") == 0)
            {
                play_game(3);
                inc_num++;
            }
            else if (args.VirtualKey.ToString().CompareTo("Left") == 0)
            {
                play_game(0);
                inc_num++;
            }
            else if (args.VirtualKey.ToString().CompareTo("Right") == 0)
            {
                play_game(1);
                inc_num++;
            }
            update_board();
        }
        void random_number_to_int()
        {
            int num,int_pl=0,i,j;
            Boolean tf=true;
            Random rnd = new Random();
            Random rnd2 = new Random();
            if (number_of(board, 25, 0) % 2 == 0 && number_of(board,25,0)>2)
                j = 2;
            else
                j = 1;
            if (number_of(board, 25, 0) > 0)
            {
                for (i = 0; i < j; i++)
                {
                    while (tf)
                    {
                        int_pl = rnd2.Next(1, 26);
                        if (board[int_pl] == 0)
                            tf = false;
                    }
                    rnd.Next(1, 28);
                    num = rnd.Next(1, 6);
                    board[int_pl] = num;
                    tf = true;
                }
            }
        }

        public void update_board()
        {
            int ins;
                swipe.Play();
            textScore.Text = score.ToString();
            textHighScore.Text = high_score.ToString();
            if (number_of(board, 25, 0) < 25)
            {
                if (inc_num % (random_num_grn) == 0)
                    random_number_to_int();
            }
                ins = board[1];
                if (ins == 0)
                    i1.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i1.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i1.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i1.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i1.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i1.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[2];
                if (ins == 0)
                    i2.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i2.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i2.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i2.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i2.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i2.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[3];
                if (ins == 0)
                    i3.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i3.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i3.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i3.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i3.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i3.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[4];
                if (ins == 0)
                    i4.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i4.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i4.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i4.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i4.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i4.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[5];
                if (ins == 0)
                    i5.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i5.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i5.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i5.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i5.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i5.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[6];
                if (ins == 0)
                    i6.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i6.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i6.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i6.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i6.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i6.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[7];
                if (ins == 0)
                    i7.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i7.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i7.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i7.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i7.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i7.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[8];
                if (ins == 0)
                    i8.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i8.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i8.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i8.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i8.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i8.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[9];
                if (ins == 0)
                    i9.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i9.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i9.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i9.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i9.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i9.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[10];
                if (ins == 0)
                    i10.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i10.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i10.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i10.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i10.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i10.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[11];
                if (ins == 0)
                    i11.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i11.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i11.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i11.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i11.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i11.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[12];
                if (ins == 0)
                    i12.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i12.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i12.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i12.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i12.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i12.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[13];
                if (ins == 0)
                    i13.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i13.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i13.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i13.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i13.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i13.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[14];
                if (ins == 0)
                    i14.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i14.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i14.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i14.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i14.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i14.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[15];
                if (ins == 0)
                    i15.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i15.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i15.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i15.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i15.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i15.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[16];
                if (ins == 0)
                    i16.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i16.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i16.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i16.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i16.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i16.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[17];
                if (ins == 0)
                    i17.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i17.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i17.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i17.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i17.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i17.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[18];
                if (ins == 0)
                    i18.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i18.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i18.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i18.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i18.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i18.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[19];
                if (ins == 0)
                    i19.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i19.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i19.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i19.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i19.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i19.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[20];
                if (ins == 0)
                    i20.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i20.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i20.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i20.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i20.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i20.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[21];
                if (ins == 0)
                    i21.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i21.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i21.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i21.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i21.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i21.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[22];
                if (ins == 0)
                    i22.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i22.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i22.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i22.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i22.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i22.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[23];
                if (ins == 0)
                    i23.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i23.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i23.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i23.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i23.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i23.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[24];
                if (ins == 0)
                    i24.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i24.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i24.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i24.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i24.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i24.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));




                ins = board[25];
                if (ins == 0)
                    i25.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/0.png"));
                else if (ins == 1)
                    i25.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/1.png"));
                else if (ins == 2)
                    i25.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/2.png"));
                else if (ins == 3)
                    i25.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/3.png"));
                else if (ins == 4)
                    i25.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/4.png"));
                else if (ins == 5)
                    i25.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/5.png"));

            }
        public void move_int(int int_num,int lrud)  //lrud,left =0 right =1, up =2,down=others; int number is 1 to 25 for our board
        {
            switch (lrud)
            {
                case 0:
                    if (board[int_num] != 0 && (int_num - 1) % 5 != 0)
                    {
                        if (board[int_num] == board[int_num - 1])
                        {
                            board[int_num] = 0;
                            score += IN_SCORE;
                        }
                        else if(board[int_num-1]==0)
                        {
                            board[int_num - 1] = board[int_num];
                            board[int_num] = 0;
                        }
                   }
                    break;
                case 1:
                    if (board[int_num] != 0 && (int_num) % 5 != 0)
                    {
                        if (board[int_num] == board[int_num + 1])
                        {
                            board[int_num] = 0;
                            score += IN_SCORE;
                        }
                        else if (board[int_num +1] == 0)
                        {
                            board[int_num +1] = board[int_num];
                            board[int_num] = 0;
                        }
                    }
                    break;
                case 2:
                    if (board[int_num] != 0 && (int_num - 1) / 5 != 0)
                    {
                        if (board[int_num] == board[int_num - 5])
                        {
                            board[int_num] = 0;
                            score += IN_SCORE;
                        }
                        else if (board[int_num - 5] == 0)
                        {
                            board[int_num - 5] = board[int_num];
                            board[int_num] = 0;
                        }
                    }
                    break;
                case 3:
                    if (board[int_num] != 0 && (25-int_num) / 5 != 0)
                    {
                        if (board[int_num] == board[int_num + 5])
                        {
                            board[int_num] = 0;
                            score += IN_SCORE;
                        }
                        else if (board[int_num +5] == 0)
                        {
                            board[int_num +5] = board[int_num];
                            board[int_num] = 0;
                        }
                    }
                    break;
            }
        }
        public void move_row(int rn,int lr) //lr -> left or right, left =0   rn -> row number
        {
            int i,n=((rn-1)*5)+1,j;
            if (lr==0)
            {
                for (j = 0; j < 25; j++)
                {
                    for (i = 1; i <= 5; i++)
                    {
                        move_int(n + i-1, 0);
                    }
                }
            }
            else
            {
                    for (j = 0; j < 25; j++)
                    {
                        for (i = 5; i >= 1; i--)
                        {
                            move_int(n + i - 1,1);
                        }
                    }
            }
        }
        public void move_column(int cn,int ud)  //ud - up or down pressed ud=0 for up
        {
            int i,j,n=cn;
            if (ud == 0)
            {
                for (j = 0; j < 25; j++)
                    for (i = 1; i <= 5; i++)
                    {
                        move_int(n + (i - 1) * 5, 2);
                    }
            }
            else
            {
                for (j = 0; j < 25; j++)
                    for (i = 5; i >= 1; i--)
                    {
                        move_int(n + (i - 1) * 5, 3);
                    }
            }
        }
        public void play_game(int move) /// 0-> left 1-> right 2->up 3->down
        {
            int i;
                switch (move)
                {
                    case 0:
                        for (i = 1; i <= 5; i++)
                            move_row(i, 0);
                        break;
                    case 1:
                        for (i = 1; i <= 5; i++)
                            move_row(i, 1);
                        break;
                    case 2:
                        for (i = 1; i <= 5; i++)
                            move_column(i, 0);
                        break;
                    case 3:
                        for (i = 1; i <= 5; i++)
                            move_column(i, 1);
                        break;
                }
                click.Stop();
            textScore.Text = score.ToString();
            if (score > high_score)
            {
                high_score = score;
                highscore(1);
            }
            //is_gamed();
            is_gameovered();

        }
        public async void is_gameovered()
        {
            int total_bxes=0;
            total_bxes = number_of(board, 25, 0);
            if (total_bxes == 0)
            {
                MessageDialog msgbox_gameover = new MessageDialog("Game Over!\nYour score is: "+score.ToString(), "FruitSwiper");
                await msgbox_gameover.ShowAsync();
                highscore(1);
                ///high_score = int.Parse(loadedHighScore);
                textHighScore.Text = high_score.ToString();
                blank_board();
                update_board();
            }
        }

        public async void is_gamed()
        {
            int i,y=0;
            for (i = 1; i <= 25; i+=5)
            {
                if ((board[i] == board[i + 1]) && (board[i + 1] == board[i + 2]) && (board[i + 2] == board[i + 3]) && (board[i + 3] == board[i + 4]) && board[i]!=0)
                    y++;
            }
            if (score > MAX_SCORE)
                y = 4;
            if(y==4)
            {
                MessageDialog msg_gamed = new MessageDialog("Gamed", "NumberGame");
                await msg_gamed.ShowAsync();
            }
        }
        public int number_of(int[] arr, int n, int num)
        {
            int i, nof = 0;
            for (i = 1; i <= n; i++)
                if (arr[i] == num)
                    nof++;
            return nof;
        }
        public void new_game(int lavel)
        {
            Random rnd = new Random();
            int i, nm;
            Boolean tf=true;
            do
            {
                for (i = 0; i < 25; i++)
                {
                    nm = rnd.Next(0, 6);
                    board[i + 1] = (int)nm;
                }
                if (number_of(board, 25, 0) >= (10))
                    tf=false;
            } while (tf);
            tf = true;
            score = 0;
            highscore(0);
            textHighScore.Text = high_score.ToString();
            update_board();
        }

        public void start_game()
        {

            int lvl = 1;
            int ind = comboboxLavel.SelectedIndex;
            if (ind == 0/*lvle.CompareTo("Very Easy") == 0*/)
            {
                lvl = 1;
                IN_SCORE = 4;
                random_num_grn = 4;
            }
            else if (ind == 1/*lvle.CompareTo("Easy") == 0*/)
            {
                lvl = 2;
                IN_SCORE = 6;
                random_num_grn = 3;
            }
            else if (ind == 2/*lvle.CompareTo("Medium") == 0*/)
            {
                lvl = 3;
                IN_SCORE = 8;
                random_num_grn = 2;
            }
            else if (ind == 3/*lvle.CompareTo("Hard") == 0*/)
            {
                lvl = 4;
                IN_SCORE = 10;
                random_num_grn = 1;
            }
            new_game(lvl);
            score = 0;
            textScore.Text = score.ToString();
            high_score = int.Parse(loadedHighScore);
            textHighScore.Text = high_score.ToString();
            inc_num = 0;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            click.Play();
            start_game();

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
        }

       

        private void button_left_Click(object sender, RoutedEventArgs e)
        {
            inc_num++;
            play_game(0);
            update_board();
        }

        private void button_right_Click(object sender, RoutedEventArgs e)
        {
            inc_num++;
            play_game(1);
            update_board();
        }

        private void button_up_Click(object sender, RoutedEventArgs e)
        {
            inc_num++;
            play_game(2);
            update_board();
        }

        private void button_down_Click(object sender, RoutedEventArgs e)
        {
            inc_num++;
            play_game(3);
            update_board();
        }

        private void onsb_Toggled(object sender, RoutedEventArgs e)
        {
            if (onsb.IsOn == false)
            {
                border.Visibility = Visibility.Collapsed;
                button_up.Visibility = Visibility.Collapsed;
                button_down.Visibility = Visibility.Collapsed;
                button_left.Visibility = Visibility.Collapsed;
                button_right.Visibility = Visibility.Collapsed;
            }
            else
            {
                border.Visibility = Visibility.Visible;
                button_up.Visibility = Visibility.Visible;
                button_down.Visibility = Visibility.Visible;
                button_left.Visibility = Visibility.Visible;
                button_right.Visibility = Visibility.Visible;
            }
        }

        private void comboboxLavel_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
        }

        private void comboboxLavel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void comboboxLavel_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
        }

        private void comboboxLavel_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxLavel_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            start_game();
        }

        private void comboboxLavel_DataContextChanged_1(FrameworkElement sender, DataContextChangedEventArgs args)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            click.Play();
        }

        



        private void sound_b_Toggled(object sender, RoutedEventArgs e)
        {
            if (sound_b.IsOn == true)
            {
                swipe.IsMuted = false;
                click.IsMuted = false;
            }
            else
            {
                swipe.IsMuted = true;
                click.IsMuted = true;
            }
        }

        private void b_about_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(About));
        }



        private void b_help_Click(object sender, RoutedEventArgs e)
        {

            click.Play();
            this.Frame.Navigate(typeof(Help));
        }

        private void b_exit_Click(object sender, RoutedEventArgs e)
        {
            click.Play();
            Application.Current.Exit();
        }
    }
}