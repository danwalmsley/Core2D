﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Core2D.Path.Segments;
using Core2D.Shapes;
using System.Linq;
using Xunit;

namespace Core2D.UnitTests
{
    public class CubicBezierSegmentTests
    {
        [Fact]
        [Trait("Core2D.Path", "Segments")]
        public void GetPoints_Should_Return_All_Segment_Points()
        {
            var segment = new CubicBezierSegment()
            {
                Point1 = new PointShape(),
                Point2 = new PointShape(),
                Point3 = new PointShape()
            };

            var target = segment.GetPoints();

            Assert.Equal(3, target.Count());

            Assert.Contains(segment.Point1, target);
            Assert.Contains(segment.Point2, target);
            Assert.Contains(segment.Point3, target);
        }

        [Fact]
        [Trait("Core2D.Path", "Segments")]
        public void ToString_Should_Return_Path_Markup()
        {
            var target = new CubicBezierSegment()
            {
                Point1 = new PointShape(),
                Point2 = new PointShape(),
                Point3 = new PointShape()
            };

            var actual = target.ToString();

            Assert.Equal("C0,0 0,0 0,0", actual);
        }
    }
}
