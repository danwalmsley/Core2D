﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Core2D
{
    /// <summary>
    /// Object representing image shape.
    /// </summary>
    public class XImage : XText
    {
        private string _key;

        /// <summary>
        /// Gets or sets image key used to retrieve bytes from <see cref="IImageCache"/> repository.
        /// </summary>
        public string Key
        {
            get { return _key; }
            set { Update(ref _key, value); }
        }

        /// <inheritdoc/>
        public override void Bind(Record r)
        {
            base.Bind(r ?? this.Data.Record);
        }

        /// <inheritdoc/>
        public override void Draw(object dc, IRenderer renderer, double dx, double dy, ImmutableArray<Property> db, Record r)
        {
            var record = r ?? this.Data.Record;

            if (State.Flags.HasFlag(ShapeStateFlags.Visible))
            {
                renderer.Draw(dc, this, dx, dy, db, record);
                base.Draw(dc, renderer, dx, dy, db, record);
            }
        }

        /// <summary>
        /// Creates a new <see cref="XImage"/> instance.
        /// </summary>
        /// <param name="x1">The X coordinate of <see cref="XImage.TopLeft"/> corner point.</param>
        /// <param name="y1">The Y coordinate of <see cref="XImage.TopLeft"/> corner point.</param>
        /// <param name="x2">The X coordinate of <see cref="XImage.BottomRight"/> corner point.</param>
        /// <param name="y2">The Y coordinate of <see cref="XImage.BottomRight"/> corner point.</param>
        /// <param name="style">The shape style.</param>
        /// <param name="point">The point template.</param>
        /// <param name="key">The image key.</param>
        /// <param name="isStroked">The flag indicating whether shape is stroked.</param>
        /// <param name="isFilled">The flag indicating whether shape is filled.</param>
        /// <param name="text">The text string.</param>
        /// <param name="name">The shape name.</param>
        /// <returns>The new instance of the <see cref="XImage"/> class.</returns>
        public static XImage Create(
            double x1, double y1,
            double x2, double y2,
            ShapeStyle style,
            BaseShape point,
            string key,
            bool isStroked = false,
            bool isFilled = false,
            string text = null,
            string name = "")
        {
            return new XImage()
            {
                Name = name,
                Style = style,
                IsStroked = isStroked,
                IsFilled = isFilled,
                Data = new Data()
                {
                    Bindings = ImmutableArray.Create<Binding>(),
                    Properties = ImmutableArray.Create<Property>()
                },
                TopLeft = XPoint.Create(x1, y1, point),
                BottomRight = XPoint.Create(x2, y2, point),
                Key = key,
                Text = text
            };
        }

        /// <summary>
        /// Creates a new <see cref="XImage"/> instance.
        /// </summary>
        /// <param name="x">The X coordinate of <see cref="XImage.TopLeft"/> and <see cref="XImage.BottomRight"/> corner points.</param>
        /// <param name="y">The Y coordinate of <see cref="XImage.TopLeft"/> and <see cref="XImage.BottomRight"/> corner points.</param>
        /// <param name="style">The shape style.</param>
        /// <param name="point">The point template.</param>
        /// <param name="key">The image key.</param>
        /// <param name="isStroked">The flag indicating whether shape is stroked.</param>
        /// <param name="isFilled">The flag indicating whether shape is filled.</param>
        /// <param name="text">The text string.</param>
        /// <param name="name">The shape name.</param>
        /// <returns>The new instance of the <see cref="XImage"/> class.</returns>
        public static XImage Create(
            double x, double y,
            ShapeStyle style,
            BaseShape point,
            string key,
            bool isStroked = false,
            bool isFilled = false,
            string text = null,
            string name = "")
        {
            return Create(x, y, x, y, style, point, key, isStroked, isFilled, text, name);
        }

        /// <summary>
        /// Creates a new <see cref="XImage"/> instance.
        /// </summary>
        /// <param name="topLeft">The <see cref="XImage.TopLeft"/> corner point.</param>
        /// <param name="bottomRight">The <see cref="XImage.BottomRight"/> corner point.</param>
        /// <param name="style">The shape style.</param>
        /// <param name="point">The point template.</param>
        /// <param name="key">The image key.</param>
        /// <param name="isStroked">The flag indicating whether shape is stroked.</param>
        /// <param name="isFilled">The flag indicating whether shape is filled.</param>
        /// <param name="text">The text string.</param>
        /// <param name="name">The shape name.</param>
        /// <returns>The new instance of the <see cref="XImage"/> class.</returns>
        public static XImage Create(
            XPoint topLeft,
            XPoint bottomRight,
            ShapeStyle style,
            BaseShape point,
            string key,
            bool isStroked = false,
            bool isFilled = false,
            string text = null,
            string name = "")
        {
            return new XImage()
            {
                Name = name,
                Style = style,
                IsStroked = isStroked,
                IsFilled = isFilled,
                Data = new Data()
                {
                    Bindings = ImmutableArray.Create<Binding>(),
                    Properties = ImmutableArray.Create<Property>()
                },
                TopLeft = topLeft,
                BottomRight = bottomRight,
                Key = key,
                Text = text
            };
        }
    }
}
