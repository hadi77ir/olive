// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//
// Author:
//	Chris Toshok (toshok@ximian.com)
//

using System.Windows;
using System.Windows.Media.Animation;

namespace System.Windows.Media {

	public class GeometryDrawing : Drawing {

		public GeometryDrawing (Brush brush, Pen pen, Geometry geometry)
		{
			Brush = brush;
			Pen = pen;
			Geometry = geometry;
		}

		public GeometryDrawing ()
		{
		}

		public new GeometryDrawing Clone ()
		{
			throw new NotImplementedException ();
		}

		public new GeometryDrawing CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			return new GeometryDrawing ();
		}

		public static readonly DependencyProperty GeometryProperty;
		public Geometry Geometry {
		    get { return (Geometry)GetValue (GeometryProperty); }
		    set { SetValue (GeometryProperty, value); }
		}

		public static readonly DependencyProperty PenProperty;
		public Pen Pen {
		    get { return (Pen)GetValue (PenProperty); }
		    set { SetValue (PenProperty, value); }
		}

		public static readonly DependencyProperty BrushProperty;
		public Brush Brush {
		    get { return (Brush)GetValue (BrushProperty); }
		    set { SetValue (BrushProperty, value); }
		}
	}

}
