using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C20_Ex02
{
    public class Move
    {
        private Point m_Source;
        private Point m_Destination;

        public Move()
        {
            m_Source = new Point(-100, -100);
            m_Destination = new Point(-100, -100);
        }

        public Move(Point i_Source, Point i_Dest)
        {
            m_Source = i_Source;
            m_Destination = i_Dest;
        }

        public Point Source
        {
            get { return m_Source; }
            set { m_Source = value; }
        }

        public Point Destination
        {
            get { return m_Destination; }
            set { m_Destination = value; }
        }

        public void MakeEmpty()
        {
            m_Source = new Point(-100, -100);
            m_Destination = new Point(-100, -100);
        }
    }
}
