using Chinook.Persistence;
using EasyLOB;
using EasyLOB.Application;
using System;
using System.IO;

namespace Chinook.Application
{
    public partial class ChinookApplication : IChinookApplication
    {
        #region Properties

        public IDIManager DIManager { get; }

        #endregion Properties

        #region Methods

        public ChinookApplication(IDIManager diManager)
        {
            DIManager = diManager;
        }

        public bool Clean(ZOperationResult operationResult, string directory)
        {
            try
            {
                string[] paths;
                //int index;

                paths = Directory.GetFiles(directory);
                //index = 1;
                foreach (string path in paths)
                {
                    File.Delete(path);
                    //operationResult.AddOperationError(index++.ToString(), path);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }

        public bool Reset(ZOperationResult operationResult, IChinookUnitOfWork unitOfWork)
        {
            try
            {
                unitOfWork.ExecuteSQL("DELETE FROM InvoiceLine WHERE InvoiceLineId > 2240");                
                unitOfWork.ExecuteSQL("DELETE FROM Invoice WHERE InvoiceId > 412");

                unitOfWork.ExecuteSQL("DELETE FROM Customer WHERE CustomerId > 59");
                unitOfWork.ExecuteSQL("DELETE FROM Employee WHERE EmployeeId > 8");

                unitOfWork.ExecuteSQL("DELETE FROM PlaylistTrack WHERE PlaylistId > 18 OR TrackId > 3503");
                unitOfWork.ExecuteSQL("DELETE FROM Track WHERE TrackId > 3503");
                unitOfWork.ExecuteSQL("DELETE FROM Playlist WHERE PlaylistId > 18");

                unitOfWork.ExecuteSQL("DELETE FROM Genre WHERE GenreId > 25");
                unitOfWork.ExecuteSQL("DELETE FROM MediaType WHERE MediaTypeId > 5");
                unitOfWork.ExecuteSQL("DELETE FROM Album WHERE AlbumId > 347");
                unitOfWork.ExecuteSQL("DELETE FROM Artist WHERE ArtistId > 275");
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }

        #endregion Methods

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose
    }
}