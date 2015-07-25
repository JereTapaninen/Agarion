using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Agarion.IO
{
    /// <summary>
    /// The window structure
    /// Position, Size, etc.
    /// </summary>
    public struct WindowComponent
    {
        /// <summary>
        /// The current position of the window
        /// </summary>
        public Point Position;
        /// <summary>
        /// The current size of the window
        /// </summary>
        public Size Size;
    }

    public class UIHandler
    {
        /// <summary>
        /// The offsets
        /// </summary>
        public Size Offsets { get; private set; }

        /// <summary>
        /// The Window Structure
        /// </summary>
        public WindowComponent Window { get; private set; }

        /// <summary>
        /// Initializes a new UI API.
        /// </summary>
        public UIHandler()
        { }

        /// <summary>
        /// Sets the window
        /// </summary>
        /// <param name="position">The window position</param>
        /// <param name="size">The window size</param>
        public void SetWindow(Point position, Size size)
        {
            Window = new WindowComponent() { Position = position, Size = size };
        }

        /// <summary>
        /// Set the offsets.
        /// </summary>
        /// <param name="size">The offset size</param>
        public void SetOffsets(Size size)
        {
            this.Offsets = size;
        }
    }
}
