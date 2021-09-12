/*
' /====================================================\
'| Developed By External Open Source                    |
'| Projected Started: 2019-11-01                        | 
'| Use: General                                         |
' \====================================================/
*/

namespace K2host.IO.Classes
{
    public class OFileType
    {

        internal byte?[] Header
        {
            get; set;
        }

        internal int HeaderOffset
        {
            get; set;
        }

        internal string Extension
        {
            get; set;
        }

        internal string Mime
        {
            get; set;
        }

        public OFileType(byte?[] header, string extension, string mime)
        {
            Header = header;
            Extension = extension;
            Mime = mime;
            HeaderOffset = 0;
        }

        public OFileType(byte?[] header, int offset, string extension, string mime)
        {
            Header = null;
            Header = header;
            HeaderOffset = offset;
            Extension = extension;
            Mime = mime;
        }

        public override bool Equals(object other)
        {

            if (!base.Equals(other))
                return false;

            if (!(other is OFileType))
                return false;

            OFileType otherType = (OFileType)other;

            if (this.Header != otherType.Header)
                return false;

            if (this.HeaderOffset != otherType.HeaderOffset)
                return false;

            if (this.Extension != otherType.Extension)
                return false;

            if (this.Mime != otherType.Mime)
                return false;

            return true;

        }

        public override int GetHashCode()
        {
            //Not used.
            return 0;
        }

        public override string ToString()
        {
            return Extension;
        }

    }
}
