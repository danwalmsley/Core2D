﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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

namespace Core2D.Wpf.Controls
{
    /// <summary>
    /// The custom <see cref="Editor"/> canvas control.
    /// </summary>
    public class EditorCanvas : Canvas
    {
        private bool _isLoaded = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorCanvas"/> class.
        /// </summary>
        public EditorCanvas()
        {
            Loaded +=
                (s, e) =>
                {
                    if (_isLoaded)
                        return;
                    else
                        _isLoaded = true;

                    Initialize();
                };

            Unloaded +=
                (s, e) =>
                {
                    if (!_isLoaded)
                        return;
                    else
                        _isLoaded = false;

                    DeInitialize();
                };
        }

        private void EditorCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var context = this.Tag as EditorContext;
            if (context == null)
                return;

            this.Focus();
            if (context.Editor.IsLeftDownAvailable())
            {
                var p = e.GetPosition(this);
                context.Editor.LeftDown(p.X, p.Y);
            }
        }

        private void EditorCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var context = this.Tag as EditorContext;
            if (context == null)
                return;

            this.Focus();
            if (context.Editor.IsLeftUpAvailable())
            {
                var p = e.GetPosition(this);
                context.Editor.LeftUp(p.X, p.Y);
            }
        }

        private void EditorCanvas_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var context = this.Tag as EditorContext;
            if (context == null)
                return;

            this.Focus();
            if (context.Editor.IsRightDownAvailable())
            {
                var p = e.GetPosition(this);
                context.Editor.RightDown(p.X, p.Y);
            }
        }

        private void EditorCanvas_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var context = this.Tag as EditorContext;
            if (context == null)
                return;

            this.Focus();
            if (context.Editor.IsRightUpAvailable())
            {
                var p = e.GetPosition(this);
                context.Editor.RightUp(p.X, p.Y);
            }
        }

        private void EditorCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var context = this.Tag as EditorContext;
            if (context == null)
                return;

            this.Focus();
            if (context.Editor.IsMoveAvailable())
            {
                var p = e.GetPosition(this);
                context.Editor.Move(p.X, p.Y);
            }
        }

        private void Initialize()
        {
            this.PreviewMouseLeftButtonDown += EditorCanvas_PreviewMouseLeftButtonDown;
            this.PreviewMouseLeftButtonUp += EditorCanvas_PreviewMouseLeftButtonUp;
            this.PreviewMouseRightButtonDown += EditorCanvas_PreviewMouseRightButtonDown;
            this.PreviewMouseRightButtonUp += EditorCanvas_PreviewMouseRightButtonUp;
            this.PreviewMouseMove += EditorCanvas_PreviewMouseMove;

            this.Focus();
        }

        private void DeInitialize()
        {
            this.PreviewMouseLeftButtonDown -= EditorCanvas_PreviewMouseLeftButtonDown;
            this.PreviewMouseLeftButtonUp -= EditorCanvas_PreviewMouseLeftButtonUp;
            this.PreviewMouseRightButtonDown -= EditorCanvas_PreviewMouseRightButtonDown;
            this.PreviewMouseRightButtonUp -= EditorCanvas_PreviewMouseRightButtonUp;
            this.PreviewMouseMove -= EditorCanvas_PreviewMouseMove;
        }
    }
}