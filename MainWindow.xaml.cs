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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lab_CarSimulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /* NAME: Kelem Nyarko
     * Project: WPF.NET C#
     * App Name: CAR_SIMULATION
     * MUSIC CREDIT: P-SQUARE--->INSTRUMENTAL
     */

    public partial class MainWindow : Window
    {
        DispatcherTimer seatBeltTimer = new DispatcherTimer(); // instance for timers
        DispatcherTimer imgBrake_LeftTimer = new DispatcherTimer();
        DispatcherTimer imgBrake_RightTimer = new DispatcherTimer();
        DispatcherTimer imgLeftTurnTimer = new DispatcherTimer();
        DispatcherTimer imgRightTurnTimer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();

            imgSeatbelt.Visibility = Visibility.Collapsed;
            imgLeftTurn.Visibility = Visibility.Collapsed;
            Clear_Fields();
            medRadio_Player.Stop();
            


            seatBeltTimer.Tick += seatBeltTimerEvent; //seatbelt timer
            seatBeltTimer.Interval = TimeSpan.FromMilliseconds(400);
            seatBeltTimer.Stop();

            imgBrake_LeftTimer.Tick += new EventHandler(imgBrake_LeftTimer_Tick); //brake light timers
            imgBrake_LeftTimer.Interval = TimeSpan.FromMilliseconds(400);
            imgBrake_LeftTimer.Stop();

            imgBrake_RightTimer.Tick += imgBrake_RightTimerEvent;
            imgBrake_RightTimer.Interval = TimeSpan.FromMilliseconds(400);
            imgBrake_RightTimer.Stop(); //stop because the hazards only trigger when the button is engaged

            imgLeftTurnTimer.Tick += imgLeftTurnTimerEvent;
            imgLeftTurnTimer.Interval = TimeSpan.FromMilliseconds(400);
            imgLeftTurnTimer.Stop();

            imgRightTurnTimer.Tick += imgRightTurnTimerEvent;
            imgRightTurnTimer.Interval = TimeSpan.FromMilliseconds(400);
            imgRightTurnTimer.Stop();

        }


        private bool BlinkOnRightTurn = false; // variable to check which timer event should be switched on
        private void imgRightTurnTimerEvent(object? sender, EventArgs e)
        {
            if (BlinkOnRightTurn) //blinks left turn light
            {
                imgRightTurn.Visibility = Visibility.Hidden;
            }
            else
            {
                imgRightTurn.Visibility = Visibility.Visible;
            }
            BlinkOnRightTurn = !BlinkOnRightTurn;
        }

        private bool BlinkOnLeftTurn = false;
        private void imgLeftTurnTimerEvent(object? sender, EventArgs e)
        {

            if (BlinkOnLeftTurn) //blinks left turn light
            {
                imgLeftTurn.Visibility = Visibility.Hidden;
            }
            else
            {
                imgLeftTurn.Visibility = Visibility.Visible;
            }
            BlinkOnLeftTurn = !BlinkOnLeftTurn;

        }

        private bool BlinkOnBrakeRight = false;
        private void imgBrake_RightTimerEvent(object? sender, EventArgs e) //timer event to blink right brake light
        {

            if (BlinkOnBrakeRight) //blinks left brake light
            {
                imgBrake_Right.Visibility = Visibility.Hidden;
            }
            else
            {
                imgBrake_Right.Visibility = Visibility.Visible;
            }
            BlinkOnBrakeRight = !BlinkOnBrakeRight;

        }

        private bool BlinkOnBrakeLeft = false;
        private void imgBrake_LeftTimer_Tick(object? sender, EventArgs e) //timer event to blink left brake light
        {
            if (BlinkOnBrakeLeft) //blinks left brake light
            {
                imgBrake_Left.Visibility = Visibility.Hidden;
            }
            else //else statement alternates image between hidden and collasped
            {
                imgBrake_Left.Visibility = Visibility.Visible;
            }
            BlinkOnBrakeLeft = !BlinkOnBrakeLeft;
        }

        private bool BlinkOn = false;
        private void seatBeltTimerEvent(object? sender, EventArgs e)
        {

            if (BlinkOn) //blinks seatbelt
            {
                imgSeatbelt.Visibility = Visibility.Hidden;
            }
            else
            {
                imgSeatbelt.Visibility= Visibility.Visible;
            }
            BlinkOn = !BlinkOn;

        }

        private void radPark_Checked(object sender, RoutedEventArgs e)
        {
            chkKey_Off.IsChecked = true;
            chkKey_Off.IsChecked = false;
        }

        private void radDrive_Checked(object sender, RoutedEventArgs e)
        {
            chkKey_On.IsChecked = true;
            chkKey_Off.IsChecked= false;
            seatBeltTimer.Start();
        }

        private void chkKey_Off_Checked(object sender, RoutedEventArgs e)
        {
            radPark.IsChecked = true;
            chkKey_On.IsChecked = false;
            chkNo_Key.IsChecked = false;
            //medDashboard.Visibility = Visibility.Collapsed;

            // imgSeatbelt.Visibility = Visibility.Visible;
            seatBeltTimer.Stop();
        }

        private void chkKey_On_Checked(object sender, RoutedEventArgs e)
        {
            chkKey_Off.IsChecked = false;
            chkNo_Key.IsChecked = false;
            chkKey_Acc.IsChecked = false;
            radPark.IsChecked = true;
            medDashboard.Visibility = Visibility.Visible;
        }

        private void chkHeadAuto_Checked(object sender, RoutedEventArgs e)
        {
            chkHead_On.IsChecked = true;
            chkHead_Off.IsChecked = false;
            chkDoor_Open___Close.IsChecked = false;
            imgHeadLeft.Visibility = Visibility.Visible;
            imgHeadRight.Visibility = Visibility.Visible;
        }

        private void chkDoor_Open___Close_Checked(object sender, RoutedEventArgs e)
        {
            chkHeadAuto.IsChecked = false;
            imgDome.Visibility = Visibility.Visible;
            imgHeadLeft.Visibility = Visibility.Collapsed;
            imgHeadRight.Visibility = Visibility.Collapsed;
            imgDome.Visibility = Visibility.Collapsed;
        }

        private void chkKey_Acc_Checked(object sender, RoutedEventArgs e)
        {
            chkKey_Off.IsChecked = false;
            chkNo_Key.IsChecked = false;
            chkKey_On.IsChecked = false;
            // medRadio_Player.Stop(); may delete
        }

        private void chkLeft_Turn_Checked(object sender, RoutedEventArgs e) //left turn signal
        {
            imgLeftTurn.Visibility = Visibility.Visible;
            imgRightTurn.Visibility = Visibility.Collapsed;
            imgLeftTurnTimer.Start();
            imgRightTurnTimer.Stop();
            chkBeltOff.IsChecked = false;
            chkRight_Turn.IsChecked = false;
        }

        private void chkbeltOn_Checked(object sender, RoutedEventArgs e)
        {
            seatBeltTimer.Stop();
            imgSeatbelt.Visibility = Visibility.Collapsed;
            chkBeltOff.IsChecked = false;
        }

        private void chkBeltOff_Checked(object sender, RoutedEventArgs e)
        {
            chkbeltOn.IsChecked = false;
            chkKey_On.IsChecked = false;
            seatBeltTimer.Start();
        }

        private void chkBrakeOn_Checked(object sender, RoutedEventArgs e) //turns on brake lights
        {
            imgBrake_Left.Visibility = Visibility.Visible;
            imgBrake_Right.Visibility = Visibility.Visible;
            chkBrakeOff.IsChecked = false;
            imgBrake_RightTimer.Stop();
            imgBrake_LeftTimer.Stop();
        }

        private void chkBrakeOff_Checked(object sender, RoutedEventArgs e)
        {
            imgBrake_Left.Visibility = Visibility.Collapsed;
            imgBrake_Right.Visibility = Visibility.Collapsed;
            chkBrakeOn.IsChecked = false;
        }

        private void chkHazOn_Checked(object sender, RoutedEventArgs e) //turns on hazard lights
        {
            chkRight_Turn.IsEnabled = false;
            chkLeft_Turn.IsEnabled = false;
            chkHazOff.IsChecked = false;
            imgLeftTurnTimer.Start();
            imgRightTurnTimer.Start();
            imgBrake_LeftTimer.Start();
            imgBrake_RightTimer.Start();
            imgBrake_Left.Visibility = Visibility.Visible;
            imgBrake_Right.Visibility = Visibility.Visible;
            imgLeftTurn.Visibility = Visibility.Visible;
            imgRightTurn.Visibility = Visibility.Visible;
        }

        private void chkHazOff_Checked(object sender, RoutedEventArgs e) //turning hazards off
        {
            chkRight_Turn.IsEnabled = true;
            chkLeft_Turn.IsEnabled = true;
            imgLeftTurnTimer.Stop();
            imgRightTurnTimer.Stop();
            chkHazOn.IsChecked = false;
            imgBrake_LeftTimer.Stop();
            imgBrake_RightTimer.Stop();
            imgBrake_Left.Visibility = Visibility.Collapsed;
            imgBrake_Right.Visibility = Visibility.Collapsed;
            imgLeftTurn.Visibility = Visibility.Collapsed;
            imgRightTurn.Visibility = Visibility.Collapsed;
        }

        private void chkHead_On_Checked(object sender, RoutedEventArgs e) // animates the headlight to 'visible' for turn on
        {
            imgHeadLeft.Visibility = Visibility.Visible;
            imgHeadRight.Visibility = Visibility.Visible;
            chkHead_Off.IsChecked = false; //can't be checked when head_On is checked
        }

        private void chkHead_Off_Checked(object sender, RoutedEventArgs e)
        {
            imgHeadLeft.Visibility = Visibility.Collapsed;
            imgHeadRight.Visibility = Visibility.Collapsed;
            chkHead_On.IsChecked = false; //can't be checked when head_Off is checked
            chkHeadAuto.IsChecked = false;
        }

        private void chkRight_Turn_Checked(object sender, RoutedEventArgs e)
        {
            imgRightTurn.Visibility = Visibility.Visible;
            imgLeftTurn.Visibility = Visibility.Collapsed;
            imgRightTurnTimer.Start();
            imgLeftTurnTimer.Stop();
            chkBeltOff.IsChecked = false;
            chkLeft_Turn.IsChecked = false;
        }

        private void chkTurn_Signal_Off_Checked(object sender, RoutedEventArgs e)
        {
            imgRightTurn.Visibility = Visibility.Collapsed;
            imgLeftTurn.Visibility = Visibility.Collapsed;
            imgRightTurnTimer.Stop();
            imgLeftTurnTimer.Stop();
            chkLeft_Turn.IsChecked = false;
            chkRight_Turn.IsChecked = false;
        }

        private void chkDome_On_Checked(object sender, RoutedEventArgs e)
        {
            imgDome.Visibility = Visibility.Visible;
            chkDome_Auto.IsChecked = true;
            chkDome_Off.IsChecked = false;
        }

        private void chkDome_Auto_Checked(object sender, RoutedEventArgs e)
        {
            imgDome.Visibility = Visibility.Visible;
            chkDome_Off.IsChecked=false;
            chkDoor_Open___Close.IsChecked = true;
        }

        private void chkDome_Off_Checked(object sender, RoutedEventArgs e)
        {
            imgDome.Visibility = Visibility.Collapsed;
            chkDome_Auto.IsChecked = false;
            chkDome_On.IsChecked = false;
        }

        private void medWind_Wiper_Loaded(object sender, RoutedEventArgs e) //starts the wiper gif as a video
        {
            medWind_Wiper.Visibility = Visibility.Collapsed;
            medWind_Wiper.Play();
        }

        private void medWind_Wiper_MediaEnded(object sender, RoutedEventArgs e) //keeps the gif in loop and overides the 'media_end' event until turned off
        {
            medWind_Wiper.Position = TimeSpan.FromMilliseconds(1);
        }

        private void chkWiper_On_Checked(object sender, RoutedEventArgs e) // turns on wipers
        {
            medWind_Wiper.Visibility = Visibility.Visible;
            chkWiper_Off.IsChecked = false;
            medWind_Wiper.Position = TimeSpan.FromMilliseconds(1);
        }

        private void chkWiper_Off_Checked(object sender, RoutedEventArgs e)
        {
            chkWiper_Auto.IsChecked = false;
            medWind_Wiper.Play();
            // medWind_Wiper.Stop();
            medWind_Wiper.Visibility = Visibility.Collapsed;
            chkWiper_On.IsChecked = false;
        }

        private void chkWiper_Auto_Checked(object sender, RoutedEventArgs e)
        {
            chkWiper_Off.IsChecked = false;
            medWind_Wiper.Visibility = Visibility.Visible;
            medWind_Wiper.Position = TimeSpan.FromMilliseconds(1);
        }

        private void chkNo_Key_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Uncheck boxes/actions before proeceeding to the next. Click Ok to continue");
            Clear_Fields();
        }

        public void Clear_Fields() //resets the controls to their initial state
        {
            chkDoor_Open___Close.IsChecked = true;
            chkWiper_Off.IsChecked = true;
            radPark.IsChecked = true;
            chkTurn_Signal_Off.IsChecked = true;
            chkDome_Off.IsChecked = true;
            chkNo_Key.IsChecked = true;
            chkHead_Off.IsChecked = true;
            chkBrakeOff.IsChecked = true;
            imgSeatbelt.Visibility = Visibility.Collapsed;
            medRadio_Player.Stop();
            chkCar_Radio_Off.IsChecked = true;
            medDashboard.Visibility = Visibility.Collapsed;

        }

        private void medRadio_Player_MediaEnded(object sender, RoutedEventArgs e) // media player event for radio
        {
            medRadio_Player.Position = TimeSpan.FromMilliseconds(1);
            medRadio_Player.Stop();
        }

        private void chkCar_Radio_Off_Checked(object sender, RoutedEventArgs e)
        {
            medRadio_Player.Stop();
            chkCar_Radio_On.IsChecked = false;
            imgRadio_Icon.Visibility = Visibility.Visible;
        }

        private void chkCar_Radio_On_Checked(object sender, RoutedEventArgs e) //turns on radio
        {
            chkCar_Radio_Off.IsChecked = false;
            medRadio_Player.Play();
            imgRadio_Icon.Visibility = Visibility.Visible;
        }

        private void medRadio_Player_Loaded(object sender, RoutedEventArgs e) // media event to turn on radio
        {
            imgRadio_Icon.Visibility = Visibility.Visible;
            medRadio_Player.Stop();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) // shuts down application
        {
            Application.Current.Shutdown();
        }

        private void medDashboard_Loaded(object sender, RoutedEventArgs e) //simulates dashboard engine start
        {
            medDashboard.Visibility = Visibility.Collapsed;
            medDashboard.Play();
        }

        private void medDashboard_MediaEnded(object sender, RoutedEventArgs e) //keeps the dash running in loop and visible until key turned to off
        {
            medDashboard.Position = TimeSpan.FromMilliseconds(1);
        }
    }
}