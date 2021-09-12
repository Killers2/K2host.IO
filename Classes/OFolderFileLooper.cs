/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-11-01                        | 
'| Use: General                                         |
' \====================================================/
*/

using System;
using System.IO;

using K2host.IO.Delegates;

namespace K2host.IO.Classes
{

    /// <summary>
    /// This class helps go though a directory structure and passback folders / files.
    /// </summary>
    public class OFolderFileLooper : IDisposable
    {

        /// <summary>
        /// Triggered when a directory is found.
        /// </summary>
        public OnDirectorieFoundEvent OnDirectorieFound { get; set; }

        /// <summary>
        /// Triggered when a file is found in the directory.
        /// </summary>
        public OnFileFoundEvent OnFileFound { get; set; }

        /// <summary>
        /// Used to creat an instance of this class
        /// </summary>
        public OFolderFileLooper() { }

        /// <summary>
        /// Loop though all files and folders.
        /// </summary>
        /// <param name="di"></param>
        public void IterateDirectories(DirectoryInfo di)
        {

            foreach (DirectoryInfo idi in di.GetDirectories())
                IterateDirectories(idi);

            OnDirectorieFound?.Invoke(di);

            foreach (FileInfo fi in di.GetFiles())
                OnFileFound?.Invoke(fi);

        }

        #region Destructor

        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {


            }

            _disposed = true;
        }

        #endregion

    }


}
