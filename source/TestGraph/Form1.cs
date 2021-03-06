﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace TestGraph
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

#if false
      var dtStart = new DateTime(2019, 4, 2, 13, 23, 0);
      var dtEnd = new DateTime(2019, 4, 2, 14, 36, 0);
#else
      var dtStart = new DateTime(2017, 3, 19, 13, 23, 0);
      var dtEnd = new DateTime(2017, 4, 8, 14, 36, 0);
#endif
      zgGraph.GraphPane.XAxis.Type = AxisType.Date;

      zgGraph.IsShowPointValues = true;
      zgGraph.IsShowCursorValues = false;

      var xscale = zgGraph.GraphPane.XAxis.Scale;
      xscale.Min = XDate.DateTimeToXLDate(dtStart);
      xscale.Max = XDate.DateTimeToXLDate(dtEnd);
      xscale.MajorStep = 1;
      xscale.MajorUnit = DateUnit.Hour;
      xscale.MinorStep = 30;
      xscale.MinorUnit = DateUnit.Minute;

      var xAxis = zgGraph.GraphPane.XAxis;
      xAxis.MajorGrid.IsVisible = true;
      xAxis.MajorGrid.Color = Color.Blue;
      xAxis.MinorGrid.IsVisible = true;
      xAxis.MinorGrid.Color = Color.AliceBlue;


      bool bAuto = true; 
      xscale.MinAuto = bAuto;
      xscale.MaxAuto = bAuto;
      xscale.MajorStepAuto = bAuto;
      xscale.MinorStepAuto = bAuto;

      var yscale = zgGraph.GraphPane.YAxis.Scale;
      yscale.MajorStepAuto = false;
      yscale.MajorStep = 1;
      yscale.Min = 0;
      yscale.Max = 10;

      var points = new PointPairList();
      points.Add(XDate.DateTimeToXLDate(dtStart), 2);
      points.Add(XDate.DateTimeToXLDate(dtStart + TimeSpan.FromMinutes(10)), 3);
      points.Add(XDate.DateTimeToXLDate(dtEnd -  TimeSpan.FromMinutes(10)), 1);
      points.Add(XDate.DateTimeToXLDate(dtEnd), 0);
      zgGraph.GraphPane.AddCurve("Fish", points, Color.Black);

#if false
      zgGraph.GraphPane.Cursors.Add(new CursorObj(XDate.DateTimeToXLDate(dtStart + TimeSpan.FromMinutes(5)), CursorOrientation.Vertical));
      zgGraph.GraphPane.Cursors.Add(new CursorObj(XDate.DateTimeToXLDate(dtEnd - TimeSpan.FromMinutes(1)), CursorOrientation.Vertical));

      zgGraph.GraphPane.Cursors.Add(new CursorObj(1.1, CursorOrientation.Horizontal));
      zgGraph.GraphPane.Cursors.Add(new CursorObj(8.2, CursorOrientation.Horizontal));
#endif

      zgGraph.GraphPane.Cursors.Add(new CursorObj(0.1, CursorOrientation.Vertical) { CoordinateUnit = CoordType.ChartFraction } );
      zgGraph.GraphPane.Cursors.Add(new CursorObj(0.8, CursorOrientation.Vertical) { CoordinateUnit = CoordType.ChartFraction });

      zgGraph.AxisChange();
      zgGraph.Invalidate();

    }
  }
}
