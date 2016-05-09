﻿using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;
using NExtra.Geo;
using System;
using System.Device.Location;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace VNHealth
{
    public partial class run2 : PhoneApplicationPage
    {
        private GeoCoordinateWatcher _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
        private MapPolyline _line;
        private DispatcherTimer _timer = new DispatcherTimer();
        private long _startTime;
        public run2()
        {
            InitializeComponent();
            _line = new MapPolyline();
            _line.StrokeColor = Colors.Red;
            _line.StrokeThickness = 5;
            Map.MapElements.Add(_line);

            _watcher.PositionChanged += Watcher_PositionChanged;

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _startTime);
            timeLabel.Text = runTime.ToString(@"hh\:mm\:ss");
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (_timer.IsEnabled)
            {
                _watcher.Stop();
                _timer.Stop();
                StartButton.Content = "Start";
            }
            else
            {
                _watcher.Start();
                _timer.Start();
                _startTime = System.Environment.TickCount;
                StartButton.Content = "Stop";
            }
        }
        private double _kilometres;
        private long _previousPositionChangeTick;

        private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var coord = new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude);

            if (_line.Path.Count > 0)
            {
                var previousPoint = _line.Path.Last();
                var distance = coord.GetDistanceTo(previousPoint);
                var millisPerKilometer = (1000.0 / distance) * (System.Environment.TickCount - _previousPositionChangeTick);
                _kilometres += distance / 1000.0;

                //paceLabel.Text = TimeSpan.FromMilliseconds(millisPerKilometer).ToString(@"mm\:ss");
                distanceLabel.Text = string.Format("{0:f2} km", _kilometres);
                caloriesLabel.Text = string.Format("{0:f0}", _kilometres * 65);

                PositionHandler handler = new PositionHandler();
                var heading = handler.CalculateBearing(new Position(previousPoint), new Position(coord));
                Map.SetView(coord, Map.ZoomLevel, heading, MapAnimationKind.Parabolic);


            }
            else
            {
                Map.Center = coord;
            }

            _line.Path.Add(coord);
            _previousPositionChangeTick = System.Environment.TickCount;
        }

        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}