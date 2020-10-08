namespace C20_Ex02
{
    public struct Cell
    {
        private eCellSign m_Sign;
        private bool m_PawnInCell;

        public Cell(eCellSign i_Sign)
        {
            m_Sign = i_Sign;
            m_PawnInCell = false;
        }
        public enum eCellSign
        {
            PawnO = 'O',
            PawnX = 'X',
            KingO = 'U',
            KingX = 'K',
            Empty = ' '
        }

        public eCellSign Sign
        {
            get
            {
                return m_Sign;
            }

            set
            {
                m_Sign = value;
            }
        }

        public bool PawnInCell
        {
            get
            {
                return m_PawnInCell;
            }

            set
            {
                m_PawnInCell = value;

                if (!m_PawnInCell)
                {
                    m_Sign = eCellSign.Empty;
                }
            }
        }
    }
}
